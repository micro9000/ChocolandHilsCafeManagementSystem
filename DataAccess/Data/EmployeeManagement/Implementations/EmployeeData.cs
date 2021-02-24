﻿using DapperGenericDataManager;
using DataAccess.Data.EmployeeManagement.Contracts;
using DataAccess.Entities.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.EmployeeManagement.Implementations
{
    public class EmployeeData : DataManagerCRUD<EmployeeModel>, IEmployeeData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public EmployeeData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<EmployeeModel> GetAllByDateHire(DateTime dateHire)
        {
            string query = @"SELECT * FROM Employees 
                            WHERE isDeleted=false AND 
                            dateHire BETWEEN @DateHire AND DATE_ADD(@DateHire, INTERVAL 1 DAY)";

            return this.GetAll(query, new { DateHire = dateHire });
        }

        public EmployeeModel GetByEmployeeNumber(string employeeNumber)
        {
            string query = @"SELECT * FROM Employees 
                            WHERE isDeleted=false AND employeeNumber=@EmployeeNumber";

            return this.GetFirstOrDefault(query, new { EmployeeNumber = employeeNumber });
        }

        public List<EmployeeModel> Search(string search)
        {
            string query = @"SELECT * FROM Employees
                            WHERE isDeleted=false AND (
                                firstName LIKE @Search OR
                                lastName LIKE @Search OR
                                address LIKE @Search OR
                                mobileNumber LIKE @Search OR
                                emailAddress LIKE @Search OR
                                branchAssign LIKE @Search)";

            return this.GetAll(query, new { Search = search });
        }
    }
}
