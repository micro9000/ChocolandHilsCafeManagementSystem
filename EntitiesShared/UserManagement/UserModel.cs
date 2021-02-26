using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.UserManagement
{
    [Table("Users")]
    public class UserModel : BaseModel
    {
        public string EmployeeNumber { get; set; }
        public string passwordSha512 { get; set; }

        [Write(false)]
        [Computed]
        public List<UserRoleModel> Roles { get; set; }

        private bool isActive;

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
    }
}
