using DapperGenericDataManager;
using DataAccess.Data.EmployeeManagement.Contracts;
using DataAccess.Entities.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.EmployeeManagement.Implementations
{
    public class EmployeeSalaryRateData : DataManagerCRUD<EmployeeSalaryRateModel>, IEmployeeSalaryRateData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public EmployeeSalaryRateData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public EmployeeSalaryRateModel GetByEmployeeNumber(string employeeNumber)
        {
            string query = @"SELECT * FROM EmployeeSalaryRate
                            WHERE isDeleted=false AND employeeNumber=@EmployeeNumber
                            ORDER BY id DESC LIMIT 1";

            return this.GetFirstOrDefault(query, new { EmployeeNumber = employeeNumber });
        }
    }
}
