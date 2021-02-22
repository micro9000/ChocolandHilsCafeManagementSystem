using DataAccess.Entities;
using DataAccess.Entities.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.UserManagementControllers
{
    public interface IUserController
    {
        UserModel SignIn(string username, string password);
    }
}
