
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
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.MainTabProdCategory = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVProrductCategories = new System.Windows.Forms.DataGridView();
            this.GBoxIngredeitnCategoryForm = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnCancelUpdateCategory = new System.Windows.Forms.Button();
            this.TbxCategory = new System.Windows.Forms.TextBox();
            this.BtnSaveCategory = new System.Windows.Forms.Button();
            this.MainTabAddProduct = new System.Windows.Forms.TabPage();
            this.SelectIngredientsTabControl = new System.Windows.Forms.TabControl();
            this.TabItemSelectIngredients = new System.Windows.Forms.TabPage();
            this.BtnRefreshIngredientList = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.TboxSearchIngredients = new System.Windows.Forms.TextBox();
            this.DGVIngredientListToSelect = new System.Windows.Forms.DataGridView();
            this.TabItemEnterIngredientAmount = new System.Windows.Forms.TabPage();
            this.DGVSelectedIngredients = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.CboxCategories = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.LblNumberOfSelectedIngredients = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.MainTabProducts = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.MainTabProdCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProrductCategories)).BeginInit();
            this.GBoxIngredeitnCategoryForm.SuspendLayout();
            this.MainTabAddProduct.SuspendLayout();
            this.SelectIngredientsTabControl.SuspendLayout();
            this.TabItemSelectIngredients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVIngredientListToSelect)).BeginInit();
            this.TabItemEnterIngredientAmount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSelectedIngredients)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1088, 59);
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
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.MainTabProdCategory);
            this.MainTabControl.Controls.Add(this.MainTabAddProduct);
            this.MainTabControl.Controls.Add(this.MainTabProducts);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainTabControl.Location = new System.Drawing.Point(0, 59);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(1088, 578);
            this.MainTabControl.TabIndex = 7;
            // 
            // MainTabProdCategory
            // 
            this.MainTabProdCategory.Controls.Add(this.label1);
            this.MainTabProdCategory.Controls.Add(this.DGVProrductCategories);
            this.MainTabProdCategory.Controls.Add(this.GBoxIngredeitnCategoryForm);
            this.MainTabProdCategory.Location = new System.Drawing.Point(4, 29);
            this.MainTabProdCategory.Name = "MainTabProdCategory";
            this.MainTabProdCategory.Padding = new System.Windows.Forms.Padding(3);
            this.MainTabProdCategory.Size = new System.Drawing.Size(1080, 545);
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
            // MainTabAddProduct
            // 
            this.MainTabAddProduct.Controls.Add(this.SelectIngredientsTabControl);
            this.MainTabAddProduct.Controls.Add(this.groupBox1);
            this.MainTabAddProduct.Controls.Add(this.LblNumberOfSelectedIngredients);
            this.MainTabAddProduct.Controls.Add(this.label6);
            this.MainTabAddProduct.Location = new System.Drawing.Point(4, 29);
            this.MainTabAddProduct.Name = "MainTabAddProduct";
            this.MainTabAddProduct.Padding = new System.Windows.Forms.Padding(3);
            this.MainTabAddProduct.Size = new System.Drawing.Size(1080, 545);
            this.MainTabAddProduct.TabIndex = 1;
            this.MainTabAddProduct.Text = "Add Product";
            this.MainTabAddProduct.UseVisualStyleBackColor = true;
            // 
            // SelectIngredientsTabControl
            // 
            this.SelectIngredientsTabControl.Controls.Add(this.TabItemSelectIngredients);
            this.SelectIngredientsTabControl.Controls.Add(this.TabItemEnterIngredientAmount);
            this.SelectIngredientsTabControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.SelectIngredientsTabControl.Location = new System.Drawing.Point(448, 3);
            this.SelectIngredientsTabControl.Name = "SelectIngredientsTabControl";
            this.SelectIngredientsTabControl.SelectedIndex = 0;
            this.SelectIngredientsTabControl.Size = new System.Drawing.Size(629, 539);
            this.SelectIngredientsTabControl.TabIndex = 55;
            // 
            // TabItemSelectIngredients
            // 
            this.TabItemSelectIngredients.Controls.Add(this.BtnRefreshIngredientList);
            this.TabItemSelectIngredients.Controls.Add(this.label8);
            this.TabItemSelectIngredients.Controls.Add(this.TboxSearchIngredients);
            this.TabItemSelectIngredients.Controls.Add(this.DGVIngredientListToSelect);
            this.TabItemSelectIngredients.Location = new System.Drawing.Point(4, 29);
            this.TabItemSelectIngredients.Name = "TabItemSelectIngredients";
            this.TabItemSelectIngredients.Padding = new System.Windows.Forms.Padding(3);
            this.TabItemSelectIngredients.Size = new System.Drawing.Size(621, 506);
            this.TabItemSelectIngredients.TabIndex = 0;
            this.TabItemSelectIngredients.Text = "Select Ingredients";
            this.TabItemSelectIngredients.UseVisualStyleBackColor = true;
            // 
            // BtnRefreshIngredientList
            // 
            this.BtnRefreshIngredientList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnRefreshIngredientList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRefreshIngredientList.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnRefreshIngredientList.ForeColor = System.Drawing.Color.White;
            this.BtnRefreshIngredientList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRefreshIngredientList.Location = new System.Drawing.Point(135, 15);
            this.BtnRefreshIngredientList.Name = "BtnRefreshIngredientList";
            this.BtnRefreshIngredientList.Size = new System.Drawing.Size(74, 30);
            this.BtnRefreshIngredientList.TabIndex = 30;
            this.BtnRefreshIngredientList.Text = "Refresh";
            this.BtnRefreshIngredientList.UseVisualStyleBackColor = false;
            this.BtnRefreshIngredientList.Click += new System.EventHandler(this.BtnRefreshIngredientList_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(215, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 21);
            this.label8.TabIndex = 29;
            this.label8.Text = "Search";
            // 
            // TboxSearchIngredients
            // 
            this.TboxSearchIngredients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TboxSearchIngredients.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TboxSearchIngredients.Location = new System.Drawing.Point(278, 14);
            this.TboxSearchIngredients.Name = "TboxSearchIngredients";
            this.TboxSearchIngredients.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TboxSearchIngredients.Size = new System.Drawing.Size(325, 29);
            this.TboxSearchIngredients.TabIndex = 28;
            this.TboxSearchIngredients.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TboxSearchIngredients_KeyUp);
            // 
            // DGVIngredientListToSelect
            // 
            this.DGVIngredientListToSelect.AllowUserToAddRows = false;
            this.DGVIngredientListToSelect.AllowUserToDeleteRows = false;
            this.DGVIngredientListToSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVIngredientListToSelect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DGVIngredientListToSelect.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DGVIngredientListToSelect.Location = new System.Drawing.Point(3, 51);
            this.DGVIngredientListToSelect.Name = "DGVIngredientListToSelect";
            this.DGVIngredientListToSelect.RowTemplate.Height = 25;
            this.DGVIngredientListToSelect.Size = new System.Drawing.Size(615, 452);
            this.DGVIngredientListToSelect.TabIndex = 0;
            this.DGVIngredientListToSelect.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVIngredientListToSelect_CellClick);
            this.DGVIngredientListToSelect.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVIngredientListToSelect_CellContentClick);
            // 
            // TabItemEnterIngredientAmount
            // 
            this.TabItemEnterIngredientAmount.Controls.Add(this.DGVSelectedIngredients);
            this.TabItemEnterIngredientAmount.Location = new System.Drawing.Point(4, 29);
            this.TabItemEnterIngredientAmount.Name = "TabItemEnterIngredientAmount";
            this.TabItemEnterIngredientAmount.Padding = new System.Windows.Forms.Padding(3);
            this.TabItemEnterIngredientAmount.Size = new System.Drawing.Size(621, 506);
            this.TabItemEnterIngredientAmount.TabIndex = 1;
            this.TabItemEnterIngredientAmount.Text = "Ingredients Amount";
            this.TabItemEnterIngredientAmount.UseVisualStyleBackColor = true;
            // 
            // DGVSelectedIngredients
            // 
            this.DGVSelectedIngredients.AllowUserToAddRows = false;
            this.DGVSelectedIngredients.AllowUserToDeleteRows = false;
            this.DGVSelectedIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVSelectedIngredients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVSelectedIngredients.Location = new System.Drawing.Point(3, 3);
            this.DGVSelectedIngredients.MultiSelect = false;
            this.DGVSelectedIngredients.Name = "DGVSelectedIngredients";
            this.DGVSelectedIngredients.RowTemplate.Height = 25;
            this.DGVSelectedIngredients.Size = new System.Drawing.Size(615, 500);
            this.DGVSelectedIngredients.TabIndex = 0;
            this.DGVSelectedIngredients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVSelectedIngredients_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.CboxCategories);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(27, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 363);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add New";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(27, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 21);
            this.label5.TabIndex = 50;
            this.label5.Text = "Price per order";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Location = new System.Drawing.Point(27, 233);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(325, 27);
            this.numericUpDown1.TabIndex = 49;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(27, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 21);
            this.label4.TabIndex = 48;
            this.label4.Text = "Product name";
            // 
            // CboxCategories
            // 
            this.CboxCategories.FormattingEnabled = true;
            this.CboxCategories.Location = new System.Drawing.Point(27, 72);
            this.CboxCategories.Name = "CboxCategories";
            this.CboxCategories.Size = new System.Drawing.Size(325, 28);
            this.CboxCategories.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(27, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 21);
            this.label3.TabIndex = 25;
            this.label3.Text = "Category";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(240, 286);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 47);
            this.button1.TabIndex = 46;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(27, 155);
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.Size = new System.Drawing.Size(325, 29);
            this.textBox1.TabIndex = 24;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(119, 286);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 47);
            this.button2.TabIndex = 2;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // LblNumberOfSelectedIngredients
            // 
            this.LblNumberOfSelectedIngredients.AutoSize = true;
            this.LblNumberOfSelectedIngredients.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblNumberOfSelectedIngredients.ForeColor = System.Drawing.Color.Black;
            this.LblNumberOfSelectedIngredients.Location = new System.Drawing.Point(276, 435);
            this.LblNumberOfSelectedIngredients.Name = "LblNumberOfSelectedIngredients";
            this.LblNumberOfSelectedIngredients.Size = new System.Drawing.Size(19, 21);
            this.LblNumberOfSelectedIngredients.TabIndex = 27;
            this.LblNumberOfSelectedIngredients.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(120, 435);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 21);
            this.label6.TabIndex = 26;
            this.label6.Text = "Selected Ingredients";
            // 
            // MainTabProducts
            // 
            this.MainTabProducts.Location = new System.Drawing.Point(4, 29);
            this.MainTabProducts.Name = "MainTabProducts";
            this.MainTabProducts.Size = new System.Drawing.Size(1080, 545);
            this.MainTabProducts.TabIndex = 2;
            this.MainTabProducts.Text = "Product List";
            this.MainTabProducts.UseVisualStyleBackColor = true;
            // 
            // ProductInventoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.panel1);
            this.Name = "ProductInventoryControl";
            this.Size = new System.Drawing.Size(1088, 637);
            this.Load += new System.EventHandler(this.ProductInventoryControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.MainTabControl.ResumeLayout(false);
            this.MainTabProdCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVProrductCategories)).EndInit();
            this.GBoxIngredeitnCategoryForm.ResumeLayout(false);
            this.GBoxIngredeitnCategoryForm.PerformLayout();
            this.MainTabAddProduct.ResumeLayout(false);
            this.MainTabAddProduct.PerformLayout();
            this.SelectIngredientsTabControl.ResumeLayout(false);
            this.TabItemSelectIngredients.ResumeLayout(false);
            this.TabItemSelectIngredients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVIngredientListToSelect)).EndInit();
            this.TabItemEnterIngredientAmount.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVSelectedIngredients)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage MainTabProdCategory;
        private System.Windows.Forms.TabPage MainTabAddProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVProrductCategories;
        private System.Windows.Forms.GroupBox GBoxIngredeitnCategoryForm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnCancelUpdateCategory;
        private System.Windows.Forms.TextBox TbxCategory;
        private System.Windows.Forms.Button BtnSaveCategory;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage MainTabProducts;
        private System.Windows.Forms.TabControl SelectIngredientsTabControl;
        private System.Windows.Forms.TabPage TabItemSelectIngredients;
        private System.Windows.Forms.TabPage TabItemEnterIngredientAmount;
        private System.Windows.Forms.ComboBox CboxCategories;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TboxSearchIngredients;
        private System.Windows.Forms.Label LblNumberOfSelectedIngredients;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView DGVIngredientListToSelect;
        private System.Windows.Forms.DataGridView DGVSelectedIngredients;
        private System.Windows.Forms.Button BtnRefreshIngredientList;
    }
}
