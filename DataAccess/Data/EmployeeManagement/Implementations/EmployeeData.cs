﻿using DapperGenericDataManager;
using DataAccess.Data.EmployeeManagement.Contracts;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Data.OtherDataManagement.Contracts;

namespace DataAccess.Data.EmployeeManagement.Implementations
{
    public class EmployeeData : DataManagerCRUD<EmployeeModel>, IEmployeeData
    {
        private readonly IDbConnectionFactory _dbConnFactory;
        private readonly IEmployeeShiftData _employeeShiftData;
        private readonly IEmployeePositionData _employeePositionData;
        private readonly IBranchData _branchData;

        public EmployeeData(IDbConnectionFactory dbConnFactory, 
                            IEmployeeShiftData employeeShiftData,
                            IEmployeePositionData employeePositionData,
                            IBranchData branchData) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
            _employeeShiftData = employeeShiftData;
            _employeePositionData = employeePositionData;
            _branchData = branchData;
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
                    emp.Position = _employeePositionData.Get(emp.PositionId);
                    emp.Branch = _branchData.Get(emp.BranchId);
                }
            }
            
            return employees;
        }

        public long GetCountByEmpNumYear(DateTime dateHire)
        {
            string query = @"SELECT COUNT(*) as count FROM Employees 
                            WHERE empNumYear = @YearHire";

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
                    emp.Position = _employeePositionData.Get(emp.PositionId);
                    emp.Branch = _branchData.Get(emp.BranchId);
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
                emp.Position = _employeePositionData.Get(emp.PositionId);
                emp.Branch = _branchData.Get(emp.BranchId);
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
                    emp.Position = _employeePositionData.Get(emp.PositionId);
                    emp.Branch = _branchData.Get(emp.BranchId);
                }
            }

            return employees;
        }


        public bool MoveEmployeesIntoOtherBranch(long previousBranchId, long newBranchId)
        {
            throw new NotImplementedException();
        }
    }
}
