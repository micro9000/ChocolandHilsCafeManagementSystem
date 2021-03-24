using EntitiesShared.EmployeeManagement;
using EntitiesShared.PayrollManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.PayrollForms.Controls
{
    public partial class PayslipItemControl : UserControl
    {
        public PayslipItemControl()
        {
            InitializeComponent();
        }

        public EmployeeModel Employee { get; set; }

        public EmployeePayslipModel Payslip { get; set; }


        private void PayslipItemControl_Load(object sender, EventArgs e)
        {
            if (Employee != null)
            {
                this.LblEmployeeName.Text = Employee.FullName;
                this.LblEmployeeNumber.Text = Employee.EmployeeNumber;
            }

            if (Payslip != null)
            {
                this.LblTotalIncome.Text = Payslip.TotalIncome.ToString();
                this.LblTotalDeductions.Text = Payslip.DeductionTotal.ToString();
                this.LblTotalNetTakeHomePay.Text = Payslip.NetTakeHomePay.ToString();

                var monthlyRate = new ListViewItem(new string[] {
                    "Monthly Rate", "", Payslip.SalaryRate.ToString()
                });
                this.LVPayslipEarnings.Items.Add(monthlyRate);

                var halfMonthlyRate = new ListViewItem(new string[] {
                    "1/2 Month Rate", "", Payslip.HalfMonthRate.ToString()
                });
                this.LVPayslipEarnings.Items.Add(halfMonthlyRate);

                var dailyRate = new ListViewItem(new string[] {
                    "Daily Rate", "", Payslip.DailyRate.ToString()
                });
                this.LVPayslipEarnings.Items.Add(dailyRate);

                if (Payslip.LateTotalDeduction > 0)
                {
                    var lessLate = new ListViewItem(new string[] {
                        "Less Late", Payslip.Late, Payslip.LateTotalDeduction.ToString()
                    });
                    this.LVPayslipEarnings.Items.Add(lessLate);
                }

                if (Payslip.UnderTimeTotalDeduction > 0)
                {
                    var underTime = new ListViewItem(new string[] {
                        "Less Undertime", Payslip.UnderTime, Payslip.UnderTimeTotalDeduction.ToString()
                    });
                    this.LVPayslipEarnings.Items.Add(underTime);
                }

                var netBasicSalary = new ListViewItem(new string[] {
                    "Net Basic salary", Payslip.NumOfDays.ToString(), Payslip.NetBasicSalary.ToString()
                });
                this.LVPayslipEarnings.Items.Add(netBasicSalary);

                if (this.Payslip.Benefits != null)
                {
                    foreach(var benefit in this.Payslip.Benefits)
                    {
                        var benefitItem = new ListViewItem(new string[] { 
                            benefit.BenefitTitle, "", benefit.Amount.ToString()
                        });
                        this.LVPayslipEarnings.Items.Add(benefitItem);
                    }
                }

                if (this.Payslip.Deductions != null)
                {
                    foreach(var deduction in this.Payslip.Deductions)
                    {
                        var deductionItem = new ListViewItem(new string[] {
                            deduction.DeductionTitle, deduction.Amount.ToString()
                        });
                        this.LVPayslipDeductions.Items.Add(deductionItem);
                    }
                }
            }
        }
    }
}
