using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.EmployeeManagement
{
    [Table("EmployeeShiftSchedules")]
    public class EmployeeShiftScheduleModel
    {
        private long id;

        [Key]
        public long Id
        {
            get { return id; }
            set { id = value; }
        }


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

        private DateTime schedDate;

        public DateTime SchedDate
        {
            get { return schedDate; }
            set { schedDate = value; }
        }


        private bool isPresent;

        // flag that will update once the employee time in
        public bool IsPresent
        {
            get { return isPresent; }
            set { isPresent = value; }
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
