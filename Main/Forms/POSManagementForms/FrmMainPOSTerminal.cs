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
        private readonly IComboMealData _comboMealData;
        private readonly IProductCategoryData _productCategoryData;
        private readonly OtherSettings _otherSettings;

        public FrmMainPOSTerminal(IProductData productData, 
                                IComboMealData comboMealData,
                                IProductCategoryData productCategoryData,
                                IOptions<OtherSettings> otherSettings)
        {
            InitializeComponent();
            _productData = productData;
            _comboMealData = comboMealData;
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


        private List<ComboMealModel> _comboMeals;

        public List<ComboMealModel> ComboMeals
        {
            get { return _comboMeals; }
            set { _comboMeals = value; }
        }


        private void FrmMainPOSTerminal_Load(object sender, EventArgs e)
        {
            SetDGVCartItemsFontAndColors();
            this.Products = _productData.GetAllNotDeleted();
            this.ProductCategories = _productCategoryData.GetAllNotDeleted();
            this.ComboMeals = _comboMealData.GetAllNotDeleted();

            DisplayProductList(this.Products);
            DisplayProductCategoryList(this.ProductCategories);
            DisplayComboMealList(this.ComboMeals);

            this.LblCurrentProductCategory.Text = "ALL";

            // Temprary method
            DisplaySampleProductsInCart(this.Products);

            InitiateTab2DineInOrdersTableStatus();
            InitializePOSCheckOutController();
            InitializeTotalAndReceiptPreviewControl();
        }

        public void InitiateTab2DineInOrdersTableStatus()
        {
            this.PanelDineInOrdersTableStatus.Controls.Clear();
            FrmDineInStatus frmDineInStatus = new FrmDineInStatus();
            frmDineInStatus.TopLevel = false;
            frmDineInStatus.FormBorderStyle = FormBorderStyle.None;
            frmDineInStatus.Dock = DockStyle.Fill;
            this.PanelDineInOrdersTableStatus.Controls.Add(frmDineInStatus);
            frmDineInStatus.BringToFront();
            frmDineInStatus.Show();
        }


        public void InitializePOSCheckOutController()
        {
            this.POSControllerSplitContainer.Panel2.Controls.Clear();
            POSCheckOutControllerControl pOSCheckOutControllerControl = new();
            pOSCheckOutControllerControl.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;
            this.POSControllerSplitContainer.Panel2.Controls.Add(pOSCheckOutControllerControl);
        }


        public void InitializeTotalAndReceiptPreviewControl()
        {
            this.POSControllerSplitContainer.Panel1.Controls.Clear();
            TotalAndReceiptPreviewControl totalAndReceiptPreviewControl = new();
            totalAndReceiptPreviewControl.Dock = DockStyle.Fill;
            //totalAndReceiptPreviewControl.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;
            this.POSControllerSplitContainer.Panel1.Controls.Add(totalAndReceiptPreviewControl);
        }

        public void DisplayProductList(List<ProductModel> products)
        {
            FLPanelProductList.Controls.Clear();
            if (products != null)
            {
                foreach (var prod in products)
                {
                    var prodItemControl = new ProductItemControl(prod, _otherSettings);
                    prodItemControl.ClickThisProduct += HandleClickProductItem;
                    FLPanelProductList.Controls.Add(prodItemControl);
                }
            }
        }


        private void BtnRefreshProductList_Click(object sender, EventArgs e)
        {
            this.LblCurrentProductCategory.Text = "ALL";
            this.TbxSearchProducts.Text = "";
            DisplayProductList(this.Products);
        }


        private void TbxSearchProducts_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.Products != null && string.IsNullOrWhiteSpace(TbxSearchProducts.Text) == false)
                {
                    var searchResults = this.Products.Where(x =>
                                                x.ProdName
                                                .ToLower()
                                                .Contains(TbxSearchProducts.Text.ToLower())
                                               ).ToList();

                    DisplayProductList(searchResults);
                }
            }
        }

        private void HandleClickProductItem(object sender, EventArgs e)
        {
            ProductItemControl productItemControl = (ProductItemControl)sender;

            if (productItemControl != null && productItemControl.Product != null)
            {
                FrmEnterProductQuantity frmEnterProductQuantity = new(productItemControl.Product, _otherSettings);
                frmEnterProductQuantity.ShowDialog();

                if (frmEnterProductQuantity.IsCancelled == false)
                {
                    MessageBox.Show(frmEnterProductQuantity.Quantity.ToString());
                }
                
            }
        }

        public void DisplayProductCategoryList(List<ProductCategoryModel> categories)
        {
            FLPanelProductCategories.Controls.Clear();
            if (categories != null)
            {
                foreach(var category in categories)
                {
                    var btnCategoryControl = new BtnProductCategoryControl(category);
                    btnCategoryControl.ClickThisCategoryButton += HandleClickProductCategoryItem;
                    FLPanelProductCategories.Controls.Add(btnCategoryControl);
                }
            }
        }


        private void HandleClickProductCategoryItem(object sender, EventArgs e)
        {
            BtnProductCategoryControl btnProductCategoryControl = (BtnProductCategoryControl)sender;

            if (btnProductCategoryControl != null && btnProductCategoryControl.ProductCategory != null)
            {
                long selectedCategoryId = btnProductCategoryControl.ProductCategory.Id;

                this.LblCurrentProductCategory.Text = btnProductCategoryControl.ProductCategory.ProdCategory;

                var products = this.Products.Where(x => x.CategoryId == selectedCategoryId).ToList();
                DisplayProductList(products);
            }
        }



        public void DisplayComboMealList(List<ComboMealModel> comboMeals)
        {
            this.FlowLayoutComboMealItems.Controls.Clear();
            if (comboMeals != null)
            {
                foreach(var meal in comboMeals)
                {
                    var comboMealItemControl = new ComboMealItemControl(meal, _otherSettings);
                    comboMealItemControl.ClickThisComboMeal += HandleClickComboMealItem;
                    comboMealItemControl.ClickThisComboMeal += DisplayFormToEnterQuantityAndAddInCartComboMeal;
                    this.FlowLayoutComboMealItems.Controls.Add(comboMealItemControl);
                }
            }
        }

        public void DisplayFormToEnterQuantityAndAddInCartComboMeal(object sender, EventArgs e)
        {
            ComboMealItemControl comboMealItemObj = (ComboMealItemControl)sender;

            if (comboMealItemObj != null && comboMealItemObj.ComboMeal != null)
            {
                FrmEnterComboMealQuantity frmEnterComboMealQuantity = new(comboMealItemObj.ComboMeal, _otherSettings);
                frmEnterComboMealQuantity.ShowDialog();
                
                if(frmEnterComboMealQuantity.IsCancelled == false)
                {
                    MessageBox.Show(frmEnterComboMealQuantity.Quantity.ToString());
                }
            }
        }


        private void HandleClickComboMealItem(object sender, EventArgs e)
        {
            ComboMealItemControl comboMealItemObj = (ComboMealItemControl)sender;

            if (comboMealItemObj != null && comboMealItemObj.ComboMeal != null)
            {
                long selectedComboMealId = comboMealItemObj.ComboMeal.Id;

                DisplayComboMealProducts(comboMealItemObj.ComboMeal);
            }
        }


        private void DisplayComboMealProducts (ComboMealModel comboMealItem)
        {
            this.LVComboMealProducts.Items.Clear();
            if (comboMealItem.Products != null)
            {
                foreach (var prod in comboMealItem.Products)
                {
                    string[] item = new string[] { prod.Product.ProdName, prod.Product.PricePerOrder.ToString("0.##") };

                    var listViewItem = new ListViewItem(item);
                    listViewItem.Tag = prod;

                    this.LVComboMealProducts.Items.Add(listViewItem);
                }
            }
        }


        private void BtnRefreshComboMealItems_Click(object sender, EventArgs e)
        {
            this.TboxSearchComboMeals.Text = "";
            this.LVComboMealProducts.Items.Clear();
            DisplayComboMealList(this.ComboMeals);
        }

        private void TboxSearchComboMeals_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter &&
                this.ComboMeals != null && 
                string.IsNullOrWhiteSpace(TboxSearchComboMeals.Text) == false)
            {
                var searchResults = this.ComboMeals.Where(x =>
                                                x.Title
                                                .ToLower()
                                                .Contains(TboxSearchComboMeals.Text.ToLower())
                                              ).ToList();

                this.LVComboMealProducts.Items.Clear();
                DisplayComboMealList(searchResults);
            }
        }

        private void SetDGVCartItemsFontAndColors()
        {
            this.DGVCartItems.BackgroundColor = Color.White;
            this.DGVCartItems.DefaultCellStyle.Font = new Font("Century Gothic", 11);
            this.DGVCartItems.RowHeadersVisible = false;
            this.DGVCartItems.RowTemplate.Height = 35;
            this.DGVCartItems.RowTemplate.Resizable = DataGridViewTriState.True;
            this.DGVCartItems.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVCartItems.AllowUserToResizeRows = false;
            this.DGVCartItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVCartItems.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVCartItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVCartItems.MultiSelect = false;
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
