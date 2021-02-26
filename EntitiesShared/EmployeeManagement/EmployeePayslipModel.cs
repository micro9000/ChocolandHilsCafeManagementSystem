using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.EmployeeManagement
{
    [Table("EmployeePayslips")]
    public class EmployeePayslipModel : BaseModel
    {
        private string employeeNumber;

        public string EmployeeNumber
        {
            get { return employeeNumber; }
            set { employeeNumber = value; }
        }

        private DateTime startShiftDate;

        public DateTime StartShiftDate
        {
            get { return startShiftDate; }
            set { startShiftDate = value; }
        }

        private DateTime endShiftDate;

        public DateTime EndShiftDate
        {
            get { return endShiftDate; }
            set { endShiftDate = value; }
        }


        private DateTime payDate;

        public DateTime PayDate
        {
            get { return payDate; }
            set { payDate = value; }
        }

        private decimal netBasicSalary;

        public decimal NetBasicSalary
        {
            get { return netBasicSalary; }
            set { netBasicSalary = value; }
        }

        private decimal benefitsTotal;

        public decimal BenefitsTotal
        {
            get { return benefitsTotal; }
            set { benefitsTotal = value; }
        }


        private List<EmployeePayslipBenefitModel> benefits;
        [Write(false)]
        [Computed]
        public List<EmployeePayslipBenefitModel> Benefits
        {
            get { return benefits; }
            set { benefits = value; }
        }


        private decimal deductionTotal;

        public decimal DeductionTotal
        {
            get { return deductionTotal; }
            set { deductionTotal = value; }
        }

        private List<EmployeePayslipDeductionModel> deductions;
        [Write(false)]
        [Computed]
        public List<EmployeePayslipDeductionModel> Deductions
        {
            get { return deductions; }
            set { deductions = value; }
        }

        private decimal totalIncome;

        public decimal TotalIncome
        {
            get { return totalIncome; }
            set { totalIncome = value; }
        }
    }
}
