using DapperGenericDataManager;
using DataAccess.Data.UserManagement.Contracts;
using DataAccess.Entities.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.UserManagement.Implementations
{
    public class RoleData : DataManagerCRUD<RoleModel>, IRoleData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public RoleData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }
    }
}
