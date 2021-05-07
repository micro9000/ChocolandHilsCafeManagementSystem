using DapperGenericDataManager;
using DataAccess.Data.PayrollManagement.Contracts;
using EntitiesShared.PayrollManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.PayrollManagement.Implementations
{
    public class EmployeeCashAdvanceRequestData : DataManagerCRUD<EmployeeCashAdvanceRequestModel>, IEmployeeCashAdvanceRequestData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public EmployeeCashAdvanceRequestData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<EmployeeCashAdvanceRequestModel> GetAllNotDeletedByEmployee(string employeeNumber)
        {
            string query = @"SELECT * FROM EmployeeCashAdvanceRequests 
                            WHERE isDeleted=false AND employeeNumber=@EmployeeNumber AND YEAR(createdAt) = @Year ORDER BY id DESC";

            return this.GetAll(query, 
                new { 
                    EmployeeNumber = employeeNumber,
                    Year = DateTime.Now.Year
                });
        }
    }
}
