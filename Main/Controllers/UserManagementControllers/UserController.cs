using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Data.User;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;
using DataAccess.Data.User.Contacts;
using DataAccess.Entities.UserManagement;

namespace Main.Controllers.UserManagementControllers
{
    public class UserController : IUserController
    {
        private readonly ILogger<LoginFrm> _logger;
        private readonly IUserData _userData;

        public UserController(ILogger<LoginFrm> logger, IUserData userData)
        {
            _logger = logger;
            _userData = userData;
        }

        public UserModel SignIn(string username, string password)
        {
            var userInfo = _userData.GetUserByUsername(username);

            if (userInfo != null)
            {
                return userInfo;
            }
            else
            {
                MessageBox.Show("Invalid username", "Login failed.");
            }

            return null;
        }
    }
}
