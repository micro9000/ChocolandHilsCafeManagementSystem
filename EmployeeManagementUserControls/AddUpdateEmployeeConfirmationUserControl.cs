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
    public partial class AddUpdateEmployeeConfirmationUserControl : UserControl
    {
        public AddUpdateEmployeeConfirmationUserControl()
        {
            InitializeComponent();
        }


        public event EventHandler BtnBackToFormClick;
        protected virtual void OnClickBtnBackToForm(EventArgs e)
        {
            BtnBackToFormClick?.Invoke(this, e);
        }

        public void DisplayEmployeeDetails(EmployeeModel employeeModel, string message)
        {
            this.LblMessage.Text = message;
            this.LblEmployeeNumber.Text = employeeModel.EmployeeNumber;
            this.LblFirstName.Text = employeeModel.FirstName;
            this.LblLastName.Text = employeeModel.LastName;
            this.LblAddress.Text = employeeModel.Address;
            this.LblDateOfBirth.Text = employeeModel.BirthDate.ToShortDateString();
            this.LblMobileNumber.Text = employeeModel.MobileNumber;
            this.LblEmail.Text = employeeModel.EmailAddress;
            this.LblBranchAssign.Text = employeeModel.BranchAssign;
            this.LblHireDate.Text = employeeModel.DateHire.ToShortDateString();
        }

        private void BtnBackToForm_Click(object sender, EventArgs e)
        {
            OnClickBtnBackToForm(EventArgs.Empty);
        }
    }
}
