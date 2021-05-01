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
    public partial class RestaurantTableItemControl : UserControl
    {
        public RestaurantTableItemControl()
        {
            InitializeComponent();
        }

        public long TransactionId { get; set; }

        public bool IsOccupied { get; set; }

        public int TableNumber { get; set; }

        public string TableTitle { get; set; }

        public event EventHandler ClickThisTable;
        protected virtual void OnClickThisTable(EventArgs e)
        {
            ClickThisTable?.Invoke(this, e);
        }


        private void RestaurantTableItemControl_Load(object sender, EventArgs e)
        {
            if (PicBoxTableStatus.Image != null)
            {
                PicBoxTableStatus.Image.Dispose();
                PicBoxTableStatus.ImageLocation = null;
                PicBoxTableStatus.Image = null;
            }

            if (this.IsOccupied)
            {
                PicBoxTableStatus.Image = Image.FromFile("./Resources/restaurant-table-red-100.png");
                PicBoxTableStatus.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {

                PicBoxTableStatus.Image = Image.FromFile("./Resources/restaurant-table-green-100.png");
                PicBoxTableStatus.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            this.LblTableNumber.Text = this.TableTitle;

            this.initControlsRecursive(this.Controls);
        }


        private void initControlsRecursive(ControlCollection coll)
        {
            foreach (Control c in coll)
            {
                c.MouseClick += (sender, e) => {
                    OnClickThisTable(EventArgs.Empty);
                };
                initControlsRecursive(c.Controls);
            }
        }
    }
}
