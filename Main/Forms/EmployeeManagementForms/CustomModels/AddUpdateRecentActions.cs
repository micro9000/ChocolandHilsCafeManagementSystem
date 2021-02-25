using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Forms.EmployeeManagementForms.CustomModels
{
    public class AddUpdateRecentActions
    {
        public string Action { get; set; }
        public string EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }

        public DateTime DateAndTime { get; set; }
    }
}
