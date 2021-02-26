using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.UserManagement
{
    [Table("Roles")]
    public class RoleModel : BaseModel
    {
        private string roleKey;

        public string RoleKey
        {
            get { return roleKey; }
            set { roleKey = value; }
        }
    }
}
