using DapperGenericDataManager;
using DataAccess.Data.EmployeeManagement.Contracts;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.EmployeeManagement.Implementations
{
    public class GovernmentAgencyData : DataManagerCRUD<GovernmentAgencyModel>, IGovernmentAgencyData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public GovernmentAgencyData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<GovernmentAgencyModel> GetAllByIsDeleted(bool isDeleted)
        {
            string query = @"SELECT * FROM GovernmentAgencies WHERE isDeleted=@IsDeleted";
            return this.GetAll(query, new { IsDeleted = isDeleted });
        }
    }
}
