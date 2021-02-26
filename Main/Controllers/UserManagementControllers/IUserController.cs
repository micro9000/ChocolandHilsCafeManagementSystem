using EntitiesShared.UserManagement;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.UserManagementControllers
{
    public interface IUserController
    {
        EntityResult<UserModel> SignIn(string username, string password);
    }
}
