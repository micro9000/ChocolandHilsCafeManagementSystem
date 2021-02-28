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
    public partial class GovtAgenciesCRUDUserControl : UserControl
    {
        public GovtAgenciesCRUDUserControl()
        {
            InitializeComponent();
        }



        private void GovtAgenciesCRUDUserControl_Load(object sender, EventArgs e)
        {
            SetDGVLeaveTypesFontAndColors();
        }


        private void SetDGVLeaveTypesFontAndColors()
        {
            this.DGVGovernmentAgencies.BackgroundColor = Color.White;
            this.DGVGovernmentAgencies.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVGovernmentAgencies.RowHeadersVisible = false;
            this.DGVGovernmentAgencies.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVGovernmentAgencies.AllowUserToResizeRows = false;
            this.DGVGovernmentAgencies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVGovernmentAgencies.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVGovernmentAgencies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVGovernmentAgencies.MultiSelect = false;

            this.DGVGovernmentAgencies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVGovernmentAgencies.ColumnHeadersHeight = 30;
        }
    }
}
