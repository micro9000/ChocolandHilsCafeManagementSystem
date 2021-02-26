using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.EmployeeManagement
{
    [Table("EmployeeBenefits")]
    public class EmployeeBenefitModel : BaseModel
    {
        private string benefitTitle;

        public string BenefitTitle
        {
            get { return benefitTitle; }
            set { benefitTitle = value; }
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


        private StaticData.EmployeeBenefitsPaySched paySched;

        public StaticData.EmployeeBenefitsPaySched PaySched
        {
            get { return paySched; }
            set { paySched = value; }
        }

        private int payMonth;
        // for specific-month-day
        public int PayMonth
        {
            get { return payMonth; }
            set { payMonth = value; }
        }

        private int payDay;
        // for specific-month-day
        public int PayDay
        {
            get { return payDay; }
            set { payDay = value; }
        }
    }
}
