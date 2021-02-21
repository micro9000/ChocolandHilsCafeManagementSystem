using Main.Controllers.UserBO;
using Main.UserManagementForms;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Main
{
    public partial class LoginFrm : Form
    {
        private readonly ILogger<LoginFrm> _logger;
        private readonly IUserController _userController;
        private readonly MainUserMgnFrm _mainUserMgnFrm;

        public LoginFrm(ILogger<LoginFrm> logger,
                            IUserController userController,
                            MainUserMgnFrm mainUserMgnFrm)
        {
            InitializeComponent();
            _logger = logger;
            _userController = userController;
            _mainUserMgnFrm = mainUserMgnFrm;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            var userInfo = _userController.SignIn("Raniel", "password");

            _logger.LogInformation("HI");

            MessageBox.Show(userInfo.Username);

            _mainUserMgnFrm.Show();
        }
    }
}
