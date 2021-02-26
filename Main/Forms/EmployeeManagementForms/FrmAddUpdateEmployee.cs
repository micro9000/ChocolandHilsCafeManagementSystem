using EntitiesShared.EmployeeManagement;
using Main.Controllers.EmployeeManagementControllers.ControllerInterface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.EmployeeManagementForms
{
    public partial class FrmAddUpdateEmployee : Form
    {
        private readonly ILogger<FrmAddUpdateEmployee> _logger;
        private readonly IEmployeeController _employeeController;

        //private List<AddUpdateRecentActions> recentActions = new List<AddUpdateRecentActions>();

        public FrmAddUpdateEmployee(ILogger<FrmAddUpdateEmployee> logger,
                                
                                IEmployeeController employeeController)
        {
            InitializeComponent();
            _logger = logger;
            _employeeController = employeeController;
        }

        private void FrmAddUpdateEmployee_Load(object sender, EventArgs e)
        {
            this.PanelAddUpdateEmployee.Location = new Point( this.ClientSize.Width / 2 - this.PanelAddUpdateEmployee.Size.Width / 2, this.ClientSize.Height / 2 - this.PanelAddUpdateEmployee.Size.Height / 2);
            this.PanelAddUpdateEmployee.Anchor = AnchorStyles.None;
        }

        private void BtnSaveEmployee_Click(object sender, EventArgs e)
        {
            var employeeInput = new EmployeeModel
            {
                FirstName = this.TbxFirstName.Text.ToUpper(),
                LastName = this.TbxLastName.Text.ToUpper(),
                Address = this.TbxAddress.Text,
                BirthDate = this.DTPicBirthDate.Value,
                MobileNumber = this.TbxMobileNumber.Text,
                EmailAddress = this.TbxEmail.Text.ToLower(),
                BranchAssign = this.TbxBranchAssign.Text,
                DateHire = this.DTPicHireDate.Value
            };

            bool isNewEmployee = true;
            if (this.RBtnUpdate.Checked)
            {
                isNewEmployee = false;
                employeeInput.EmployeeNumber = this.TbxEmployeeNumber.Text;
            }

            var saveResults = _employeeController.Save(employeeInput, isNewEmployee);

            string resultMessages = "";
            foreach(var msg in saveResults.Messages)
            {
                resultMessages += msg + "\n";
            }

            if (saveResults.IsSuccess)
            {

                MessageBox.Show(resultMessages, "Save employee details", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.TbxEmployeeNumber.Text = "";
                this.TbxFirstName.Text = "";
                this.TbxLastName.Text = "";
                this.TbxAddress.Text = "";
                this.TbxMobileNumber.Text = "";
                this.TbxEmail.Text = "";
                this.TbxBranchAssign.Text = "";
                this.DTPicBirthDate.Value = DateTime.Now;
                this.DTPicHireDate.Value = DateTime.Now;

                this.RBtnNew.Checked = false;
                this.RBtnUpdate.Checked = false;
            }
            else
            {
                MessageBox.Show(resultMessages, "Save employee details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


        //private void DisplayRecentChanges()
        //{
        //    int row = 0;
        //    foreach(var log in this.recentActions)
        //    {
        //        row = DataGdVwRecentActions.Rows.Add();
        //        DataGdVwRecentActions.Rows[row].Cells[0].Value = log.Action;
        //        DataGdVwRecentActions.Rows[row].Cells[1].Value = log.EmployeeNumber;
        //        DataGdVwRecentActions.Rows[row].Cells[2].Value = log.EmployeeName;
        //        DataGdVwRecentActions.Rows[row].Cells[3].Value = log.DateAndTime.ToLongDateString();
        //    }
        //}

        private void RBtnNew_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb != null && rb.Checked)
            {
                TbxEmployeeNumber.Enabled = false;
            }
        }

        private void RBtnUpdate_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb != null && rb.Checked)
            {
                TbxEmployeeNumber.Enabled = true;
            }
        }

        private void TbxEmployeeNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;

                string employeeNumber = TbxEmployeeNumber.Text;

                if (employeeNumber != "")
                {
                    var employeeDetails = _employeeController.GetByEmployeeNumber(employeeNumber);

                    if (employeeDetails != null)
                    {
                        this.TbxFirstName.Text = employeeDetails.FirstName;
                        this.TbxLastName.Text = employeeDetails.LastName;
                        this.TbxAddress.Text = employeeDetails.Address;
                        this.TbxMobileNumber.Text = employeeDetails.MobileNumber;
                        this.TbxEmail.Text = employeeDetails.EmailAddress;
                        this.TbxBranchAssign.Text = employeeDetails.BranchAssign;
                        this.DTPicBirthDate.Value = employeeDetails.BirthDate;
                        this.DTPicHireDate.Value = employeeDetails.DateHire;
                    }
                    else
                    {
                        MessageBox.Show("Employee not found!", "Search employee", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    
                }
            }
        }
    }
}
