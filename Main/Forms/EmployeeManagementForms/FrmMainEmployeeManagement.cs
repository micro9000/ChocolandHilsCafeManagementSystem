using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess.Data.EmployeeManagement.Contracts;
using DataAccess.Data.OtherDataManagement.Contracts;
using EntitiesShared.EmployeeManagement;
using Main.Controllers.EmployeeManagementControllers.ControllerInterface;
using Main.Forms.EmployeeManagementForms.Controls;
using Microsoft.Extensions.Logging;

namespace Main.Forms.EmployeeManagementForms
{
    public partial class FrmMainEmployeeManagement : Form
    {
        private readonly ILogger<FrmMainEmployeeManagement> _logger;
        private readonly IGovernmentAgencyData _governmentAgencyData;
        private readonly IEmployeeController _employeeController;

        public FrmMainEmployeeManagement(ILogger<FrmMainEmployeeManagement> logger,
                                IGovernmentAgencyData governmentAgencyData,
                                IEmployeeController employeeController)
        {
            InitializeComponent();
            _logger = logger;
            _governmentAgencyData = governmentAgencyData;
            _employeeController = employeeController;
        }

        private void EmployeeMenuItemsMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;

            if (clickedItem != null && clickedItem.Name == "ToolStripItem_Add")
            {
                // Add/update form
                DisplayAddUpdateEmployeeUserControl();
            }
            else if (clickedItem != null && clickedItem.Name == "ToolStripItem_List")
            {
                // Employees list
                DisplayEmployeeListUserControl();
            }
            else if (clickedItem != null && clickedItem.Name == "ToolStripItem_Details")
            {
                // Employee Details
                DisplayEmployeeDetailsUserControl();
            }
        }

        private void PayrollMenuItems_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;

            if (clickedItem != null && clickedItem.Name == "")
            {
            }
        }

        #region Add/Update employee confirmation user control related methods event handlers

        //public void DisplayAddUpdateEmployeeConfirmationUserControl(EmployeeModel employeeDetails, string msg)
        //{
        //    this.panelContainer.Controls.Clear();
        //    var userControlToDisplay = new AddUpdateEmployeeConfirmationUserControl();
        //    //userControlToDisplay.Location = new Point(this.ClientSize.Width / 2 - userControlToDisplay.Size.Width / 2, this.ClientSize.Height / 2 - userControlToDisplay.Size.Height / 2);
        //    //userControlToDisplay.Anchor = AnchorStyles.None;

        //    userControlToDisplay.BtnBackToFormClick += HandleBackToForm;

        //    userControlToDisplay.DisplayEmployeeDetails(employeeDetails, msg);

        //    this.panelContainer.Controls.Add(userControlToDisplay);
        //}

        private void HandleBackToForm(object sender, EventArgs e)
        {
            DisplayAddUpdateEmployeeUserControl();
        }

        #endregion


        #region Add/Update employee user control related methods and event handlers

        private void DisplayAddUpdateEmployeeUserControl()
        {
            this.panelContainer.Controls.Clear();

            var controlToDisplay = new EmployeeDetailsCRUDControl();
            //addUpdateEmployeeUserControl.Dock = DockStyle.Fill;
            controlToDisplay.Location = new Point(this.ClientSize.Width / 2 - controlToDisplay.Size.Width / 2, this.ClientSize.Height / 2 - controlToDisplay.Size.Height / 2);
            controlToDisplay.Anchor = AnchorStyles.None;

            controlToDisplay.GovtAgencies = _governmentAgencyData.GetAllNotDeleted();
            // TODO: add the existing emp. govt. ids from our database and use the CustomModels -> EmployeeGovtIdCardTempModel.cs

            // event added
            controlToDisplay.EmployeeSaved += this.HandleEmployeeSaved;
            controlToDisplay.PropertyChanged += this.OnEmployeeNumberEnter;

            this.panelContainer.Controls.Add(controlToDisplay);
        }

        private void HandleEmployeeSaved(object sender, EventArgs e)
        {
            EmployeeDetailsCRUDControl employeeCRUDControlObj = (EmployeeDetailsCRUDControl)sender;

            var saveResults = _employeeController.SaveEmployeeDetails(employeeCRUDControlObj.IsNew,
                                                                      employeeCRUDControlObj.Employee,
                                                                       employeeCRUDControlObj.EmployeeGovtIdCards,
                                                                       employeeCRUDControlObj.EmployeeSalary);

            string resultMessages = "";
            foreach (var msg in saveResults.Messages)
            {
                resultMessages += msg + "\n";
            }

            if (saveResults.IsSuccess)
            {
                MessageBox.Show(resultMessages, "Save employee details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                employeeCRUDControlObj.ClearForm();

                //string msg = addUpdateEmployeeObj.IsNew ? "Successfully save new employee details." : "Successfully update employee details.";

                //DisplayAddUpdateEmployeeConfirmationUserControl(saveResults.Data, msg);
            }
            else
            {
                MessageBox.Show(resultMessages, "Save employee details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OnEmployeeNumberEnter(object sender, PropertyChangedEventArgs e)
        {
            EmployeeDetailsCRUDControl employeeCRUDControlObj = (EmployeeDetailsCRUDControl)sender;
            var employeeDetails = this._employeeController.GetByEmployeeNumber(employeeCRUDControlObj.EmployeeNumber);

            if (employeeDetails != null && employeeDetails.IsSuccess && employeeDetails.Data != null)
            {
                employeeCRUDControlObj.EmployeeGovtIdCards = _employeeController.GetAllEmployeeIdCardsMapToCustomModel(employeeDetails.Data.EmployeeNumber);
                employeeCRUDControlObj.EmployeeSalary = _employeeController.GetEmployeeSalaryRateByEmployeeNumber(employeeDetails.Data.EmployeeNumber).Data;
                employeeCRUDControlObj.DisplayEmployeeDetails(employeeDetails.Data);
                employeeCRUDControlObj.MoveToNextTabSaveEmployeeDetails();
            }
            else
            {
                string resultMessages = "";
                foreach (var msg in employeeDetails.Messages)
                {
                    resultMessages += msg + "\n";
                }
                MessageBox.Show(resultMessages, "Search employee details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        #endregion


        #region Employee list user control related methods and event handlers

        private void DisplayEmployeeListUserControl()
        {
            this.panelContainer.Controls.Clear();

            var employeeListControlObj = new EmployeeListControl();
            employeeListControlObj.Dock = DockStyle.Fill;
            //userControlToDisplay.Location = new Point(this.ClientSize.Width / 2 - userControlToDisplay.Size.Width / 2, this.ClientSize.Height / 2 - userControlToDisplay.Size.Height / 2);
            //userControlToDisplay.Anchor = AnchorStyles.None;

            employeeListControlObj.Employees = this._employeeController.GetAll().Data;
            employeeListControlObj.DisplayEmployeeList();

            employeeListControlObj.PropertyChanged += OnEmployeeViewDetails; // when view details button click
            employeeListControlObj.SearchStringEnter += this.OnSearchStringEnter; // when Search button click
            employeeListControlObj.ReloadEmployeeList += this.OnReloadEmployeeList; // when button reload click

            this.panelContainer.Controls.Add(employeeListControlObj);
        }

        // when view details button click
        private void OnEmployeeViewDetails (object sender, PropertyChangedEventArgs e)
        {
            EmployeeListControl employeeListControlObj = (EmployeeListControl)sender;
            var selectedEmployeeNumber = employeeListControlObj.SelectedEmployeeNumber;
            MessageBox.Show(selectedEmployeeNumber);

            this.panelContainer.Controls.Clear();

            var employeeDetailsControl = new EmployeeDetailsControl();
            employeeDetailsControl.Dock = DockStyle.Fill;

            this.panelContainer.Controls.Add(employeeDetailsControl);

            // TODO: Use this method to display all information related to the employee
        }

        // when search string key up == enter
        private void OnSearchStringEnter(object sender, EventArgs e)
        {
            EmployeeListControl employeeListControlObj = (EmployeeListControl)sender;
            var searchParams = employeeListControlObj.SearchEmployeeParameters;
            employeeListControlObj.Employees = this._employeeController.Search(searchParams.SearchString).Data;
            employeeListControlObj.DisplayEmployeeList();
        }

        // when button reload click
        private void OnReloadEmployeeList(object sender, EventArgs e)
        {
            EmployeeListControl employeeListControlObj = (EmployeeListControl)sender;
            employeeListControlObj.Employees = this._employeeController.GetAll().Data;
            employeeListControlObj.DisplayEmployeeList();
        }

        #endregion



        #region Employee Details user control related methods and event handlers
        private void DisplayEmployeeDetailsUserControl()
        {
            this.panelContainer.Controls.Clear();

            var employeeDetailsControlObj = new EmployeeDetailsControl();
            employeeDetailsControlObj.Dock = DockStyle.Fill;
            //userControlToDisplay.Location = new Point(this.ClientSize.Width / 2 - userControlToDisplay.Size.Width / 2, this.ClientSize.Height / 2 - userControlToDisplay.Size.Height / 2);
            //userControlToDisplay.Anchor = AnchorStyles.None;


            employeeDetailsControlObj.EmployeeNumberPropertyChanged += OnViewEmployeeDetails;
            //userControlToDisplay.PropertySelectedLeaveTypeIdToDeleteChanged += OnLeaveTypeSelectToDelete;

            //userControlToDisplay.Employees = this._employeeController.GetAll().Data;
            //userControlToDisplay.DisplayEmployeeList();

            //userControlToDisplay.PropertyChanged += OnEmployeeViewDetails;

            this.panelContainer.Controls.Add(employeeDetailsControlObj);
        }

        private void OnViewEmployeeDetails(object sender, PropertyChangedEventArgs e)
        {
            EmployeeDetailsControl employeeDetailsControlObj = (EmployeeDetailsControl)sender;
            var EmployeeNumber = employeeDetailsControlObj.EmployeeNumber;

            employeeDetailsControlObj.EmployeeFullInformations = this._employeeController.GetEmployeeFullInformations(EmployeeNumber).Data;
            employeeDetailsControlObj.DisplayAllEmployeeInformations();

        }


        #endregion
    }
}
