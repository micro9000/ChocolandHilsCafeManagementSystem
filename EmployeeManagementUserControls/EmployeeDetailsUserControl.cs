using EntitiesShared.EmployeeManagement.DisplayModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagementUserControls
{
    public partial class EmployeeDetailsUserControl : UserControl
    {
        private Button currentButton;

        public EmployeeDetailsUserControl()
        {
            InitializeComponent();
        }

        private EmployeeDetailsModel employeeDetails;

        public EmployeeDetailsModel EmployeeDetails
        {
            get { return employeeDetails; }
            set { employeeDetails = value; }
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

        private void BtnViewPersonalInformation_Click(object sender, EventArgs e)
        {
            this.PnlEmployeeInfoContainer.Controls.Clear();

            ActivateButton(sender);

            var userControlToDisplay = new EmployeePersonalInfoUserControl();
            userControlToDisplay.Dock = DockStyle.Fill;
            //userControlToDisplay.Location = new Point(this.ClientSize.Width / 2 - userControlToDisplay.Size.Width / 2, this.ClientSize.Height / 2 - userControlToDisplay.Size.Height / 2);
            //userControlToDisplay.Anchor = AnchorStyles.None;

            this.PnlEmployeeInfoContainer.Controls.Add(userControlToDisplay);
        }

        private void BtnViewEmployeeAttendance_Click(object sender, EventArgs e)
        {
            this.PnlEmployeeInfoContainer.Controls.Clear();

            ActivateButton(sender);

            var userControlToDisplay = new EmployeeAttendanceHistoryUserControl();
            userControlToDisplay.Dock = DockStyle.Fill;
            //userControlToDisplay.Location = new Point(this.ClientSize.Width / 2 - userControlToDisplay.Size.Width / 2, this.ClientSize.Height / 2 - userControlToDisplay.Size.Height / 2);
            //userControlToDisplay.Anchor = AnchorStyles.None;

            this.PnlEmployeeInfoContainer.Controls.Add(userControlToDisplay);
        }

        private void BtnViewEmployeePayslipHistory_Click(object sender, EventArgs e)
        {
            this.PnlEmployeeInfoContainer.Controls.Clear();

            ActivateButton(sender);

            var userControlToDisplay = new EmployeePayslipHistoryUserControl();
            userControlToDisplay.Dock = DockStyle.Fill;
            //userControlToDisplay.Location = new Point(this.ClientSize.Width / 2 - userControlToDisplay.Size.Width / 2, this.ClientSize.Height / 2 - userControlToDisplay.Size.Height / 2);
            //userControlToDisplay.Anchor = AnchorStyles.None;

            this.PnlEmployeeInfoContainer.Controls.Add(userControlToDisplay);
        }
    }
}
