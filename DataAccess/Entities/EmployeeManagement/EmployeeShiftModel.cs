using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.EmployeeManagement
{
    [Table("EmployeeShifts")]
    public class EmployeeShiftModel
    {
        private long id;

        [Key]
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

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
