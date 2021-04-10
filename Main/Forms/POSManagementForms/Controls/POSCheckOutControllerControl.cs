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
    public partial class POSCheckOutControllerControl : UserControl
    {
        public POSCheckOutControllerControl()
        {
            InitializeComponent();
        }


        private void POSCheckOutControllerControl_Load(object sender, EventArgs e)
        {
            SetDGVActiveDineInTransactionsFontAndColors();
        }


        private void SetDGVActiveDineInTransactionsFontAndColors()
        {
            this.DGVActiveDineInTransactions.BackgroundColor = Color.White;
            this.DGVActiveDineInTransactions.DefaultCellStyle.Font = new Font("Century Gothic", 11);
            this.DGVActiveDineInTransactions.RowHeadersVisible = false;
            this.DGVActiveDineInTransactions.RowTemplate.Height = 35;
            this.DGVActiveDineInTransactions.RowTemplate.Resizable = DataGridViewTriState.True;
            this.DGVActiveDineInTransactions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVActiveDineInTransactions.AllowUserToResizeRows = false;
            this.DGVActiveDineInTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVActiveDineInTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVActiveDineInTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVActiveDineInTransactions.MultiSelect = false;
        }


        private void BtnNewTransaction_Click(object sender, EventArgs e)
        {
            FrmNewTransaction frmNewTransaction = new();
            frmNewTransaction.ShowDialog();
        }

    }
}
