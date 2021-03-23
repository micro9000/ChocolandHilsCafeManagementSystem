using EntitiesShared.EmployeeManagement;
using EntitiesShared.OtherDataManagement;
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

namespace Main.Forms.PayrollForms.Controls
{
    public partial class GeneratePayrollControl : UserControl
    {


        private DateTime payDate;

        public DateTime PayDate
        {
            get { return payDate; }
            set { payDate = value; }
        }

        private DateTime shiftStartDate;

        public DateTime ShiftStartDate
        {
            get { return shiftStartDate; }
            set { shiftStartDate = value; }
        }

        private DateTime shiftEndDate;

        public DateTime ShiftEndDate
        {
            get { return shiftEndDate; }
            set { shiftEndDate = value; }
        }

        // Event handler for saving leave type
        public event EventHandler InitiatePayrollGeneration;
        protected virtual void OnInitiatePayrollGeneration(EventArgs e)
        {
            InitiatePayrollGeneration?.Invoke(this, e);
        }


        private List<EmployeeAttendanceModel> attendanceHistory;

        public List<EmployeeAttendanceModel> AttendanceHistory
        {
            get { return attendanceHistory; }
            set { attendanceHistory = value; }
        }


        private List<EmployeeLeaveModel> employeeLeaveHistory;

        public List<EmployeeLeaveModel> EmployeeLeaveHistory
        {
            get { return employeeLeaveHistory; }
            set { employeeLeaveHistory = value; }
        }

        private List<EmployeeModel> employees;

        public List<EmployeeModel> Employees
        {
            get { return employees; }
            set { employees = value; }
        }


        private List<GovernmentAgencyModel> governmentAgencies;

        public List<GovernmentAgencyModel> GovernmentAgencies
        {
            get { return governmentAgencies; }
            set { governmentAgencies = value; }
        }


        private List<EmployeeBenefitModel> benefits;

        public List<EmployeeBenefitModel> Benefits
        {
            get { return benefits; }
            set { benefits = value; }
        }


        private List<EmployeeDeductionModel> deductions;
        public List<EmployeeDeductionModel> Deductions
        {
            get { return deductions; }
            set { deductions = value; }
        }

        private readonly DecimalMinutesToHrsConverter _decimalMinutesToHrsConverter;

        public GeneratePayrollControl(DecimalMinutesToHrsConverter decimalMinutesToHrsConverter)
        {
            InitializeComponent();
            _decimalMinutesToHrsConverter = decimalMinutesToHrsConverter;
        }

        private void SetDGVFontAndColors()
        {
            this.DGVEmployeeList.BackgroundColor = Color.White;
            this.DGVEmployeeList.DefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVEmployeeList.RowHeadersVisible = false;
            this.DGVEmployeeList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVEmployeeList.AllowUserToResizeRows = false;
            this.DGVEmployeeList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVEmployeeList.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVEmployeeList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVEmployeeList.MultiSelect = false;
            this.DGVEmployeeList.ReadOnly = false;
            this.DGVEmployeeList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVEmployeeList.ColumnHeadersHeight = 30;

            this.DGVGovtAgencies.BackgroundColor = Color.White;
            this.DGVGovtAgencies.DefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVGovtAgencies.RowHeadersVisible = false;
            this.DGVGovtAgencies.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVGovtAgencies.AllowUserToResizeRows = false;
            this.DGVGovtAgencies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVGovtAgencies.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVGovtAgencies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVGovtAgencies.MultiSelect = false;
            this.DGVGovtAgencies.ReadOnly = false;
            this.DGVGovtAgencies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVGovtAgencies.ColumnHeadersHeight = 30;

            this.DGVBenefitsList.BackgroundColor = Color.White;
            this.DGVBenefitsList.DefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVBenefitsList.RowHeadersVisible = false;
            this.DGVBenefitsList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVBenefitsList.AllowUserToResizeRows = false;
            this.DGVBenefitsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVBenefitsList.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVBenefitsList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVBenefitsList.MultiSelect = false;
            this.DGVBenefitsList.ReadOnly = false;
            this.DGVBenefitsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVBenefitsList.ColumnHeadersHeight = 30;

            this.DGVDeductionList.BackgroundColor = Color.White;
            this.DGVDeductionList.DefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVDeductionList.RowHeadersVisible = false;
            this.DGVDeductionList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVDeductionList.AllowUserToResizeRows = false;
            this.DGVDeductionList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVDeductionList.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVDeductionList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVDeductionList.MultiSelect = false;
            this.DGVDeductionList.ReadOnly = false;
            this.DGVDeductionList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVDeductionList.ColumnHeadersHeight = 30;
        }

        private void GeneratePayrollControl_Load(object sender, EventArgs e)
        {
            SetDGVFontAndColors();
            //DisplayEmployees();
        }

        private void BtnGeneratePayrollInitiate_Click(object sender, EventArgs e)
        {
            this.PayDate = DPickerPaydate.Value;
            this.ShiftStartDate = DPickerShiftStartDate.Value;
            this.ShiftEndDate = DPickerShiftEndDate.Value;

            OnInitiatePayrollGeneration(EventArgs.Empty);
        }

        public void DisplayEmployeeWithAttendanceRecordAndSalary()
        {
            if (this.AttendanceHistory != null && this.Employees != null)
            {
                this.DGVEmployeeList.Rows.Clear();
                if (this.Employees != null)
                {
                    this.DGVEmployeeList.ColumnCount = 8;

                    this.DGVEmployeeList.Columns[0].Name = "EmployeeNumber2";
                    this.DGVEmployeeList.Columns[0].HeaderText = "Employee Number";
                    this.DGVEmployeeList.Columns[0].Visible = true;

                    this.DGVEmployeeList.Columns[1].Name = "Fullname2";
                    this.DGVEmployeeList.Columns[1].HeaderText = "Fullname";
                    this.DGVEmployeeList.Columns[1].Visible = true;

                    this.DGVEmployeeList.Columns[2].Name = "DailyRate";
                    this.DGVEmployeeList.Columns[2].HeaderText = "Daily Rate";
                    this.DGVEmployeeList.Columns[2].Visible = true;

                    this.DGVEmployeeList.Columns[3].Name = "Days";
                    this.DGVEmployeeList.Columns[3].HeaderText = "Days";
                    this.DGVEmployeeList.Columns[3].Visible = true;

                    this.DGVEmployeeList.Columns[4].Name = "L";
                    this.DGVEmployeeList.Columns[4].HeaderText = "L";
                    this.DGVEmployeeList.Columns[4].Visible = true;

                    this.DGVEmployeeList.Columns[5].Name = "Late";
                    this.DGVEmployeeList.Columns[5].HeaderText = "Late";
                    this.DGVEmployeeList.Columns[5].Visible = true;

                    this.DGVEmployeeList.Columns[6].Name = "UT";
                    this.DGVEmployeeList.Columns[6].HeaderText = "UT";
                    this.DGVEmployeeList.Columns[6].Visible = true;

                    this.DGVEmployeeList.Columns[7].Name = "OT";
                    this.DGVEmployeeList.Columns[7].HeaderText = "OT";
                    this.DGVEmployeeList.Columns[7].Visible = true;

                    DataGridViewCheckBoxColumn selectChbxToSchedule = new DataGridViewCheckBoxColumn();
                    selectChbxToSchedule.HeaderText = "Select";
                    selectChbxToSchedule.Name = "selectEmpCkbox";
                    selectChbxToSchedule.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.DGVEmployeeList.Columns.Add(selectChbxToSchedule);


                    foreach (var employee in this.Employees)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(this.DGVEmployeeList);

                        string fullName = $"{employee.FirstName} {employee.MiddleName} {employee.LastName}";

                        row.Cells[0].Value = employee.EmployeeNumber;
                        row.Cells[1].Value = fullName;

                        if (employee.SalaryRates != null)
                        {
                            row.Cells[2].Value = employee.SalaryRates.DailyRate;
                        }


                        var currentEmpAttendanceRec = this.AttendanceHistory.Where(x => x.EmployeeNumber == employee.EmployeeNumber).ToList();
                        var totalDays = currentEmpAttendanceRec.Count;
                        var totalLateInMins = currentEmpAttendanceRec.Sum(x => x.TotalLate);
                        var totalUnderTime = currentEmpAttendanceRec.Sum(x => x.TotalUnderTime);

                        row.Cells[3].Value = totalDays.ToString();

                        if (this.EmployeeLeaveHistory != null)
                        {
                            var currentEmpLeave = this.EmployeeLeaveHistory.Where(x => x.EmployeeNumber == employee.EmployeeNumber).ToList();
                            var totalLeave = currentEmpLeave.Sum(x => x.NumberOfDays);
                            row.Cells[4].Value = totalLeave.ToString();
                        }
                        else
                        {
                            row.Cells[4].Value = "";
                        }

                        row.Cells[5].Value = _decimalMinutesToHrsConverter.ConvertToStringHrs(totalLateInMins);
                        row.Cells[6].Value = _decimalMinutesToHrsConverter.ConvertToStringHrs(totalUnderTime);

                        row.Cells[7].Value = "";

                        this.DGVEmployeeList.Rows.Add(row);
                    }

                }
            }
        }
    }
}
