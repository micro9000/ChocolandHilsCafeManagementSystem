using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.POSManagementForms.Controls
{
    public partial class FrmDineInStatus : Form
    {
        public FrmDineInStatus()
        {
            InitializeComponent();
        }

        private void FrmDineInStatus_Load(object sender, EventArgs e)
        {
            for(var n=1; n <= 20; n++)
            {
                var tableItemControl = new RestaurantTableItemControl()
                {
                    IsOccupied = true,
                    TableNumber = n
                };

                this.FlowLayoutTables.Controls.Add(tableItemControl);
            }
        }
    }
}
