using DataAccess.Data.InventoryManagement.Contracts;
using EntitiesShared;
using EntitiesShared.InventoryManagement;
using EntitiesShared.POSManagement;
using EntitiesShared.POSManagement.CustomModels;
using Main.Controllers.POSControllers.ControllerInterface;
using Main.Forms.POSManagementForms.Controls;
using Microsoft.Extensions.Options;
using Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.POSManagementForms
{
    public partial class FrmMainPOSTerminal : Form
    {
        private readonly IProductData _productData;
        private readonly IComboMealData _comboMealData;
        private readonly IProductCategoryData _productCategoryData;
        private readonly IPOSCommandController _iPOSCommandController;
        private readonly IPOSReadController _pOSReadController;
        private readonly OtherSettings _otherSettings;

        public FrmMainPOSTerminal(IProductData productData,
                                IComboMealData comboMealData,
                                IProductCategoryData productCategoryData,
                                IPOSCommandController iPOSCommandController,
                                IPOSReadController pOSReadController,
                                IOptions<OtherSettings> otherSettings)
        {
            InitializeComponent();
            _productData = productData;
            _comboMealData = comboMealData;
            _productCategoryData = productCategoryData;
            _iPOSCommandController = iPOSCommandController;
            _pOSReadController = pOSReadController;
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


        private List<TableStatusModel> _tableStatuses;

        public List<TableStatusModel> TableStatus
        {
            get { return _tableStatuses; }
            set { _tableStatuses = value; }
        }

        private SaleTransactionModel _currentSaleTransaction = new SaleTransactionModel();

        public SaleTransactionModel CurrentSaleTransaction
        {
            get { return _currentSaleTransaction; }
            set { _currentSaleTransaction = value; }
        }

        POSControllerControl pOSControllerControl;

        private void FrmMainPOSTerminal_Load(object sender, EventArgs e)
        {
            SetDGVCartItemsFontAndColors();
            this.Products = _productData.GetAllNotDeleted();
            this.ProductCategories = _productCategoryData.GetAllNotDeleted();
            this.ComboMeals = _comboMealData.GetAllNotDeleted();
            //this.TableStatus = _pOSReadController.GetTableStatus();

            DisplayProductList(this.Products);
            DisplayProductCategoryList(this.ProductCategories);
            DisplayComboMealList(this.ComboMeals);

            this.LblCurrentProductCategory.Text = "ALL";

            // initialize controls
            InitializePOSControllerControl();
            InitializeTotalAndReceiptPreviewControl();
        }

        public void InitializePOSControllerControl()
        {
            this.PanelPOSController.Controls.Clear();
            this.pOSControllerControl = new(_iPOSCommandController, _pOSReadController);
            //pOSControllerControl.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;
            this.pOSControllerControl.Dock = DockStyle.Fill;
            this.pOSControllerControl.NewTransactionInitiated += HandleOnNewTransactionInitiated;
            this.pOSControllerControl.ViewDineInTransDetails += HandleOnViewDineInTransDetails;

            this.PanelPOSController.Controls.Add(this.pOSControllerControl);
        }

        private void HandleOnNewTransactionInitiated(object sender, EventArgs e)
        {
            POSControllerControl pOSControllerControl = (POSControllerControl)sender;

            // set newly created sale transaction object
            this.CurrentSaleTransaction = pOSControllerControl.CurrentSaleTransaction;
        }

        private void HandleOnViewDineInTransDetails(object sender, EventArgs e)
        {
            DisplayCurrentSaleTransactionProductsInCartDGV(this.pOSControllerControl.CurrentSaleTransactionProducts);
        }


        // Total and receip preview control
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

                if (frmEnterProductQuantity.IsCancelled == false && frmEnterProductQuantity.Product != null)
                {
                    var existingProdInCart = this.pOSControllerControl.CurrentSaleTransactionProducts
                                                        .Where(x => x.ProductId == frmEnterProductQuantity.Product.Id)
                                                        .FirstOrDefault();

                    if (existingProdInCart == null)
                    {
                        var newProductRef = JsonSerializer.Deserialize<ProductModel>(JsonSerializer.Serialize(frmEnterProductQuantity.Product));

                        this.pOSControllerControl.CurrentSaleTransactionProducts.Add(new SaleTransactionProductModel
                        {
                            ProductId = newProductRef.Id,
                            Qty = frmEnterProductQuantity.Quantity,
                            productCurrentPrice = newProductRef.PricePerOrder,
                            Product = newProductRef,
                            totalAmount = (frmEnterProductQuantity.Quantity * newProductRef.PricePerOrder)
                        });
                    }
                    else
                    {
                        existingProdInCart.Qty += frmEnterProductQuantity.Quantity;
                        existingProdInCart.totalAmount = (existingProdInCart.Qty * existingProdInCart.productCurrentPrice);

                    }


                    DisplayCurrentSaleTransactionProductsInCartDGV(this.pOSControllerControl.CurrentSaleTransactionProducts);

                    //MessageBox.Show(.ToString());
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


        public void DisplayCurrentSaleTransactionProductsInCartDGV(List<SaleTransactionProductModel> products)
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

                foreach (var item in products)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGVCartItems);
                    row.Height = 35;

                    row.Cells[0].Value = item.Id;
                    row.Cells[1].Value = item.Product.ProdName;
                    row.Cells[2].Value = item.productCurrentPrice;
                    row.Cells[3].Value = item.Qty;
                    row.Cells[4].Value = item.totalAmount;

                    DGVCartItems.Rows.Add(row);
                }
            }
        }

        private void POSMainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tables tab
            if (POSMainTabControl.SelectedTab == POSMainTabControl.TabPages[1])
            {
                this.TableStatus = _pOSReadController.GetTableStatus();
                DisplayTableStatus(this.TableStatus);
            }
        }

        public void DisplayTableStatus(List<TableStatusModel> tableStatus)
        {
            this.FlowLayoutTables.Controls.Clear();
            foreach (var table in tableStatus)
            {
                var tableItemControl = new RestaurantTableItemControl()
                {
                    IsOccupied = table.Status == StaticData.TableStatus.Occupied,
                    TableNumber = table.TableNumber,
                    TableTitle = table.TableTitle
                };

                this.FlowLayoutTables.Controls.Add(tableItemControl);
            }
        }

    }
}
