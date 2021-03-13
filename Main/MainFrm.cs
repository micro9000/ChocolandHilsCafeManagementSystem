﻿using Main.Forms.EmployeeManagementForms;
using Main.Forms.OtherDataForms;
using Main.Forms.PayrollForms;
using Main.Forms.UserManagementForms;
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
        private readonly FrmMainEmployeeManagement _frmMainEmployeeManagement;
        private readonly FrmOtherData _frmOtherData;
        private readonly FrmPayroll _payrollForm;
        private readonly FrmUserManagement _frmUserManagement;
        private Button currentButton;
        private Form activeForm;

        public MainFrm(Sessions sessions,
                        FrmMainEmployeeManagement frmMainEmployeeManagement,
                        FrmOtherData frmOtherData,
                        FrmPayroll payrollForm,
                        FrmUserManagement frmUserManagement)
        {
            InitializeComponent();
            _sessions = sessions;
            _frmMainEmployeeManagement = frmMainEmployeeManagement;
            _frmOtherData = frmOtherData;
            _payrollForm = payrollForm;
            _frmUserManagement = frmUserManagement;
        }

        private void MainFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _sessions.CurrentLoggedInUser = null;
            Application.Exit();
        }


        public void DisplayHomeControl() {
            var homeControlObj = new HomeControl();
            //addUpdateEmployeeUserControl.Dock = DockStyle.Fill;
            homeControlObj.Location = new Point(this.ClientSize.Width / 2 - homeControlObj.Size.Width / 2, this.ClientSize.Height / 2 - homeControlObj.Size.Height / 2);
            homeControlObj.Anchor = AnchorStyles.None;

            homeControlObj.Greeting = $"Welcome back {_sessions.CurrentLoggedInUser.FullName}!";

            this.panelMainBody.Controls.Add(homeControlObj);
        }


        private void MainFrm_Load(object sender, EventArgs e)
        {
            if (_sessions != null && _sessions.CurrentLoggedInUser != null)
            {
                this.LblCurrentUserName.Text = _sessions.CurrentLoggedInUser.FullName;
                this.LblCurrentUserRoles.Text = _sessions.CurrentLoggedInUser.Role.Role.RoleKey.ToString();

                //DisplayHomeControl();
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
    }
}
