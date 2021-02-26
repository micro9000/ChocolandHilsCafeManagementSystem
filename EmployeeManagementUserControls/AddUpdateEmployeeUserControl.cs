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
        private EmployeeModel employee;

        public event EventHandler EmployeeSaved;

        protected virtual void OnEmployeeSaved (EventArgs e)
        {
            EmployeeSaved?.Invoke(this, e);
        }

        public EmployeeModel Employee
        {
            get { return employee; }
            set { employee = value; }
        }


        public AddUpdateEmployeeUserControl()
        {
            InitializeComponent();
        }

        private void BtnSaveEmployee_Click(object sender, EventArgs e)
        {
            Employee = new EmployeeModel
            {
                EmployeeNumber = this.TbxEmployeeNumber.Text,
                FirstName = this.TbxFirstName.Text,
                LastName = this.TbxLastName.Text,
                BirthDate = this.DTPicBirthDate.Value,
                MobileNumber = this.TbxMobileNumber.Text,
                DateHire = this.DTPicHireDate.Value,
                Address = this.TbxAddress.Text,
                BranchAssign = this.TbxBranchAssign.Text,
                EmailAddress = this.TbxEmail.Text
            };

            OnEmployeeSaved(EventArgs.Empty);
        }
    }
}
