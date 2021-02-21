using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.EmployeeManagement
{
    [Table("EmployeeAttendance")]
    public class EmployeeAttendanceModel
    {
        private long id;

        [Key]
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private string employeeNumber;

        public string EmployeeNumber
        {
            get { return employeeNumber; }
            set { employeeNumber = value; }
        }

        private DateTime workDate;

        public DateTime WorkDate
        {
            get { return workDate; }
            set { workDate = value; }
        }

        private long shiftSchedId;

        public long ShiftSchedId
        {
            get { return shiftSchedId; }
            set { shiftSchedId = value; }
        }

        private EmployeeShiftScheduleModel shiftSchedule;

        public EmployeeShiftScheduleModel ShiftSchedule
        {
            get { return shiftSchedule; }
            set { shiftSchedule = value; }
        }


        private DateTime timeIn1;

        public DateTime TimeIn1
        {
            get { return timeIn1; }
            set { timeIn1 = value; }
        }

        private DateTime timeOut1;
        //noon break (matic based on timeout2) , 12:00NN, based on shiftsched:breaktime
        public DateTime TimeOut1
        {
            get { return timeOut1; }
            set { timeOut1 = value; }
        }

        private DateTime timeIn2;
        // noon time-in (matic on timeout2) : 01:00PM, based on shiftsched:breaktime
        public DateTime TimeIn2
        {
            get { return timeIn2; }
            set { timeIn2 = value; }
        }

        private DateTime timeOut2;

        public DateTime TimeOut2
        {
            get { return timeOut2; }
            set { timeOut2 = value; }
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


        private DateTime createdAt = DateTime.UtcNow;

        public DateTime CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; }
        }

        private DateTime updatedAt = DateTime.UtcNow;

        public DateTime UpdatedAt
        {
            get { return updatedAt; }
            set { updatedAt = value; }
        }

        private DateTime? deletedAt;

        public DateTime? DeletedAt
        {
            get { return deletedAt; }
            set { deletedAt = value; }
        }

        private bool isDeleted;

        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }
    }
}
