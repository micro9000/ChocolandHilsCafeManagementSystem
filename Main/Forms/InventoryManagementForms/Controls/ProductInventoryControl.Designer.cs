
namespace Main.Forms.InventoryManagementForms.Controls
{
    partial class ProductInventoryControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.MainTabProdCategory = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVProrductCategories = new System.Windows.Forms.DataGridView();
            this.GBoxIngredeitnCategoryForm = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnCancelUpdateCategory = new System.Windows.Forms.Button();
            this.TbxCategory = new System.Windows.Forms.TextBox();
            this.BtnSaveCategory = new System.Windows.Forms.Button();
            this.MainTabProducts = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.MainTabProdCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProrductCategories)).BeginInit();
            this.GBoxIngredeitnCategoryForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(920, 59);
            this.panel1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Product Inventory";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.MainTabProdCategory);
            this.tabControl1.Controls.Add(this.MainTabProducts);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.Location = new System.Drawing.Point(0, 59);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(920, 493);
            this.tabControl1.TabIndex = 7;
            // 
            // MainTabProdCategory
            // 
            this.MainTabProdCategory.Controls.Add(this.label1);
            this.MainTabProdCategory.Controls.Add(this.DGVProrductCategories);
            this.MainTabProdCategory.Controls.Add(this.GBoxIngredeitnCategoryForm);
            this.MainTabProdCategory.Location = new System.Drawing.Point(4, 29);
            this.MainTabProdCategory.Name = "MainTabProdCategory";
            this.MainTabProdCategory.Padding = new System.Windows.Forms.Padding(3);
            this.MainTabProdCategory.Size = new System.Drawing.Size(912, 460);
            this.MainTabProdCategory.TabIndex = 0;
            this.MainTabProdCategory.Text = "Categories";
            this.MainTabProdCategory.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(60, 359);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(793, 74);
            this.label1.TabIndex = 55;
            this.label1.Text = "Notes: If you want to delete a category, you can reassign all products under that" +
    " category to new category or delete all products with that category";
            // 
            // DGVProrductCategories
            // 
            this.DGVProrductCategories.AllowUserToAddRows = false;
            this.DGVProrductCategories.AllowUserToDeleteRows = false;
            this.DGVProrductCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVProrductCategories.Location = new System.Drawing.Point(403, 28);
            this.DGVProrductCategories.Name = "DGVProrductCategories";
            this.DGVProrductCategories.ReadOnly = true;
            this.DGVProrductCategories.RowTemplate.Height = 25;
            this.DGVProrductCategories.Size = new System.Drawing.Size(450, 284);
            this.DGVProrductCategories.TabIndex = 54;
            this.DGVProrductCategories.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVProrductCategories_CellClick);
            // 
            // GBoxIngredeitnCategoryForm
            // 
            this.GBoxIngredeitnCategoryForm.Controls.Add(this.label9);
            this.GBoxIngredeitnCategoryForm.Controls.Add(this.BtnCancelUpdateCategory);
            this.GBoxIngredeitnCategoryForm.Controls.Add(this.TbxCategory);
            this.GBoxIngredeitnCategoryForm.Controls.Add(this.BtnSaveCategory);
            this.GBoxIngredeitnCategoryForm.ForeColor = System.Drawing.Color.Black;
            this.GBoxIngredeitnCategoryForm.Location = new System.Drawing.Point(60, 28);
            this.GBoxIngredeitnCategoryForm.Name = "GBoxIngredeitnCategoryForm";
            this.GBoxIngredeitnCategoryForm.Size = new System.Drawing.Size(299, 284);
            this.GBoxIngredeitnCategoryForm.TabIndex = 53;
            this.GBoxIngredeitnCategoryForm.TabStop = false;
            this.GBoxIngredeitnCategoryForm.Text = "Add New";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(16, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 21);
            this.label9.TabIndex = 25;
            this.label9.Text = "Category";
            // 
            // BtnCancelUpdateCategory
            // 
            this.BtnCancelUpdateCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelUpdateCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelUpdateCategory.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelUpdateCategory.ForeColor = System.Drawing.Color.White;
            this.BtnCancelUpdateCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelUpdateCategory.Location = new System.Drawing.Point(166, 159);
            this.BtnCancelUpdateCategory.Name = "BtnCancelUpdateCategory";
            this.BtnCancelUpdateCategory.Size = new System.Drawing.Size(115, 47);
            this.BtnCancelUpdateCategory.TabIndex = 46;
            this.BtnCancelUpdateCategory.Text = "Cancel";
            this.BtnCancelUpdateCategory.UseVisualStyleBackColor = false;
            this.BtnCancelUpdateCategory.Visible = false;
            this.BtnCancelUpdateCategory.Click += new System.EventHandler(this.BtnCancelUpdateCategory_Click);
            // 
            // TbxCategory
            // 
            this.TbxCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbxCategory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbxCategory.Location = new System.Drawing.Point(16, 110);
            this.TbxCategory.Name = "TbxCategory";
            this.TbxCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TbxCategory.Size = new System.Drawing.Size(265, 29);
            this.TbxCategory.TabIndex = 24;
            // 
            // BtnSaveCategory
            // 
            this.BtnSaveCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSaveCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveCategory.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveCategory.ForeColor = System.Drawing.Color.White;
            this.BtnSaveCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveCategory.Location = new System.Drawing.Point(16, 159);
            this.BtnSaveCategory.Name = "BtnSaveCategory";
            this.BtnSaveCategory.Size = new System.Drawing.Size(115, 47);
            this.BtnSaveCategory.TabIndex = 2;
            this.BtnSaveCategory.Text = "Save";
            this.BtnSaveCategory.UseVisualStyleBackColor = false;
            this.BtnSaveCategory.Click += new System.EventHandler(this.BtnSaveCategory_Click);
            // 
            // MainTabProducts
            // 
            this.MainTabProducts.Location = new System.Drawing.Point(4, 29);
            this.MainTabProducts.Name = "MainTabProducts";
            this.MainTabProducts.Padding = new System.Windows.Forms.Padding(3);
            this.MainTabProducts.Size = new System.Drawing.Size(912, 460);
            this.MainTabProducts.TabIndex = 1;
            this.MainTabProducts.Text = "Products";
            this.MainTabProducts.UseVisualStyleBackColor = true;
            // 
            // ProductInventoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "ProductInventoryControl";
            this.Size = new System.Drawing.Size(920, 552);
            this.Load += new System.EventHandler(this.ProductInventoryControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.MainTabProdCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVProrductCategories)).EndInit();
            this.GBoxIngredeitnCategoryForm.ResumeLayout(false);
            this.GBoxIngredeitnCategoryForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage MainTabProdCategory;
        private System.Windows.Forms.TabPage MainTabProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVProrductCategories;
        private System.Windows.Forms.GroupBox GBoxIngredeitnCategoryForm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnCancelUpdateCategory;
        private System.Windows.Forms.TextBox TbxCategory;
        private System.Windows.Forms.Button BtnSaveCategory;
    }
}
