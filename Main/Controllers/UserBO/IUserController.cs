using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.UserBO
{
    public interface IUserController
    {
        UserModel SignIn(string username, string password);
    }
}
