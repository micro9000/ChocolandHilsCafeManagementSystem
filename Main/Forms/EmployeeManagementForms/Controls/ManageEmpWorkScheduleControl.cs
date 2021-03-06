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


        public ManageEmpWorkScheduleControl()
        {
            InitializeComponent();
        }


        private void ManageEmpWorkScheduleControl_Load(object sender, EventArgs e)
        {
            SetDGVGeneratedWorkSchedulesFontAndColors();
        }

        private void SetDGVGeneratedWorkSchedulesFontAndColors()
        {
            this.DGVGeneratedWorkSchedules.BackgroundColor = Color.White;
            this.DGVGeneratedWorkSchedules.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVGeneratedWorkSchedules.RowHeadersVisible = false;
            this.DGVGeneratedWorkSchedules.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVGeneratedWorkSchedules.AllowUserToResizeRows = false;
            this.DGVGeneratedWorkSchedules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVGeneratedWorkSchedules.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVGeneratedWorkSchedules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVGeneratedWorkSchedules.MultiSelect = false;

            this.DGVGeneratedWorkSchedules.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVGeneratedWorkSchedules.ColumnHeadersHeight = 30;
        }

        private void BtnGenerateEmployeeWorkSched_Click(object sender, EventArgs e)
        {

        }
    }
}
