using EntitiesShared.EmployeeManagement;
using EntitiesShared.OtherDataManagement;
using EntitiesShared.PayrollManagement;
using EntitiesShared.PayrollManagement.Models;
using Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
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

            this.DGVEmployeeListForOverview.BackgroundColor = Color.White;
            this.DGVEmployeeListForOverview.DefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVEmployeeListForOverview.RowHeadersVisible = false;
            this.DGVEmployeeListForOverview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVEmployeeListForOverview.AllowUserToResizeRows = false;
            this.DGVEmployeeListForOverview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVEmployeeListForOverview.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVEmployeeListForOverview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVEmployeeListForOverview.MultiSelect = false;
            this.DGVEmployeeListForOverview.ReadOnly = false;
            this.DGVEmployeeListForOverview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVEmployeeListForOverview.ColumnHeadersHeight = 30;
        }

        private void GeneratePayrollControl_Load(object sender, EventArgs e)
        {
            SetDGVFontAndColors();
            DisplayGovernmentAgencyList();
            DisplayBenefitsInDGV();
            DisplayDeductionsInDGV();
        }

        private void BtnGeneratePayrollInitiate_Click(object sender, EventArgs e)
        {
            this.PayDate = DPickerPaydate.Value;
            this.ShiftStartDate = DPickerShiftStartDate.Value;
            this.ShiftEndDate = DPickerShiftEndDate.Value;

            this.LblPaydate.Text = DPickerPaydate.Value.ToShortDateString();
            this.LblAttendanceDateStart.Text = DPickerShiftStartDate.Value.ToShortDateString();
            this.LblAttendanceDateEnd.Text = DPickerShiftEndDate.Value.ToShortDateString();

            OnInitiatePayrollGeneration(EventArgs.Empty);
        }


        public void DisplayEmployeeWithAttendanceRecordAndSalary(List<EmployeeModel> EmployeeList)
        {
            if (this.AttendanceHistory != null && EmployeeList != null)
            {
                this.DGVEmployeeList.Rows.Clear();
                if (EmployeeList != null)
                {
                    this.DGVEmployeeList.ColumnCount = 8;

                    this.DGVEmployeeList.Columns[0].Name = "EmployeeNumber";
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


                    foreach (var employee in EmployeeList)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(this.DGVEmployeeList);

                        row.Cells[0].Value = employee.EmployeeNumber;
                        row.Cells[1].Value = employee.FullName;

                        if (employee.SalaryRates != null)
                        {
                            row.Cells[2].Value = employee.SalaryRates.DailyRate;
                        }

                        var currentEmpAttendanceRec = this.AttendanceHistory.Where(x => x.EmployeeNumber == employee.EmployeeNumber).ToList();
                        var totalDays = currentEmpAttendanceRec.Count;
                        var totalLateInMins = currentEmpAttendanceRec.Sum(x => x.TotalLate);
                        var totalUnderTime = currentEmpAttendanceRec.Sum(x => x.TotalUnderTime);

                        if (totalDays <= 0)
                        {
                            row.DefaultCellStyle.ForeColor = Color.Red;
                            row.ReadOnly = true;
                        }

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

                        row.Tag = employee;

                        this.DGVEmployeeList.Rows.Add(row);
                    }

                }
            }
        }

        private void TboxSearchEmployee_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var searchStr = TboxSearchEmployee.Text;
                var searchEmployeeResults = this.Employees.Where(x => x.EmployeeNumber.Contains(searchStr) || 
                                                        x.FullName.Contains(searchStr)).ToList();

                this.DisplayEmployeeWithAttendanceRecordAndSalary(searchEmployeeResults);

                e.Handled = true;
            }
        }

        private void BtnSelectAllEmployeesInDGV_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.DGVEmployeeList.Rows)
            {
                if (row.ReadOnly == false)
                    row.Cells["selectEmpCkbox"].Value = (bool)true;
            }
        }

        public void DisplayGovernmentAgencyList()
        {
            this.DGVGovtAgencies.Rows.Clear();
            if (this.GovernmentAgencies != null)
            {
                this.DGVGovtAgencies.ColumnCount = 2;

                this.DGVGovtAgencies.Columns[0].Name = "GovernmentAgencyId";
                this.DGVGovtAgencies.Columns[0].Visible = false;

                this.DGVGovtAgencies.Columns[1].Name = "AgencyTitle";
                this.DGVGovtAgencies.Columns[1].HeaderText = "Agency";

                DataGridViewCheckBoxColumn selectChbxToSchedule = new DataGridViewCheckBoxColumn();
                selectChbxToSchedule.HeaderText = "Select";
                selectChbxToSchedule.Name = "selectGovtAngencyCkbox";
                selectChbxToSchedule.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.DGVGovtAgencies.Columns.Add(selectChbxToSchedule);

                foreach (var agency in this.GovernmentAgencies)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVGovtAgencies);

                    row.Cells[0].Value = agency.Id;
                    row.Cells[1].Value = agency.GovtAgency;

                    row.Tag = agency;

                    this.DGVGovtAgencies.Rows.Add(row);
                }
            }
        }

        public void DisplayBenefitsInDGV()
        {
            this.DGVBenefitsList.Rows.Clear();
            if (this.Benefits != null)
            {
                this.DGVBenefitsList.ColumnCount = 3;

                this.DGVBenefitsList.Columns[0].Name = "benefitId";
                this.DGVBenefitsList.Columns[0].Visible = false;

                this.DGVBenefitsList.Columns[1].Name = "BenefitTitle";
                this.DGVBenefitsList.Columns[1].HeaderText = "Title";

                this.DGVBenefitsList.Columns[2].Name = "BenefitAmount";
                this.DGVBenefitsList.Columns[2].HeaderText = "Amount";

                DataGridViewCheckBoxColumn selectChbxToSchedule = new DataGridViewCheckBoxColumn();
                selectChbxToSchedule.HeaderText = "Select";
                selectChbxToSchedule.Name = "selectBenefitCkbox";
                selectChbxToSchedule.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.DGVBenefitsList.Columns.Add(selectChbxToSchedule);

                foreach (var benefit in this.Benefits)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGVBenefitsList);

                    row.Cells[0].Value = benefit.Id;
                    row.Cells[1].Value = benefit.BenefitTitle;
                    row.Cells[2].Value = benefit.Amount;

                    row.Tag = benefit;

                    DGVBenefitsList.Rows.Add(row);
                }

            }
        }

        public void DisplayDeductionsInDGV()
        {
            this.DGVDeductionList.Rows.Clear();
            if (this.Deductions != null)
            {
                this.DGVDeductionList.ColumnCount = 3;

                this.DGVDeductionList.Columns[0].Name = "benefitId";
                this.DGVDeductionList.Columns[0].Visible = false;

                this.DGVDeductionList.Columns[1].Name = "DeductionTitle";
                this.DGVDeductionList.Columns[1].HeaderText = "Title";

                this.DGVDeductionList.Columns[2].Name = "DeductionAmount";
                this.DGVDeductionList.Columns[2].HeaderText = "Amount";

                DataGridViewCheckBoxColumn selectChbxToSchedule = new DataGridViewCheckBoxColumn();
                selectChbxToSchedule.HeaderText = "Select";
                selectChbxToSchedule.Name = "selectDeductionCkbox";
                selectChbxToSchedule.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.DGVDeductionList.Columns.Add(selectChbxToSchedule);

                foreach (var deduction in this.Deductions)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGVDeductionList);

                    row.Cells[0].Value = deduction.Id;
                    row.Cells[1].Value = deduction.DeductionTitle;
                    row.Cells[2].Value = deduction.Amount;

                    row.Tag = deduction;

                    DGVDeductionList.Rows.Add(row);
                }

            }
        }


        private void BtnSelectAllGovtAgencies_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.DGVGovtAgencies.Rows)
            {
                row.Cells["selectGovtAngencyCkbox"].Value = (bool)true;
            }
        }

        private void BtnSelectAllBenefits_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.DGVBenefitsList.Rows)
            {
                row.Cells["selectBenefitCkbox"].Value = (bool)true;
            }
        }

        private void BtnSelectAllDeductions_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.DGVDeductionList.Rows)
            {
                row.Cells["selectDeductionCkbox"].Value = (bool)true;
            }
        }

        public List<EmployeeModel> GetSelectedEmployeeToGeneratePayslip()
        {
            List<EmployeeModel> selectedEmployees = new List<EmployeeModel>();

            foreach (DataGridViewRow row in this.DGVEmployeeList.Rows)
            {
                if (row.ReadOnly == false)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["selectEmpCkbox"].Value);
                    if (isSelected)
                    {
                        string empNum = row.Cells["EmployeeNumber"].Value.ToString();
                        var empInList = this.Employees.Where(x => x.EmployeeNumber == empNum).FirstOrDefault();

                        var currentEmpAttendanceRec = this.AttendanceHistory.Where(x => x.EmployeeNumber == empNum).ToList();
                        var totalDays = currentEmpAttendanceRec.Count;

                        if (empInList != null && totalDays > 0)
                        {
                            var empTmp = JsonSerializer.Deserialize<EmployeeModel>(JsonSerializer.Serialize(empInList));
                            selectedEmployees.Add(empTmp);
                        }
                    }
                }
            }

            return selectedEmployees;
        }


        public List<GovernmentAgencyModel> GetSelectedGovtAgenciesToGeneratePayslip()
        {
            List<GovernmentAgencyModel> selectedGovtAgencies = new List<GovernmentAgencyModel>();

            foreach (DataGridViewRow row in this.DGVGovtAgencies.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["selectGovtAngencyCkbox"].Value);
                if (isSelected)
                {
                    var selectedGovt = (GovernmentAgencyModel)row.Tag;
                    var govtAgencyInList = this.GovernmentAgencies.Where(x => x.Id == selectedGovt.Id).FirstOrDefault();

                    if (govtAgencyInList != null)
                    {
                        var govtAgencyTemp = JsonSerializer.Deserialize<GovernmentAgencyModel>(JsonSerializer.Serialize(govtAgencyInList));
                        selectedGovtAgencies.Add(govtAgencyTemp);
                    }
                }
            }

            return selectedGovtAgencies;
        }


        public List<EmployeeBenefitModel> GetSelectedEmpBenefitsToGeneratePayslip()
        {
            List<EmployeeBenefitModel> selectedEmpBenefits = new List<EmployeeBenefitModel>();

            foreach (DataGridViewRow row in this.DGVBenefitsList.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["selectBenefitCkbox"].Value);
                if (isSelected)
                {
                    var selectedEmpBenefit = (EmployeeBenefitModel)row.Tag;
                    var empBenefitInList = this.Benefits.Where(x => x.Id == selectedEmpBenefit.Id).FirstOrDefault();

                    if (empBenefitInList != null)
                    {
                        var govtAgencyTemp = JsonSerializer.Deserialize<EmployeeBenefitModel>(JsonSerializer.Serialize(empBenefitInList));
                        selectedEmpBenefits.Add(govtAgencyTemp);
                    }
                }
            }

            return selectedEmpBenefits;
        }

        public List<EmployeeDeductionModel> GetSelectedEmpDeductionsToGeneratePayslip()
        {
            List<EmployeeDeductionModel> selectedEmpDeductions = new List<EmployeeDeductionModel>();

            foreach (DataGridViewRow row in this.DGVDeductionList.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["selectDeductionCkbox"].Value);
                if (isSelected)
                {
                    var selectedEmpDeduction = (EmployeeDeductionModel)row.Tag;
                    var empDeductionInList = this.Deductions.Where(x => x.Id == selectedEmpDeduction.Id).FirstOrDefault();

                    if (empDeductionInList != null)
                    {
                        var govtAgencyTemp = JsonSerializer.Deserialize<GovernmentAgencyModel>(JsonSerializer.Serialize(empDeductionInList));
                        selectedEmpDeductions.Add(empDeductionInList);
                    }
                }
            }

            return selectedEmpDeductions;
        }

        public void ClearDGVEmployeeListForOverview()
        {
            this.DGVEmployeeListForOverview.Rows.Clear();
            this.PanelEmployeePayslipContainer.Controls.Clear();
        }

        public void DisplayEmployeeInOverviewTag(List<EmployeeModel> EmployeeList)
        {
            if (this.AttendanceHistory != null && EmployeeList != null)
            {
                ClearDGVEmployeeListForOverview();
                if (EmployeeList != null)
                {
                    this.DGVEmployeeListForOverview.ColumnCount = 2;

                    this.DGVEmployeeListForOverview.Columns[0].Name = "EmployeeNumber";
                    this.DGVEmployeeListForOverview.Columns[0].HeaderText = "Employee Number";
                    this.DGVEmployeeListForOverview.Columns[0].Visible = true;

                    this.DGVEmployeeListForOverview.Columns[1].Name = "Fullname2";
                    this.DGVEmployeeListForOverview.Columns[1].HeaderText = "Fullname";
                    this.DGVEmployeeListForOverview.Columns[1].Visible = true;

                    foreach (var employee in EmployeeList)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(this.DGVEmployeeListForOverview);

                        row.Cells[0].Value = employee.EmployeeNumber;
                        row.Cells[1].Value = employee.FullName;

                        row.Tag = employee;

                        this.DGVEmployeeListForOverview.Rows.Add(row);
                    }

                }
            }
        }


        public PaydaySalaryComputationPayslip GetEmployeeAttendanceRecordWithSalaryComputation(EmployeeModel employee)
        {
            if (this.AttendanceHistory != null && employee != null)
            {
                var currentEmpAttendanceRec = this.AttendanceHistory.Where(x => x.EmployeeNumber == employee.EmployeeNumber).ToList();
                decimal totalDays = currentEmpAttendanceRec.Count;
                decimal totalLeaveDays = 0;

                if (this.EmployeeLeaveHistory != null)
                {
                    var currentEmpLeave = this.EmployeeLeaveHistory.Where(x => x.EmployeeNumber == employee.EmployeeNumber).ToList();
                    totalLeaveDays = currentEmpLeave.Sum(x => x.NumberOfDays);
                }
                totalDays += totalLeaveDays;

                decimal netBasicSalary = currentEmpAttendanceRec.Sum(x => x.TotalDailySalary);
                netBasicSalary += employee.SalaryRates.DailyRate * totalLeaveDays;

                // no need to deduct this in netBasicSalary, since we already deduct late and undertime upon inserting the data in time-in and out terminal
                decimal lateDeductions = currentEmpAttendanceRec.Sum(x => x.LateTotalDeduction);
                decimal underTimeDeductions = currentEmpAttendanceRec.Sum(x => x.UnderTimeTotalDeduction);

                return new PaydaySalaryComputationPayslip
                {
                    Late = currentEmpAttendanceRec.Sum(x => x.TotalLate).ToString() + "m",
                    LateTotalDeduction = lateDeductions,
                    UnderTime = currentEmpAttendanceRec.Sum(x => x.TotalUnderTime).ToString() + "m",
                    UnderTimeTotalDeduction = underTimeDeductions,
                    NumberOfDays = totalDays.ToString() + "d",
                    NetBasicSalary = netBasicSalary
                };
            }

            return new PaydaySalaryComputationPayslip();
        }


        private List<EmployeePayslipGeneration> employeePayslipGenerations = new List<EmployeePayslipGeneration>();

        public List<EmployeePayslipGeneration> EmployeePayslipGenerations
        {
            get { return employeePayslipGenerations; }
            set { employeePayslipGenerations = value; }
        }


        public event EventHandler GenerateEmployeePayslip;
        protected virtual void OnGenerateEmployeePayslip(EventArgs e)
        {
            GenerateEmployeePayslip?.Invoke(this, e);
        }

        private void BtnGenerateEmployeePayslip_Click(object sender, EventArgs e)
        {
            var SelectedEmployeesForPayrollGeneration = this.GetSelectedEmployeeToGeneratePayslip();
            if (SelectedEmployeesForPayrollGeneration != null && SelectedEmployeesForPayrollGeneration.Count > 0)
            {
                var SelectedGovtAgenciesForPayrollGeneration = this.GetSelectedGovtAgenciesToGeneratePayslip();
                var SelectedBenefitsForPayrollGeneration = this.GetSelectedEmpBenefitsToGeneratePayslip();
                var SelectedDeductionsForPayrollGeneration = this.GetSelectedEmpDeductionsToGeneratePayslip();

                EmployeePayslipGenerations = new List<EmployeePayslipGeneration>();

                foreach (var selectedEmp in SelectedEmployeesForPayrollGeneration)
                {
                    EmployeePayslipGenerations.Add(new EmployeePayslipGeneration
                    {
                        PayDate = this.PayDate,
                        ShiftStartDate = this.ShiftStartDate,
                        ShiftEndDate = this.ShiftEndDate,
                        Employee = selectedEmp,
                        PaydaySalaryComputation = this.GetEmployeeAttendanceRecordWithSalaryComputation(selectedEmp),
                        AttendanceHistory = this.AttendanceHistory != null ? this.AttendanceHistory.Where(x => x.EmployeeNumber == selectedEmp.EmployeeNumber).ToList() : null,
                        EmployeeLeaves = this.EmployeeLeaveHistory != null ? this.EmployeeLeaveHistory.Where(x => x.EmployeeNumber == selectedEmp.EmployeeNumber).ToList() : null,
                        SelectedGovtAgencies = SelectedGovtAgenciesForPayrollGeneration,
                        SelectedBenefits = SelectedBenefitsForPayrollGeneration,
                        SelectedDeductions = SelectedDeductionsForPayrollGeneration
                    });
                }

                OnGenerateEmployeePayslip(EventArgs.Empty);

                this.DisplayEmployeeInOverviewTag(SelectedEmployeesForPayrollGeneration);
            }
            else
            {
                MessageBox.Show("No selected employee for payslip generation.", "Get selected employees", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private string selectedEmployeeNumberToViewPayslip;

        public string SelectedEmployeeNumberToViewPayslip
        {
            get { return selectedEmployeeNumberToViewPayslip; }
            set { selectedEmployeeNumberToViewPayslip = value; }
        }

        public event EventHandler ViewEmployeePayslip;
        protected virtual void OnViewEmployeePayslip(EventArgs e)
        {
            ViewEmployeePayslip?.Invoke(this, e);
        }

        private void DGVEmployeeListForOverview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (DGVEmployeeListForOverview.CurrentRow != null)
                {
                    SelectedEmployeeNumberToViewPayslip = DGVEmployeeListForOverview.CurrentRow.Cells[0].Value.ToString();
                    OnViewEmployeePayslip(EventArgs.Empty);
                }
            }
        }

        public void DisplayEmployeePayslip(EmployeeModel employee, EmployeePayslipModel payslip)
        {
            this.PanelEmployeePayslipContainer.Controls.Clear();
            var payslipItemControlObj = new PayslipItemControl { Employee = employee, Payslip = payslip};
            payslipItemControlObj.Location = new Point(this.PanelEmployeePayslipContainer.Width / 2 - payslipItemControlObj.Size.Width / 2, this.PanelEmployeePayslipContainer.Height / 2 - payslipItemControlObj.Size.Height / 2);
            payslipItemControlObj.Anchor = AnchorStyles.None;
            this.PanelEmployeePayslipContainer.Controls.Add(payslipItemControlObj);
        }


        public event EventHandler CancelAllEmployeePayslip;
        protected virtual void OnCancelAllEmployeePayslip(EventArgs e)
        {
            CancelAllEmployeePayslip?.Invoke(this, e);
        }

        private void BtnCancelAllEmployeePayslip_Click(object sender, EventArgs e)
        {
            OnCancelAllEmployeePayslip(EventArgs.Empty);
        }

        public event EventHandler CancelSelectedEmployeePayslip;
        protected virtual void OnCancelSelectedEmployeePayslip(EventArgs e)
        {
            CancelSelectedEmployeePayslip?.Invoke(this, e);
        }
        private void BtnCancelSelectedEmployeePayslip_Click(object sender, EventArgs e)
        {
            OnCancelSelectedEmployeePayslip(EventArgs.Empty);
        }
    }
}
