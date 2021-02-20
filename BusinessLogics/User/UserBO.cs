using BusinessLogics.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogics.User
{
    public class UserBO : IUserBO
    {
        public UserLoginInfoDTO SignIn(string username, string password)
        {
            return new UserLoginInfoDTO { 
                Username = username,
                Role = "employee"
            };
        }
    }
}
