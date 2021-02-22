using DataAccess.Entities.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public static class Sessions
    {
        public static UserModel CurrentLoggedInUser { get; set; }


    }
}
