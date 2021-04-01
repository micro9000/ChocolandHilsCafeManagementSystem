
namespace Main.Forms.InventoryManagementForms.Controls
{
    partial class IngredientCategoryControl
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
            this.GBoxIngredeitnCategoryForm = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnCancelUpdate = new System.Windows.Forms.Button();
            this.TbxCategory = new System.Windows.Forms.TextBox();
            this.BtnSaveCategory = new System.Windows.Forms.Button();
            this.DGVIngredientCategories = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.GBoxIngredeitnCategoryForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVIngredientCategories)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(799, 94);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Ingredient Categories";
            // 
            // GBoxIngredeitnCategoryForm
            // 
            this.GBoxIngredeitnCategoryForm.Controls.Add(this.label9);
            this.GBoxIngredeitnCategoryForm.Controls.Add(this.BtnCancelUpdate);
            this.GBoxIngredeitnCategoryForm.Controls.Add(this.TbxCategory);
            this.GBoxIngredeitnCategoryForm.Controls.Add(this.BtnSaveCategory);
            this.GBoxIngredeitnCategoryForm.ForeColor = System.Drawing.Color.Black;
            this.GBoxIngredeitnCategoryForm.Location = new System.Drawing.Point(11, 122);
            this.GBoxIngredeitnCategoryForm.Name = "GBoxIngredeitnCategoryForm";
            this.GBoxIngredeitnCategoryForm.Size = new System.Drawing.Size(299, 221);
            this.GBoxIngredeitnCategoryForm.TabIndex = 48;
            this.GBoxIngredeitnCategoryForm.TabStop = false;
            this.GBoxIngredeitnCategoryForm.Text = "Add New";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(15, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "Category";
            // 
            // BtnCancelUpdate
            // 
            this.BtnCancelUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelUpdate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelUpdate.ForeColor = System.Drawing.Color.White;
            this.BtnCancelUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelUpdate.Location = new System.Drawing.Point(165, 113);
            this.BtnCancelUpdate.Name = "BtnCancelUpdate";
            this.BtnCancelUpdate.Size = new System.Drawing.Size(115, 47);
            this.BtnCancelUpdate.TabIndex = 46;
            this.BtnCancelUpdate.Text = "Cancel";
            this.BtnCancelUpdate.UseVisualStyleBackColor = false;
            this.BtnCancelUpdate.Visible = false;
            this.BtnCancelUpdate.Click += new System.EventHandler(this.BtnCancelUpdate_Click);
            // 
            // TbxCategory
            // 
            this.TbxCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbxCategory.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbxCategory.Location = new System.Drawing.Point(15, 64);
            this.TbxCategory.Name = "TbxCategory";
            this.TbxCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TbxCategory.Size = new System.Drawing.Size(265, 27);
            this.TbxCategory.TabIndex = 24;
            // 
            // BtnSaveCategory
            // 
            this.BtnSaveCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSaveCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveCategory.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveCategory.ForeColor = System.Drawing.Color.White;
            this.BtnSaveCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveCategory.Location = new System.Drawing.Point(15, 113);
            this.BtnSaveCategory.Name = "BtnSaveCategory";
            this.BtnSaveCategory.Size = new System.Drawing.Size(115, 47);
            this.BtnSaveCategory.TabIndex = 2;
            this.BtnSaveCategory.Text = "Save";
            this.BtnSaveCategory.UseVisualStyleBackColor = false;
            this.BtnSaveCategory.Click += new System.EventHandler(this.BtnSaveCategory_Click);
            // 
            // DGVIngredientCategories
            // 
            this.DGVIngredientCategories.AllowUserToAddRows = false;
            this.DGVIngredientCategories.AllowUserToDeleteRows = false;
            this.DGVIngredientCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVIngredientCategories.Location = new System.Drawing.Point(333, 122);
            this.DGVIngredientCategories.Name = "DGVIngredientCategories";
            this.DGVIngredientCategories.ReadOnly = true;
            this.DGVIngredientCategories.RowTemplate.Height = 25;
            this.DGVIngredientCategories.Size = new System.Drawing.Size(450, 221);
            this.DGVIngredientCategories.TabIndex = 49;
            this.DGVIngredientCategories.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVIngredientCategories_CellClick);
            // 
            // IngredientCategoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.DGVIngredientCategories);
            this.Controls.Add(this.GBoxIngredeitnCategoryForm);
            this.Controls.Add(this.panel1);
            this.Name = "IngredientCategoryControl";
            this.Size = new System.Drawing.Size(799, 368);
            this.Load += new System.EventHandler(this.IngredientCategoryControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.GBoxIngredeitnCategoryForm.ResumeLayout(false);
            this.GBoxIngredeitnCategoryForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVIngredientCategories)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GBoxIngredeitnCategoryForm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnCancelUpdate;
        private System.Windows.Forms.TextBox TbxCategory;
        private System.Windows.Forms.Button BtnSaveCategory;
        private System.Windows.Forms.DataGridView DGVIngredientCategories;
    }
}
