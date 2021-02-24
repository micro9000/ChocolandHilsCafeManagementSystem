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
    public class EmployeeDeductionData : DataManagerCRUD<EmployeeDeductionModel>, IEmployeeDeductionData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public EmployeeDeductionData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<EmployeeDeductionModel> GetAllByIsEnabled(bool isEnabled)
        {
            string query = @"SELECT * FROM EmployeeDeductions
                            WHERE isDeleted=false AND isEnabled=@IsEnabled";

            return this.GetAll(query, new { IsEnabled = isEnabled });
        }
    }
}
