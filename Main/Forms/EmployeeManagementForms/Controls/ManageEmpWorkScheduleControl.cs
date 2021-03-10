using EntitiesShared.EmployeeManagement;
using EntitiesShared.EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.EmployeeManagementForms.Controls
{
    public partial class ManageEmpWorkScheduleControl : UserControl
    {

        private List<EmployeeModel> employees;

        public List<EmployeeModel> Employees
        {
            get { return employees; }
            set { employees = value; }
        }


        private List<EmployeeShiftModel> workShifts;

        public List<EmployeeShiftModel> WorkShifts
        {
            get { return workShifts; }
            set { workShifts = value; }
        }


        private List<EmployeeShiftDayModel> workShiftDays;

        public List<EmployeeShiftDayModel> WorkShiftDays
        {
            get { return workShiftDays; }
            set { workShiftDays = value; }
        }


        public ManageEmpWorkScheduleControl()
        {
            InitializeComponent();
        }


        private void ManageEmpWorkScheduleControl_Load(object sender, EventArgs e)
        {
            SetDGVEmployeeListFontAndColors();
            SetDGVShiftListFontAndColors();

            DisplayWorkShifts();
            DisplayEmployees();
        }

        private void SetDGVEmployeeListFontAndColors()
        {
            this.DGVEmployeeList.BackgroundColor = Color.White;
            this.DGVEmployeeList.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVEmployeeList.RowHeadersVisible = false;
            this.DGVEmployeeList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVEmployeeList.AllowUserToResizeRows = false;
            this.DGVEmployeeList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVEmployeeList.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            //this.DGVEmployeeList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVEmployeeList.MultiSelect = false;
            this.DGVEmployeeList.ReadOnly = false;

            this.DGVEmployeeList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVEmployeeList.ColumnHeadersHeight = 30;
        }

        private void SetDGVShiftListFontAndColors()
        {
            this.DGVShiftList.BackgroundColor = Color.White;
            this.DGVShiftList.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVShiftList.RowHeadersVisible = false;
            this.DGVShiftList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVShiftList.AllowUserToResizeRows = false;
            this.DGVShiftList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVShiftList.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVShiftList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVShiftList.MultiSelect = false;

            this.DGVShiftList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVShiftList.ColumnHeadersHeight = 30;
        }


        // Event handler for saving
        public event EventHandler ShiftSelected;
        protected virtual void OnShiftSelected(EventArgs e)
        {
            ShiftSelected?.Invoke(this, e);
        }

        private long selectedShiftId;

        public long SelectedShiftId
        {
            get { return selectedShiftId; }
            set { selectedShiftId = value; }
        }


        public void DisplayEmployees()
        {
            this.DGVEmployeeList.Rows.Clear();
            if (this.Employees != null)
            {
                this.DGVEmployeeList.ColumnCount = 4;


                DataGridViewCheckBoxColumn selectChbx = new DataGridViewCheckBoxColumn();
                selectChbx.HeaderText = "Select";
                selectChbx.Name = "selectEmpCkbox";
                selectChbx.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.DGVEmployeeList.Columns.Insert(0, selectChbx);

                this.DGVEmployeeList.Columns[1].Name = "EmployeeNumber";
                this.DGVEmployeeList.Columns[1].Visible = true;

                this.DGVEmployeeList.Columns[2].Name = "Fullname";
                this.DGVEmployeeList.Columns[2].Visible = true;

                this.DGVEmployeeList.Columns[3].Name = "Position";
                this.DGVEmployeeList.Columns[3].Visible = true;

                foreach (var employee in this.Employees)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVEmployeeList);

                    string fullName = $"{employee.FirstName} {employee.MiddleName} {employee.LastName}";

                    row.Cells[0].Value = false;
                    row.Cells[1].Value = employee.EmployeeNumber;
                    row.Cells[2].Value = fullName;
                    row.Cells[3].Value = employee.Position;

                    if (employee.Shift != null)
                    {
                        row.Cells[4].Value = employee.Shift.Shift;
                    }

                    this.DGVEmployeeList.Rows.Add(row);
                }
            }
        }

        public void DisplayWorkShifts()
        {
            this.DGVShiftList.Rows.Clear();
            if (this.WorkShifts != null)
            {
                this.DGVShiftList.ColumnCount = 3;

                this.DGVShiftList.Columns[0].Name = "ShiftId";
                this.DGVShiftList.Columns[0].Visible = false;

                this.DGVShiftList.Columns[1].Name = "Shift";
                this.DGVShiftList.Columns[1].Visible = true;

                this.DGVShiftList.Columns[2].Name = "Time";
                this.DGVShiftList.Columns[2].Visible = true;

                foreach(var shift in this.WorkShifts)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVShiftList);

                    string timeStartAndEnd = $"{shift.StartTime.ToString("hh:mm:ss tt", CultureInfo.CurrentCulture)} to {shift.EndTime.ToString("hh:mm:ss tt", CultureInfo.CurrentCulture)}";

                    row.Cells[0].Value = shift.Id;
                    row.Cells[1].Value = shift.Shift;
                    row.Cells[2].Value = timeStartAndEnd;

                    this.DGVShiftList.Rows.Add(row);
                }
            }
        }


        public void ResetShiftDaysCheckBoxes()
        {
            foreach (var daysCheckBoxControl in this.GroupPanelShiftDays.Controls)
            {
                if (daysCheckBoxControl is CheckBox)
                {
                    ((CheckBox)daysCheckBoxControl).Checked = false;
                }
            }
        }

        public void DisplayWorkShiftDays()
        {
            ResetShiftDaysCheckBoxes();
            if (this.WorkShiftDays != null)
            {
                foreach (var shiftDay in this.WorkShiftDays)
                {
                    string dayNameTag = $"{shiftDay.DayName}-{shiftDay.OrderNum}";

                    foreach (var daysCheckBoxControl in this.GroupPanelShiftDays.Controls)
                    {
                        if (daysCheckBoxControl is CheckBox)
                        {
                            if (((CheckBox)daysCheckBoxControl).Tag.ToString() == dayNameTag)
                            {
                                ((CheckBox)daysCheckBoxControl).Checked = true;
                            }
                        }
                    }
                }
            }
        }

        private void DGVShiftList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string shiftId = this.DGVShiftList.CurrentRow.Cells[0].Value.ToString();
                this.SelectedShiftId = long.Parse(shiftId);
                this.OnShiftSelected(EventArgs.Empty);
            }
        }

        private void BtnSaveEmployeeShiftSchedule_Click(object sender, EventArgs e)
        {
            List<string> empNums = new List<string>();
            foreach (DataGridViewRow row in this.DGVEmployeeList.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["selectEmpCkbox"].Value);
                if (isSelected)
                {
                    empNums.Add(row.Cells["EmployeeNumber"].Value.ToString());
                }
            }

            MessageBox.Show(string.Join(",", empNums.ToArray()));
        }

    }
}
