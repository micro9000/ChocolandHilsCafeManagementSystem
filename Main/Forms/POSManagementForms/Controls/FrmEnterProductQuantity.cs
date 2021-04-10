using EntitiesShared.InventoryManagement;
using Shared;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Main.Forms.POSManagementForms.Controls
{
    public partial class FrmEnterProductQuantity : Form
    {
        public FrmEnterProductQuantity(ProductModel product, OtherSettings otherSettings)
        {
            InitializeComponent();

            Product = product;
            _otherSettings = otherSettings;
        }

        private ProductModel product;
        private readonly OtherSettings _otherSettings;

        public ProductModel Product
        {
            get { return product; }
            set { product = value; }
        }


        public int Quantity { get; set; }

        public bool IsCancelled { get; set; }

        private void FrmEnterProductQuantity_Load(object sender, EventArgs e)
        {
            this.NumUpDownOrderQty.Focus();
            NumUpDownOrderQty.Select(0, this.NumUpDownOrderQty.Value.ToString().Length);

            if (this.Product != null)
            {
                this.LblProductName.Text = this.Product.ProdName;
                this.LblProductPrice.Text = this.Product.PricePerOrder.ToString("0.##");
            }

            string appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var ProductImgsDirInfo = Directory.CreateDirectory($"{appPath}{_otherSettings.ProductImgsFileDirName}");

            if (ProductImgsDirInfo.Exists)
            {
                string empImgPath = $"{appPath}\\{_otherSettings.ProductImgsFileDirName}\\{this.Product.ImageFilename}";

                if (File.Exists(empImgPath))
                {
                    PicBoxProductImage.Image = new Bitmap(empImgPath);
                    PicBoxProductImage.SizeMode = PictureBoxSizeMode.StretchImage;
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
