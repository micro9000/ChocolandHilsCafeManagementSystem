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
        private readonly ILeaveTypeController _leaveTypeController;

        public FrmMainEmployeeManagement(ILogger<FrmMainEmployeeManagement> logger,
                                IEmployeeController employeeController,
                                ILeaveTypeController leaveTypeController)
        {
            InitializeComponent();
            _logger = logger;
            _employeeController = employeeController;
            _leaveTypeController = leaveTypeController;
        }

        private void EmployeeMenuItemsMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;

            if (clickedItem != null && clickedItem.Name == "ToolStripItem_Add")
            {
                DisplayAddUpdateEmployeeUserControl();
            }
            else if (clickedItem != null && clickedItem.Name == "ToolStripItem_List")
            {
                DisplayEmployeeListUserControl();
            }
        }

        private void PayrollMenuItems_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;

            if (clickedItem != null && clickedItem.Name == "LeaveTypesStripMenuItem")
            {
                DisplayLeaveTypesUserControl();
            }
        }

        // --------------------------------------------------------------------------------------
        #region Add/Update employee confirmation user control related methods event handlers

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

        private void HandleBackToForm(object sender, EventArgs e)
        {
            DisplayAddUpdateEmployeeUserControl();
        }

        #endregion Add/Update employee confirmation user control related methods event handlers


        // --------------------------------------------------------------------------------------
        #region Add/Update employee user control related methods and event handlers

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
            addUpdateEmployeeObj.DisplayEmployeeDetails(employeeDetails.Data);
        }
        #endregion Add/Update employee user control related methods and event handlers


        // --------------------------------------------------------------------------------------
        #region Employee list user control related methods and event handlers

        private void DisplayEmployeeListUserControl()
        {
            this.panelContainer.Controls.Clear();

            var userControlToDisplay = new DisplayEmployeeListUserControl();
            userControlToDisplay.Dock = DockStyle.Fill;
            //userControlToDisplay.Location = new Point(this.ClientSize.Width / 2 - userControlToDisplay.Size.Width / 2, this.ClientSize.Height / 2 - userControlToDisplay.Size.Height / 2);
            //userControlToDisplay.Anchor = AnchorStyles.None;

            userControlToDisplay.Employees = this._employeeController.GetAll().Data;
            userControlToDisplay.DisplayEmployeeList();

            userControlToDisplay.PropertyChanged += OnEmployeeViewDetails; // when view details button click
            userControlToDisplay.SearchStringEnter += this.OnSearchStringEnter; // when Search button click
            userControlToDisplay.ReloadEmployeeList += this.OnReloadEmployeeList; // when button reload click

            this.panelContainer.Controls.Add(userControlToDisplay);
        }

        // when view details button click
        private void OnEmployeeViewDetails (object sender, PropertyChangedEventArgs e)
        {
            DisplayEmployeeListUserControl employeeListUserControlObj = (DisplayEmployeeListUserControl)sender;
            var selectedEmployeeNumber = employeeListUserControlObj.SelectedEmployeeNumber;
            MessageBox.Show(selectedEmployeeNumber);

            this.panelContainer.Controls.Clear();

            var employeeDetailsUserControl = new EmployeeDetailsUserControl();
            employeeDetailsUserControl.Dock = DockStyle.Fill;

            this.panelContainer.Controls.Add(employeeDetailsUserControl);

            // TODO: Use this method to display all information related to the employee
        }

        // when search string key up == enter
        private void OnSearchStringEnter(object sender, EventArgs e)
        {
            DisplayEmployeeListUserControl employeeListUserControlObj = (DisplayEmployeeListUserControl)sender;
            var searchParams = employeeListUserControlObj.SearchEmployeeParameters;
            employeeListUserControlObj.Employees = this._employeeController.Search(searchParams.SearchString).Data;
            employeeListUserControlObj.DisplayEmployeeList();
        }

        // when button reload click
        private void OnReloadEmployeeList(object sender, EventArgs e)
        {
            DisplayEmployeeListUserControl employeeListUserControlObj = (DisplayEmployeeListUserControl)sender;
            employeeListUserControlObj.Employees = this._employeeController.GetAll().Data;
            employeeListUserControlObj.DisplayEmployeeList();
        }

        #endregion


        // --------------------------------------------------------------------------------------
        #region Leave types user control related methods and event handlers

        private void DisplayLeaveTypesUserControl()
        {
            this.panelContainer.Controls.Clear();

            var userControlToDisplay = new LeaveTypesCRUDUserControl();
            userControlToDisplay.Dock = DockStyle.Fill;
            //userControlToDisplay.Location = new Point(this.ClientSize.Width / 2 - userControlToDisplay.Size.Width / 2, this.ClientSize.Height / 2 - userControlToDisplay.Size.Height / 2);
            //userControlToDisplay.Anchor = AnchorStyles.None;

            userControlToDisplay.LeaveTypes = _leaveTypeController.GetAll().Data;
            userControlToDisplay.LeaveTypeSaved += HandleLeaveTypeSaved;

            userControlToDisplay.PropertySelectedLeaveTypeIdToUpdateChanged += OnLeaveTypeSelectToUpdate;
            userControlToDisplay.PropertySelectedLeaveTypeIdToDeleteChanged += OnLeaveTypeSelectToDelete;

            //userControlToDisplay.Employees = this._employeeController.GetAll().Data;
            //userControlToDisplay.DisplayEmployeeList();

            //userControlToDisplay.PropertyChanged += OnEmployeeViewDetails;

            this.panelContainer.Controls.Add(userControlToDisplay);
        }


        private void HandleLeaveTypeSaved(object sender, EventArgs e)
        {
            LeaveTypesCRUDUserControl userControlObj = (LeaveTypesCRUDUserControl)sender;

            var saveResults = _leaveTypeController.Save(userControlObj.LeaveTypeToAddUpdate, userControlObj.IsSaveNew);
            string resultMessages = "";
            foreach (var msg in saveResults.Messages)
            {
                resultMessages += msg + "\n";
            }

            if (saveResults.IsSuccess)
            {
                MessageBox.Show(resultMessages, "Save employee details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                userControlObj.ResetForm();
                userControlObj.LeaveTypes = _leaveTypeController.GetAll().Data;
                userControlObj.DisplayLeaveTypeList();

                //string msg = addUpdateEmployeeObj.IsNew ? "Successfully save new employee details." : "Successfully update employee details.";

                //DisplayAddUpdateEmployeeConfirmationUserControl(saveResults.Data, msg);
            }
            else
            {
                MessageBox.Show(resultMessages, "Save employee details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OnLeaveTypeSelectToUpdate(object sender, PropertyChangedEventArgs e)
        {
            LeaveTypesCRUDUserControl userControlObj = (LeaveTypesCRUDUserControl)sender;
            var selectedLeaveTypeId = userControlObj.SelectedLeaveTypeToUpdateId;
            if (long.TryParse(selectedLeaveTypeId, out long leaveTypeId))
            {
                userControlObj.LeaveTypeToAddUpdate = _leaveTypeController.GetById(leaveTypeId).Data;
                userControlObj.DisplaySelectedLeaveType();
            }
        }

        private void OnLeaveTypeSelectToDelete(object sender, PropertyChangedEventArgs e)
        {
            LeaveTypesCRUDUserControl userControlObj = (LeaveTypesCRUDUserControl)sender;
            var selectedLeaveTypeId = userControlObj.SelectedLeaveTypeToDeleteId;
            if (long.TryParse(selectedLeaveTypeId, out long leaveTypeId))
            {
                DialogResult res = MessageBox.Show("Are you sure, you want to delete this?", "Delete confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                
                if (res == DialogResult.OK)
                {
                    var deleteResults = _leaveTypeController.Delete(leaveTypeId);
                    string resultMessages = "";
                    foreach (var msg in deleteResults.Messages)
                    {
                        resultMessages += msg + "\n";
                    }

                    if (deleteResults.IsSuccess)
                    {
                        MessageBox.Show(resultMessages, "Delete leave type", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        userControlObj.ResetForm();
                        userControlObj.LeaveTypes = _leaveTypeController.GetAll().Data;
                        userControlObj.DisplayLeaveTypeList();
                    }
                    else
                    {
                        MessageBox.Show(resultMessages, "Save leave type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                
            }
        }

        #endregion
    }
}
