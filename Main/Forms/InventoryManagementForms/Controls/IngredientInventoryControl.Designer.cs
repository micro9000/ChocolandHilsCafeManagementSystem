
namespace Main.Forms.InventoryManagementForms.Controls
{
    partial class IngredientInventoryControl
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
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVIngredientCategories = new System.Windows.Forms.DataGridView();
            this.GBoxIngredeitnCategoryForm = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnCancelUpdate = new System.Windows.Forms.Button();
            this.TbxCategory = new System.Windows.Forms.TextBox();
            this.BtnSaveCategory = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnSearchIngredient = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.TboxSearchIngredient = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnCancelSaveIngredientDetails = new System.Windows.Forms.Button();
            this.BtnSaveIngredientDetails = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CBoxUnitOfMeasurements = new System.Windows.Forms.ComboBox();
            this.TboxIngredientName = new System.Windows.Forms.TextBox();
            this.CboxIngredientsCategories = new System.Windows.Forms.ComboBox();
            this.DGVIngredientList = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVIngredientCategories)).BeginInit();
            this.GBoxIngredeitnCategoryForm.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVIngredientList)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1147, 59);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Ingredient Categories";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.Location = new System.Drawing.Point(0, 59);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1147, 563);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.DGVIngredientCategories);
            this.tabPage4.Controls.Add(this.GBoxIngredeitnCategoryForm);
            this.tabPage4.Location = new System.Drawing.Point(4, 30);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1139, 529);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Categories";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(157, 387);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(793, 74);
            this.label1.TabIndex = 52;
            this.label1.Text = "Notes: If you want to delete a category, you can reassign all ingredients under t" +
    "hat category to new category or delete all ingredients with that category";
            // 
            // DGVIngredientCategories
            // 
            this.DGVIngredientCategories.AllowUserToAddRows = false;
            this.DGVIngredientCategories.AllowUserToDeleteRows = false;
            this.DGVIngredientCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVIngredientCategories.Location = new System.Drawing.Point(500, 56);
            this.DGVIngredientCategories.Name = "DGVIngredientCategories";
            this.DGVIngredientCategories.ReadOnly = true;
            this.DGVIngredientCategories.RowTemplate.Height = 25;
            this.DGVIngredientCategories.Size = new System.Drawing.Size(450, 284);
            this.DGVIngredientCategories.TabIndex = 51;
            this.DGVIngredientCategories.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVIngredientCategories_CellClick);
            // 
            // GBoxIngredeitnCategoryForm
            // 
            this.GBoxIngredeitnCategoryForm.Controls.Add(this.label9);
            this.GBoxIngredeitnCategoryForm.Controls.Add(this.BtnCancelUpdate);
            this.GBoxIngredeitnCategoryForm.Controls.Add(this.TbxCategory);
            this.GBoxIngredeitnCategoryForm.Controls.Add(this.BtnSaveCategory);
            this.GBoxIngredeitnCategoryForm.ForeColor = System.Drawing.Color.Black;
            this.GBoxIngredeitnCategoryForm.Location = new System.Drawing.Point(157, 56);
            this.GBoxIngredeitnCategoryForm.Name = "GBoxIngredeitnCategoryForm";
            this.GBoxIngredeitnCategoryForm.Size = new System.Drawing.Size(299, 284);
            this.GBoxIngredeitnCategoryForm.TabIndex = 50;
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
            // BtnCancelUpdate
            // 
            this.BtnCancelUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelUpdate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelUpdate.ForeColor = System.Drawing.Color.White;
            this.BtnCancelUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelUpdate.Location = new System.Drawing.Point(166, 159);
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
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.DGVIngredientList);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1139, 529);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ingredients";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnRefresh);
            this.groupBox2.Controls.Add(this.BtnSearchIngredient);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.TboxSearchIngredient);
            this.groupBox2.Location = new System.Drawing.Point(6, 359);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 157);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            // 
            // BtnSearchIngredient
            // 
            this.BtnSearchIngredient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSearchIngredient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearchIngredient.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSearchIngredient.ForeColor = System.Drawing.Color.White;
            this.BtnSearchIngredient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSearchIngredient.Location = new System.Drawing.Point(232, 100);
            this.BtnSearchIngredient.Name = "BtnSearchIngredient";
            this.BtnSearchIngredient.Size = new System.Drawing.Size(94, 33);
            this.BtnSearchIngredient.TabIndex = 9;
            this.BtnSearchIngredient.Text = "Search";
            this.BtnSearchIngredient.UseVisualStyleBackColor = false;
            this.BtnSearchIngredient.Click += new System.EventHandler(this.BtnSearchIngredient_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 21);
            this.label6.TabIndex = 6;
            this.label6.Text = "Ingredient Name";
            // 
            // TboxSearchIngredient
            // 
            this.TboxSearchIngredient.Location = new System.Drawing.Point(20, 65);
            this.TboxSearchIngredient.Name = "TboxSearchIngredient";
            this.TboxSearchIngredient.Size = new System.Drawing.Size(306, 29);
            this.TboxSearchIngredient.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnCancelSaveIngredientDetails);
            this.groupBox1.Controls.Add(this.BtnSaveIngredientDetails);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CBoxUnitOfMeasurements);
            this.groupBox1.Controls.Add(this.TboxIngredientName);
            this.groupBox1.Controls.Add(this.CboxIngredientsCategories);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 341);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // BtnCancelSaveIngredientDetails
            // 
            this.BtnCancelSaveIngredientDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelSaveIngredientDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelSaveIngredientDetails.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelSaveIngredientDetails.ForeColor = System.Drawing.Color.White;
            this.BtnCancelSaveIngredientDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelSaveIngredientDetails.Location = new System.Drawing.Point(211, 272);
            this.BtnCancelSaveIngredientDetails.Name = "BtnCancelSaveIngredientDetails";
            this.BtnCancelSaveIngredientDetails.Size = new System.Drawing.Size(115, 47);
            this.BtnCancelSaveIngredientDetails.TabIndex = 9;
            this.BtnCancelSaveIngredientDetails.Text = "Cancel";
            this.BtnCancelSaveIngredientDetails.UseVisualStyleBackColor = false;
            // 
            // BtnSaveIngredientDetails
            // 
            this.BtnSaveIngredientDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSaveIngredientDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveIngredientDetails.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveIngredientDetails.ForeColor = System.Drawing.Color.White;
            this.BtnSaveIngredientDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveIngredientDetails.Location = new System.Drawing.Point(90, 272);
            this.BtnSaveIngredientDetails.Name = "BtnSaveIngredientDetails";
            this.BtnSaveIngredientDetails.Size = new System.Drawing.Size(115, 47);
            this.BtnSaveIngredientDetails.TabIndex = 8;
            this.BtnSaveIngredientDetails.Text = "Save";
            this.BtnSaveIngredientDetails.UseVisualStyleBackColor = false;
            this.BtnSaveIngredientDetails.Click += new System.EventHandler(this.BtnSaveIngredientDetails_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(208, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "Unit of Measurement (UOM)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ingredient name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Category";
            // 
            // CBoxUnitOfMeasurements
            // 
            this.CBoxUnitOfMeasurements.FormattingEnabled = true;
            this.CBoxUnitOfMeasurements.Location = new System.Drawing.Point(20, 226);
            this.CBoxUnitOfMeasurements.Name = "CBoxUnitOfMeasurements";
            this.CBoxUnitOfMeasurements.Size = new System.Drawing.Size(306, 29);
            this.CBoxUnitOfMeasurements.TabIndex = 2;
            // 
            // TboxIngredientName
            // 
            this.TboxIngredientName.Location = new System.Drawing.Point(20, 146);
            this.TboxIngredientName.Name = "TboxIngredientName";
            this.TboxIngredientName.Size = new System.Drawing.Size(306, 29);
            this.TboxIngredientName.TabIndex = 1;
            // 
            // CboxIngredientsCategories
            // 
            this.CboxIngredientsCategories.FormattingEnabled = true;
            this.CboxIngredientsCategories.Location = new System.Drawing.Point(20, 66);
            this.CboxIngredientsCategories.Name = "CboxIngredientsCategories";
            this.CboxIngredientsCategories.Size = new System.Drawing.Size(306, 29);
            this.CboxIngredientsCategories.TabIndex = 0;
            // 
            // DGVIngredientList
            // 
            this.DGVIngredientList.AllowUserToAddRows = false;
            this.DGVIngredientList.AllowUserToDeleteRows = false;
            this.DGVIngredientList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVIngredientList.Dock = System.Windows.Forms.DockStyle.Right;
            this.DGVIngredientList.Location = new System.Drawing.Point(362, 3);
            this.DGVIngredientList.Name = "DGVIngredientList";
            this.DGVIngredientList.ReadOnly = true;
            this.DGVIngredientList.RowTemplate.Height = 25;
            this.DGVIngredientList.Size = new System.Drawing.Size(774, 523);
            this.DGVIngredientList.TabIndex = 0;
            this.DGVIngredientList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVIngredientList_CellClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1139, 529);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Inventory";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 30);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1139, 529);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Transaction History";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRefresh.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnRefresh.ForeColor = System.Drawing.Color.White;
            this.BtnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRefresh.Location = new System.Drawing.Point(134, 100);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(94, 33);
            this.BtnRefresh.TabIndex = 10;
            this.BtnRefresh.Text = "Refresh";
            this.BtnRefresh.UseVisualStyleBackColor = false;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // IngredientInventoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "IngredientInventoryControl";
            this.Size = new System.Drawing.Size(1147, 622);
            this.Load += new System.EventHandler(this.IngredientInventoryControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVIngredientCategories)).EndInit();
            this.GBoxIngredeitnCategoryForm.ResumeLayout(false);
            this.GBoxIngredeitnCategoryForm.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVIngredientList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView DGVIngredientCategories;
        private System.Windows.Forms.GroupBox GBoxIngredeitnCategoryForm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnCancelUpdate;
        private System.Windows.Forms.TextBox TbxCategory;
        private System.Windows.Forms.Button BtnSaveCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVIngredientList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CBoxUnitOfMeasurements;
        private System.Windows.Forms.TextBox TboxIngredientName;
        private System.Windows.Forms.ComboBox CboxIngredientsCategories;
        private System.Windows.Forms.Button BtnCancelSaveIngredientDetails;
        private System.Windows.Forms.Button BtnSaveIngredientDetails;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnSearchIngredient;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TboxSearchIngredient;
        private System.Windows.Forms.Button BtnRefresh;
    }
}
