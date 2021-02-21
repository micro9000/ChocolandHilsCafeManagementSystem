using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.EmployeeManagement
{
    [Table("EmployeeLeaves")]
    public class EmployeeLeaveModel
    {
        private long id;

        [Key]
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private long leaveId;

        public long LeaveId
        {
            get { return leaveId; }
            set { leaveId = value; }
        }


        private string employeeNumber;

        public string EmployeeNumber
        {
            get { return employeeNumber; }
            set { employeeNumber = value; }
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
