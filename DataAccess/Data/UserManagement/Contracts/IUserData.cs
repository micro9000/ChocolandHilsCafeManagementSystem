using DapperGenericDataManager;
using DataAccess.Entities.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.UserManagement.Contracts
{
    public interface IUserData : IDataManagerCRUD<UserModel>
    {
        UserModel GetUserByEmployeeNumber(string empNumber);
    }
}
