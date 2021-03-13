using Main.Controllers.UserManagementControllers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Main
{
    public partial class LoginFrm : Form
    {
        private readonly ILogger<LoginFrm> _logger;
        private readonly IUserController _userController;
        private readonly Sessions _sessions;
        private readonly MainFrm _mainFrm;

        public LoginFrm(ILogger<LoginFrm> logger,
                            IUserController userController,
                            Sessions sessions,
                            MainFrm mainFrm)
        {
            InitializeComponent();
            _logger = logger;
            _userController = userController;
            _sessions = sessions;
            _mainFrm = mainFrm;
        }


        private void Login()
        {
            var signResults = _userController.SignIn(this.TbxUsername.Text, this.TbxPassword.Text);

            if (signResults.IsSuccess)
            {
                _sessions.CurrentLoggedInUser = signResults.Data;

                var checkedButton = GPanelChooseTerminal.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);


                if (checkedButton == null)
                {
                    MessageBox.Show("Kindly choose application you are going to use", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //MessageBox.Show(checkedButton.Name);

                if (checkedButton.Name == "RBtnAdminDashboard")
                {
                    _mainFrm.Show();
                    this.Hide();
                }

            }
            else
            {
                string messages = "";
                foreach(var msg in signResults.Messages)
                {
                    messages += msg + " | ";
                }
                MessageBox.Show(messages);
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void TbxPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
                e.Handled = true;
            }
        }

        private void BtnOpenAttendanceTerminal_Click(object sender, EventArgs e)
        {
            //AttendanceTerminalForm attendanceTerminalFrm = new AttendanceTerminalForm();
            //attendanceTerminalFrm.Show();
        }
    }
}
