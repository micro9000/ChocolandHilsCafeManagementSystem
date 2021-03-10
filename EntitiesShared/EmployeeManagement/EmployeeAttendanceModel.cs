using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.EmployeeManagement
{
    [Table("EmployeeAttendance")]
    public class EmployeeAttendanceModel : BaseModel
    {
        private string employeeNumber;

        public string EmployeeNumber
        {
            get { return employeeNumber; }
            set { employeeNumber = value; }
        }

        private long shiftId;

        public long ShiftId
        {
            get { return shiftId; }
            set { shiftId = value; }
        }

        private EmployeeShiftModel shift;

        public EmployeeShiftModel Shift
        {
            get { return shift; }
            set { shift = value; }
        }


        private DateTime workDate;

        public DateTime WorkDate
        {
            get { return workDate; }
            set { workDate = value; }
        }

        private DateTime timeIn;

        public DateTime TimeIn
        {
            get { return timeIn; }
            set { timeIn = value; }
        }

        private DateTime timeOut;

        public DateTime TimeOut
        {
            get { return timeOut; }
            set { timeOut = value; }
        }


        private decimal lateMins;

        public decimal LateMins
        {
            get { return lateMins; }
            set { lateMins = value; }
        }

        private decimal underTimeMins;

        public decimal UnderTimeMins
        {
            get { return underTimeMins; }
            set { underTimeMins = value; }
        }
    }
}
