using DataAccess.Data.EmployeeManagement.Contracts;
using Main.Forms.PayrollForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.PayrollForms
{
    public partial class FrmPayroll : Form
    {
        private readonly IEmployeeData _employeeData;

        public FrmPayroll(IEmployeeData employeeData)
        {
            InitializeComponent();
            _employeeData = employeeData;
        }

        private void CMStripPayroll_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;

            if (clickedItem != null && clickedItem.Name == "TStripMenuItemGenerate")
            {
                DisplayGeneratePayrollControl();
            }
        }

        public void DisplayGeneratePayrollControl()
        {
            this.panelContainer.Controls.Clear();
            var controlToDisplay = new GeneratePayrollControl();
            controlToDisplay.Location = new Point(this.ClientSize.Width / 2 - controlToDisplay.Size.Width / 2, this.ClientSize.Height / 2 - controlToDisplay.Size.Height / 2);
            controlToDisplay.Anchor = AnchorStyles.None;

            this.panelContainer.Controls.Add(controlToDisplay);
        }
    }
}
