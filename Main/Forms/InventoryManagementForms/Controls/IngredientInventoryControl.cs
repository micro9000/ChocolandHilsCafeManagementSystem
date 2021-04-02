﻿using EntitiesShared;
using EntitiesShared.InventoryManagement;
using Shared.CustomModels;
using Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.InventoryManagementForms.Controls
{
    public partial class IngredientInventoryControl : UserControl
    {
        public IngredientInventoryControl(UOMConverter uOMConverter)
        {
            InitializeComponent();
            _uOMConverter = uOMConverter;
        }

        private void IngredientInventoryControl_Load(object sender, EventArgs e)
        {
            SetDGVIngredientCategoriesFontAndColors();
            SetDGVIngredientListFontAndColors();
            SetDGVIngredientInventoriesFontAndColors();
            SetDGVInventoryTransactionHistoryFontAndColors();
            SetDGVInventoryNearOnExpirationDateFontAndColors();

            DisplayIngredientCategoriesInDGV();
            DisplayUnitOfMeasurementsInCBox();
            DisplayIngredientInDGV();

            DisplayIngredientInventoriesNearOnExpirationDate();

            this.PropertyIsNewIngredientInventoryChanged += OnIsNewIngredientInventoryUpdate;

            this.MainTabControl.SelectedIndex = this.MainTabControl.TabPages.IndexOf(MainTabIngredientList);
        }

        #region Ingredient categories

        private List<IngredientCategoryModel> _ingredientCategories;

        public List<IngredientCategoryModel> IngredientCategories
        {
            get { return _ingredientCategories; }
            set { _ingredientCategories = value; }
        }

        private IngredientCategoryModel _categoryToAddUpdate;

        public IngredientCategoryModel CategoryToAddUpdate
        {
            get { return _categoryToAddUpdate; }
            set { _categoryToAddUpdate = value; }
        }

        public bool IsSaveNew { get; set; } = true;

        public event EventHandler IngredientCategorySaved;
        protected virtual void OnIngredientCategorySaved(EventArgs e)
        {
            IngredientCategorySaved?.Invoke(this, e);
        }



        private void SetDGVIngredientCategoriesFontAndColors()
        {
            this.DGVIngredientCategories.BackgroundColor = Color.White;
            this.DGVIngredientCategories.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVIngredientCategories.RowHeadersVisible = false;
            this.DGVIngredientCategories.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVIngredientCategories.AllowUserToResizeRows = false;
            this.DGVIngredientCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVIngredientCategories.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVIngredientCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVIngredientCategories.MultiSelect = false;

            this.DGVIngredientCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVIngredientCategories.ColumnHeadersHeight = 30;
        }


        public void DisplayIngredientCategoriesInDGV()
        {
            DisplayIngredientsInCbox(); // We put it here so we can also update the combox when the user update or delete category

            this.DGVIngredientCategories.Rows.Clear();
            if (this.IngredientCategories != null)
            {
                this.DGVIngredientCategories.ColumnCount = 3;

                this.DGVIngredientCategories.Columns[0].Name = "CategoryId";
                this.DGVIngredientCategories.Columns[0].Visible = false;

                this.DGVIngredientCategories.Columns[1].Name = "Category";
                this.DGVIngredientCategories.Columns[1].HeaderText = "Category";

                this.DGVIngredientCategories.Columns[2].Name = "CreatedAt";
                this.DGVIngredientCategories.Columns[2].HeaderText = "Created At";

                // Update button
                DataGridViewImageColumn btnUpdateImg = new DataGridViewImageColumn();
                //btnUpdateLeaveTypeImg.Name = "";
                btnUpdateImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnUpdateImg.Image = Image.FromFile("./Resources/edit-24.png");
                this.DGVIngredientCategories.Columns.Add(btnUpdateImg);


                // Delete button
                DataGridViewImageColumn btnDeleteImg = new DataGridViewImageColumn();
                //btnDeleteLeaveTypeImg.Name = "";
                btnDeleteImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnDeleteImg.Image = Image.FromFile("./Resources/remove-24.png");
                this.DGVIngredientCategories.Columns.Add(btnDeleteImg);

                foreach (var category in this.IngredientCategories)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVIngredientCategories);

                    row.Cells[0].Value = category.Id;
                    row.Cells[1].Value = category.Category;
                    row.Cells[2].Value = category.CreatedAt.ToShortDateString();

                    this.DGVIngredientCategories.Rows.Add(row);
                }
            }

        }

        public void ResetForm()
        {
            this.TbxCategory.Text = "";
            this.BtnCancelUpdate.Visible = false;
            this.GBoxIngredeitnCategoryForm.Text = "Add new";
            this.IsSaveNew = true;
            this.CategoryToAddUpdate = null;
            this.SelectedCategoryId = 0;
        }

        private void BtnSaveCategory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.TbxCategory.Text))
                return;

            if (this.IsSaveNew == true)
            {
                this.CategoryToAddUpdate = new IngredientCategoryModel
                {
                    Category = this.TbxCategory.Text
                };
            }
            else
            {
                this.CategoryToAddUpdate.Category = this.TbxCategory.Text;
            }

            OnIngredientCategorySaved(EventArgs.Empty);
        }

        private void BtnCancelUpdate_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        public int SelectedCategoryId { get; set; }
        public event EventHandler SelectCategoryToUpdate;
        protected virtual void OnSelectCategoryToUpdate(EventArgs e)
        {
            SelectCategoryToUpdate?.Invoke(this, e);
        }

        public event EventHandler SelectCategoryToDelete;
        protected virtual void OnSelectCategoryToDelete(EventArgs e)
        {
            SelectCategoryToDelete?.Invoke(this, e);
        }


        public void DisplaySelectedCategoryDetails()
        {
            if (this.CategoryToAddUpdate != null)
            {
                this.TbxCategory.Text = this.CategoryToAddUpdate.Category;
            }
        }

        private void DGVIngredientCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Update button
            if ((e.ColumnIndex == 3) && e.RowIndex > -1)
            {
                if (DGVIngredientCategories.CurrentRow != null)
                {
                    string categoryId = DGVIngredientCategories.CurrentRow.Cells[0].Value.ToString();

                    SelectedCategoryId = int.Parse(categoryId);

                    this.BtnCancelUpdate.Visible = true;
                    this.IsSaveNew = false;

                    OnSelectCategoryToUpdate(EventArgs.Empty);
                }
            }

            // Delete button
            if ((e.ColumnIndex == 4) && e.RowIndex > -1)
            {
                if (DGVIngredientCategories.CurrentRow != null)
                {
                    string categoryId = DGVIngredientCategories.CurrentRow.Cells[0].Value.ToString();
                    SelectedCategoryId = int.Parse(categoryId);
                    OnSelectCategoryToDelete(EventArgs.Empty);
                }
            }
        }

        #endregion


        #region Ingredients

        private void SetDGVIngredientListFontAndColors()
        {
            this.DGVIngredientList.BackgroundColor = Color.White;
            this.DGVIngredientList.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVIngredientList.RowHeadersVisible = false;
            this.DGVIngredientList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVIngredientList.AllowUserToResizeRows = false;
            this.DGVIngredientList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVIngredientList.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVIngredientList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVIngredientList.MultiSelect = false;

            this.DGVIngredientList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVIngredientList.ColumnHeadersHeight = 30;
        }

        public void DisplayUnitOfMeasurementsInCBox()
        {
            var UOMs = StaticData.GetUnitOfMeasurements;

            ComboboxItem item;

            foreach (var uom in UOMs)
            {
                item = new ComboboxItem();
                item.Text = uom.Value;
                item.Value = uom.Key;

                this.CBoxUnitOfMeasurements.Items.Add(item);
            }
        }

        public void DisplayIngredientsInCbox()
        {
            this.CboxIngredientsCategories.Items.Clear();
            this.CboxFilterByCategory.Items.Clear();

            if (this.IngredientCategories != null)
            {
                ComboboxItem item;

                foreach (var category in this.IngredientCategories)
                {
                    item = new ComboboxItem();
                    item.Text = category.Category;
                    item.Value = category.Id;

                    this.CboxIngredientsCategories.Items.Add(item);
                }

                ComboboxItem itemForFilter;

                foreach (var category in this.IngredientCategories)
                {
                    itemForFilter = new ComboboxItem();
                    itemForFilter.Text = category.Category;
                    itemForFilter.Value = category.Id;

                    this.CboxFilterByCategory.Items.Add(itemForFilter);
                }
            }
        }

        private List<IngredientModel> _ingredients;

        public List<IngredientModel> Ingredients
        {
            get { return _ingredients; }
            set { _ingredients = value; }
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

        public void DisplayIngredientInDGV()
        {
            DisplayIngredientsInCbox(); // We put it here so we can also update the combox when the user update or delete category
            DisplayIngredientInDGV(this.Ingredients);
        }


        public void DisplayIngredientInDGV(List<IngredientModel> Ingredients)
        {
            this.DGVIngredientList.Rows.Clear();
            if (Ingredients != null)
            {
                this.DGVIngredientList.ColumnCount = 5;

                this.DGVIngredientList.Columns[0].Name = "IngredientId";
                this.DGVIngredientList.Columns[0].Visible = false;

                this.DGVIngredientList.Columns[1].Name = "Ingredient";
                this.DGVIngredientList.Columns[1].HeaderText = "Ingredient";

                this.DGVIngredientList.Columns[2].Name = "Category";
                this.DGVIngredientList.Columns[2].HeaderText = "Category";

                this.DGVIngredientList.Columns[3].Name = "UOM";
                this.DGVIngredientList.Columns[3].HeaderText = "UOM";

                this.DGVIngredientList.Columns[4].Name = "QtyValue";
                this.DGVIngredientList.Columns[4].HeaderText = "Rem. Qty Value";


                // View inventory button
                DataGridViewImageColumn btnViewInventoryImg = new DataGridViewImageColumn();
                //btnDeleteLeaveTypeImg.Name = "";
                btnViewInventoryImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnViewInventoryImg.Image = Image.FromFile("./Resources/view-details-24.png");
                this.DGVIngredientList.Columns.Add(btnViewInventoryImg);


                // Update button
                DataGridViewImageColumn btnUpdateImg = new DataGridViewImageColumn();
                //btnUpdateLeaveTypeImg.Name = "";
                btnUpdateImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnUpdateImg.Image = Image.FromFile("./Resources/edit-24.png");
                this.DGVIngredientList.Columns.Add(btnUpdateImg);


                // Delete button
                DataGridViewImageColumn btnDeleteImg = new DataGridViewImageColumn();
                //btnDeleteLeaveTypeImg.Name = "";
                btnDeleteImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnDeleteImg.Image = Image.FromFile("./Resources/remove-24.png");
                this.DGVIngredientList.Columns.Add(btnDeleteImg);

                foreach (var ing in Ingredients)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVIngredientList);

                    row.Cells[0].Value = ing.Id;
                    row.Cells[1].Value = ing.IngName;
                    row.Cells[2].Value = ing.Category.Category;
                    row.Cells[3].Value = ing.UOM;
                    row.Cells[4].Value = this.GetUOMFormatted(ing.UOM, ing.RemainingQtyValue);

                    this.DGVIngredientList.Rows.Add(row);
                }
            }
        }


        private IngredientModel _ingredientToAddUpdate;
        private readonly UOMConverter _uOMConverter;

        public IngredientModel IngredientToAddUpdate
        {
            get { return _ingredientToAddUpdate; }
            set { _ingredientToAddUpdate = value; }
        }

        public bool IsNewIngredient { get; set; } = true;


        public event EventHandler IngredientSaved;
        protected virtual void OnIngredientSaved(EventArgs e)
        {
            IngredientSaved?.Invoke(this, e);
        }

        private void BtnSaveIngredientDetails_Click(object sender, EventArgs e)
        {
            if (this.CboxIngredientsCategories.SelectedIndex >= 0 && 
                this.CBoxUnitOfMeasurements.SelectedIndex >= 0 &&
                string.IsNullOrEmpty(this.TboxIngredientName.Text) == false)
            {
                var selectedCategory = this.CboxIngredientsCategories.SelectedItem as ComboboxItem;
                var selectedUOM = this.CBoxUnitOfMeasurements.SelectedItem as ComboboxItem;
                string ingredientName = this.TboxIngredientName.Text;

                if (this.IsNewIngredient)
                {
                    this.IngredientToAddUpdate = new IngredientModel
                    {
                        CategoryId = int.Parse(selectedCategory.Value.ToString()),
                        UOM = (StaticData.UOM)Enum.Parse(typeof(StaticData.UOM), selectedUOM.Value.ToString()),
                        IngName = ingredientName
                    };

                    OnIngredientSaved(EventArgs.Empty);
                }
                else
                {
                    this.IngredientToAddUpdate.CategoryId = int.Parse(selectedCategory.Value.ToString());
                    this.IngredientToAddUpdate.UOM = (StaticData.UOM)Enum.Parse(typeof(StaticData.UOM), selectedUOM.Value.ToString());
                    this.IngredientToAddUpdate.IngName = ingredientName;

                    OnIngredientSaved(EventArgs.Empty);
                }
            }
        }


        public void ResetIngredientForm()
        {
            this.CboxIngredientsCategories.SelectedIndex = -1;
            this.CBoxUnitOfMeasurements.SelectedIndex = -1;
            this.TboxIngredientName.Text = "";
            this.IngredientToAddUpdate = null;
            this.IsNewIngredient = true;
        }

        public event EventHandler IngredientGetInventories;
        protected virtual void OnIngredientGetInventories(EventArgs e)
        {
            IngredientGetInventories?.Invoke(this, e);
        }

        public event EventHandler IngredientDelete;
        protected virtual void OnIngredientDelete(EventArgs e)
        {
            IngredientDelete?.Invoke(this, e);
        }

        public int SelectedIngredientId { get; set; }
        private IngredientModel selectedIngredient;

        public IngredientModel SelectedIngredient
        {
            get { return selectedIngredient; }
            set { selectedIngredient = value; }
        }


        private void DGVIngredientList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // View inventory button
            if ((e.ColumnIndex == 5) && e.RowIndex > -1)
            {
                if (DGVIngredientList.CurrentRow != null)
                {
                    int ingredientId = int.Parse(DGVIngredientList.CurrentRow.Cells[0].Value.ToString());
                    SelectedIngredient = this.Ingredients.Where(x => x.Id == ingredientId).FirstOrDefault();
                    SelectedIngredientId = ingredientId;

                    OnIngredientGetInventories(EventArgs.Empty);

                    MoveToInventoryTabAndDisplayIngredientInventories();
                }
            }


            // Update button
            if ((e.ColumnIndex == 6) && e.RowIndex > -1)
            {
                if (DGVIngredientList.CurrentRow != null)
                {
                    string ingredientId = DGVIngredientList.CurrentRow.Cells[0].Value.ToString();
                    DisplaySelectedIngredientInForm(int.Parse(ingredientId));
                }
            }

            // Delete button
            if ((e.ColumnIndex == 7) && e.RowIndex > -1)
            {
                if (DGVIngredientList.CurrentRow != null)
                {
                    string ingredientId = DGVIngredientList.CurrentRow.Cells[0].Value.ToString();
                    SelectedIngredientId = int.Parse(ingredientId);
                    OnIngredientDelete(EventArgs.Empty);
                }
            }
        }

        public void DisplaySelectedIngredientInForm(int ingredientId)
        {
            if(this.Ingredients != null)
            {
                var ingredientDetails = this.Ingredients.Where(x => x.Id == ingredientId).FirstOrDefault();

                if (ingredientDetails != null)
                {
                    this.IngredientToAddUpdate = ingredientDetails;
                    this.IsNewIngredient = false;

                    this.TboxIngredientName.Text = ingredientDetails.IngName;

                    for (int i = 0; i < this.CboxIngredientsCategories.Items.Count; i++)
                    {
                        var item = this.CboxIngredientsCategories.Items[i] as ComboboxItem;
                        if (int.Parse(item.Value.ToString()) == ingredientDetails.CategoryId)
                        {
                            this.CboxIngredientsCategories.SelectedIndex = i;
                            break;
                        }
                    }

                    for(int i=0; i< this.CBoxUnitOfMeasurements.Items.Count; i++)
                    {
                        var item = this.CBoxUnitOfMeasurements.Items[i] as ComboboxItem;
                        if ((StaticData.UOM)Enum.Parse(typeof(StaticData.UOM), item.Value.ToString()) == ingredientDetails.UOM)
                        {
                            this.CBoxUnitOfMeasurements.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }

        private void BtnSearchIngredient_Click(object sender, EventArgs e)
        {
            string searchStr = this.TboxSearchIngredient.Text;
            int categoryId = 0;

            if (this.CboxFilterByCategory.SelectedIndex >= 0)
            {
                var selectedCategory = this.CboxFilterByCategory.SelectedItem as ComboboxItem;
                categoryId = int.Parse(selectedCategory.Value.ToString());
            }

            var searchResults = this.Ingredients.Where(x => x.IngName.Contains(searchStr)).ToList();

            if (categoryId > 0 && string.IsNullOrWhiteSpace(searchStr) == false)
            { // both category and search string
                searchResults = this.Ingredients.Where(x => x.IngName.Contains(searchStr) && x.CategoryId == categoryId).ToList();

            }else if (categoryId > 0 && string.IsNullOrWhiteSpace(searchStr) == true)
            {
                // category only
                searchResults = this.Ingredients.Where(x => x.CategoryId == categoryId).ToList();
            }

            this.DisplayIngredientInDGV(searchResults);
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            this.TboxSearchIngredient.Text = "";
            this.DisplayIngredientInDGV(this.Ingredients);
        }

        #endregion


        private void SetDGVIngredientInventoriesFontAndColors()
        {
            this.DGVIngredientInventories.BackgroundColor = Color.White;
            this.DGVIngredientInventories.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVIngredientInventories.RowHeadersVisible = false;
            this.DGVIngredientInventories.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVIngredientInventories.AllowUserToResizeRows = false;
            this.DGVIngredientInventories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVIngredientInventories.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVIngredientInventories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVIngredientInventories.MultiSelect = false;

            this.DGVIngredientInventories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVIngredientInventories.ColumnHeadersHeight = 30;
        }


        private List<IngredientInventoryModel> selectedIngredientInventories;

        public List<IngredientInventoryModel> SelectedIngredientInventories
        {
            get { return selectedIngredientInventories; }
            set { selectedIngredientInventories = value; }
        }

        public void MoveToInventoryTabAndDisplayIngredientInventories()
        {
            if (this.SelectedIngredient == null)
                return;

            this.LblSelectedIngToViewOrAddInventory.Text = this.SelectedIngredient.IngName;
            this.LblSelectedIngUOMToViewOrAddInventory.Text = this.SelectedIngredient.UOM.ToString();

            string uom = $"({this.SelectedIngredient.UOM})";
            this.LblQuantityValueIndicator.Text = uom;
            this.LblUOMForUnitCostIndicator.Text = uom;
            this.LblQuantityValueIndicator1.Text = uom;
            this.LblQuantityValueIndicator2.Text = uom;

            DisplayIngredientInventories();

            this.MainTabControl.SelectedIndex = this.MainTabControl.TabPages.IndexOf(MainTabIngInventories);
        }


        public void DisplayIngredientInventories()
        {
            if (this.SelectedIngredient == null)
                return;

            this.DGVIngredientInventories.Rows.Clear();
            if (SelectedIngredientInventories != null)
            {
                this.DGVIngredientInventories.ColumnCount = 5;

                this.DGVIngredientInventories.Columns[0].Name = "IngInventoryId";
                this.DGVIngredientInventories.Columns[0].Visible = false;

                this.DGVIngredientInventories.Columns[1].Name = "InitialQtyValue";
                this.DGVIngredientInventories.Columns[1].HeaderText = "Initial Qty Value";

                this.DGVIngredientInventories.Columns[2].Name = "RemainingQtyValue";
                this.DGVIngredientInventories.Columns[2].HeaderText = "Remaining Qty Value";

                this.DGVIngredientInventories.Columns[3].Name = "UnitCost";
                this.DGVIngredientInventories.Columns[3].HeaderText = "Unit Cost";

                this.DGVIngredientInventories.Columns[4].Name = "ExpirationDate";
                this.DGVIngredientInventories.Columns[4].HeaderText = "Expiration Date";

                // Update button
                DataGridViewImageColumn btnUpdateImg = new DataGridViewImageColumn();
                //btnUpdateLeaveTypeImg.Name = "";
                btnUpdateImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnUpdateImg.Image = Image.FromFile("./Resources/edit-24.png");
                this.DGVIngredientInventories.Columns.Add(btnUpdateImg);

                // Delete button
                DataGridViewImageColumn btnDeleteImg = new DataGridViewImageColumn();
                //btnDeleteLeaveTypeImg.Name = "";
                btnDeleteImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnDeleteImg.Image = Image.FromFile("./Resources/remove-24.png");
                this.DGVIngredientInventories.Columns.Add(btnDeleteImg);

                foreach (var item in SelectedIngredientInventories)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVIngredientInventories);

                    if (item.ExpirationDate == DateTime.Now || item.ExpirationDate <= DateTime.Now.AddDays(5))
                    {
                        row.DefaultCellStyle.ForeColor = Color.Red;
                    }

                    row.Cells[0].Value = item.Id;
                    row.Cells[1].Value = this.GetUOMFormatted(this.SelectedIngredient.UOM, item.InitialQtyValue);
                    row.Cells[2].Value = this.GetUOMFormatted(this.SelectedIngredient.UOM, item.RemainingQtyValue);
                    row.Cells[3].Value = item.UnitCost;
                    row.Cells[4].Value = item.ExpirationDate.ToShortDateString();

                    this.DGVIngredientInventories.Rows.Add(row);
                }
            }
        }


        public event EventHandler IngredientInventorySave;
        protected virtual void OnIngredientInventorySave(EventArgs e)
        {
            IngredientInventorySave?.Invoke(this, e);
        }

        private IngredientInventoryModel ingInventoryToAddUpdate;

        public IngredientInventoryModel IngredientInventoryToAddUpdate
        {
            get { return ingInventoryToAddUpdate; }
            set { ingInventoryToAddUpdate = value; }
        }


        // Use on clicking update button
        public event PropertyChangedEventHandler PropertyIsNewIngredientInventoryChanged;

        private bool _isNewIngredientInventory = true;

        public bool IsNewIngredientInventory
        {
            get { return _isNewIngredientInventory; }
            set { 
                _isNewIngredientInventory = value;

                if (PropertyIsNewIngredientInventoryChanged != null)
                {
                    PropertyIsNewIngredientInventoryChanged(this, new PropertyChangedEventArgs(IsNewIngredientInventory.ToString()));
                }
            }
        }


        private void OnIsNewIngredientInventoryUpdate(object sender, PropertyChangedEventArgs e)
        {
            if (IsNewIngredientInventory == true)
            {
                this.LblNewOrUpdateInventoryIndicator.Text = "New inventory";

                this.BtnIncreaseInventory.Enabled = false;
                this.BtnCancelIncreaseInventory.Enabled = false;
                this.BtnDecreaseInvetory.Enabled = false;
                this.BtnCancelDecreaseInventory.Enabled = false;
            }
            else
            {
                this.LblNewOrUpdateInventoryIndicator.Text = "Update inventory";

                this.BtnIncreaseInventory.Enabled = true;
                this.BtnCancelIncreaseInventory.Enabled = true;
                this.BtnDecreaseInvetory.Enabled = true;
                this.BtnCancelDecreaseInventory.Enabled = true;
            }
        }

        public string Remarks { get; set; }

        public decimal GetUOMToSmallUOM(StaticData.UOM uom, decimal qtyValue)
        {
            decimal newQtyValue = 0;

            switch (uom)
            {
                case StaticData.UOM.kg:
                    newQtyValue = _uOMConverter.kg_to_gram(qtyValue);
                    break;

                case StaticData.UOM.L:
                    newQtyValue = _uOMConverter.L_to_ml(qtyValue);
                    break;

                case StaticData.UOM.pcs:
                    newQtyValue = qtyValue;
                    break;
                default:
                    qtyValue = 0;
                    break;
            }

            return newQtyValue;
        }

        public decimal GetUOMToBigUOM(StaticData.UOM uom, decimal qtyValue)
        {
            decimal newQtyValue = 0;

            switch (uom)
            {
                case StaticData.UOM.kg:
                    newQtyValue = _uOMConverter.gram_to_kg(qtyValue);
                    break;

                case StaticData.UOM.L:
                    newQtyValue = _uOMConverter.ml_to_L(qtyValue);
                    break;

                case StaticData.UOM.pcs:
                    newQtyValue = qtyValue;
                    break;
                default:
                    qtyValue = 0;
                    break;
            }

            return newQtyValue;
        }

        public void ResetNewUpdateIngredeintInventoryForm()
        {
            this.TboxRemarks.Text = "";
            this.NumUDQtyValForIngInventory.Value = 0;
            this.NumUDUnitCostForIngInventory.Value = 0;
            this.DPickerExpirationDateForIngInventory.Value = DateTime.Now;
            this.IsNewIngredientInventory = true;


            NumUDIncreaseInventoryQtyValue.Value = 0;
            NumUDDecreaseInventoryQtyValue.Value = 0;
        }

        private void BtnSaveNewIngInventory_Click(object sender, EventArgs e)
        {
            this.Remarks = this.TboxRemarks.Text; // Remarks
            decimal qtyValue = this.NumUDQtyValForIngInventory.Value;
            decimal unitCost = this.NumUDUnitCostForIngInventory.Value;
            DateTime expDate = this.DPickerExpirationDateForIngInventory.Value;

            if (expDate <= DateTime.Now)
            {
                MessageBox.Show("Invalid Expiration Date", "Expiration date", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (SelectedIngredientId <= 0 || SelectedIngredient == null)
            {
                MessageBox.Show("Please select ingredient first.", "No selected ingredient", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            StaticData.UOM selectedIngredientUOM = SelectedIngredient.UOM;
            decimal newQtyValue = GetUOMToSmallUOM(selectedIngredientUOM, qtyValue);

            if (this.IsNewIngredientInventory)
            {
                this.IngredientInventoryToAddUpdate = new IngredientInventoryModel { 
                    IngredientId = SelectedIngredientId,
                    InitialQtyValue = newQtyValue,
                    RemainingQtyValue = newQtyValue,
                    UnitCost = unitCost,
                    ExpirationDate = expDate
                };
            }
            else
            {
                if (this.IngredientInventoryToAddUpdate != null)
                {
                    this.IngredientInventoryToAddUpdate.InitialQtyValue = newQtyValue;
                    this.IngredientInventoryToAddUpdate.RemainingQtyValue = newQtyValue;
                    this.IngredientInventoryToAddUpdate.UnitCost = unitCost;
                    this.IngredientInventoryToAddUpdate.ExpirationDate = expDate;
                }
            }

            OnIngredientInventorySave(EventArgs.Empty);
        }

        private void BtnCancelSaveIngInventory_Click(object sender, EventArgs e)
        {
            ResetNewUpdateIngredeintInventoryForm();
        }


        public long SelectedInventoryId { get; set; }
        public event EventHandler IngredientInventoryDelete;
        protected virtual void OnIngredientInventoryDelete(EventArgs e)
        {
            IngredientInventoryDelete?.Invoke(this, e);
        }

        private void DGVIngredientInventories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Update button
            if ((e.ColumnIndex == 5) && e.RowIndex > -1)
            {
                if (DGVIngredientInventories.CurrentRow != null && SelectedIngredientInventories != null)
                {
                    long inventoryId = long.Parse(DGVIngredientInventories.CurrentRow.Cells[0].Value.ToString());
                    this.SelectedInventoryId = inventoryId;

                    var ingredientInventory = this.SelectedIngredientInventories.Where(x => x.Id == inventoryId).FirstOrDefault();
                    this.IngredientInventoryToAddUpdate = ingredientInventory;
                    DisplaySelectedInventoryInSaveNewUpdateForm(ingredientInventory);

                    this.IsNewIngredientInventory = false;
                }
            }


            // Delete button
            if ((e.ColumnIndex == 6) && e.RowIndex > -1)
            {
                if (string.IsNullOrWhiteSpace(this.TboxRemarks.Text))
                {
                    MessageBox.Show("Please provide remarks", "Delete inventory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (DGVIngredientInventories.CurrentRow != null && SelectedIngredientInventories != null)
                {
                    this.Remarks = this.TboxRemarks.Text; // Remarks
                    this.SelectedInventoryId = long.Parse(DGVIngredientInventories.CurrentRow.Cells[0].Value.ToString());

                    OnIngredientInventoryDelete(EventArgs.Empty);
                }
            }
        }

        public void DisplaySelectedInventoryInSaveNewUpdateForm(IngredientInventoryModel ingredientInventory)
        {
            if (ingredientInventory != null && this.SelectedIngredient != null)
            {
                this.NumUDQtyValForIngInventory.Value = this.GetUOMToBigUOM(this.SelectedIngredient.UOM, ingredientInventory.RemainingQtyValue);
                this.NumUDUnitCostForIngInventory.Value = ingredientInventory.UnitCost;
                this.DPickerExpirationDateForIngInventory.Value = ingredientInventory.ExpirationDate;
            }
        }


        private void BtnCancelIncreaseInventory_Click(object sender, EventArgs e)
        {
            ResetNewUpdateIngredeintInventoryForm();
        }

        private void BtnCancelDecreaseInventory_Click(object sender, EventArgs e)
        {
            ResetNewUpdateIngredeintInventoryForm();
        }

        public decimal IncreaseInventoryQtyValue { get; set; }
        public decimal DecreaseInventoryQtyValue { get; set; }

        public event EventHandler IncreaseInventoryQtyValueSave;
        protected virtual void OnIncreaseInventoryQtyValueSave(EventArgs e)
        {
            IncreaseInventoryQtyValueSave?.Invoke(this, e);
        }

        public event EventHandler DecreaseInventoryQtyValueSave;
        protected virtual void OnDecreaseInventoryQtyValueSave(EventArgs e)
        {
            DecreaseInventoryQtyValueSave?.Invoke(this, e);
        }

        private void BtnIncreaseInventory_Click(object sender, EventArgs e)
        {
            if (NumUDIncreaseInventoryQtyValue.Value > 0 && SelectedIngredient != null)
            {
                if (string.IsNullOrWhiteSpace(this.TboxRemarks.Text))
                {
                    MessageBox.Show("Please provide remarks", "Delete inventory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                this.Remarks = this.TboxRemarks.Text;

                decimal newQtyValue = GetUOMToSmallUOM(SelectedIngredient.UOM, NumUDIncreaseInventoryQtyValue.Value);

                IncreaseInventoryQtyValue = newQtyValue;

                OnIncreaseInventoryQtyValueSave(EventArgs.Empty);

            }
        }

        private void BtnDecreaseInvetory_Click(object sender, EventArgs e)
        {
            if (NumUDDecreaseInventoryQtyValue.Value > 0 && SelectedIngredient != null)
            {
                if (string.IsNullOrWhiteSpace(this.TboxRemarks.Text))
                {
                    MessageBox.Show("Please provide remarks", "Delete inventory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                this.Remarks = this.TboxRemarks.Text;


                decimal newQtyValue = GetUOMToSmallUOM(SelectedIngredient.UOM, NumUDDecreaseInventoryQtyValue.Value);

                DecreaseInventoryQtyValue = newQtyValue;
                OnDecreaseInventoryQtyValueSave(EventArgs.Empty);

            }
        }

        private void SetDGVInventoryTransactionHistoryFontAndColors()
        {
            this.DGVInventoryTransactionHistory.BackgroundColor = Color.White;
            this.DGVInventoryTransactionHistory.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVInventoryTransactionHistory.RowHeadersVisible = false;
            this.DGVInventoryTransactionHistory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVInventoryTransactionHistory.AllowUserToResizeRows = false;
            this.DGVInventoryTransactionHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVInventoryTransactionHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVInventoryTransactionHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVInventoryTransactionHistory.MultiSelect = false;

            this.DGVInventoryTransactionHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVInventoryTransactionHistory.ColumnHeadersHeight = 30;
        }

        private List<IngInventoryTransactionModel> inventoryTransactionModels;

        public List<IngInventoryTransactionModel> InventoryTransactionHistory
        {
            get { return inventoryTransactionModels; }
            set { inventoryTransactionModels = value; }
        }


        public void DisplayInventoryTransactionHistory()
        {
            this.DGVInventoryTransactionHistory.Rows.Clear();
            if (this.InventoryTransactionHistory != null)
            {
                this.DGVInventoryTransactionHistory.ColumnCount = 7;

                this.DGVInventoryTransactionHistory.Columns[0].Name = "IngInventoryTransId";
                this.DGVInventoryTransactionHistory.Columns[0].Visible = false;

                this.DGVInventoryTransactionHistory.Columns[1].Name = "InventoryTransactionType";
                this.DGVInventoryTransactionHistory.Columns[1].HeaderText = "Transaction Type";

                this.DGVInventoryTransactionHistory.Columns[2].Name = "InventoryTransQtyValue";
                this.DGVInventoryTransactionHistory.Columns[2].HeaderText = "Qty Value";

                this.DGVInventoryTransactionHistory.Columns[3].Name = "InventoryTransUnitCost";
                this.DGVInventoryTransactionHistory.Columns[3].HeaderText = "Unit Cost";

                this.DGVInventoryTransactionHistory.Columns[4].Name = "InventoryTransExpirationDate";
                this.DGVInventoryTransactionHistory.Columns[4].HeaderText = "Expiration Date";

                this.DGVInventoryTransactionHistory.Columns[5].Name = "InventoryTransUser";
                this.DGVInventoryTransactionHistory.Columns[5].HeaderText = "User";

                this.DGVInventoryTransactionHistory.Columns[6].Name = "InventoryTransDate";
                this.DGVInventoryTransactionHistory.Columns[6].HeaderText = "Date";

                foreach (var item in InventoryTransactionHistory)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVInventoryTransactionHistory);

                    row.Cells[0].Value = item.Id;
                    row.Cells[1].Value = item.TransType.ToString();
                    row.Cells[2].Value = this.GetUOMFormatted(this.SelectedIngredient.UOM, item.QtyVal);
                    row.Cells[3].Value = item.UnitCost;
                    row.Cells[4].Value = item.ExpirationDate.ToShortDateString();
                    row.Cells[5].Value = item.User.FullName;
                    row.Cells[6].Value = item.CreatedAt.ToShortDateString();

                    this.DGVInventoryTransactionHistory.Rows.Add(row);
                }
            }
        }


        public DateTime FilterTransactionStartDate { get; set; }
        public DateTime FilterTransactionEndDate { get; set; }

        public event EventHandler FilterTransactionHistory;
        protected virtual void OnFilterTransactionHistory(EventArgs e)
        {
            FilterTransactionHistory?.Invoke(this, e);
        }

        private void BtnFilterInventoryTransHistory_Click(object sender, EventArgs e)
        {
            FilterTransactionStartDate = DPicFilterInventoryTransStartDate.Value;
            FilterTransactionEndDate = DPicFilterInventoryTransEndDate.Value;
            OnFilterTransactionHistory(EventArgs.Empty);
        }

        private void DGVInventoryTransactionHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (DGVInventoryTransactionHistory.CurrentRow != null && this.InventoryTransactionHistory != null)
                {
                    long selectedTransactionId = long.Parse(DGVInventoryTransactionHistory.CurrentRow.Cells[0].Value.ToString());

                    var transactionDetails = this.InventoryTransactionHistory.Where(x => x.Id == selectedTransactionId).FirstOrDefault();

                    if (transactionDetails != null)
                    {
                        this.TboxTransactionHistoryRemarks.Text = transactionDetails.Remarks;
                    }
                }
            }
        }


        private void SetDGVInventoryNearOnExpirationDateFontAndColors()
        {
            this.DGVInventoryNearOnExpirationDate.BackgroundColor = Color.White;
            this.DGVInventoryNearOnExpirationDate.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVInventoryNearOnExpirationDate.RowHeadersVisible = false;
            this.DGVInventoryNearOnExpirationDate.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVInventoryNearOnExpirationDate.AllowUserToResizeRows = false;
            this.DGVInventoryNearOnExpirationDate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVInventoryNearOnExpirationDate.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVInventoryNearOnExpirationDate.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVInventoryNearOnExpirationDate.MultiSelect = false;

            this.DGVInventoryNearOnExpirationDate.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVInventoryNearOnExpirationDate.ColumnHeadersHeight = 30;
        }


        private List<IngredientInventoryModel> inventoriesNearOnExpirationDate;

        public List<IngredientInventoryModel> InventoriesNearOnExpirationDate
        {
            get { return inventoriesNearOnExpirationDate; }
            set { inventoriesNearOnExpirationDate = value; }
        }


        public void DisplayIngredientInventoriesNearOnExpirationDate()
        {
            this.DGVInventoryNearOnExpirationDate.Rows.Clear();
            if (InventoriesNearOnExpirationDate != null)
            {
                this.DGVInventoryNearOnExpirationDate.ColumnCount = 6;

                this.DGVInventoryNearOnExpirationDate.Columns[0].Name = "IngredientIdForNearExp";
                this.DGVInventoryNearOnExpirationDate.Columns[0].Visible = false;

                this.DGVInventoryNearOnExpirationDate.Columns[1].Name = "IngredientNameForNearExp";
                this.DGVInventoryNearOnExpirationDate.Columns[1].HeaderText = "Ingredient Name";

                this.DGVInventoryNearOnExpirationDate.Columns[2].Name = "InitialQtyValueForNearExp";
                this.DGVInventoryNearOnExpirationDate.Columns[2].HeaderText = "Initial Qty Value";

                this.DGVInventoryNearOnExpirationDate.Columns[3].Name = "RemainingQtyValueForNearExp";
                this.DGVInventoryNearOnExpirationDate.Columns[3].HeaderText = "Remaining Qty Value";

                this.DGVInventoryNearOnExpirationDate.Columns[4].Name = "UnitCostForNearExp";
                this.DGVInventoryNearOnExpirationDate.Columns[4].HeaderText = "Unit Cost";

                this.DGVInventoryNearOnExpirationDate.Columns[5].Name = "ExpirationDateForNearExp";
                this.DGVInventoryNearOnExpirationDate.Columns[5].HeaderText = "Expiration Date";

                // View inventory button
                DataGridViewImageColumn btnViewInventoryImg = new DataGridViewImageColumn();
                //btnDeleteLeaveTypeImg.Name = "";
                btnViewInventoryImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnViewInventoryImg.Image = Image.FromFile("./Resources/view-details-24.png");
                this.DGVInventoryNearOnExpirationDate.Columns.Add(btnViewInventoryImg);

                foreach (var item in InventoriesNearOnExpirationDate)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVInventoryNearOnExpirationDate);

                    row.Cells[0].Value = item.Ingredient.Id; // we need the ingredient id, instead of the inventory id
                    row.Cells[1].Value = item.Ingredient.IngName;
                    row.Cells[2].Value = this.GetUOMFormatted(item.Ingredient.UOM, item.InitialQtyValue);
                    row.Cells[3].Value = this.GetUOMFormatted(item.Ingredient.UOM, item.RemainingQtyValue);
                    row.Cells[4].Value = item.UnitCost;
                    row.Cells[5].Value = item.ExpirationDate.ToLongDateString();

                    this.DGVInventoryNearOnExpirationDate.Rows.Add(row);
                }
            }
        }

        private void DGVInventoryNearOnExpirationDate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // View inventory button
            if ((e.ColumnIndex == 6) && e.RowIndex > -1)
            {
                if (DGVInventoryNearOnExpirationDate.CurrentRow != null)
                {
                    int ingredientId = int.Parse(DGVInventoryNearOnExpirationDate.CurrentRow.Cells[0].Value.ToString());

                    SelectedIngredient = this.Ingredients.Where(x => x.Id == ingredientId).FirstOrDefault();
                    SelectedIngredientId = ingredientId;

                    OnIngredientGetInventories(EventArgs.Empty);

                    MoveToInventoryTabAndDisplayIngredientInventories();
                }
            }
        }

        public DateTime FilterInventoryByExpirationStartDate { get; set; }
        public DateTime FilterInventoryByExpirationEndDate { get; set; }

        public event EventHandler FilterInventoryByExpirationDate;
        protected virtual void OnFilterInventoryByExpirationDate(EventArgs e)
        {
            FilterInventoryByExpirationDate?.Invoke(this, e);
        }

        private void BtnFilterInventoryByExpirationDate_Click(object sender, EventArgs e)
        {
            this.FilterInventoryByExpirationStartDate = this.DPicFilterByExpirationStartDate.Value;
            this.FilterInventoryByExpirationEndDate = this.DPicFilterByExpirationEndDate.Value;

            OnFilterInventoryByExpirationDate(EventArgs.Empty);
        }
    }
}
