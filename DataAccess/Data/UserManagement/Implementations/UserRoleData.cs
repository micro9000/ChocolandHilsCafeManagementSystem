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
    public class UserRoleData : DataManagerCRUD<UserRoleModel>, IUserRoleData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public UserRoleData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }
    }
}
