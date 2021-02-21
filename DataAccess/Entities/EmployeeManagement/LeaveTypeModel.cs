using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.EmployeeManagement
{
    [Table("LeaveTypes")]
    public class LeaveTypeModel
    {
        private long id;

        [Key]
        public long Id
        {
            get { return id; }
            set { id = value; }
        }


        private string leaveType;

        public string LeaveType
        {
            get { return leaveType; }
            set { leaveType = value; }
        }


        private int numberOfDays;

        public int NumberOfDays
        {
            get { return numberOfDays; }
            set { numberOfDays = value; }
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
