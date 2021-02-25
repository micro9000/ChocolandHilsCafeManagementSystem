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
    public partial class FrmMainEmployeeManagement : Form
    {
        private readonly FrmAddUpdateEmployee _frmAddUpdateEmployee;
        private Form activeForm;
        public FrmMainEmployeeManagement(FrmAddUpdateEmployee frmAddUpdateEmployee)
        {
            InitializeComponent();
            _frmAddUpdateEmployee = frmAddUpdateEmployee;
        }

        private void EmployeeMenuItemsMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;

            if (clickedItem != null && clickedItem.Name == "ToolStripItem_Add")
            {
                this.OpenChildForm(_frmAddUpdateEmployee, sender);
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Hide();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.PanelEmpMgmtMainBody.Controls.Add(childForm);
            this.PanelEmpMgmtMainBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            this.LblRenderedFormTitle.Text = childForm.Text;
        }
    }
}
