using EntitiesShared;
using EntitiesShared.InventoryManagement;
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
        public ProductInventoryControl(UOMConverter uOMConverter)
        {
            InitializeComponent();
            _uOMConverter = uOMConverter;
        }

        private readonly UOMConverter _uOMConverter;



        private void ProductInventoryControl_Load(object sender, EventArgs e)
        {
            SetDGVProrductCategoriesFontAndColors();
            SetDGVIngredientListToSelectFontAndColors();
            SetDGVSelectedIngredientsFontAndColors();

            DisplayProductCategoriesInDGV();

            DisplayIngredientInDGV(Ingredients);

            SetDGVSelectedIngredientsColumns();
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
            if(this.ProductCategories != null)
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
            string[] uomList = new string[] { };

            switch (uom)
            {
                case StaticData.UOM.kg:
                    uomList = new string[] { "kg", "grams" };
                    break;

                case StaticData.UOM.L:
                    uomList = new string[] { "L", "ml" };
                    break;

                case StaticData.UOM.pcs:
                    uomList = new string[] { "pcs", "pc" };
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

            NumericUpDownColumn textboxColumn = new NumericUpDownColumn();
            textboxColumn.HeaderText = "Amount";
            textboxColumn.Name = "selectedIngredientAmount";
            textboxColumn.DefaultCellStyle.BackColor = Color.Bisque;
            textboxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            textboxColumn.ReadOnly = false;
            DGVSelectedIngredients.Columns.Add(textboxColumn);
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
                        }
                        
                    }
                }

                this.LblNumberOfSelectedIngredients.Text = this.SelectedIngredients.Count().ToString();
            }
              
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
                        }

                    }
                }

                this.LblNumberOfSelectedIngredients.Text = this.SelectedIngredients.Count().ToString();
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
            DisplayIngredientInDGV(Ingredients);
        }
    }
}
