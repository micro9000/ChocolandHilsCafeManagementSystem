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
    public partial class ProductInventoryControl : UserControl
    {
        public ProductInventoryControl()
        {
            InitializeComponent();
        }

        private void ProductInventoryControl_Load(object sender, EventArgs e)
        {
            SetDGVProrductCategoriesFontAndColors();

            DisplayProductCategoriesInDGV();
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
            //DisplayIngredientsInCbox(); // We put it here so we can also update the combox when the user update or delete category

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


    }
}
