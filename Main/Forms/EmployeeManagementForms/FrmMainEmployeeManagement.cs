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
using Main.Controllers.OtherDataController.ControllerInterface;
using Main.Forms.EmployeeManagementForms.Controls;
using Microsoft.Extensions.Logging;
using Shared.Helpers;

namespace Main.Forms.EmployeeManagementForms
{
    public partial class FrmMainEmployeeManagement : Form
    {
        private readonly ILogger<FrmMainEmployeeManagement> _logger;
        private readonly DecimalMinutesToHrsConverter _decimalMinutesToHrsConverter;
        private readonly IGovernmentAgencyData _governmentAgencyData;
        private readonly IEmployeeLeaveData _employeeLeaveData;
        private readonly IEmployeeShiftDayData _employeeShiftDayData;
        private readonly IEmployeeController _employeeController;
        private readonly IWorkShiftController _workShiftController;
        private readonly ILeaveTypeController _leaveTypeController;
        private readonly IEmployeeLeaveController _employeeLeaveController;
        private readonly IHolidayController _holidayController;
        private readonly IHolidayData _holidayData;
        private readonly IEmployeeAttendanceData _employeeAttendanceData;

        public FrmMainEmployeeManagement(ILogger<FrmMainEmployeeManagement> logger,
                                    DecimalMinutesToHrsConverter decimalMinutesToHrsConverter,
                                IGovernmentAgencyData governmentAgencyData,
                                IEmployeeLeaveData employeeLeaveData,
                                IEmployeeShiftDayData employeeShiftDayData,
                                IEmployeeController employeeController,
                                IWorkShiftController workShiftController,
                                ILeaveTypeController leaveTypeController,
                                IEmployeeLeaveController employeeLeaveController,
                                IHolidayController holidayController,
                                IHolidayData holidayData,
                                IEmployeeAttendanceData employeeAttendanceData)
        {
            InitializeComponent();
            _logger = logger;
            _decimalMinutesToHrsConverter = decimalMinutesToHrsConverter;
            _governmentAgencyData = governmentAgencyData;
            _employeeLeaveData = employeeLeaveData;
            _employeeShiftDayData = employeeShiftDayData;
            _employeeController = employeeController;
            _workShiftController = workShiftController;
            _leaveTypeController = leaveTypeController;
            _employeeLeaveController = employeeLeaveController;
            _holidayController = holidayController;
            _holidayData = holidayData;
            _employeeAttendanceData = employeeAttendanceData;
        }

        private void EmployeeMenuItemsMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;

            if (clickedItem != null && clickedItem.Name == "ToolStripItem_DetailsCRUD")
            {
                // Add/update form
                DisplayAddUpdateEmployeeUserControl();
            }
            else if (clickedItem != null && clickedItem.Name == "ToolStripItem_List")
            {
                DisplayEmployeeListUserControl();
            }
            else if (clickedItem != null && clickedItem.Name == "ToolStripItem_FileLeave")
            {
                // Employee Leave management
                DisplayEmployeeLeaveManagementControl();
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


        private void HandleBackToForm(object sender, EventArgs e)
        {
            DisplayAddUpdateEmployeeUserControl();
        }

        #endregion


        #region Add/Update employee user control related methods and event handlers

        private void DisplayAddUpdateEmployeeUserControl()
        {
            this.panelContainer.Controls.Clear();

            var controlToDisplay = new EmployeeDetailsCRUDControl(_decimalMinutesToHrsConverter);
            //addUpdateEmployeeUserControl.Dock = DockStyle.Fill;
            controlToDisplay.Location = new Point(this.ClientSize.Width / 2 - controlToDisplay.Size.Width / 2, this.ClientSize.Height / 2 - controlToDisplay.Size.Height / 2);
            controlToDisplay.Anchor = AnchorStyles.None;

            controlToDisplay.GovtAgencies = _governmentAgencyData.GetAllNotDeleted();
            controlToDisplay.WorkShifts = _workShiftController.GetAll().Data;
            // TODO: add the existing emp. govt. ids from our database and use the CustomModels -> EmployeeGovtIdCardTempModel.cs

            // event added
            controlToDisplay.EmployeeSaved += this.HandleEmployeeSaved;
            controlToDisplay.PropertyChanged += this.OnEmployeeNumberEnter;
            controlToDisplay.WorkShiftSelected += HandleSelectedWorkShiftToGetOtherInfo;
            controlToDisplay.FilterEmployeeAttendance += HandleFilterEmployeeAttendance;

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
                string imageFileName = employeeCRUDControlObj.UploadEmployeeImage(saveResults.Data.Employee.EmployeeNumber);

                _employeeController.SaveEmployeeImageFileName(saveResults.Data.Employee.EmployeeNumber, imageFileName);

                employeeCRUDControlObj.ClearForm();

                //string msg = addUpdateEmployeeObj.IsNew ? "Successfully save new employee details." : "Successfully update employee details.";

                //DisplayAddUpdateEmployeeConfirmationUserControl(saveResults.Data, msg);
            }
            else
            {
                MessageBox.Show(resultMessages, "Save employee details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void HandleSelectedWorkShiftToGetOtherInfo(object sender, EventArgs e)
        {
            EmployeeDetailsCRUDControl employeeCRUDControlObj = (EmployeeDetailsCRUDControl)sender;
            long selectedWorkShiftId = employeeCRUDControlObj.SelectedShiftId;

            if (selectedWorkShiftId > 0)
            {
                var shiftDays = _employeeShiftDayData.GetByShiftId(selectedWorkShiftId);
                employeeCRUDControlObj.WorkShiftDays = shiftDays;
                employeeCRUDControlObj.DisplayWorkShiftDays();
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


                int year = DateTime.Now.Year;
                DateTime Jan1 = new DateTime(year, 1, 1);
                DateTime today = DateTime.Now;

                employeeCRUDControlObj.AttendanceHistory = _employeeAttendanceData.GetAllAttendanceRecordByWorkDateRange(employeeDetails.Data.EmployeeNumber, Jan1, today);
                employeeCRUDControlObj.DisplayAttendanceRecord();

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

        private void HandleFilterEmployeeAttendance(object sender, EventArgs e)
        {
            EmployeeDetailsCRUDControl employeeDetailsCRUDControlObj = (EmployeeDetailsCRUDControl)sender;
            var EmployeeNumber = employeeDetailsCRUDControlObj.EmployeeNumber;
            DateTime startDate = employeeDetailsCRUDControlObj.FilterAttendanceStartDate;
            DateTime endDate = employeeDetailsCRUDControlObj.FilterAttendanceEndDate;

            employeeDetailsCRUDControlObj.AttendanceHistory = _employeeAttendanceData.GetAllAttendanceRecordByWorkDateRange(EmployeeNumber, startDate, endDate);
            employeeDetailsCRUDControlObj.DisplayAttendanceRecord();
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
            
            this.panelContainer.Controls.Clear();

            var employeeDetailsCRUDControl = new EmployeeDetailsCRUDControl(_decimalMinutesToHrsConverter);

            employeeDetailsCRUDControl.GovtAgencies = _governmentAgencyData.GetAllNotDeleted();
            employeeDetailsCRUDControl.WorkShifts = _workShiftController.GetAll().Data;

            // event added
            employeeDetailsCRUDControl.EmployeeSaved += this.HandleEmployeeSaved;
            employeeDetailsCRUDControl.PropertyChanged += this.OnEmployeeNumberEnter;
            employeeDetailsCRUDControl.WorkShiftSelected += HandleSelectedWorkShiftToGetOtherInfo;
            employeeDetailsCRUDControl.FilterEmployeeAttendance += HandleFilterEmployeeAttendance;

            employeeDetailsCRUDControl.Location = new Point(this.ClientSize.Width / 2 - employeeDetailsCRUDControl.Size.Width / 2, this.ClientSize.Height / 2 - employeeDetailsCRUDControl.Size.Height / 2);
            employeeDetailsCRUDControl.Anchor = AnchorStyles.None;
            employeeDetailsCRUDControl.UpdateEmployeeDetails();

            employeeDetailsCRUDControl.TbxEmployeeNumber.Text = selectedEmployeeNumber;
            employeeDetailsCRUDControl.EmployeeNumber = selectedEmployeeNumber;

            this.panelContainer.Controls.Add(employeeDetailsCRUDControl);

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


        private void WorkSchedulesMenItems_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;

            if (clickedItem != null && clickedItem.Name == "WorkShiftsMenItem")
            {
                // CRUD form
                DisplayWorkScheduleShiftsCRUDControl();
            }else if (clickedItem != null && clickedItem.Name == "EmpWorkShiftScheds")
            {
                DisplayEmployeeWorkShiftScheduleMgmntControl();
            }
            else if (clickedItem != null && clickedItem.Name == "HolidaysMenuItem")
            {
                DisplayHolidayCRUDControl();
            }
        }

        public void DisplayWorkScheduleShiftsCRUDControl()
        {
            this.panelContainer.Controls.Clear();

            var workShiftsCRUDControlObj = new WorkShiftCRUDControl();
            //addUpdateEmployeeUserControl.Dock = DockStyle.Fill;
            workShiftsCRUDControlObj.Location = new Point(this.ClientSize.Width / 2 - workShiftsCRUDControlObj.Size.Width / 2, this.ClientSize.Height / 2 - workShiftsCRUDControlObj.Size.Height / 2);
            workShiftsCRUDControlObj.Anchor = AnchorStyles.None;

            workShiftsCRUDControlObj.EmployeeShifts = _workShiftController.GetAll().Data;

            workShiftsCRUDControlObj.EmployeeShiftSaved += HandleWorkShiftSaved;
            workShiftsCRUDControlObj.PropSelectedEmpShiftIdToUpdateChanged += OnShiftSelectedToUpdate;
            workShiftsCRUDControlObj.PropSelectedEmpShiftIdToDeleteChanged += OnShiftSelectedToDelete;

            this.panelContainer.Controls.Add(workShiftsCRUDControlObj);
        }

        private void HandleWorkShiftSaved (object sender, EventArgs e)
        {
            WorkShiftCRUDControl workShiftsCRUDControlObj = (WorkShiftCRUDControl)sender;

            var saveWorkShift = workShiftsCRUDControlObj.EmployeeShiftToAddUpdate;
            var shiftDays = workShiftsCRUDControlObj.EmployeeShiftDaysToAddUpdate;
            bool isNew = workShiftsCRUDControlObj.IsSaveNew;

            if (saveWorkShift != null)
            {
                var saveResults = _workShiftController.Save(saveWorkShift, shiftDays, isNew);

                string resultMessages = "";
                foreach (var msg in saveResults.Messages)
                {
                    resultMessages += msg + "\n";
                }

                if (saveResults.IsSuccess)
                {
                    MessageBox.Show(resultMessages, "Save shift details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    workShiftsCRUDControlObj.ResetForm();

                    workShiftsCRUDControlObj.EmployeeShifts = _workShiftController.GetAll().Data;
                    workShiftsCRUDControlObj.DisplayWorkShiftList();

                    //string msg = addUpdateEmployeeObj.IsNew ? "Successfully save new employee details." : "Successfully update employee details.";

                    //DisplayAddUpdateEmployeeConfirmationUserControl(saveResults.Data, msg);
                }
                else
                {
                    MessageBox.Show(resultMessages, "Save shift details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void OnShiftSelectedToUpdate(object sender, PropertyChangedEventArgs e)
        {
            WorkShiftCRUDControl workShiftsCRUDControlObj = (WorkShiftCRUDControl)sender;
            var selectedShiftId = workShiftsCRUDControlObj.SelectedEmpShiftIdToUpdate;

            if (long.TryParse(selectedShiftId, out long shiftId))
            {
                var selectedShift = _workShiftController.GetById(shiftId).Data;
                if (selectedShift != null)
                {
                    workShiftsCRUDControlObj.EmployeeShiftToAddUpdate = selectedShift;
                    workShiftsCRUDControlObj.EmployeeShiftDaysToAddUpdate = _employeeShiftDayData.GetByShiftId(selectedShift.Id);
                    workShiftsCRUDControlObj.DisplaySelectedShift();
                }
                
            }

        }

        private void OnShiftSelectedToDelete(object sender, PropertyChangedEventArgs e)
        {
            WorkShiftCRUDControl workShiftsCRUDControlObj = (WorkShiftCRUDControl)sender;
            var selectedShiftId = workShiftsCRUDControlObj.SelectedEmpShiftIdToDelete;

            if (long.TryParse(selectedShiftId, out long shiftId))
            {
                DialogResult res = MessageBox.Show("Are you sure, you want to delete this?", "Delete confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res == DialogResult.OK)
                {
                    var deleteResults = _workShiftController.Delete(shiftId);

                    string resultMessages = "";
                    foreach (var msg in deleteResults.Messages)
                    {
                        resultMessages += msg + "\n";
                    }

                    if (deleteResults.IsSuccess)
                    {
                        MessageBox.Show(resultMessages, "Delete shift.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        workShiftsCRUDControlObj.ResetForm();
                        workShiftsCRUDControlObj.EmployeeShifts = _workShiftController.GetAll().Data;
                        workShiftsCRUDControlObj.DisplayWorkShiftList();
                    }
                    else
                    {
                        MessageBox.Show(resultMessages, "Delete shift", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        #region Employee Work shift scheduling control
        public void DisplayEmployeeWorkShiftScheduleMgmntControl()
        {
            this.panelContainer.Controls.Clear();

            var manageEmpWorkScheduleControlObj = new ManageEmpWorkScheduleControl();
            //addUpdateEmployeeUserControl.Dock = DockStyle.Fill;
            manageEmpWorkScheduleControlObj.Location = new Point(this.ClientSize.Width / 2 - manageEmpWorkScheduleControlObj.Size.Width / 2, this.ClientSize.Height / 2 - manageEmpWorkScheduleControlObj.Size.Height / 2);
            manageEmpWorkScheduleControlObj.Anchor = AnchorStyles.None;

            manageEmpWorkScheduleControlObj.Employees = _employeeController.GetAll().Data;
            manageEmpWorkScheduleControlObj.WorkShifts = _workShiftController.GetAll().Data;

            manageEmpWorkScheduleControlObj.ShiftSelected += HandleShiftSelectedToGetAdditionalDetails;
            manageEmpWorkScheduleControlObj.EmployeeShiftUpdated += HandleUpdateEmployeeShift;

            //manageEmpWorkScheduleControlObj.EmployeeShifts = _workShiftController.GetAll().Data;

            //manageEmpWorkScheduleControlObj.EmployeeShiftSaved += HandleWorkShiftSaved;
            //manageEmpWorkScheduleControlObj.PropSelectedEmpShiftIdToUpdateChanged += OnShiftSelectedToUpdate;
            //manageEmpWorkScheduleControlObj.PropSelectedEmpShiftIdToDeleteChanged += OnShiftSelectedToDelete;

            this.panelContainer.Controls.Add(manageEmpWorkScheduleControlObj);
        }

        private void HandleShiftSelectedToGetAdditionalDetails(object sender, EventArgs e)
        {
            ManageEmpWorkScheduleControl manageEmpWorkScheduleControlObj = (ManageEmpWorkScheduleControl)sender;
            var selectedShiftId = manageEmpWorkScheduleControlObj.SelectedShiftId;

            if (selectedShiftId > 0)
            {
                var shiftDays = _employeeShiftDayData.GetByShiftId(selectedShiftId);
                manageEmpWorkScheduleControlObj.WorkShiftDays = shiftDays;
                manageEmpWorkScheduleControlObj.DisplayWorkShiftDays();
            }
        }


        private void HandleUpdateEmployeeShift(object sender, EventArgs e)
        {
            ManageEmpWorkScheduleControl manageEmpWorkScheduleControlObj = (ManageEmpWorkScheduleControl)sender;
            var updateEmployeeShift = manageEmpWorkScheduleControlObj.UpdateEmployeeShift;

            if (updateEmployeeShift != null)
            {
                var updateResults = _employeeController.UpdateEmployeesShift(updateEmployeeShift);

                string resultMessages = "";
                foreach (var msg in updateResults.Messages)
                {
                    resultMessages += msg + "\n";
                }

                MessageBox.Show(resultMessages, "Update employee shift", MessageBoxButtons.OK, MessageBoxIcon.Information);

                manageEmpWorkScheduleControlObj.Employees = _employeeController.GetAll().Data;
                manageEmpWorkScheduleControlObj.WorkShifts = _workShiftController.GetAll().Data;

                manageEmpWorkScheduleControlObj.DisplayEmployees();
                manageEmpWorkScheduleControlObj.DisplayWorkShifts();
                manageEmpWorkScheduleControlObj.ResetUpdateEmployeeShiftVal();
            }
        }


        #endregion

        #region Employee leave management

        private void DisplayEmployeeLeaveManagementControl()
        {
            this.panelContainer.Controls.Clear();

            var employeeLeaveManagementControlObj = new EmployeeLeaveManagementControl();
            //employeeLeaveManagementControlObj.Dock = DockStyle.Fill;
            employeeLeaveManagementControlObj.Location = new Point(this.ClientSize.Width / 2 - employeeLeaveManagementControlObj.Size.Width / 2, this.ClientSize.Height / 2 - employeeLeaveManagementControlObj.Size.Height / 2);
            employeeLeaveManagementControlObj.Anchor = AnchorStyles.None;

            employeeLeaveManagementControlObj.EmployeeLeaveSaved += HandleSaveEmployeeLeave;
            employeeLeaveManagementControlObj.DeleteEmployeeLeave += HandleDeleteEmployeeLeave;
            employeeLeaveManagementControlObj.FilterEmployeeLeave += HandleFilterEmployeeLeaveHistory;

            employeeLeaveManagementControlObj.PropSelectedEmpShiftIdToUpdateChanged += OnSearchByEmployeeNumberLeaves;
            employeeLeaveManagementControlObj.EmployeeRemainingLeaveFetch += HandleSearchingEmployeeRemainingLeaveCounts;
            employeeLeaveManagementControlObj.LeaveTypes = _leaveTypeController.GetAll().Data;
            //userControlToDisplay.PropertySelectedLeaveTypeIdToDeleteChanged += OnLeaveTypeSelectToDelete;

            //userControlToDisplay.Employees = this._employeeController.GetAll().Data;
            //userControlToDisplay.DisplayEmployeeList();

            //userControlToDisplay.PropertyChanged += OnEmployeeViewDetails;

            this.panelContainer.Controls.Add(employeeLeaveManagementControlObj);
        }

        private void OnSearchByEmployeeNumberLeaves(object sender, PropertyChangedEventArgs e)
        {
            EmployeeLeaveManagementControl employeeLeaveManagementControlObj = (EmployeeLeaveManagementControl)sender;
            var employeeNumber = employeeLeaveManagementControlObj.EmployeeNumber;

            if (string.IsNullOrEmpty(employeeNumber) == false)
            {
                employeeLeaveManagementControlObj.Employee = _employeeController.GetByEmployeeNumber(employeeNumber).Data;
                employeeLeaveManagementControlObj.DisplaySearchEmployee();

                // search all leave by employee
                employeeLeaveManagementControlObj.EmployeeLeaveHistory = _employeeLeaveData.GetAllByEmployeeNumberAndYear(employeeNumber, DateTime.Now.Year);
                employeeLeaveManagementControlObj.DisplayEmployeeLeaveHistory();
            }
        }

        private void HandleSearchingEmployeeRemainingLeaveCounts(object sender, EventArgs e)
        {
            EmployeeLeaveManagementControl employeeLeaveManagementControlObj = (EmployeeLeaveManagementControl)sender;
            var selectedLeaveType = employeeLeaveManagementControlObj.SelectedLeaveType;
            var employeeNumber = employeeLeaveManagementControlObj.EmployeeNumber;

            if (selectedLeaveType != null && string.IsNullOrEmpty(employeeNumber) == false)
            {
                var empLeavesBySelectedLeave = _employeeLeaveData.GetAllByEmployeeNumberAndLeaveId(employeeNumber, selectedLeaveType.Id, DateTime.Now.Year);
                
                if (empLeavesBySelectedLeave != null && empLeavesBySelectedLeave.Count > 0)
                {
                    var lastEmpLeave = empLeavesBySelectedLeave.LastOrDefault();
                    decimal remainingLeave = lastEmpLeave.RemainingDays;
                    employeeLeaveManagementControlObj.DisplayEmpRemainingLeaveCount(remainingLeave);
                }
                else
                {
                    employeeLeaveManagementControlObj.DisplayEmpRemainingLeaveCount(selectedLeaveType.NumberOfDays);
                }
            }
        }

        private void HandleSaveEmployeeLeave(object sender, EventArgs e)
        {
            EmployeeLeaveManagementControl employeeLeaveManagementControlObj = (EmployeeLeaveManagementControl)sender;
            var newEmployeeLeave = employeeLeaveManagementControlObj.NewEmployeeLeave;

            if (newEmployeeLeave != null)
            {
                // for now, the transaction is always new
                var saveResults = _employeeLeaveController.Save(newEmployeeLeave, true);

                string resultMessages = "";
                foreach (var msg in saveResults.Messages)
                {
                    resultMessages += msg + "\n";
                }

                if (saveResults.IsSuccess)
                {
                    MessageBox.Show(resultMessages, "Save employee leave details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    employeeLeaveManagementControlObj.ResetForm();

                    // search all leave by employee
                    employeeLeaveManagementControlObj.EmployeeLeaveHistory = _employeeLeaveData.GetAllByEmployeeNumberAndYear(newEmployeeLeave.EmployeeNumber, DateTime.Now.Year);
                    employeeLeaveManagementControlObj.DisplayEmployeeLeaveHistory();

                    //string msg = addUpdateEmployeeObj.IsNew ? "Successfully save new employee details." : "Successfully update employee details.";

                    //DisplayAddUpdateEmployeeConfirmationUserControl(saveResults.Data, msg);
                }
                else
                {
                    MessageBox.Show(resultMessages, "Save shift details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void HandleDeleteEmployeeLeave(object sender, EventArgs e)
        {
            EmployeeLeaveManagementControl employeeLeaveManagementControlObj = (EmployeeLeaveManagementControl)sender;
            var employeeNumber = employeeLeaveManagementControlObj.EmployeeNumber;
            var selectedEmployeeLeaveId = employeeLeaveManagementControlObj.EmployeeLeaveId;

            if (string.IsNullOrEmpty(employeeNumber) == false && selectedEmployeeLeaveId > 0)
            {
                DialogResult res = MessageBox.Show("Are you sure, you want to delete this?", "Delete confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res == DialogResult.OK)
                {
                    var saveResults = _employeeLeaveController.Delete(selectedEmployeeLeaveId, employeeNumber);

                    string resultMessages = "";
                    foreach (var msg in saveResults.Messages)
                    {
                        resultMessages += msg + "\n";
                    }

                    if (saveResults.IsSuccess)
                    {
                        MessageBox.Show(resultMessages, "Delete employee leave details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // search all leave by employee
                        employeeLeaveManagementControlObj.EmployeeLeaveHistory = _employeeLeaveData.GetAllByEmployeeNumberAndYear(employeeNumber, DateTime.Now.Year);
                        employeeLeaveManagementControlObj.DisplayEmployeeLeaveHistory();
                    }
                    else
                    {
                        MessageBox.Show(resultMessages, "Delete employee leave details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }


        private void HandleFilterEmployeeLeaveHistory(object sender, EventArgs e)
        {
            EmployeeLeaveManagementControl employeeLeaveManagementControlObj = (EmployeeLeaveManagementControl)sender;
            var employeeNumber = employeeLeaveManagementControlObj.EmployeeNumber;
            var year = employeeLeaveManagementControlObj.FilterEmployeeLeaveHistoryYear;

            if (string.IsNullOrEmpty(employeeNumber) == false)
            {
                // search all leave by employee
                employeeLeaveManagementControlObj.EmployeeLeaveHistory = _employeeLeaveData.GetAllByEmployeeNumberAndYear(employeeNumber, year);
                employeeLeaveManagementControlObj.DisplayEmployeeLeaveHistory();
            }
        }

        #endregion

        #region Holiday CRUD Control

        public void DisplayHolidayCRUDControl()
        {
            this.panelContainer.Controls.Clear();

            var holidayCRUDControlObj = new HolidayCRUDControl();
            //addUpdateEmployeeUserControl.Dock = DockStyle.Fill;
            holidayCRUDControlObj.Location = new Point(this.ClientSize.Width / 2 - holidayCRUDControlObj.Size.Width / 2, this.ClientSize.Height / 2 - holidayCRUDControlObj.Size.Height / 2);
            holidayCRUDControlObj.Anchor = AnchorStyles.None;

            holidayCRUDControlObj.Holidays = _holidayData.GetAllNotDeleted();
            holidayCRUDControlObj.DisplayHolidays();

            holidayCRUDControlObj.HolidaySaved += HandleSaveHoliday;
            holidayCRUDControlObj.HolidayDelete += HandleDeleteHoliday;

            this.panelContainer.Controls.Add(holidayCRUDControlObj);
        }


        private void HandleSaveHoliday(object sender, EventArgs e)
        {
            HolidayCRUDControl holidayCRUDControlObj = (HolidayCRUDControl)sender;
            var newHolidayDetails = holidayCRUDControlObj.NewHolidayToAdd;

            if (newHolidayDetails != null)
            {
                // for now, the transaction is always new holiday
                var saveResults = _holidayController.Save(newHolidayDetails, true);

                string resultMessages = "";
                foreach (var msg in saveResults.Messages)
                {
                    resultMessages += msg + "\n";
                }

                if (saveResults.IsSuccess)
                {
                    MessageBox.Show(resultMessages, "Save employee leave details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    holidayCRUDControlObj.ResetForm();

                    holidayCRUDControlObj.Holidays = _holidayData.GetAllNotDeleted();
                    holidayCRUDControlObj.DisplayHolidays();
                }
                else
                {
                    MessageBox.Show(resultMessages, "Save shift details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void HandleDeleteHoliday(object sender, EventArgs e)
        {
            HolidayCRUDControl holidayCRUDControlObj = (HolidayCRUDControl)sender;
            long holidayIdToDelete = holidayCRUDControlObj.HolidayIdToDelete;

            if (holidayIdToDelete > 0)
            {
                DialogResult res = MessageBox.Show("Are you sure, you want to delete this?", "Delete confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res == DialogResult.OK)
                {
                    var saveResults = _holidayController.Delete(holidayIdToDelete);

                    string resultMessages = "";
                    foreach (var msg in saveResults.Messages)
                    {
                        resultMessages += msg + "\n";
                    }

                    if (saveResults.IsSuccess)
                    {
                        MessageBox.Show(resultMessages, "Delete holiday details", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        holidayCRUDControlObj.Holidays = _holidayData.GetAllNotDeleted();
                        holidayCRUDControlObj.DisplayHolidays();
                    }
                    else
                    {
                        MessageBox.Show(resultMessages, "Delete holiday details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }


        #endregion
    }
}
