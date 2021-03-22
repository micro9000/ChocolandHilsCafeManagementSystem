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
        private readonly IEmployeeSalaryRateData _employeeSalaryRateData;

        public EmployeeData(IDbConnectionFactory dbConnFactory, 
                            IEmployeeShiftData employeeShiftData,
                            IEmployeeSalaryRateData employeeSalaryRateData) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
            _employeeShiftData = employeeShiftData;
            _employeeSalaryRateData = employeeSalaryRateData;
        }

        public List<EmployeeModel> GetAllNotDeleted()
        {
            string query = @"SELECT * FROM Employees WHERE isDeleted=false";

            var employees = this.GetAll(query);

            if (employees != null)
            {
                foreach (var emp in employees)
                {
                    emp.Shift = _employeeShiftData.GetById(emp.ShiftId);
                    emp.SalaryRates = _employeeSalaryRateData.GetByEmployeeNumber(emp.EmployeeNumber);
                }
            }
            
            return employees;
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
            string query = @"SELECT * FROM Employees WHERE isDeleted=false AND 
                            dateHire BETWEEN @DateHire AND DATE_ADD(@DateHire, INTERVAL 1 DAY)";

            var employees = this.GetAll(query, new { DateHire = dateHire });

            if (employees != null)
            {
                foreach (var emp in employees)
                {
                    emp.Shift = _employeeShiftData.GetById(emp.ShiftId);
                    emp.SalaryRates = _employeeSalaryRateData.GetByEmployeeNumber(emp.EmployeeNumber);
                }
            }
            
            return employees;
        }

        public EmployeeModel GetByEmployeeNumber(string employeeNumber)
        {
            string query = @"SELECT * FROM Employees 
                            WHERE isDeleted=false AND employeeNumber=@EmployeeNumber";
            
            var emp = this.GetFirstOrDefault(query, new { EmployeeNumber = employeeNumber });

            if (emp != null)
            {
                emp.Shift = _employeeShiftData.GetById(emp.ShiftId);
                emp.SalaryRates = _employeeSalaryRateData.GetByEmployeeNumber(emp.EmployeeNumber);
            }

            return emp;
        }

        public List<EmployeeModel> Search(string search)
        {
            string query = @"SELECT * 
                            FROM Employees
                            WHERE isDeleted=false AND (
                            employeeNumber LIKE @Search OR
                            firstName LIKE @Search OR
                            lastName LIKE @Search OR
                            address LIKE @Search OR
                            mobileNumber LIKE @Search OR
                            emailAddress LIKE @Search OR
                            branchAssign LIKE @Search)";

            var employees = this.GetAll(query, new { Search = "%" + search + "%" });

            if (employees != null)
            {
                foreach (var emp in employees)
                {
                    emp.Shift = _employeeShiftData.GetById(emp.ShiftId);
                    emp.SalaryRates = _employeeSalaryRateData.GetByEmployeeNumber(emp.EmployeeNumber);
                }
            }

            return employees;
        }
    }
}
