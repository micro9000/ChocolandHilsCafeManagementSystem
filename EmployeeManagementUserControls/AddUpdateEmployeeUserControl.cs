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
    public partial class AddUpdateEmployeeUserControl : UserControl
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private EmployeeModel employee;

        public EmployeeModel Employee
        {
            get { return employee; }
            set { employee = value; }
        }


        private bool isNew;

        public bool IsNew
        {
            get { return isNew; }
            set { isNew = value; }
        }

        
        public event EventHandler EmployeeSaved;
        protected virtual void OnEmployeeSaved (EventArgs e)
        {
            EmployeeSaved?.Invoke(this, e);
        }

        private string employeeNumber;

        public string EmployeeNumber
        {
            get { return employeeNumber; }
            set {
                employeeNumber = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(EmployeeNumber));
                }
            }
        }



        public AddUpdateEmployeeUserControl()
        {
            InitializeComponent();
        }

        public void ClearForm()
        {
            this.TbxFirstName.Text = "";
            this.TbxLastName.Text = "";
            this.DTPicBirthDate.Value = DateTime.Now;
            this.TbxMobileNumber.Text = "";
            this.DTPicHireDate.Value = DateTime.Now;
            this.TbxAddress.Text = "";
            this.TbxBranchAssign.Text = "";
            this.TbxEmail.Text = "";

            this.RBtnNew.Checked = false;
            this.RBtnUpdate.Checked = false;
        }


        public void DisplayEmployeeDetails(EmployeeModel employeeDetails)
        {
            if (employeeDetails != null)
            {
                this.TbxFirstName.Text = employeeDetails.FirstName;
                this.TbxLastName.Text = employeeDetails.LastName;
                this.DTPicBirthDate.Value = employeeDetails.BirthDate;
                this.TbxMobileNumber.Text = employeeDetails.MobileNumber;
                this.DTPicHireDate.Value = employeeDetails.DateHire;
                this.TbxAddress.Text = employeeDetails.Address;
                this.TbxBranchAssign.Text = employeeDetails.BranchAssign;
                this.TbxEmail.Text = employeeDetails.EmailAddress;

                this.RBtnNew.Checked = false;
                this.RBtnUpdate.Checked = true;
            }
            else
            {
                MessageBox.Show("Employee details not found!", "Searching employee details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void BtnSaveEmployee_Click(object sender, EventArgs e)
        {
            if (this.RBtnUpdate.Checked == false && this.RBtnNew.Checked == false)
            {
                MessageBox.Show("Kindly choose action.", "Save employee", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Employee = new EmployeeModel
            {
                FirstName = this.TbxFirstName.Text,
                LastName = this.TbxLastName.Text,
                BirthDate = this.DTPicBirthDate.Value,
                MobileNumber = this.TbxMobileNumber.Text,
                DateHire = this.DTPicHireDate.Value,
                Address = this.TbxAddress.Text,
                BranchAssign = this.TbxBranchAssign.Text,
                EmailAddress = this.TbxEmail.Text
            };

            if (this.RBtnUpdate.Checked)
            {
                this.IsNew = false;
                Employee.EmployeeNumber = this.TbxEmployeeNumber.Text;
            }

            OnEmployeeSaved(EventArgs.Empty);
        }

        private void RBtnUpdate_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb != null && rb.Checked)
            {
                this.IsNew = false;
                TbxEmployeeNumber.Enabled = true;
            }
        }

        private void RBtnNew_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb != null && rb.Checked)
            {
                this.IsNew = true;
                TbxEmployeeNumber.Enabled = false;
            }
        }

        private void TbxEmployeeNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                this.EmployeeNumber = TbxEmployeeNumber.Text;
            }
        }
    }


}
