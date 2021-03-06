using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.EmployeeManagement.Models
{
    public class EmployeeWorkShiftScheduleModel
    {
        private EmployeeModel employee;

        public EmployeeModel Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        private DateTime startSchedDate;

        public DateTime StartSchedDate
        {
            get { return startSchedDate; }
            set { startSchedDate = value; }
        }

        private DateTime endSchedDate;

        public DateTime EndSchedDate
        {
            get { return endSchedDate; }
            set { endSchedDate = value; }
        }


    }
}
