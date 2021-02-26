using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.EmployeeManagement
{
    [Table("EmployeeSalaryRate")]
    public class EmployeeSalaryRateModel : BaseModel
    {
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
    }
}
