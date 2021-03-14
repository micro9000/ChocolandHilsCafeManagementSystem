using EntitiesShared.EmployeeManagement;
using EntitiesShared.EmployeeManagement.Models;
using Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.EmployeeManagementForms.Controls
{
    public partial class EmployeeDetailsControl : UserControl
    {
        public EmployeeDetailsControl(DecimalMinutesToHrsConverter decimalMinutesToHrsConverter)
        {
            InitializeComponent();
            _decimalMinutesToHrsConverter = decimalMinutesToHrsConverter;
        }

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

        private List<EmployeeAttendanceModel> attendanceHistory;

        public List<EmployeeAttendanceModel> AttendanceHistory
        {
            get { return attendanceHistory; }
            set { attendanceHistory = value; }
        }

        private EmployeeDetailsModel employeeFullInformations = new EmployeeDetailsModel();
        private readonly DecimalMinutesToHrsConverter _decimalMinutesToHrsConverter;

        public EmployeeDetailsModel EmployeeFullInformations
        {
            get { return employeeFullInformations; }
            set { employeeFullInformations = value; }
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
                ListViewEmpGovtIdCards.Items.Clear();
                var idCards = this.EmployeeFullInformations.EmployeeGovtIdCards.Select(x => x.EmployeeGovtIdCard).ToList();

                foreach (var card in idCards)
                {
                    var row = new string[] { card.GovernmentAgency.GovtAgency, card.EmployeeIdNumber };
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


        public void DisplayAttendanceRecord()
        {
            if (this.AttendanceHistory != null)
            {
                this.LViewAttendanceHistoryForToday.Items.Clear();
                foreach (var attendance in this.AttendanceHistory)
                {
                    DateTime firstTimeOut = DateTime.Now;
                    if (attendance.FirstTimeOut == DateTime.MinValue)
                    {
                        firstTimeOut = attendance.Shift.EarlyTimeOut;
                    }
                    else
                    {
                        firstTimeOut = attendance.FirstTimeOut;
                    }

                    string firstTimeINandOUT = $"{attendance.FirstTimeIn.ToString("hh:mm")} {firstTimeOut.ToString("hh:mm")}";

                    string secondTimeINandOUT = "";

                    if (attendance.IsTimeOutProvided)
                    {
                        secondTimeINandOUT = $"{attendance.SecondTimeIn.ToString("hh:mm")} {attendance.SecondTimeOut.ToString("hh:mm")}";
                    }

                    string whoDayTotalHrs = _decimalMinutesToHrsConverter.Convert(attendance.FirstHalfHrs + attendance.SecondHalfHrs);
                    string late = _decimalMinutesToHrsConverter.Convert(attendance.FirstHalfLateMins + attendance.SecondHalfLateMins);
                    string underTime = _decimalMinutesToHrsConverter.Convert(attendance.FirstHalfUnderTimeMins + attendance.SecondHalfUnderTimeMins);
                    string overTime = _decimalMinutesToHrsConverter.Convert(attendance.OverTimeMins);

                    var row = new string[]
                    {
                        attendance.WorkDate.ToShortDateString(),
                        attendance.Shift.Shift,
                        $"{attendance.Shift.StartTime.ToString("hh:mm tt")} to {attendance.Shift.EndTime.ToString("hh:mm tt")}",
                        firstTimeINandOUT,
                        secondTimeINandOUT,
                        whoDayTotalHrs,
                        late,
                        underTime,
                        overTime
                    };

                    var listViewItem = new ListViewItem(row);
                    listViewItem.Tag = attendance;

                    this.LViewAttendanceHistoryForToday.Items.Add(listViewItem);
                }
            }
        }


        private DateTime filterAttendanceStartDate;

        public DateTime FilterAttendanceStartDate
        {
            get { return filterAttendanceStartDate; }
            set { filterAttendanceStartDate = value; }
        }


        private DateTime filterAttendanceEndDate;

        public DateTime FilterAttendanceEndDate
        {
            get { return filterAttendanceEndDate; }
            set { filterAttendanceEndDate = value; }
        }


        // Event handler for saving leave type
        public event EventHandler FilterEmployeeAttendance;
        protected virtual void OnFilterEmployeeAttendance(EventArgs e)
        {
            FilterEmployeeAttendance?.Invoke(this, e);
        }


        private void BtnFilterAttendanceHistory_Click(object sender, EventArgs e)
        {
            FilterAttendanceStartDate = this.DPickerFilterAttendanceStartDate.Value;
            FilterAttendanceEndDate = this.DPickerFilterAttendanceEndDate.Value;

            if (string.IsNullOrEmpty(this.TboxSearchEmployeeNumber.Text))
            {
                MessageBox.Show("Search employee first.", "Search employee details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            OnFilterEmployeeAttendance(EventArgs.Empty);
        }
    }
}
