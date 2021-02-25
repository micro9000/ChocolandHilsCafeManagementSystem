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

        private Button currentButton;
        private Form activeForm;

        public MainFrm(Sessions sessions)
        {
            InitializeComponent();
            _sessions = sessions;
        }

        private void MainFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _sessions.CurrentLoggedInUser = null;
            Application.Exit();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            if (_sessions != null && _sessions.CurrentLoggedInUser != null)
            {
                this.LblCurrentUserName.Text = _sessions.CurrentLoggedInUser.EmployeeNumber;
                string roles = "";
                foreach (var role in _sessions.CurrentLoggedInUser.Roles)
                {
                    roles += role.Role.RoleKey + ",";
                }
                this.LblCurrentUserRoles.Text = roles;
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
                activeForm.Close();

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
            OpenChildForm(new Forms.EmployeeManagementForms.FrmMainEmployeeManagement(), sender);
        }

        private void BtnPayrollSystem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UserManagementForms.MainUserMgnFrm(), sender);
        }
    }
}
