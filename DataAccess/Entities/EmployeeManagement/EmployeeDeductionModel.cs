using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.EmployeeManagement
{
    [Table("EmployeeDeductions")]
    public class EmployeeDeductionModel
    {
        private long id;

        [Key]
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private string deductionTitle;

        public string DeductionTitle
        {
            get { return deductionTitle; }
            set { deductionTitle = value; }
        }

        private decimal amount;

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        private bool isEnabled;

        public bool IsEnabled
        {
            get { return isEnabled; }
            set { isEnabled = value; }
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
