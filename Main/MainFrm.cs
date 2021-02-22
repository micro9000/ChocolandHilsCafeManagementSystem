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
            if (_sessions != null)
            {
                this.LblCurrentUserName.Text = _sessions.CurrentLoggedInUser.EmployeeNumber;
                string roles = "";
                foreach(var role in _sessions.CurrentLoggedInUser.Roles)
                {
                    roles += role.Role.RoleKey + " ";
                }
                this.LblUserRoles.Text = roles;
            }
        }
    }
}
