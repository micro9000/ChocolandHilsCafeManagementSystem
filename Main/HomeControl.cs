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
    public partial class HomeControl : UserControl
    {

        private string greeting;

        public string Greeting
        {
            get { return greeting; }
            set { 
                greeting = value;
                this.LblGreetings.Text = value;
            }
        }


        public HomeControl()
        {
            InitializeComponent();
        }
    }
}
