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
    public class UserData : DataManagerCRUD<UserModel>, IUserData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public UserData(IDbConnectionFactory dbConnFactory) : 
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public UserModel GetUserByEmployeeNumber(string empNumber)
        {
            string query = @"SELECT * FROM Users 
                            WHERE isDeleted=False AND isActive=True AND employeeNumber=@EmployeeNumber";

            return this.GetFirstOrDefault(query, new { EmployeeNumber = empNumber });
        }
    }
}
