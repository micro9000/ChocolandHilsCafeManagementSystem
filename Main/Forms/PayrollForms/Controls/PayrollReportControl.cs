using EntitiesShared.PayrollManagement;
using Shared.CustomModels;
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
    public partial class PayrollReportControl : UserControl
    {
        public PayrollReportControl()
        {
            InitializeComponent();
        }

        private List<DateTime> payslipDateList;

        public List<DateTime> PayslipDateList
        {
            get { return payslipDateList; }
            set { payslipDateList = value; }
        }

        private void PayrollReportControl_Load(object sender, EventArgs e)
        {
            DisplayPayslipPaydateList();
        }

        public void DisplayPayslipPaydateList()
        {
            // Work shifts load in combo box
            if (this.PayslipDateList != null)
            {
                ComboboxItem item;
                foreach (var paydate in this.PayslipDateList)
                {
                    item = new ComboboxItem();
                    item.Text = paydate.ToShortDateString();
                    item.Value = paydate;
                    this.CBoxPayslipDates.Items.Add(item);
                }
            }
        }

        public DateTime SelectedPayslipPayDate { get; set; }

        public event EventHandler RetrieveEmployeePayslips;
        protected virtual void OnRetrieveEmployeePayslips(EventArgs e)
        {
            RetrieveEmployeePayslips?.Invoke(this, e);
        }

        private void BtnFilterPayrollHistory_Click(object sender, EventArgs e)
        {
            var selectedPaydate = this.CBoxPayslipDates.SelectedItem as ComboboxItem;
            if (selectedPaydate != null)
            {
                SelectedPayslipPayDate = DateTime.Parse(selectedPaydate.Value.ToString());
                OnRetrieveEmployeePayslips(EventArgs.Empty);
            }
        }


        private List<EmployeePayslipModel> employeePayslipsByPaydate;

        public List<EmployeePayslipModel> EmployeePayslipsByPaydate
        {
            get { return employeePayslipsByPaydate; }
            set { employeePayslipsByPaydate = value; }
        }

        public void DisplayPayslipHistory()
        {
            this.LVEmployeePayslipsHistory.Items.Clear();
            if (this.EmployeePayslipsByPaydate != null)
            {
                decimal totalPayment = 0;
                foreach(var payslip in this.EmployeePayslipsByPaydate)
                {
                    string[] item = new string[] {
                        payslip.EmployeeNumber,
                        payslip.Employee.FullName,
                        $"{payslip.StartShiftDate.ToString("dd/MM")}-{payslip.EndShiftDate.ToString("dd/MM")}",
                        payslip.DailyRate.ToString(),
                        payslip.Late,
                        payslip.LateTotalDeduction.ToString(),
                        payslip.UnderTime,
                        payslip.UnderTimeTotalDeduction.ToString(),
                        payslip.NetBasicSalary.ToString(),
                        payslip.BenefitsTotal.ToString(),
                        payslip.DeductionTotal.ToString(),
                        payslip.NetTakeHomePay.ToString(),
                        payslip.NumOfDays,
                        payslip.EmployerGovtContributionTotal.ToString()
                    };

                    totalPayment += payslip.NetTakeHomePay;
                    totalPayment += payslip.EmployerGovtContributionTotal;

                    var listViewItem = new ListViewItem(item);

                    this.LVEmployeePayslipsHistory.Items.Add(listViewItem);
                }

                this.LblTotalPayment.Text = totalPayment.ToString();
            }
        }

        public event EventHandler GeneratePDFEmployeePayslipsReport;
        protected virtual void OnGeneratePDFEmployeePayslipsReport(EventArgs e)
        {
            GeneratePDFEmployeePayslipsReport?.Invoke(this, e);
        }
        private void BtnGenerateEmployeePayslipsReportPDF_Click(object sender, EventArgs e)
        {
            OnGeneratePDFEmployeePayslipsReport(EventArgs.Empty);
        }
    }
}
