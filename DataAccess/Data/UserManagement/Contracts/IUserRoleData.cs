using DapperGenericDataManager;
using DataAccess.Entities.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.UserManagement.Contracts
{
    public interface IUserRoleData : IDataManagerCRUD<UserRoleModel>
    {
        List<UserRoleModel> GetUserRoles(long userId);
    }
}
