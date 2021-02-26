using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.EmployeeManagement
{
    [Table("EmployeeShifts")]
    public class EmployeeShiftModel : BaseModel
    {
        private string shift;

        public string Shift
        {
            get { return shift; }
            set { shift = value; }
        }

        // create new class that will inherit this class

        private string startTime;

        public string StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        private string endTime;

        public string EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        private decimal numberOfHrs;

        public decimal NumberOfHrs
        {
            get { return numberOfHrs; }
            set { numberOfHrs = value; }
        }

        private string breakTime;

        public string BreakTime
        {
            get { return breakTime; }
            set { breakTime = value; }
        }


        private decimal breakTimeHrs;

        public decimal BreakTimeHrs
        {
            get { return breakTimeHrs; }
            set { breakTimeHrs = value; }
        }

        private bool isActive;

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
    }
}
