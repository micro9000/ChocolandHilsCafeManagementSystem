using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeManagementUserControls;
using EntitiesShared.EmployeeManagement;
using Main.Controllers.EmployeeManagementControllers.ControllerInterface;
using Microsoft.Extensions.Logging;

namespace Main.Forms.EmployeeManagementForms
{
    public partial class FrmMainEmployeeManagement : Form
    {
        private readonly ILogger<FrmMainEmployeeManagement> _logger;
        private readonly IEmployeeController _employeeController;

        public FrmMainEmployeeManagement(ILogger<FrmMainEmployeeManagement> logger,
                                IEmployeeController employeeController)
        {
            InitializeComponent();
            _logger = logger;
            _employeeController = employeeController;
            //_frmAddUpdateEmployee = frmAddUpdateEmployee;
        }

        private void DisplayAddUpdateEmployeeUserControl()
        {
            this.panelContainer.Controls.Clear();

            var userControlToDisplay = new AddUpdateEmployeeUserControl();
            //addUpdateEmployeeUserControl.Dock = DockStyle.Fill;
            userControlToDisplay.Location = new Point(this.ClientSize.Width / 2 - userControlToDisplay.Size.Width / 2, this.ClientSize.Height / 2 - userControlToDisplay.Size.Height / 2);
            userControlToDisplay.Anchor = AnchorStyles.None;

            // event added
            userControlToDisplay.EmployeeSaved += this.HandleEmployeeSaved;
            userControlToDisplay.PropertyChanged += this.OnEmployeeNumberEnter;

            this.panelContainer.Controls.Add(userControlToDisplay);
        }

        public void DisplayAddUpdateEmployeeConfirmationUserControl(EmployeeModel employeeDetails, string msg)
        {
            this.panelContainer.Controls.Clear();
            var userControlToDisplay = new AddUpdateEmployeeConfirmationUserControl();
            userControlToDisplay.Location = new Point(this.ClientSize.Width / 2 - userControlToDisplay.Size.Width / 2, this.ClientSize.Height / 2 - userControlToDisplay.Size.Height / 2);
            userControlToDisplay.Anchor = AnchorStyles.None;

            userControlToDisplay.BtnBackToFormClick += HandleBackToForm;

            userControlToDisplay.DisplayEmployeeDetails(employeeDetails, msg);

            this.panelContainer.Controls.Add(userControlToDisplay);
        }


        private void DisplayEmployeeListUserControl()
        {
            this.panelContainer.Controls.Clear();

            var userControlToDisplay = new DisplayEmployeeListUserControl();
            userControlToDisplay.Dock = DockStyle.Fill;
            //userControlToDisplay.Location = new Point(this.ClientSize.Width / 2 - userControlToDisplay.Size.Width / 2, this.ClientSize.Height / 2 - userControlToDisplay.Size.Height / 2);
            //userControlToDisplay.Anchor = AnchorStyles.None;

            this.panelContainer.Controls.Add(userControlToDisplay);
        }

        private void EmployeeMenuItemsMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;

            if (clickedItem != null && clickedItem.Name == "ToolStripItem_Add")
            {

                //this.OpenChildForm(_frmAddUpdateEmployee, sender);

                DisplayAddUpdateEmployeeUserControl();
            }
            else if (clickedItem != null && clickedItem.Name == "ToolStripItem_List")
            {
                DisplayEmployeeListUserControl();
            }
        }

        private void HandleBackToForm (object sender, EventArgs e)
        {
            DisplayAddUpdateEmployeeUserControl();
        }

        private void HandleEmployeeSaved(object sender, EventArgs e)
        {
            AddUpdateEmployeeUserControl addUpdateEmployeeObj = (AddUpdateEmployeeUserControl)sender;

            var saveResults = _employeeController.Save(addUpdateEmployeeObj.Employee, addUpdateEmployeeObj.IsNew);
            string resultMessages = "";
            foreach (var msg in saveResults.Messages)
            {
                resultMessages += msg + "\n";
            }

            if (saveResults.IsSuccess)
            {
                MessageBox.Show(resultMessages, "Save employee details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                addUpdateEmployeeObj.ClearForm();

                string msg = addUpdateEmployeeObj.IsNew ? "Successfully save new employee details." : "Successfully update employee details.";

                DisplayAddUpdateEmployeeConfirmationUserControl(saveResults.Data, msg);
            }
            else
            {
                MessageBox.Show(resultMessages, "Save employee details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void OnEmployeeNumberEnter(object sender, PropertyChangedEventArgs e)
        {
            AddUpdateEmployeeUserControl addUpdateEmployeeObj = (AddUpdateEmployeeUserControl)sender;
            var employeeDetails = this._employeeController.GetByEmployeeNumber(addUpdateEmployeeObj.EmployeeNumber);
            addUpdateEmployeeObj.DisplayEmployeeDetails(employeeDetails);
        }
    }
}
