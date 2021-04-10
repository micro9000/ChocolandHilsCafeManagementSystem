using DataAccess.Data.InventoryManagement.Contracts;
using EntitiesShared.InventoryManagement;
using Main.Forms.POSManagementForms.Controls;
using Microsoft.Extensions.Options;
using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.POSManagementForms
{
    public partial class FrmMainPOSTerminal : Form
    {
        private readonly IProductData _productData;
        private readonly IProductCategoryData _productCategoryData;
        private readonly OtherSettings _otherSettings;

        public FrmMainPOSTerminal(IProductData productData, 
                                IProductCategoryData productCategoryData,
                                IOptions<OtherSettings> otherSettings)
        {
            InitializeComponent();
            _productData = productData;
            _productCategoryData = productCategoryData;
            _otherSettings = otherSettings.Value;
        }

        private List<ProductModel> _products;

        public List<ProductModel> Products
        {
            get { return _products; }
            set { _products = value; }
        }

        private List<ProductCategoryModel> _productCategories;

        public List<ProductCategoryModel> ProductCategories
        {
            get { return _productCategories; }
            set { _productCategories = value; }
        }


        private void FrmMainPOSTerminal_Load(object sender, EventArgs e)
        {
            SetDGVCartItemsFontAndColors();
            this.Products = _productData.GetAllNotDeleted();
            this.ProductCategories = _productCategoryData.GetAllNotDeleted();

            DisplayProductList(this.Products);
            DisplayProductCategoryList(this.ProductCategories);

            DisplaySampleProductsInCart(this.Products);
        }

        public void DisplayProductList(List<ProductModel> products)
        {
            if (products != null)
            {
                foreach (var prod in products)
                {
                    var prodItemControl = new ProductItemControl(prod, _otherSettings);
                    FLPanelProductList.Controls.Add(prodItemControl);
                }
            }
        }

        public void DisplayProductCategoryList(List<ProductCategoryModel> categories)
        {
            if (categories != null)
            {
                foreach(var category in categories)
                {
                    var btnCategoryControl = new BtnProductCategoryControl(category);
                    FLPanelProductCategories.Controls.Add(btnCategoryControl);
                }
            }
        }


        private void SetDGVCartItemsFontAndColors()
        {
            this.DGVCartItems.BackgroundColor = Color.White;
            this.DGVCartItems.DefaultCellStyle.Font = new Font("Century Gothic", 11);
            //this.DGVEmployees.DefaultCellStyle.ForeColor = Color.White;
            //this.DGVEmployees.DefaultCellStyle.BackColor = Color.FromArgb(99, 99, 138);
            //this.DGVEmployees.DefaultCellStyle.SelectionForeColor = Color.FromArgb(42, 42, 64);
            //this.DGVEmployees.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;

            this.DGVCartItems.RowHeadersVisible = false;
            this.DGVCartItems.RowTemplate.Height = 35;
            this.DGVCartItems.RowTemplate.Resizable = DataGridViewTriState.True;
            this.DGVCartItems.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVCartItems.AllowUserToResizeRows = false;
            this.DGVCartItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVCartItems.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            //this.DGVEmployees.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            //this.DGVEmployees.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            //this.DGVEmployees.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(42, 42, 64);
            //this.DGVEmployees.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;


            this.DGVCartItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVCartItems.MultiSelect = false;

            //this.DGVCartItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //this.DGVCartItems.ColumnHeadersHeight = 30;

        }


        public void DisplaySampleProductsInCart(List<ProductModel> products)
        {
            if (products != null)
            {
                this.DGVCartItems.Rows.Clear();
                this.DGVCartItems.ColumnCount = 5;

                this.DGVCartItems.Columns[0].Name = "ProductId";
                this.DGVCartItems.Columns[0].Visible = false;

                this.DGVCartItems.Columns[1].Name = "ItemName";
                this.DGVCartItems.Columns[1].HeaderText = "ItemName";
                this.DGVCartItems.Columns[1].Width = 300;

                this.DGVCartItems.Columns[2].Name = "Price";
                this.DGVCartItems.Columns[2].HeaderText = "Price";
                this.DGVCartItems.Columns[2].Width = 80;

                this.DGVCartItems.Columns[3].Name = "Quantity";
                this.DGVCartItems.Columns[3].HeaderText = "Qty";
                this.DGVCartItems.Columns[3].Width = 60;

                this.DGVCartItems.Columns[4].Name = "Total";
                this.DGVCartItems.Columns[4].HeaderText = "Total";
                this.DGVCartItems.Columns[4].Width = 80;

                DataGridViewButtonColumn btnIncreaseQty = new DataGridViewButtonColumn();
                btnIncreaseQty.HeaderText = "Inc. Qty";
                btnIncreaseQty.Text = "+";
                btnIncreaseQty.Name = "btnIncreaseQty";
                btnIncreaseQty.UseColumnTextForButtonValue = true;
                btnIncreaseQty.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnIncreaseQty.FlatStyle = FlatStyle.Flat;
                btnIncreaseQty.CellTemplate.Style.BackColor = Color.FromArgb(71, 125, 78);
                btnIncreaseQty.CellTemplate.Style.Font = new Font("Century Gothic", 14, FontStyle.Bold);
                this.DGVCartItems.Columns.Add(btnIncreaseQty);

                DataGridViewButtonColumn btnDecreaseQty = new DataGridViewButtonColumn();
                btnDecreaseQty.HeaderText = "Dec. Qty";
                btnDecreaseQty.Text = "-";
                btnDecreaseQty.Name = "btnDecreaseQty";
                btnDecreaseQty.UseColumnTextForButtonValue = true;
                btnDecreaseQty.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnDecreaseQty.FlatStyle = FlatStyle.Flat;
                btnDecreaseQty.CellTemplate.Style.BackColor = Color.FromArgb(125, 112, 71);
                btnDecreaseQty.CellTemplate.Style.Font = new Font("Century Gothic", 14, FontStyle.Bold);
                this.DGVCartItems.Columns.Add(btnDecreaseQty);


                DataGridViewButtonColumn btnRemoveItem = new DataGridViewButtonColumn();
                btnRemoveItem.HeaderText = "Remove";
                btnRemoveItem.Text = "X";
                btnRemoveItem.Name = "btnRemvoeItem";
                btnRemoveItem.UseColumnTextForButtonValue = true;
                btnRemoveItem.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnRemoveItem.FlatStyle = FlatStyle.Flat;
                btnRemoveItem.CellTemplate.Style.BackColor = Color.FromArgb(145, 82, 48);
                btnRemoveItem.CellTemplate.Style.Font = new Font("Century Gothic", 14, FontStyle.Bold);
                this.DGVCartItems.Columns.Add(btnRemoveItem);

                foreach (var prod in products)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGVCartItems);
                    row.Height = 35;

                    //row.DefaultCellStyle.Padding = new Padding(0, 10, 0, 10);

                    row.Cells[0].Value = prod.Id;
                    row.Cells[1].Value = prod.ProdName;
                    row.Cells[2].Value = prod.PricePerOrder;
                    row.Cells[3].Value = 1;
                    row.Cells[4].Value = 100;

                    DGVCartItems.Rows.Add(row);
                }
            }
        }

    }
}
