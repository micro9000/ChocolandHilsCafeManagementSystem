﻿using DataAccess.Data.InventoryManagement.Contracts;
using Main.Forms.AttendanceTerminal;
using Main.Forms.EmployeeManagementForms;
using Main.Forms.InventoryManagementForms;
using Main.Forms.OtherDataForms;
using Main.Forms.PayrollForms;
using Main.Forms.UserManagementForms;
using Microsoft.Extensions.Options;
using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public partial class MainFrm : Form
    {
        private readonly Sessions _sessions;
        private readonly OtherSettings _otherSettings;
        private readonly FrmMainEmployeeManagement _frmMainEmployeeManagement;
        private readonly FrmOtherData _frmOtherData;
        private readonly FrmPayroll _payrollForm;
        private readonly FrmUserManagement _frmUserManagement;
        private readonly AttendanceTerminalForm _attendanceTerminalForm;
        private readonly FrmInventory _frmInventory;
        private readonly HomeFrm _frmHome;
        private readonly IIngredientInventoryData _ingredientInventoryData;
        private Button currentButton;
        private Form activeForm;

        public MainFrm(Sessions sessions,
                        IOptions<OtherSettings> otherSettingsOptions,
                        FrmMainEmployeeManagement frmMainEmployeeManagement,
                        FrmOtherData frmOtherData,
                        FrmPayroll payrollForm,
                        FrmUserManagement frmUserManagement,
                        AttendanceTerminalForm attendanceTerminalForm,
                        FrmInventory frmInventory,
                        HomeFrm frmHome,
                        IIngredientInventoryData ingredientInventoryData)
        {
            InitializeComponent();
            _sessions = sessions;
            _otherSettings = otherSettingsOptions.Value;
            _frmMainEmployeeManagement = frmMainEmployeeManagement;
            _frmOtherData = frmOtherData;
            _payrollForm = payrollForm;
            _frmUserManagement = frmUserManagement;
            _attendanceTerminalForm = attendanceTerminalForm;
            _frmInventory = frmInventory;
            _frmHome = frmHome;
            _ingredientInventoryData = ingredientInventoryData;
        }

        private void MainFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _sessions.CurrentLoggedInUser = null;
            Application.Exit();
        }


        public void DisplayHomeControl() {
            
        }


        private void MainFrm_Load(object sender, EventArgs e)
        {
            if (_sessions != null && _sessions.CurrentLoggedInUser != null)
            {
                this.LblCurrentUserName.Text = _sessions.CurrentLoggedInUser.FullName;
                this.LblCurrentUserRoles.Text = _sessions.CurrentLoggedInUser.Role.Role.RoleKey.ToString();

                if (_sessions.CurrentLoggedInUser.Role.Role.RoleKey == EntitiesShared.StaticData.UserRole.normal)
                {
                    this.BtnEmployeeManagementMenuItem.Visible = false;
                    this.BtnPayrollSystem.Visible = false;
                    this.BtnInventorySystem.Visible = false;
                    this.BtnSalesReportSystem.Visible = false;
                    this.BtnSettingsSystem.Visible = false;
                    this.BtnUserMgnment.Visible = false;
                    this.BtnOtherData.Visible = false;
                }
            }


            List<AlertMessage> alertMessages = new();

            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddDays(_otherSettings.NumDaysNotifyUserForInventoryExpDate);
            int notificationCountForInventory = _ingredientInventoryData.GetCountOfIngredientInventoryByExpirationDate(startDate, endDate);
            if (notificationCountForInventory > 0)
            {
                this.BtnInventorySystem.Text = $"Inventory ({notificationCountForInventory})";
                this.BtnInventorySystem.ForeColor = Color.Red;

                string msg = $"{notificationCountForInventory} ingredient(s) inventory near on expiration date";
                ToolTipForNavButtons.SetToolTip(this.BtnInventorySystem, msg);

                alertMessages.Add(new AlertMessage { Title = "Inventory ingredients expiration", Message = msg });
            }


            if (alertMessages != null && alertMessages.Count > 0)
            {
                FrmAlertMessage frmAlertMessage = new();
                frmAlertMessage.AlertMessages = alertMessages;

                frmAlertMessage.ShowDialog();
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelSidebar.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.Transparent;
                }
            }
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.FromArgb(42, 42, 64);
                    //btnCloseChildForm.Visible = true;
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Hide();

            ActivateButton(btnSender);

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelMainBody.Controls.Add(childForm);
            this.panelMainBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            this.LblRenderedFormTitle.Text = childForm.Text;
        }

        private void BtnUserLogout_Click(object sender, EventArgs e)
        {
            _sessions.CurrentLoggedInUser = null;
            Application.Exit();
        }

        private void BtnEmployeeManagementMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(_frmMainEmployeeManagement, sender);
        }

        private void BtnPayrollSystem_Click(object sender, EventArgs e)
        {
            OpenChildForm(_payrollForm, sender);
        }

        private void BtnOtherData_Click(object sender, EventArgs e)
        {
            OpenChildForm(_frmOtherData, sender);
        }

        private void BtnUserMgnment_Click(object sender, EventArgs e)
        {
            OpenChildForm(_frmUserManagement, sender);
        }

        private void BtnAttendanceTerminal_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Hide();

            ActivateButton(sender);

            activeForm = _attendanceTerminalForm;
            _attendanceTerminalForm.TopLevel = false;

            _attendanceTerminalForm.Location = new Point(this.panelMainBody.Width / 2 - _attendanceTerminalForm.Size.Width / 2, this.panelMainBody.Height / 2 - _attendanceTerminalForm.Size.Height / 2);
            _attendanceTerminalForm.Anchor = AnchorStyles.None;

            _attendanceTerminalForm.FormBorderStyle = FormBorderStyle.None;
            this.panelMainBody.Controls.Add(_attendanceTerminalForm);
            this.panelMainBody.Tag = _attendanceTerminalForm;
            _attendanceTerminalForm.BringToFront();
            _attendanceTerminalForm.Show();
            this.LblRenderedFormTitle.Text = _attendanceTerminalForm.Text;
        }

        private void BtnInventorySystem_Click(object sender, EventArgs e)
        {
            OpenChildForm(_frmInventory, sender);
        }

        private void BtnGoToHomeFrm_Click(object sender, EventArgs e)
        {
            OpenChildForm(_frmHome, sender);
        }
    }
}
