using EntitiesShared.EmployeeManagement;
using EntitiesShared.OtherDataManagement;
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

        public GeneratePayrollControl()
        {
            InitializeComponent();
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

        private void TabControlDeductions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //public void DisplayEmployees()
        //{
        //    this.DGVEmployeeList.Rows.Clear();
        //    if (this.Employees != null)
        //    {
        //        this.DGVEmployeeList.ColumnCount = 4;

        //        this.DGVEmployeeList.Columns[0].Name = "EmployeeNumber2";
        //        this.DGVEmployeeList.Columns[0].HeaderText = "Employee Number";
        //        this.DGVEmployeeList.Columns[0].Visible = true;

        //        this.DGVEmployeeList.Columns[1].Name = "Fullname2";
        //        this.DGVEmployeeList.Columns[1].HeaderText = "Fullname";
        //        this.DGVEmployeeList.Columns[1].Visible = true;

        //        this.DGVEmployeeList.Columns[2].Name = "Position2";
        //        this.DGVEmployeeList.Columns[2].HeaderText = "Position";
        //        this.DGVEmployeeList.Columns[2].Visible = true;

        //        this.DGVEmployeeList.Columns[3].Name = "DailyRate";
        //        this.DGVEmployeeList.Columns[3].HeaderText = "Daily Rate";
        //        this.DGVEmployeeList.Columns[3].Visible = true;

        //        DataGridViewCheckBoxColumn selectChbxToSchedule = new DataGridViewCheckBoxColumn();
        //        selectChbxToSchedule.HeaderText = "Select";
        //        selectChbxToSchedule.Name = "selectEmpCkbox";
        //        selectChbxToSchedule.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        //        this.DGVEmployeeList.Columns.Add(selectChbxToSchedule);

        //        foreach (var employee in this.Employees)
        //        {
        //            DataGridViewRow row = new DataGridViewRow();
        //            row.CreateCells(this.DGVEmployeeList);

        //            string fullName = $"{employee.FirstName} {employee.MiddleName} {employee.LastName}";

        //            row.Cells[0].Value = employee.EmployeeNumber;
        //            row.Cells[1].Value = fullName;
        //            row.Cells[2].Value = employee.Position;

        //            if (employee.SalaryRates != null)
        //            {
        //                row.Cells[3].Value = employee.SalaryRates.DailyRate;
        //            }

        //            this.DGVEmployeeList.Rows.Add(row);
        //        }

        //    }
        //}
    }
}
