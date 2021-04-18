using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.SalesReport.Controls
{
    public partial class SaleTotalReportItemControl : UserControl
    {
        public SaleTotalReportItemControl(string saleReportType, decimal amount, string saleReportForThe)
        {
            InitializeComponent();

            this.SaleReportType = saleReportType;
            this.Amount = amount;
            this.SaleReportForThe = saleReportForThe;
        }

        public string SaleReportType { get; set; }

        public decimal Amount { get; set; }

        public string SaleReportForThe { get; set; }

        private void SaleTotalReportItemControl_Load(object sender, EventArgs e)
        {
            this.LblSaleReportType.Text = SaleReportType;
            this.LblAmount.Text = Amount.ToString("0.##");
            this.LblSaleReportForThe.Text = SaleReportForThe;
        }
    }
}
