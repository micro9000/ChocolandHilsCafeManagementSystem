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
    public class EmployeeGovtContributionData : DataManagerCRUD<EmployeeGovtContributionModel>, IEmployeeGovtContributionData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public EmployeeGovtContributionData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }
    }
}
