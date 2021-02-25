using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.EmployeeManagementForms
{
    public partial class FrmAddUpdateEmployee : Form
    {
        public FrmAddUpdateEmployee()
        {
            InitializeComponent();
        }

        private void FrmAddUpdateEmployee_Load(object sender, EventArgs e)
        {
            this.PanelAddUpdateEmployee.Location = new Point( this.ClientSize.Width / 2 - this.PanelAddUpdateEmployee.Size.Width / 2, this.ClientSize.Height / 2 - this.PanelAddUpdateEmployee.Size.Height / 2);
            this.PanelAddUpdateEmployee.Anchor = AnchorStyles.None;
        }
    }
}
