using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.EmployeeManagement.Models
{
    public class WorkforceSchedule
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        private Dictionary<DateTime, List<EmployeeModel>> workForceByDate;

        public Dictionary<DateTime, List<EmployeeModel>> WorkForceByDate
        {
            get { return workForceByDate; }
            set { workForceByDate = value; }
        }
    }
}
