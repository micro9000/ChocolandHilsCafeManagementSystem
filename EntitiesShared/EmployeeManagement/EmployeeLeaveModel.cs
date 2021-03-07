using Dapper.Contrib.Extensions;
using EntitiesShared.OtherDataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.EmployeeManagement
{
    [Table("EmployeeLeaves")]
    public class EmployeeLeaveModel : BaseModel
    {
        private long leaveId;

        public long LeaveId
        {
            get { return leaveId; }
            set { leaveId = value; }
        }

        private LeaveTypeModel leaveType;

        [Write(false)]
        [Computed]
        public LeaveTypeModel LeaveType
        {
            get { return leaveType; }
            set { leaveType = value; }
        }


        private string employeeNumber;

        public string EmployeeNumber
        {
            get { return employeeNumber; }
            set { employeeNumber = value; }
        }

        private string reason;

        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }


        private DateTime startDate;

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        private DateTime endDate;

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }


        private decimal numberOfDays;

        public decimal NumberOfDays
        {
            get { return numberOfDays; }
            set { numberOfDays = value; }
        }

        private decimal remainingDays;

        public decimal RemainingDays
        {
            get { return remainingDays; }
            set { remainingDays = value; }
        }


        private int currentYear;

        public int CurrentYear
        {
            get { return currentYear; }
            set { currentYear = value; }
        }
    }
}
