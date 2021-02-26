using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DataAccess.Data.UserManagement.Contracts;
using Shared.Helpers;
using Shared.ResponseModels;
using EntitiesShared.UserManagement;

namespace Main.Controllers.UserManagementControllers
{
    public class UserController : IUserController
    {
        private readonly ILogger<LoginFrm> _logger;
        private readonly Hashing _hashing;
        private readonly IUserData _userData;
        private readonly IUserRoleData _userRoleData;

        public UserController(ILogger<LoginFrm> logger,
                                Hashing hashing,
                                IUserData userData,
                                IUserRoleData userRoleData)
        {
            _logger = logger;
            _hashing = hashing;
            _userData = userData;
            _userRoleData = userRoleData;
        }

        public EntityResult<UserModel> SignIn(string employeeNumber, string password)
        {
            var result = new EntityResult<UserModel>();
            result.IsSuccess = false;
            result.Messages.Add("User not found.");

            try
            {
                string hashPassword = _hashing.GetSHA512String(password);
                var userInfo = _userData.GetUserByEmployeeNumber(employeeNumber);

                if (userInfo != null)
                {
                    if (userInfo.passwordSha512.ToUpper() == hashPassword.ToUpper())
                    {
                        // Add user roles
                        userInfo.Roles = _userRoleData.GetUserRoles(userInfo.Id);

                        result.Data = userInfo;
                        result.IsSuccess = true;
                        result.Messages.Add("User found.");
                    }
                }
            }catch(Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                result.Messages.Add("Internal error, kindly check system logs and report this error to developer.");
            }

            return result;
        }
    }
}
