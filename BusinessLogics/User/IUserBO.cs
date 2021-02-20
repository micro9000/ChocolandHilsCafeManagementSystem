using BusinessLogics.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogics.User
{
    public interface IUserBO
    {
        public UserLoginInfoDTO SignIn(string username, string password);
    }
}
