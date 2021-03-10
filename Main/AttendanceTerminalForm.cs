using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public partial class AttendanceTerminalForm : Form
    {
        private readonly ILogger<LoginFrm> _logger;

        public AttendanceTerminalForm(ILogger<LoginFrm> logger)
        {
            InitializeComponent();
            _logger = logger;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.LblCurrentDate.Text = DateTime.Now.ToLongDateString();
            this.LblCurrentTime.Text = DateTime.Now.ToString("hh:mm:ss tt", CultureInfo.CurrentCulture);
        }

        private void BtnSaveSubmitTimeINorOut_Click(object sender, EventArgs e)
        {

        }
    }
}
