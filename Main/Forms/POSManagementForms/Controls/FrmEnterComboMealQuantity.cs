using EntitiesShared.InventoryManagement;
using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.POSManagementForms.Controls
{
    public partial class FrmEnterComboMealQuantity : Form
    {
        private readonly OtherSettings _otherSettings;

        public FrmEnterComboMealQuantity(ComboMealModel comboMeal, OtherSettings otherSettings)
        {
            InitializeComponent();
            _otherSettings = otherSettings;

            ComboMeal = comboMeal;
        }

        private ComboMealModel _comboMeal;
        public ComboMealModel ComboMeal
        {
            get { return _comboMeal; }
            set { _comboMeal = value; }
        }

        public int Quantity { get; set; }

        public bool IsCancelled { get; set; }

        private void FrmEnterComboMealQuantity_Load(object sender, EventArgs e)
        {
            this.NumUpDownOrderQty.Focus();
            NumUpDownOrderQty.Select(0, this.NumUpDownOrderQty.Value.ToString().Length);

            if (this.ComboMeal != null)
            {
                this.LblComboMealName.Text = this.ComboMeal.Title;
                this.LblComboMealPrice.Text = this.ComboMeal.Price.ToString("0.##");

                string appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                var ComboMealImgsDirInfo = Directory.CreateDirectory($"{appPath}{_otherSettings.ComboMealImgsFileDirName}");

                if (ComboMealImgsDirInfo.Exists)
                {
                    string imgPath = $"{appPath}\\{_otherSettings.ComboMealImgsFileDirName}\\{this.ComboMeal.ImageFilename}";

                    if (File.Exists(imgPath))
                    {
                        PicBoxComboMealImage.Image = new Bitmap(imgPath);
                        PicBoxComboMealImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
        }

        private void NumUpDownOrderQty_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Quantity = Convert.ToInt32(NumUpDownOrderQty.Value);
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            IsCancelled = true;
            this.Close();
        }
    }
}
