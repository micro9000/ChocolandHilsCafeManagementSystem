using EmployeeManagementUserControls.CustomModels;
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
    public partial class EmployeeDetailsUserControl : UserControl
    {
        private Button currentButton;

        public event PropertyChangedEventHandler EmployeeNumberPropertyChanged;
        private string employeeNumber;

        public string EmployeeNumber
        {
            get { return employeeNumber; }
            set
            {
                employeeNumber = value;
                if (EmployeeNumberPropertyChanged != null)
                {
                    EmployeeNumberPropertyChanged(this, new PropertyChangedEventArgs(EmployeeNumber));
                }
            }
        }


        private EmployeeDetailsModel employeeFullInformations = new EmployeeDetailsModel();

        public EmployeeDetailsModel EmployeeFullInformations
        {
            get { return employeeFullInformations; }
            set { employeeFullInformations = value; }
        }


        public EmployeeDetailsUserControl()
        {
            InitializeComponent();
        }
        
        private void EmployeeDetailsUserControl_Load(object sender, EventArgs e)
        {
        }

        private void BtnSaveEmployee_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.TboxSearchEmployeeNumber.Text) == false)
            {
                this.EmployeeNumber = this.TboxSearchEmployeeNumber.Text;
            }
        }

        public void DisplayAllEmployeeInformations()
        {
            DisplayEmployeePersonalDetails();
            DisplayEmployeeGovtIds();
            DisplaySalaryRate();
        }

        private void DisplayEmployeePersonalDetails()
        {
            if (this.EmployeeFullInformations != null && this.EmployeeFullInformations.Employee != null)
            {
                var empDetails = this.EmployeeFullInformations.Employee;

                this.LblFullname.Text = $"{empDetails.LastName.ToUpper()} {empDetails.FirstName}, {empDetails.LastName}";
                this.LblAddress.Text = empDetails.Address;
                this.LblBirthdate.Text = empDetails.BirthDate.ToShortDateString();

                var timeSpan = DateTime.Now - empDetails.BirthDate;
                int age = new DateTime(timeSpan.Ticks).Year - 1;
                this.LblAge.Text = age.ToString();

                this.LblContactNumber.Text = empDetails.MobileNumber;
                this.LblEmail.Text = empDetails.EmailAddress;

                this.LblDateHire.Text = empDetails.DateHire.ToShortDateString();
                this.LblPosition.Text = empDetails.Position;
                this.LblBranchAssign.Text = empDetails.BranchAssign;
            }
        }

        private void DisplayEmployeeGovtIds()
        {
            if (this.EmployeeFullInformations != null && this.EmployeeFullInformations.EmployeeGovtIdCards != null)
            {
                var idCards = this.EmployeeFullInformations.EmployeeGovtIdCards.Select(x => x.EmployeeGovtIdCard).ToList();

                foreach (var card in idCards)
                {
                    var row = new string[] { card.EmployeeNumber, card.EmployeeIdNumber };
                    var listViewItem = new ListViewItem(row);
                    listViewItem.Tag = card;

                    ListViewEmpGovtIdCards.Items.Add(listViewItem);
                }
            }

        }

        private void DisplaySalaryRate()
        {
            if (this.EmployeeFullInformations != null && this.EmployeeFullInformations.EmployeeSalary != null)
            {
                var empSalary = this.EmployeeFullInformations.EmployeeSalary;

                this.LblSalaryRate.Text = empSalary.SalaryRate.ToString();
                this.LblHalfMonthSalaryRate.Text = empSalary.HalfMonthRate.ToString();
                this.LblDailyRate.Text = empSalary.DailyRate.ToString();
            }
        }
    }
}
