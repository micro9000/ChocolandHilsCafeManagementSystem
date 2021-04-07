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
    public partial class NotificationItemControl : UserControl
    {
        public NotificationItemControl()
        {
            InitializeComponent();
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { 
                title = value;
                LblTitle.Text = value;
            }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { 
                message = value;
                LblMessage.Text = value;
            }
        }


    }
}
