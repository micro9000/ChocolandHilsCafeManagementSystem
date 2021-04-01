using EntitiesShared.InventoryManagement;
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
    public partial class IngredientCategoryControl : UserControl
    {
        public IngredientCategoryControl()
        {
            InitializeComponent();
        }


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


        private void IngredientCategoryControl_Load(object sender, EventArgs e)
        {
            SetDGVIngredientCategoriesFontAndColors();
            DisplayIngredientsInDGV();
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


        public void DisplayIngredientsInDGV()
        {
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

                foreach(var category in this.IngredientCategories)
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
            } else {
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

        public void DisplaySelectedCategoryDetails()
        {
            if (this.CategoryToAddUpdate != null)
            {
                this.TbxCategory.Text = this.CategoryToAddUpdate.Category;
            }
        }
    }
}
