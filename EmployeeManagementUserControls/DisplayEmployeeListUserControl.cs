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
    public partial class DisplayEmployeeListUserControl : UserControl
    {
        public DisplayEmployeeListUserControl()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string selectedEmployeeNumber;

        public string SelectedEmployeeNumber
        {
            get { return selectedEmployeeNumber; }
            set {
                selectedEmployeeNumber = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(SelectedEmployeeNumber));
                }
            }
        }



        private List<EmployeeModel> employees;

        public List<EmployeeModel> Employees
        {
            get { return employees; }
            set { employees = value; }
        }


        public void DisplayEmployeeList()
        {
            if (Employees != null)
            {
                this.DGVEmployees.ColumnCount = 10;

                this.DGVEmployees.Columns[0].Name = "EmployeeNumber";
                this.DGVEmployees.Columns[0].HeaderText = "Employee #";
                this.DGVEmployees.Columns[0].Visible = true;

                this.DGVEmployees.Columns[1].Name = "Fullname";
                this.DGVEmployees.Columns[1].HeaderText = "Fullname";

                this.DGVEmployees.Columns[2].Name = "EmpAddress";
                this.DGVEmployees.Columns[2].HeaderText = "Address";

                this.DGVEmployees.Columns[3].Name = "DateOfBirth";
                this.DGVEmployees.Columns[3].HeaderText = "Date of birth";

                this.DGVEmployees.Columns[4].Name = "MobileNumber";
                this.DGVEmployees.Columns[4].HeaderText = "Mobile #";

                this.DGVEmployees.Columns[5].Name = "EmailAddress";
                this.DGVEmployees.Columns[5].HeaderText = "Email";

                this.DGVEmployees.Columns[6].Name = "BranchAssign";
                this.DGVEmployees.Columns[6].HeaderText = "Branch Assign";

                this.DGVEmployees.Columns[7].Name = "DateHire";
                this.DGVEmployees.Columns[7].HeaderText = "Date hire";

                this.DGVEmployees.Columns[8].Name = "CreatedAt";
                this.DGVEmployees.Columns[8].HeaderText = "Created At";

                this.DGVEmployees.Columns[9].Name = "UpdatedAt";
                this.DGVEmployees.Columns[9].HeaderText = "Updated At";

                DataGridViewImageColumn btnViewDetailsImg = new DataGridViewImageColumn();
                btnViewDetailsImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnViewDetailsImg.Image = Image.FromFile("./Resouces/view-details-24.png");
                this.DGVEmployees.Columns.Add(btnViewDetailsImg);


                foreach (var employee in Employees)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGVEmployees);

                    row.Cells[0].Value = employee.EmployeeNumber;
                    row.Cells[1].Value = $"{employee.FirstName} {employee.LastName}";
                    row.Cells[2].Value = employee.Address;
                    row.Cells[3].Value = employee.BirthDate.ToShortDateString();
                    row.Cells[4].Value = employee.MobileNumber;
                    row.Cells[5].Value = employee.EmailAddress;
                    row.Cells[6].Value = employee.BranchAssign;
                    row.Cells[7].Value = employee.DateHire.ToShortDateString();
                    row.Cells[8].Value = employee.CreatedAt.ToShortDateString();
                    row.Cells[9].Value = employee.UpdatedAt.ToShortDateString();
                    DGVEmployees.Rows.Add(row);
                }
            }
            
        }

        private void DisplayEmployeeListUserControl_Load(object sender, EventArgs e)
        {
            SetDGVEmployeesFontAndColors();
            DisplayEmployeeList();
        }

        private void DGVEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10 && e.RowIndex > -1)
            {
                if (DGVEmployees.CurrentRow != null)
                {
                    string employeeNumber = DGVEmployees.CurrentRow.Cells[0].Value.ToString();
                    SelectedEmployeeNumber = employeeNumber;
                }
            }
        }

        private void DGVEmployees_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10 && e.RowIndex > -1)
            {
                DGVEmployees.Cursor = Cursors.Hand;
            }
            else
            {
                DGVEmployees.Cursor = Cursors.Default;
            }
        }

        private void SetDGVEmployeesFontAndColors()
        {
            this.DGVEmployees.BackgroundColor = Color.White;
            this.DGVEmployees.DefaultCellStyle.Font = new Font("Century Gothic", 12);
            //this.DGVEmployees.DefaultCellStyle.ForeColor = Color.White;
            //this.DGVEmployees.DefaultCellStyle.BackColor = Color.FromArgb(99, 99, 138);
            //this.DGVEmployees.DefaultCellStyle.SelectionForeColor = Color.FromArgb(42, 42, 64);
            //this.DGVEmployees.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;

            this.DGVEmployees.RowHeadersVisible = false;
            this.DGVEmployees.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVEmployees.AllowUserToResizeRows = false;
            this.DGVEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVEmployees.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            //this.DGVEmployees.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            //this.DGVEmployees.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            //this.DGVEmployees.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(42, 42, 64);
            //this.DGVEmployees.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;


            this.DGVEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVEmployees.MultiSelect = false;

            this.DGVEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVEmployees.ColumnHeadersHeight = 30;
        }

    }
}
