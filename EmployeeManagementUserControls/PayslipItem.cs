using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagementUserControls
{
    public partial class PayslipItem : UserControl
    {
        public PayslipItem()
        {
            InitializeComponent();
        }

        private string payDay;

        [Category("Custome props")]
        public string PayDay
        {
            get { return payDay; }
            set { payDay = value; this.LblPayday.Text = value; }
        }

        private decimal totalBenefits;

        [Category("Custome props")]
        public decimal TotalBenefits
        {
            get { return totalBenefits; }
            set { totalBenefits = value; this.LblTotalBenefits.Text = value.ToString("C"); }
        }

        private decimal totalIncome;

        [Category("Custome props")]
        public decimal TotalIncome
        {
            get { return totalIncome; }
            set { totalIncome = value; this.LblTotalIncome.Text = value.ToString("C"); }
        }

        private decimal totalDeduction;

        public decimal TotalDeduction
        {
            get { return totalDeduction; }
            set { totalDeduction = value; this.LblTotalDeduction.Text = value.ToString("C"); }
        }

        private decimal totalNetTakeHomePay;

        public decimal TotalNetTakeHomePay
        {
            get { return totalNetTakeHomePay; }
            set { totalNetTakeHomePay = value; LblTotalTakeHomePay.Text = value.ToString("C"); }
        }

        private List<EmployeePayslipBenefitModel> benefits;

        public List<EmployeePayslipBenefitModel> Benefits
        {
            get { return benefits; }
            set {
                benefits = value;

                foreach(var benefit in benefits)
                {
                    var row = new string[] { benefit.BenefitTitle, benefit.Amount.ToString("C") };
                    var listViewItem = new ListViewItem(row);
                    listViewItem.Tag = benefit;

                    ListViewBenefits.Items.Add(listViewItem);
                }
            }
        }


        private List<EmployeePayslipDeductionModel> deductions;

        public List<EmployeePayslipDeductionModel> Deductions
        {
            get { return deductions; }
            set {
                deductions = value;

                foreach (var deduction in deductions)
                {
                    var row = new string[] { deduction.DeductionTitle, deduction.Amount.ToString("C") };
                    var listViewItem = new ListViewItem(row);
                    listViewItem.Tag = deduction;

                    ListViewDeductions.Items.Add(listViewItem);
                }
            }
        }



    }
}
