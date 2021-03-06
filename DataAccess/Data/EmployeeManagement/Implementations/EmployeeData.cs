using DapperGenericDataManager;
using DataAccess.Data.EmployeeManagement.Contracts;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DataAccess.Data.EmployeeManagement.Implementations
{
    public class EmployeeData : DataManagerCRUD<EmployeeModel>, IEmployeeData
    {
        private readonly IDbConnectionFactory _dbConnFactory;
        private readonly IEmployeeShiftData _employeeShiftData;

        public EmployeeData(IDbConnectionFactory dbConnFactory, IEmployeeShiftData employeeShiftData) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
            _employeeShiftData = employeeShiftData;
        }

        public List<EmployeeModel> GetAllNotDeleted()
        {
            string query = @"SELECT * 
                            FROM Employees AS EMP
                            JOIN EmployeeShifts AS SHIFT ON EMP.shiftId=SHIFT.id
                            WHERE EMP.isDeleted=false";

            List<EmployeeModel> results = new List<EmployeeModel>();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<EmployeeModel, EmployeeShiftModel, EmployeeModel>(query,
                        (emp, shift) => {
                            emp.Shift = shift;
                            return emp;
                        }).ToList();
                conn.Close();
            }

            return results;
        }

        public long GetCountByEmpNumYear(DateTime dateHire)
        {
            string query = @"SELECT COUNT(*) as count FROM Employees 
                            WHERE isDeleted=false AND 
                            empNumYear = @YearHire";

            return this.GetValue<long>(query, new { YearHire = dateHire.Year });
        }

        public List<EmployeeModel> GetAllByDateHire(DateTime dateHire)
        {
            string query = @"SELECT * 
                            FROM Employees  AS EMP
                            JOIN EmployeeShifts AS SHIFT ON EMP.shiftId=SHIFT.id
                            WHERE EMP.isDeleted=false AND 
                            EMP.dateHire BETWEEN @DateHire AND DATE_ADD(@DateHire, INTERVAL 1 DAY)";

            List<EmployeeModel> results = new List<EmployeeModel>();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<EmployeeModel, EmployeeShiftModel, EmployeeModel>(query,
                        (emp, shift) => {
                            emp.Shift = shift;
                            return emp;
                        }, new { DateHire = dateHire }).ToList();
                conn.Close();
            }

            return results;
        }

        public EmployeeModel GetByEmployeeNumber(string employeeNumber)
        {
            string query = @"SELECT * FROM Employees 
                            WHERE isDeleted=false AND employeeNumber=@EmployeeNumber";

            var empDetails = this.GetFirstOrDefault(query, new { EmployeeNumber = employeeNumber });

            if (empDetails != null)
            {
                empDetails.Shift = _employeeShiftData.Get(empDetails.ShiftId);
            }

            return empDetails;
        }

        public List<EmployeeModel> Search(string search)
        {
            string query = @"SELECT * 
                            FROM Employees AS EMP
                            JOIN EmployeeShifts AS SHIFT ON EMP.shiftId=SHIFT.id
                            WHERE EMP.isDeleted=false AND (
                            EMP.employeeNumber LIKE @Search OR
                            EMP.firstName LIKE @Search OR
                            EMP.lastName LIKE @Search OR
                            EMP.address LIKE @Search OR
                            EMP.mobileNumber LIKE @Search OR
                            EMP.emailAddress LIKE @Search OR
                            EMP.branchAssign LIKE @Search)";

            List<EmployeeModel> results = new List<EmployeeModel>();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<EmployeeModel, EmployeeShiftModel, EmployeeModel>(query,
                        (emp, shift) => {
                            emp.Shift = shift;
                            return emp;
                        }, new { Search = "%" + search + "%" }).ToList();
                conn.Close();
            }

            return results;
        }
    }
}
