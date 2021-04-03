using EntitiesShared;
using EntitiesShared.InventoryManagement;
using Main.Controllers.InventoryControllers;
using Main.FormModels;
using Shared.CustomModels;
using Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.InventoryManagementForms.Controls
{
    public partial class ProductInventoryControl : UserControl
    {
        public ProductInventoryControl(UOMConverter uOMConverter,
                            IIngredientInventoryManager ingredientInventoryManager)
        {
            InitializeComponent();
            _uOMConverter = uOMConverter;
            _ingredientInventoryManager = ingredientInventoryManager;
        }

        private readonly UOMConverter _uOMConverter;
        private readonly IIngredientInventoryManager _ingredientInventoryManager;

        private void ProductInventoryControl_Load(object sender, EventArgs e)
        {
            SetDGVProrductCategoriesFontAndColors();
            SetDGVIngredientListToSelectFontAndColors();
            SetDGVSelectedIngredientsFontAndColors();
            SetDGVProductListAndDGVProductExistingIngredientsFontAndColors();

            SetDGVSelectedIngredientsColumns();

            DisplayProductCategoriesInDGV();
            DisplayExistingProductsInDGV(this.ExistingProducts);
            DisplayIngredientInDGV(Ingredients);


            this.PropertyIsIsNewProductChanged += OnisNewProductUpdate;

        }

        private void SetDGVProrductCategoriesFontAndColors()
        {
            this.DGVProrductCategories.BackgroundColor = Color.White;
            this.DGVProrductCategories.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVProrductCategories.RowHeadersVisible = false;
            this.DGVProrductCategories.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVProrductCategories.AllowUserToResizeRows = false;
            this.DGVProrductCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVProrductCategories.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVProrductCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVProrductCategories.MultiSelect = false;

            this.DGVProrductCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVProrductCategories.ColumnHeadersHeight = 30;
        }

        private List<ProductCategoryModel> _productCategories;

        public List<ProductCategoryModel> ProductCategories
        {
            get { return _productCategories; }
            set { _productCategories = value; }
        }

        private ProductCategoryModel productCategoryToAddUpdate;

        public ProductCategoryModel ProductCategoryToAddUpdate
        {
            get { return productCategoryToAddUpdate; }
            set { productCategoryToAddUpdate = value; }
        }

        public int SelectedProductCategoryId { get; set; }

        public bool IsNewProductCategory { get; set; } = true;

        public event EventHandler ProductCategorySave;
        protected virtual void OnProductCategorySave(EventArgs e)
        {
            ProductCategorySave?.Invoke(this, e);
        }

        public void ResetProductCategoryForm()
        {
            this.TbxCategory.Text = "";
            this.BtnCancelUpdateCategory.Visible = false;
            this.GBoxIngredeitnCategoryForm.Text = "Add new";
            this.IsNewProductCategory = true;
            this.ProductCategoryToAddUpdate = null;
            this.SelectedProductCategoryId = 0;
        }


        private void BtnSaveCategory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.TbxCategory.Text))
                return;

            if (this.IsNewProductCategory == true)
            {
                this.ProductCategoryToAddUpdate = new ProductCategoryModel
                {
                    ProdCategory = this.TbxCategory.Text
                };
            }
            else
            {
                this.ProductCategoryToAddUpdate.ProdCategory = this.TbxCategory.Text;
            }

            OnProductCategorySave(EventArgs.Empty);
        }


        public void DisplayProductCategoriesInDGV()
        {
            DisplayIngredientsInCbox(); // We put it here so we can also update the combox when the user update or delete category

            this.DGVProrductCategories.Rows.Clear();
            if (this.ProductCategories != null)
            {
                this.DGVProrductCategories.ColumnCount = 3;

                this.DGVProrductCategories.Columns[0].Name = "CategoryId";
                this.DGVProrductCategories.Columns[0].Visible = false;

                this.DGVProrductCategories.Columns[1].Name = "Category";
                this.DGVProrductCategories.Columns[1].HeaderText = "Category";

                this.DGVProrductCategories.Columns[2].Name = "CreatedAt";
                this.DGVProrductCategories.Columns[2].HeaderText = "Created At";

                // Update button
                DataGridViewImageColumn btnUpdateImg = new DataGridViewImageColumn();
                //btnUpdateLeaveTypeImg.Name = "";
                btnUpdateImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnUpdateImg.Image = Image.FromFile("./Resources/edit-24.png");
                this.DGVProrductCategories.Columns.Add(btnUpdateImg);


                // Delete button
                DataGridViewImageColumn btnDeleteImg = new DataGridViewImageColumn();
                //btnDeleteLeaveTypeImg.Name = "";
                btnDeleteImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnDeleteImg.Image = Image.FromFile("./Resources/remove-24.png");
                this.DGVProrductCategories.Columns.Add(btnDeleteImg);

                foreach (var category in this.ProductCategories)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVProrductCategories);

                    row.Cells[0].Value = category.Id;
                    row.Cells[1].Value = category.ProdCategory;
                    row.Cells[2].Value = category.CreatedAt.ToShortDateString();

                    this.DGVProrductCategories.Rows.Add(row);
                }
            }

        }


        public void DisplayIngredientsInCbox()
        {
            this.CboxCategories.Items.Clear();

            if (this.ProductCategories != null)
            {
                ComboboxItem item;
                foreach (var category in this.ProductCategories)
                {
                    item = new ComboboxItem();
                    item.Text = category.ProdCategory;
                    item.Value = category.Id;

                    this.CboxCategories.Items.Add(item);
                }
            }

            this.CboxCategoryForFilteringProducts.Items.Clear();

            if (this.ProductCategories != null)
            {
                ComboboxItem item;
                foreach (var category in this.ProductCategories)
                {
                    item = new ComboboxItem();
                    item.Text = category.ProdCategory;
                    item.Value = category.Id;

                    this.CboxCategoryForFilteringProducts.Items.Add(item);
                }
            }
        }

        public int SelectedCategoryId { get; set; }
        //public event EventHandler SelectCategoryToUpdate;
        //protected virtual void OnSelectCategoryToUpdate(EventArgs e)
        //{
        //    SelectCategoryToUpdate?.Invoke(this, e);
        //}

        public event EventHandler SelectCategoryToDelete;
        protected virtual void OnSelectCategoryToDelete(EventArgs e)
        {
            SelectCategoryToDelete?.Invoke(this, e);
        }

        public void DisplaySelectedCategoryDetails()
        {
            if (this.ProductCategoryToAddUpdate != null)
            {
                this.TbxCategory.Text = this.ProductCategoryToAddUpdate.ProdCategory;
            }
        }

        private void DGVProrductCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Update button
            if ((e.ColumnIndex == 3) && e.RowIndex > -1)
            {
                if (DGVProrductCategories.CurrentRow != null && this.ProductCategories != null)
                {
                    string categoryId = DGVProrductCategories.CurrentRow.Cells[0].Value.ToString();

                    SelectedCategoryId = int.Parse(categoryId);

                    this.BtnCancelUpdateCategory.Visible = true;
                    this.IsNewProductCategory = false;

                    this.ProductCategoryToAddUpdate = this.ProductCategories.Where(x => x.Id == SelectedCategoryId).FirstOrDefault();
                    DisplaySelectedCategoryDetails();

                    //OnSelectCategoryToUpdate(EventArgs.Empty);
                }
            }

            // Delete button
            if ((e.ColumnIndex == 4) && e.RowIndex > -1)
            {
                if (DGVProrductCategories.CurrentRow != null)
                {
                    string categoryId = DGVProrductCategories.CurrentRow.Cells[0].Value.ToString();
                    SelectedCategoryId = int.Parse(categoryId);
                    OnSelectCategoryToDelete(EventArgs.Empty);
                }
            }
        }

        private void BtnCancelUpdateCategory_Click(object sender, EventArgs e)
        {
            this.ResetProductCategoryForm();
        }




        // ###################################################################


        private void SetDGVProductListAndDGVProductExistingIngredientsFontAndColors()
        {
            this.DGVProductList.BackgroundColor = Color.White;
            this.DGVProductList.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVProductList.RowHeadersVisible = false;
            this.DGVProductList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVProductList.AllowUserToResizeRows = false;
            this.DGVProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVProductList.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVProductList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVProductList.MultiSelect = false;

            this.DGVProductList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVProductList.ColumnHeadersHeight = 30;


            // --------------------------------

            this.DGVProductExistingIngredients.BackgroundColor = Color.White;
            this.DGVProductExistingIngredients.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVProductExistingIngredients.RowHeadersVisible = false;
            this.DGVProductExistingIngredients.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVProductExistingIngredients.AllowUserToResizeRows = false;
            this.DGVProductExistingIngredients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVProductExistingIngredients.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVProductExistingIngredients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVProductExistingIngredients.MultiSelect = false;

            this.DGVProductExistingIngredients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVProductExistingIngredients.ColumnHeadersHeight = 30;
        }



        private List<ProductModel> _existingProducts;

        public List<ProductModel> ExistingProducts
        {
            get { return _existingProducts; }
            set { _existingProducts = value; }
        }

        private List<ProductIngredientModel> _existingProductIngredients;

        public List<ProductIngredientModel> ExistingProductIngredients
        {
            get { return _existingProductIngredients; }
            set { _existingProductIngredients = value; }
        }


        public void DisplayExistingProductsInDGV(List<ProductModel> products)
        {
            this.DGVProductList.Rows.Clear();

            if (products != null)
            {
                this.DGVProductList.ColumnCount = 4;

                this.DGVProductList.Columns[0].Name = "ProductId";
                this.DGVProductList.Columns[0].Visible = false;

                this.DGVProductList.Columns[1].Name = "Category";
                this.DGVProductList.Columns[1].HeaderText = "Category";

                this.DGVProductList.Columns[2].Name = "ProductName";
                this.DGVProductList.Columns[2].HeaderText = "Name";

                this.DGVProductList.Columns[3].Name = "PricePerOrder";
                this.DGVProductList.Columns[3].HeaderText = "Price per order";

                // Update button
                DataGridViewImageColumn btnUpdateImg = new DataGridViewImageColumn();
                //btnUpdateLeaveTypeImg.Name = "";
                btnUpdateImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnUpdateImg.Image = Image.FromFile("./Resources/edit-24.png");
                this.DGVProductList.Columns.Add(btnUpdateImg);

                foreach (var product in products)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVProductList);

                    row.Cells[0].Value = product.Id;
                    row.Cells[0].ReadOnly = true;

                    row.Cells[1].Value = product.Category.ProdCategory;
                    row.Cells[1].ReadOnly = true;

                    row.Cells[2].Value = product.ProdName;
                    row.Cells[2].ReadOnly = true;

                    row.Cells[3].Value = product.PricePerOrder;
                    row.Cells[3].ReadOnly = true;

                    this.DGVProductList.Rows.Add(row);
                }
            }
        }


        public void DisplayProductsExistingIngredientsInDGV()
        {
            this.DGVProductExistingIngredients.Rows.Clear();

            if (this.ExistingProductIngredients != null)
            {
                this.DGVProductExistingIngredients.ColumnCount = 5;

                this.DGVProductExistingIngredients.Columns[0].Name = "ProductIngredientId";
                this.DGVProductExistingIngredients.Columns[0].Visible = false;

                this.DGVProductExistingIngredients.Columns[1].Name = "IngredientName";
                this.DGVProductExistingIngredients.Columns[1].HeaderText = "IngredientName";

                this.DGVProductExistingIngredients.Columns[2].Name = "UOM";
                this.DGVProductExistingIngredients.Columns[2].HeaderText = "UOM";

                this.DGVProductExistingIngredients.Columns[3].Name = "QtyValue";
                this.DGVProductExistingIngredients.Columns[3].HeaderText = "Qty value";

                this.DGVProductExistingIngredients.Columns[4].Name = "Cost";
                this.DGVProductExistingIngredients.Columns[4].HeaderText = "Cost";

                decimal totalCost = 0;

                foreach (var ingredient in ExistingProductIngredients)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVProductExistingIngredients);

                    row.Cells[0].Value = ingredient.Id;
                    row.Cells[0].ReadOnly = true;

                    row.Cells[1].Value = ingredient.Ingredient.IngName;
                    row.Cells[1].ReadOnly = true;

                    row.Cells[2].Value = ingredient.UOM;
                    row.Cells[2].ReadOnly = true;

                    row.Cells[3].Value = ingredient.QtyValue;
                    row.Cells[3].ReadOnly = true;

                    decimal tempCost = _ingredientInventoryManager.GetProductIngredientCost(ingredient.IngredientId, ingredient.QtyValue, ingredient.UOM);
                    totalCost += tempCost;

                    row.Cells[4].Value = tempCost;
                    row.Cells[4].ReadOnly = true;

                    this.DGVProductExistingIngredients.Rows.Add(row);
                }

                this.LblTotalCostOfIngredients.Text = totalCost.ToString("0.##");
            }
        }

        public int SelectedExistingProductId { get; set; }

        public event EventHandler GetProductExistingIngredients;
        protected virtual void OnGetProductExistingIngredients(EventArgs e)
        {
            GetProductExistingIngredients?.Invoke(this, e);
        }

        public event EventHandler GetProductDetailsAndDispalyInForm;
        protected virtual void OnGetProductDetailsAndDispalyInForm(EventArgs e)
        {
            GetProductDetailsAndDispalyInForm?.Invoke(this, e);
        }

        private void DGVProductList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (DGVProductList.CurrentRow != null && this.ExistingProducts != null)
                {
                    SelectedExistingProductId = int.Parse(DGVProductList.CurrentRow.Cells[0].Value.ToString());
                    OnGetProductExistingIngredients(EventArgs.Empty);
                }
            }

            //Update button
            if ((e.ColumnIndex == 4) && e.RowIndex > -1)
            {
                if (DGVProductList.CurrentRow != null && this.ProductCategories != null)
                {
                    SelectedExistingProductId = int.Parse(DGVProductList.CurrentRow.Cells[0].Value.ToString());
                    OnGetProductDetailsAndDispalyInForm(EventArgs.Empty);
                }
            }
        }

        // ###################################################################

        private List<IngredientModel> _ingredients;
        public List<IngredientModel> Ingredients
        {
            get { return _ingredients; }
            set { _ingredients = value; }
        }

        private Dictionary<int, IngredientModel> selectedIngredients = new Dictionary<int, IngredientModel>();

        public Dictionary<int, IngredientModel> SelectedIngredients
        {
            get { return selectedIngredients; }
            set { selectedIngredients = value; }
        }

        private void SetDGVIngredientListToSelectFontAndColors()
        {
            this.DGVIngredientListToSelect.BackgroundColor = Color.White;
            this.DGVIngredientListToSelect.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVIngredientListToSelect.RowHeadersVisible = false;
            this.DGVIngredientListToSelect.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVIngredientListToSelect.AllowUserToResizeRows = false;
            this.DGVIngredientListToSelect.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVIngredientListToSelect.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVIngredientListToSelect.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVIngredientListToSelect.MultiSelect = false;

            this.DGVIngredientListToSelect.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVIngredientListToSelect.ColumnHeadersHeight = 30;
        }

        private void SetDGVSelectedIngredientsFontAndColors()
        {
            this.DGVSelectedIngredients.BackgroundColor = Color.White;
            this.DGVSelectedIngredients.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVSelectedIngredients.RowHeadersVisible = false;
            this.DGVSelectedIngredients.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVSelectedIngredients.AllowUserToResizeRows = false;
            this.DGVSelectedIngredients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVSelectedIngredients.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            //this.DGVSelectedIngredients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVSelectedIngredients.MultiSelect = false;

            this.DGVSelectedIngredients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVSelectedIngredients.ColumnHeadersHeight = 30;
        }



        public void DisplayIngredientInDGV(List<IngredientModel> Ingredients)
        {
            this.DGVIngredientListToSelect.Rows.Clear();
            if (Ingredients != null)
            {
                this.DGVIngredientListToSelect.ColumnCount = 5;

                this.DGVIngredientListToSelect.Columns[0].Name = "IngredientId";
                this.DGVIngredientListToSelect.Columns[0].Visible = false;

                this.DGVIngredientListToSelect.Columns[1].Name = "Ingredient";
                this.DGVIngredientListToSelect.Columns[1].HeaderText = "Ingredient";

                this.DGVIngredientListToSelect.Columns[2].Name = "Category";
                this.DGVIngredientListToSelect.Columns[2].HeaderText = "Category";

                this.DGVIngredientListToSelect.Columns[3].Name = "UOM";
                this.DGVIngredientListToSelect.Columns[3].HeaderText = "UOM";

                this.DGVIngredientListToSelect.Columns[4].Name = "QtyValue";
                this.DGVIngredientListToSelect.Columns[4].HeaderText = "Rem. Qty Value";

                DataGridViewCheckBoxColumn selectChbx = new DataGridViewCheckBoxColumn();
                selectChbx.HeaderText = "Select";
                selectChbx.Name = "selectIngredientCkbox";
                selectChbx.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                selectChbx.ReadOnly = false;
                this.DGVIngredientListToSelect.Columns.Add(selectChbx);

                //// Delete button
                //DataGridViewImageColumn btnDeleteImg = new DataGridViewImageColumn();
                ////btnDeleteLeaveTypeImg.Name = "";
                //btnDeleteImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //btnDeleteImg.Image = Image.FromFile("./Resources/icons8-plus-24.png");
                //this.DGVIngredientListToSelect.Columns.Add(btnDeleteImg);

                foreach (var ing in Ingredients)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVIngredientListToSelect);

                    row.Cells[0].Value = ing.Id;
                    row.Cells[0].ReadOnly = true;

                    row.Cells[1].Value = ing.IngName;
                    row.Cells[1].ReadOnly = true;

                    row.Cells[2].Value = ing.Category.Category;
                    row.Cells[2].ReadOnly = true;

                    row.Cells[3].Value = ing.UOM;
                    row.Cells[3].ReadOnly = true;

                    row.Cells[4].Value = this.GetUOMFormatted(ing.UOM, ing.RemainingQtyValue);
                    row.Cells[4].ReadOnly = true;



                    this.DGVIngredientListToSelect.Rows.Add(row);
                }

                if (this.SelectedIngredients.Count > 0)
                {
                    foreach (DataGridViewRow row in this.DGVIngredientListToSelect.Rows)
                    {
                        int ingredientIdTemp = int.Parse(row.Cells["IngredientId"].Value.ToString());
                        if (this.SelectedIngredients.ContainsKey(ingredientIdTemp))
                        {
                            row.Cells["selectIngredientCkbox"].Value = (bool)true;
                        }
                    }
                }

            }
        }

        public void UncheckSelectedProductsInDGV()
        {
            foreach (DataGridViewRow row in this.DGVIngredientListToSelect.Rows)
            {
                row.Cells["selectIngredientCkbox"].Value = (bool)false;
            }
        }

        public string GetUOMFormatted(StaticData.UOM uom, decimal qtyValue)
        {
            string uomFormatted = "";

            switch (uom)
            {
                case StaticData.UOM.kg:
                    uomFormatted = _uOMConverter.gram_to_kg_format(qtyValue);
                    break;

                case StaticData.UOM.L:
                    uomFormatted = _uOMConverter.ml_to_L_format(qtyValue);
                    break;

                case StaticData.UOM.pcs:
                    uomFormatted = _uOMConverter.pc_format(qtyValue);
                    break;
                default:
                    uomFormatted = "0";
                    break;
            }

            return uomFormatted;
        }

        public string[] GetUOMSmallAndBig (StaticData.UOM uom)
        {
            var uomList = new string[] { };

            switch (uom)
            {
                case StaticData.UOM.kg:

                    uomList = new string[] { StaticData.UOM.kg.ToString(), StaticData.UOM.g.ToString() };
                    break;

                case StaticData.UOM.L:
                    uomList = new string[] { StaticData.UOM.L.ToString(), StaticData.UOM.ml.ToString() };

                    break;

                case StaticData.UOM.pcs:
                    uomList = new string[] { StaticData.UOM.pcs.ToString() , StaticData.UOM.pc.ToString() };
                    break;

                default:
                    break;
            }

            return uomList;
        }

        public void SetDGVSelectedIngredientsColumns()
        {
            this.DGVSelectedIngredients.ColumnCount = 4;

            this.DGVSelectedIngredients.Columns[0].Name = "IngredientId";
            this.DGVSelectedIngredients.Columns[0].Visible = false;

            this.DGVSelectedIngredients.Columns[1].Name = "Ingredient";
            this.DGVSelectedIngredients.Columns[1].HeaderText = "Ingredient";

            this.DGVSelectedIngredients.Columns[2].Name = "QtyValue";
            this.DGVSelectedIngredients.Columns[2].HeaderText = "Rem. Qty Value";

            this.DGVSelectedIngredients.Columns[3].Name = "UOM";
            this.DGVSelectedIngredients.Columns[3].HeaderText = "UOM";


            // Delete button
            DataGridViewImageColumn btnDeleteImg = new DataGridViewImageColumn();
            //btnDeleteLeaveTypeImg.Name = "";
            btnDeleteImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            btnDeleteImg.Image = Image.FromFile("./Resources/remove-24.png");
            btnDeleteImg.ReadOnly = false;
            this.DGVSelectedIngredients.Columns.Add(btnDeleteImg);

            DataGridViewComboBoxColumn newColumn = new DataGridViewComboBoxColumn();
            newColumn.Name = "UOMToUse";
            this.DGVSelectedIngredients.Columns.Add(newColumn);

            //DataGridViewTextBoxColumn textboxColumn = new DataGridViewTextBoxColumn();

            NumericUpDownColumn numTextBox = new NumericUpDownColumn();
            numTextBox.HeaderText = "Amount";
            numTextBox.Name = "selectedIngredientAmount";
            numTextBox.DefaultCellStyle.BackColor = Color.Bisque;
            numTextBox.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            numTextBox.ReadOnly = false;
            DGVSelectedIngredients.Columns.Add(numTextBox);


            DataGridViewTextBoxColumn textboxColumn = new DataGridViewTextBoxColumn();
            textboxColumn.HeaderText = "Cost";
            textboxColumn.Name = "TotalCost";
            textboxColumn.DefaultCellStyle.BackColor = Color.Bisque;
            textboxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            textboxColumn.ReadOnly = true;
            DGVSelectedIngredients.Columns.Add(textboxColumn);
        }


        public void AddIngredientInDGVSelectedIngredients(IngredientModel ingredient, StaticData.UOM? uomToUseDefaultValue = null, decimal defaultQtyValue = 0)
        {
            if (ingredient != null)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.DGVSelectedIngredients);

                row.Cells[0].Value = ingredient.Id;
                row.Cells[0].ReadOnly = true;

                row.Cells[1].Value = ingredient.IngName;
                row.Cells[1].ReadOnly = true;

                row.Cells[2].Value = this.GetUOMFormatted(ingredient.UOM, ingredient.RemainingQtyValue);
                row.Cells[2].ReadOnly = true;

                row.Cells[3].Value = ingredient.UOM;
                row.Cells[3].ReadOnly = true;

                this.DGVSelectedIngredients.Rows.Add(row);

                DataGridViewComboBoxCell UOMToUseCell = (DataGridViewComboBoxCell)(row.Cells["UOMToUse"]);
                UOMToUseCell.DataSource = this.GetUOMSmallAndBig(ingredient.UOM);
                
                if (uomToUseDefaultValue != null)
                {
                    UOMToUseCell.Value = uomToUseDefaultValue.ToString();
                }

                NumericUpDownCell qtyValue = (NumericUpDownCell)(row.Cells["selectedIngredientAmount"]);
                qtyValue.Value = defaultQtyValue;
            }
        }


        private void DGVIngredientListToSelect_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            if ((e.ColumnIndex == this.DGVIngredientListToSelect.CurrentRow.Cells["selectIngredientCkbox"].ColumnIndex) && e.RowIndex > -1)
            {
                DataGridViewCheckBoxCell cell = this.DGVIngredientListToSelect.CurrentCell as DataGridViewCheckBoxCell;

                if (cell != null && !cell.ReadOnly)
                {
                    cell.Value = cell.Value == null || !((bool)cell.Value);
                    this.DGVIngredientListToSelect.RefreshEdit();
                    this.DGVIngredientListToSelect.NotifyCurrentCellDirty(true);
                }

                bool isSelected = Convert.ToBoolean(this.DGVIngredientListToSelect.CurrentRow.Cells["selectIngredientCkbox"].Value);
                int ingredientId = int.Parse(this.DGVIngredientListToSelect.CurrentRow.Cells["IngredientId"].Value.ToString());

                if (isSelected)
                {
                    var ingredient = this.Ingredients.Where(x => x.Id == ingredientId).FirstOrDefault();

                    if (this.SelectedIngredients.ContainsKey(ingredientId) == false)
                    {
                        this.SelectedIngredients.Add(ingredientId, ingredient);

                        AddIngredientInDGVSelectedIngredients(ingredient);
                    }
                }
                else
                {
                    if (this.SelectedIngredients.ContainsKey(ingredientId))
                    {
                        if (this.SelectedIngredients.Remove(ingredientId))
                        {
                            foreach (DataGridViewRow row in this.DGVSelectedIngredients.Rows)
                            {
                                int tempIngredientId = int.Parse(row.Cells["IngredientId"].Value.ToString());

                                if (tempIngredientId == ingredientId)
                                {
                                    this.DGVSelectedIngredients.Rows.RemoveAt(row.Index);
                                }
                            }

                            // Marking existing ingredient if on update transaction
                            MarkAsDeletedExistingIngredientIfUpdate(ingredientId);
                        }
                    }
                }

                this.LblNumberOfSelectedIngredients.Text = this.SelectedIngredients.Count().ToString();
            }
              
        }

        public void RefreshDGVSelectedIngredientsToComputeTotalCost()
        {
            decimal totalCost = 0;
            foreach (DataGridViewRow row in this.DGVSelectedIngredients.Rows)
            {
                if (row.Cells["UOMToUse"].Value != null)
                {
                    int ingredientId = int.Parse(row.Cells["IngredientId"].Value.ToString());
                    decimal qtyValue = decimal.Parse(row.Cells["selectedIngredientAmount"].Value.ToString());
                    var selectedUOM = (StaticData.UOM)Enum.Parse(typeof(StaticData.UOM), row.Cells["UOMToUse"].Value.ToString());

                    decimal cost = _ingredientInventoryManager.GetProductIngredientCost(ingredientId, qtyValue, selectedUOM);
                    totalCost += cost;

                    row.Cells["TotalCost"].Value = cost;
                }
            }

            this.LblTotalCostFromAddingNewProduct.Text = totalCost.ToString("0.##");
        }

        private void BtnCompute_Click(object sender, EventArgs e)
        {
            RefreshDGVSelectedIngredientsToComputeTotalCost();
        }

        private void DGVIngredientListToSelect_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DGVIngredientListToSelect.RefreshEdit();
        }

        private void DGVSelectedIngredients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 4) && e.RowIndex > -1)
            {
                if (DGVSelectedIngredients.CurrentRow != null)
                {
                    int ingredientId = int.Parse(DGVSelectedIngredients.CurrentRow.Cells[0].Value.ToString());

                    if (this.SelectedIngredients.ContainsKey(ingredientId))
                    {
                        if (this.SelectedIngredients.Remove(ingredientId))
                        {
                            this.DGVSelectedIngredients.Rows.RemoveAt(e.RowIndex);

                            foreach (DataGridViewRow row in this.DGVIngredientListToSelect.Rows)
                            {
                                int ingredientIdTemp = int.Parse(row.Cells["IngredientId"].Value.ToString());

                                if (ingredientIdTemp == ingredientId)
                                {
                                    row.Cells["selectIngredientCkbox"].Value = (bool)false;
                                }
                            }

                            // Marking existing ingredient if on update transaction
                            MarkAsDeletedExistingIngredientIfUpdate(ingredientId);
                        }

                    }
                }

                this.LblNumberOfSelectedIngredients.Text = this.SelectedIngredients.Count().ToString();
            }


            if ((e.ColumnIndex == 6) && e.RowIndex > -1)
            {
                DGVSelectedIngredients.CurrentCell = DGVSelectedIngredients[e.ColumnIndex, e.RowIndex];
                DGVSelectedIngredients.BeginEdit(true);
                string numUpDownVal = DGVSelectedIngredients.CurrentCell.Value != null ? DGVSelectedIngredients.CurrentCell.Value.ToString() : "";
                ((NumericUpDown)DGVSelectedIngredients.EditingControl).Select(0, numUpDownVal.Length);
            }
        }

        private void TboxSearchIngredients_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && string.IsNullOrWhiteSpace(TboxSearchIngredients.Text) == false)
            {
                var searchResults = this.Ingredients.Where(x => x.IngName.Contains(TboxSearchIngredients.Text)).ToList();
                DisplayIngredientInDGV(searchResults);
            }
        }

        private void BtnRefreshIngredientList_Click(object sender, EventArgs e)
        {
            this.TboxSearchIngredients.Text = "";
            DisplayIngredientInDGV(Ingredients);
        }


        private List<ProductIngredientModel> _productSelectedIngredients = new List<ProductIngredientModel>();

        public List<ProductIngredientModel> ProductSelectedIngredients
        {
            get { return _productSelectedIngredients; }
            set { _productSelectedIngredients = value; }
        }

        public void MarkAsDeletedExistingIngredientIfUpdate(int ingredientId)
        {
            if (this.ProductSelectedIngredients != null)
            {
                var existingIngredient = this.ProductSelectedIngredients.Where(x => x.IngredientId == ingredientId).FirstOrDefault();

                if (existingIngredient != null && existingIngredient.Id > 0)
                {
                    existingIngredient.IsDeleted = true;
                    existingIngredient.DeletedAt = DateTime.Now;
                }
            }
        }

        private ProductModel _productToAddUpdate;

        public ProductModel ProductToAddUpdate
        {
            get { return _productToAddUpdate; }
            set { _productToAddUpdate = value; }
        }


        public event PropertyChangedEventHandler PropertyIsIsNewProductChanged;
        private bool isNewProduct = true;

        public bool IsNewProduct
        {
            get { return isNewProduct; }
            set { 
                isNewProduct = value; 
                
                if (PropertyIsIsNewProductChanged != null)
                {
                    PropertyIsIsNewProductChanged(this, new PropertyChangedEventArgs(IsNewProduct.ToString()));
                }
            }
        }


        private void OnisNewProductUpdate(object sender, PropertyChangedEventArgs e)
        { 
            if (IsNewProduct)
            {
                this.BtnCancelSaveProductDetails.Visible = false;
                this.LblNewOrUpdateProductIndicator.Text = "Add New product";
            }
            else
            {
                this.BtnCancelSaveProductDetails.Visible = true;
                this.LblNewOrUpdateProductIndicator.Text = "Update product";
            }
        }

        public event EventHandler ProductSave;
        protected virtual void OnProductSave(EventArgs e)
        {
            ProductSave?.Invoke(this, e);
        }

        private void BtnSaveProductDetails_Click(object sender, EventArgs e)
        {
            if (ProductSelectedIngredients == null)
            {
                ProductSelectedIngredients = new List<ProductIngredientModel>();
            }
            bool isContinueToGenerateData = true;

            if (this.CboxCategories.SelectedIndex < 0)
            {
                MessageBox.Show($"Kindly choose category.", "Product Category", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var selectedCategory = this.CboxCategories.SelectedItem as ComboboxItem;
            int categoryId = int.Parse(selectedCategory.Value.ToString());

            if (string.IsNullOrEmpty(TboxProductName.Text))
            {
                MessageBox.Show($"Provide product name.", "Product name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (NumUpDownPricePerOrder.Value <= 0)
            {
                MessageBox.Show($"Provide price per order.", "Product price per order", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.SelectedIngredients == null)
            {
                MessageBox.Show($"Kindly choose product's ingredients.", "Product's ingredients", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.SelectedIngredients.Count == 0)
            {
                MessageBox.Show($"Kindly choose product's ingredients.", "Product's ingredients", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (DataGridViewRow row in this.DGVSelectedIngredients.Rows)
            {
                int tempIngredientId = int.Parse(row.Cells["IngredientId"].Value.ToString());
                string ingredientNmae = row.Cells["Ingredient"].Value.ToString();
                string uom = row.Cells["UOMToUse"].Value != null ? row.Cells["UOMToUse"].Value.ToString() : "";
                string qtyValueTmp = row.Cells["selectedIngredientAmount"].Value != null ? row.Cells["selectedIngredientAmount"].Value.ToString() : "";

                if (string.IsNullOrEmpty(uom))
                {
                    MessageBox.Show($"Kindly choose unit of measurement for {ingredientNmae}", "Unit of measurement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    isContinueToGenerateData = false;
                    break;
                }

                if (string.IsNullOrEmpty(qtyValueTmp))
                {
                    MessageBox.Show($"Kindly provide quantity value for {ingredientNmae}", "Quantity value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    isContinueToGenerateData = false;
                    break;
                }

                if (decimal.TryParse(qtyValueTmp, out decimal qtyValue))
                {
                    var existingIngredientDetails = ProductSelectedIngredients.Where(x => x.IngredientId == tempIngredientId).FirstOrDefault() ;

                    if (existingIngredientDetails == null)
                    {
                        ProductSelectedIngredients.Add(new ProductIngredientModel
                        {
                            IngredientId = tempIngredientId,
                            UOM = (StaticData.UOM)Enum.Parse(typeof(StaticData.UOM), uom),
                            QtyValue = qtyValue
                        });
                    }
                    else
                    {
                        existingIngredientDetails.UOM = (StaticData.UOM)Enum.Parse(typeof(StaticData.UOM), uom);
                        existingIngredientDetails.QtyValue = qtyValue;
                        existingIngredientDetails.IsDeleted = false;
                        existingIngredientDetails.DeletedAt = DateTime.MinValue;
                    }
                    
                }
            }

            if (isContinueToGenerateData == true)
            {
                if (IsNewProduct)
                {
                    this.ProductToAddUpdate = new ProductModel
                    {
                        CategoryId = categoryId,
                        ProdName = TboxProductName.Text,
                        PricePerOrder = NumUpDownPricePerOrder.Value
                    };
                    OnProductSave(EventArgs.Empty);
                }
                else
                {
                    if (this.ProductToAddUpdate != null)
                    {
                        this.ProductToAddUpdate.CategoryId = categoryId;
                        this.ProductToAddUpdate.ProdName = TboxProductName.Text;
                        this.ProductToAddUpdate.PricePerOrder = NumUpDownPricePerOrder.Value;

                        OnProductSave(EventArgs.Empty);
                    }
                }
            }
        }

        public void ClearProductDetailsForm()
        {
            this.IsNewProduct = true;
            this.ProductToAddUpdate = null;
            this.SelectedIngredients = new Dictionary<int, IngredientModel>();
            this.ProductSelectedIngredients = new List<ProductIngredientModel>();
            this.DGVSelectedIngredients.Rows.Clear();
            this.UncheckSelectedProductsInDGV();
            this.CboxCategories.SelectedIndex = -1;
            this.TboxProductName.Text = "";
            this.NumUpDownPricePerOrder.Value = 0;
            this.LblNumberOfSelectedIngredients.Text = "0";
            this.BtnCancelSaveProductDetails.Visible = false;
        }

        private void BtnCancelSaveProductDetails_Click(object sender, EventArgs e)
        {
            ClearProductDetailsForm();
        }


        public void DisplayProductDetailsAndIngredientsInFormAndDGV()
        {
            this.SelectedIngredients = new Dictionary<int, IngredientModel>();
            this.DGVSelectedIngredients.Rows.Clear();
            this.UncheckSelectedProductsInDGV();

            if (this.ProductToAddUpdate != null)
            {

                for (var i=0; i< this.CboxCategories.Items.Count; i++)
                {
                    var item = this.CboxCategories.Items[i] as ComboboxItem;
                    if (int.Parse(item.Value.ToString()) == this.ProductToAddUpdate.CategoryId)
                    {
                        this.CboxCategories.SelectedIndex = i;
                        break;
                    }
                }

                this.TboxProductName.Text = this.ProductToAddUpdate.ProdName;
                this.NumUpDownPricePerOrder.Value = this.ProductToAddUpdate.PricePerOrder;

                if (this.ProductSelectedIngredients != null)
                {
                    //int[] existingIngredientIds = this.ProductSelectedIngredients.Select(x => x.IngredientId).ToArray();

                    foreach (DataGridViewRow row in this.DGVIngredientListToSelect.Rows)
                    {
                        int ingredientIdInTheDGV = int.Parse(row.Cells["IngredientId"].Value.ToString());
                        var existingIngredientDetails = this.ProductSelectedIngredients.Where(x => x.IngredientId == ingredientIdInTheDGV).FirstOrDefault();

                        if (existingIngredientDetails != null)
                        {
                            row.Cells["selectIngredientCkbox"].Value = (bool)true;

                            var ingredientDetails = this.Ingredients.Where(x => x.Id == ingredientIdInTheDGV).FirstOrDefault();

                            if (ingredientDetails != null)
                            {
                                if (this.SelectedIngredients.ContainsKey(ingredientDetails.Id) == false)
                                {
                                    this.SelectedIngredients.Add(ingredientDetails.Id, ingredientDetails);

                                    AddIngredientInDGVSelectedIngredients(ingredientDetails, existingIngredientDetails.UOM, existingIngredientDetails.QtyValue);
                                }
                            }
                        }
                    }
                }

                this.MainTabControl.SelectedIndex = this.MainTabControl.TabPages.IndexOf(MainTabAddProduct);
                this.BtnCancelSaveProductDetails.Visible = true;
                this.IsNewProduct = false;
            }
        }


        private void BtnFilterProducts_Click(object sender, EventArgs e)
        {
            if (this.ExistingProducts != null)
            {
                int categoryId = 0;
                string productName = this.TboxProductNameForFiltering.Text;

                if (this.CboxCategoryForFilteringProducts.SelectedIndex >= 0)
                {
                    var selectedCategory = this.CboxCategoryForFilteringProducts.SelectedItem as ComboboxItem;
                    categoryId = int.Parse(selectedCategory.Value.ToString());
                }

                List<ProductModel> searchResults = new List<ProductModel>();
                if (categoryId > 0 && string.IsNullOrEmpty(productName)) // Category only
                {
                    searchResults = this.ExistingProducts.Where(x => x.CategoryId == categoryId).ToList();
                }else if (categoryId > 0 && string.IsNullOrEmpty(productName) == false) // both
                {
                    searchResults = this.ExistingProducts.Where(x => x.CategoryId == categoryId && x.ProdName.ToLower().Contains(productName)).ToList();
                }
                else if (categoryId == 0 && string.IsNullOrEmpty(productName) == false) // product name only
                {
                    searchResults = this.ExistingProducts.Where(x => x.ProdName.ToLower().Contains(productName)).ToList();
                }
                
                DisplayExistingProductsInDGV(searchResults);
            }
        }

        public event EventHandler RefreshProductList;
        protected virtual void OnRefreshProductList(EventArgs e)
        {
            RefreshProductList?.Invoke(this, e);
        }

        private void BtnRefreshProductList_Click(object sender, EventArgs e)
        {
            OnRefreshProductList(EventArgs.Empty);
            this.TboxProductNameForFiltering.Text = "";
            this.CboxCategoryForFilteringProducts.SelectedIndex = -1;
        }

    }
}
