using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.EmployeeManagement
{
    [Table("EmployeeShiftSchedules")]
    public class EmployeeShiftScheduleModel : BaseModel
    {
        private long shiftId;

        public long ShiftId
        {
            get { return shiftId; }
            set { shiftId = value; }
        }

        private EmployeeShiftModel shift;

        [Write(false)]
        [Computed]
        public EmployeeShiftModel Shift
        {
            get { return shift; }
            set { shift = value; }
        }


        private string employeeNumber;

        public string EmployeeNumber
        {
            get { return employeeNumber; }
            set { employeeNumber = value; }
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


        private bool isDone;

        public bool IsDone
        {
            get { return isDone; }
            set { isDone = value; }
        }


    }
}
