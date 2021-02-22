using DapperGenericDataManager;
using DataAccess.Data.User.Contacts;
using DataAccess.Entities.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.User
{
    public class UserData : DataManagerCRUD<UserModel>, IUserData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public UserData(IDbConnectionFactory dbConnFactory) : 
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public UserModel GetUserByUsername(string username)
        {
            return new UserModel {
                EmployeeNumber = username,
                passwordSha512 = "test"
            };
        }
    }
}
