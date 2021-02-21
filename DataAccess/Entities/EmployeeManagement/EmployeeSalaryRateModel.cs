using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.EmployeeManagement
{
    [Table("EmployeeSalaryRate")]
    public class EmployeeSalaryRateModel
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

        private decimal salaryRate;

        public decimal SalaryRate
        {
            get { return salaryRate; }
            set { salaryRate = value; }
        }

        private decimal halfMonthRate;

        public decimal HalfMonthRate
        {
            get { return halfMonthRate; }
            set { halfMonthRate = value; }
        }

        private decimal dailyRate;

        public decimal DailyRate
        {
            get { return dailyRate; }
            set { dailyRate = value; }
        }

        private decimal increase;

        public decimal Increase
        {
            get { return increase; }
            set { increase = value; }
        }

        private DateTime increaseDate;

        public DateTime IncreaseDate
        {
            get { return increaseDate; }
            set { increaseDate = value; }
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
