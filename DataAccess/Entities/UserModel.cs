using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccess.StaticData;

namespace DataAccess.Entities
{
    [Table("Users")]
    public class UserModel
    {
        [Key]
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public UserRole Role { get; set; }

        //[Write(false)]
        //[Computed]
        //public string ToString { get; set; }
    }
}
