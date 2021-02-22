using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DataAccess.Entities.UserManagement;
using DataAccess.Data.UserManagement.Contracts;
using Shared.Helpers;

namespace Main.Controllers.UserManagementControllers
{
    public class UserController : IUserController
    {
        private readonly ILogger<LoginFrm> _logger;
        private readonly Hashing _hashing;
        private readonly IUserData _userData;

        public UserController(ILogger<LoginFrm> logger,
                                Hashing hashing,
                                IUserData userData)
        {
            _logger = logger;
            _hashing = hashing;
            _userData = userData;
        }

        public EntityResult<UserModel> SignIn(string employeeNumber, string password)
        {
            string hashPassword = _hashing.GetSHA512String(password);
            var userInfo = _userData.GetUserByEmployeeNumber(employeeNumber);

            var result = new EntityResult<UserModel>();
            result.IsSuccess = false;
            result.Messages.Add("User not found.");

            if (userInfo != null)
            {
                if (userInfo.passwordSha512.ToUpper() == hashPassword.ToUpper())
                {
                    result.Data = userInfo;
                    result.IsSuccess = true;
                    result.Messages.Add("User found.");
                }
            }

            return result;
        }
    }
}
