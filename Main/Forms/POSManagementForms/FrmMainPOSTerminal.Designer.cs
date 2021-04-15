
namespace Main.Forms.POSManagementForms
{
    partial class FrmMainPOSTerminal
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.LeftSideSplitInnerContainer = new System.Windows.Forms.SplitContainer();
            this.DGVCartItems = new System.Windows.Forms.DataGridView();
            this.TopPanelInSplitContainerPanel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TabControlProductsAndComboMeals = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.RightSideSplitInnerContainer = new System.Windows.Forms.SplitContainer();
            this.FLPanelProductList = new System.Windows.Forms.FlowLayoutPanel();
            this.FLPanelProductCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.TopPanelInSplitContainerPanel2 = new System.Windows.Forms.Panel();
            this.LblCurrentProductCategory = new System.Windows.Forms.Label();
            this.BtnRefreshProductList = new System.Windows.Forms.Button();
            this.TbxSearchProducts = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.FlowLayoutComboMealItems = new System.Windows.Forms.FlowLayoutPanel();
            this.LVComboMealProducts = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnRefreshComboMealItems = new System.Windows.Forms.Button();
            this.TboxSearchComboMeals = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.POSMainTabControl = new System.Windows.Forms.TabControl();
            this.TabPageStore = new System.Windows.Forms.TabPage();
            this.TabPageTableStatus = new System.Windows.Forms.TabPage();
            this.PanelDineInOrdersTableStatus = new System.Windows.Forms.Panel();
            this.FlowLayoutTables = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.PanelPOSController = new System.Windows.Forms.Panel();
            this.POSControllerSplitContainer = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftSideSplitInnerContainer)).BeginInit();
            this.LeftSideSplitInnerContainer.Panel1.SuspendLayout();
            this.LeftSideSplitInnerContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCartItems)).BeginInit();
            this.TopPanelInSplitContainerPanel1.SuspendLayout();
            this.TabControlProductsAndComboMeals.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RightSideSplitInnerContainer)).BeginInit();
            this.RightSideSplitInnerContainer.Panel1.SuspendLayout();
            this.RightSideSplitInnerContainer.Panel2.SuspendLayout();
            this.RightSideSplitInnerContainer.SuspendLayout();
            this.TopPanelInSplitContainerPanel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.POSMainTabControl.SuspendLayout();
            this.TabPageStore.SuspendLayout();
            this.TabPageTableStatus.SuspendLayout();
            this.PanelDineInOrdersTableStatus.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.POSControllerSplitContainer)).BeginInit();
            this.POSControllerSplitContainer.Panel2.SuspendLayout();
            this.POSControllerSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.MainSplitContainer.Panel1.Controls.Add(this.LeftSideSplitInnerContainer);
            this.MainSplitContainer.Panel1.Controls.Add(this.TopPanelInSplitContainerPanel1);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.MainSplitContainer.Panel2.Controls.Add(this.TabControlProductsAndComboMeals);
            this.MainSplitContainer.Size = new System.Drawing.Size(1207, 632);
            this.MainSplitContainer.SplitterDistance = 603;
            this.MainSplitContainer.TabIndex = 0;
            // 
            // LeftSideSplitInnerContainer
            // 
            this.LeftSideSplitInnerContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftSideSplitInnerContainer.Location = new System.Drawing.Point(0, 54);
            this.LeftSideSplitInnerContainer.Name = "LeftSideSplitInnerContainer";
            this.LeftSideSplitInnerContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // LeftSideSplitInnerContainer.Panel1
            // 
            this.LeftSideSplitInnerContainer.Panel1.Controls.Add(this.DGVCartItems);
            this.LeftSideSplitInnerContainer.Size = new System.Drawing.Size(603, 578);
            this.LeftSideSplitInnerContainer.SplitterDistance = 340;
            this.LeftSideSplitInnerContainer.TabIndex = 2;
            // 
            // DGVCartItems
            // 
            this.DGVCartItems.AllowUserToAddRows = false;
            this.DGVCartItems.AllowUserToDeleteRows = false;
            this.DGVCartItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVCartItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVCartItems.Location = new System.Drawing.Point(0, 0);
            this.DGVCartItems.Name = "DGVCartItems";
            this.DGVCartItems.ReadOnly = true;
            this.DGVCartItems.RowTemplate.Height = 25;
            this.DGVCartItems.Size = new System.Drawing.Size(603, 340);
            this.DGVCartItems.TabIndex = 0;
            this.DGVCartItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVCartItems_CellClick);
            // 
            // TopPanelInSplitContainerPanel1
            // 
            this.TopPanelInSplitContainerPanel1.Controls.Add(this.label10);
            this.TopPanelInSplitContainerPanel1.Controls.Add(this.label9);
            this.TopPanelInSplitContainerPanel1.Controls.Add(this.textBox7);
            this.TopPanelInSplitContainerPanel1.Controls.Add(this.label1);
            this.TopPanelInSplitContainerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanelInSplitContainerPanel1.Location = new System.Drawing.Point(0, 0);
            this.TopPanelInSplitContainerPanel1.Name = "TopPanelInSplitContainerPanel1";
            this.TopPanelInSplitContainerPanel1.Size = new System.Drawing.Size(603, 54);
            this.TopPanelInSplitContainerPanel1.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(473, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 21);
            this.label10.TabIndex = 5;
            this.label10.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(412, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 21);
            this.label9.TabIndex = 4;
            this.label9.Text = "Items:";
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox7.Location = new System.Drawing.Point(159, 12);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(234, 29);
            this.textBox7.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search item code";
            // 
            // TabControlProductsAndComboMeals
            // 
            this.TabControlProductsAndComboMeals.Controls.Add(this.tabPage2);
            this.TabControlProductsAndComboMeals.Controls.Add(this.tabPage3);
            this.TabControlProductsAndComboMeals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlProductsAndComboMeals.Location = new System.Drawing.Point(0, 0);
            this.TabControlProductsAndComboMeals.Name = "TabControlProductsAndComboMeals";
            this.TabControlProductsAndComboMeals.SelectedIndex = 0;
            this.TabControlProductsAndComboMeals.Size = new System.Drawing.Size(600, 632);
            this.TabControlProductsAndComboMeals.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.RightSideSplitInnerContainer);
            this.tabPage2.Controls.Add(this.TopPanelInSplitContainerPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(592, 598);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Products";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // RightSideSplitInnerContainer
            // 
            this.RightSideSplitInnerContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightSideSplitInnerContainer.Location = new System.Drawing.Point(3, 77);
            this.RightSideSplitInnerContainer.Name = "RightSideSplitInnerContainer";
            this.RightSideSplitInnerContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // RightSideSplitInnerContainer.Panel1
            // 
            this.RightSideSplitInnerContainer.Panel1.Controls.Add(this.FLPanelProductList);
            // 
            // RightSideSplitInnerContainer.Panel2
            // 
            this.RightSideSplitInnerContainer.Panel2.Controls.Add(this.FLPanelProductCategories);
            this.RightSideSplitInnerContainer.Size = new System.Drawing.Size(586, 518);
            this.RightSideSplitInnerContainer.SplitterDistance = 304;
            this.RightSideSplitInnerContainer.TabIndex = 2;
            // 
            // FLPanelProductList
            // 
            this.FLPanelProductList.AutoScroll = true;
            this.FLPanelProductList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FLPanelProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLPanelProductList.Location = new System.Drawing.Point(0, 0);
            this.FLPanelProductList.Name = "FLPanelProductList";
            this.FLPanelProductList.Size = new System.Drawing.Size(586, 304);
            this.FLPanelProductList.TabIndex = 0;
            // 
            // FLPanelProductCategories
            // 
            this.FLPanelProductCategories.AutoScroll = true;
            this.FLPanelProductCategories.BackColor = System.Drawing.SystemColors.ControlLight;
            this.FLPanelProductCategories.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FLPanelProductCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLPanelProductCategories.Location = new System.Drawing.Point(0, 0);
            this.FLPanelProductCategories.Name = "FLPanelProductCategories";
            this.FLPanelProductCategories.Size = new System.Drawing.Size(586, 210);
            this.FLPanelProductCategories.TabIndex = 0;
            // 
            // TopPanelInSplitContainerPanel2
            // 
            this.TopPanelInSplitContainerPanel2.Controls.Add(this.LblCurrentProductCategory);
            this.TopPanelInSplitContainerPanel2.Controls.Add(this.BtnRefreshProductList);
            this.TopPanelInSplitContainerPanel2.Controls.Add(this.TbxSearchProducts);
            this.TopPanelInSplitContainerPanel2.Controls.Add(this.label2);
            this.TopPanelInSplitContainerPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanelInSplitContainerPanel2.Location = new System.Drawing.Point(3, 3);
            this.TopPanelInSplitContainerPanel2.Name = "TopPanelInSplitContainerPanel2";
            this.TopPanelInSplitContainerPanel2.Size = new System.Drawing.Size(586, 74);
            this.TopPanelInSplitContainerPanel2.TabIndex = 1;
            // 
            // LblCurrentProductCategory
            // 
            this.LblCurrentProductCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(209)))));
            this.LblCurrentProductCategory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblCurrentProductCategory.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblCurrentProductCategory.ForeColor = System.Drawing.Color.White;
            this.LblCurrentProductCategory.Location = new System.Drawing.Point(0, 53);
            this.LblCurrentProductCategory.Name = "LblCurrentProductCategory";
            this.LblCurrentProductCategory.Size = new System.Drawing.Size(586, 21);
            this.LblCurrentProductCategory.TabIndex = 63;
            this.LblCurrentProductCategory.Text = "Current Category";
            // 
            // BtnRefreshProductList
            // 
            this.BtnRefreshProductList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnRefreshProductList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRefreshProductList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnRefreshProductList.ForeColor = System.Drawing.Color.White;
            this.BtnRefreshProductList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRefreshProductList.Location = new System.Drawing.Point(441, 8);
            this.BtnRefreshProductList.Name = "BtnRefreshProductList";
            this.BtnRefreshProductList.Size = new System.Drawing.Size(136, 31);
            this.BtnRefreshProductList.TabIndex = 62;
            this.BtnRefreshProductList.Text = "Refresh Products";
            this.BtnRefreshProductList.UseVisualStyleBackColor = false;
            this.BtnRefreshProductList.Click += new System.EventHandler(this.BtnRefreshProductList_Click);
            // 
            // TbxSearchProducts
            // 
            this.TbxSearchProducts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbxSearchProducts.Location = new System.Drawing.Point(127, 10);
            this.TbxSearchProducts.Name = "TbxSearchProducts";
            this.TbxSearchProducts.Size = new System.Drawing.Size(284, 29);
            this.TbxSearchProducts.TabIndex = 1;
            this.TbxSearchProducts.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbxSearchProducts_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(25, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Search item";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.splitContainer1);
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Location = new System.Drawing.Point(4, 30);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(592, 598);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Combo Meals";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 57);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.FlowLayoutComboMealItems);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.LVComboMealProducts);
            this.splitContainer1.Size = new System.Drawing.Size(586, 538);
            this.splitContainer1.SplitterDistance = 316;
            this.splitContainer1.TabIndex = 3;
            // 
            // FlowLayoutComboMealItems
            // 
            this.FlowLayoutComboMealItems.AutoScroll = true;
            this.FlowLayoutComboMealItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FlowLayoutComboMealItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowLayoutComboMealItems.Location = new System.Drawing.Point(0, 0);
            this.FlowLayoutComboMealItems.Name = "FlowLayoutComboMealItems";
            this.FlowLayoutComboMealItems.Size = new System.Drawing.Size(586, 316);
            this.FlowLayoutComboMealItems.TabIndex = 0;
            // 
            // LVComboMealProducts
            // 
            this.LVComboMealProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.LVComboMealProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LVComboMealProducts.GridLines = true;
            this.LVComboMealProducts.HideSelection = false;
            this.LVComboMealProducts.Location = new System.Drawing.Point(0, 0);
            this.LVComboMealProducts.Name = "LVComboMealProducts";
            this.LVComboMealProducts.Size = new System.Drawing.Size(586, 218);
            this.LVComboMealProducts.TabIndex = 0;
            this.LVComboMealProducts.UseCompatibleStateImageBehavior = false;
            this.LVComboMealProducts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Product";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Price";
            this.columnHeader2.Width = 100;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnRefreshComboMealItems);
            this.panel2.Controls.Add(this.TboxSearchComboMeals);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(586, 54);
            this.panel2.TabIndex = 2;
            // 
            // BtnRefreshComboMealItems
            // 
            this.BtnRefreshComboMealItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnRefreshComboMealItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRefreshComboMealItems.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnRefreshComboMealItems.ForeColor = System.Drawing.Color.White;
            this.BtnRefreshComboMealItems.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRefreshComboMealItems.Location = new System.Drawing.Point(434, 15);
            this.BtnRefreshComboMealItems.Name = "BtnRefreshComboMealItems";
            this.BtnRefreshComboMealItems.Size = new System.Drawing.Size(136, 31);
            this.BtnRefreshComboMealItems.TabIndex = 63;
            this.BtnRefreshComboMealItems.Text = "Refresh Combo Meals";
            this.BtnRefreshComboMealItems.UseVisualStyleBackColor = false;
            this.BtnRefreshComboMealItems.Click += new System.EventHandler(this.BtnRefreshComboMealItems_Click);
            // 
            // TboxSearchComboMeals
            // 
            this.TboxSearchComboMeals.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TboxSearchComboMeals.Location = new System.Drawing.Point(127, 17);
            this.TboxSearchComboMeals.Name = "TboxSearchComboMeals";
            this.TboxSearchComboMeals.Size = new System.Drawing.Size(284, 29);
            this.TboxSearchComboMeals.TabIndex = 1;
            this.TboxSearchComboMeals.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TboxSearchComboMeals_KeyUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(25, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 21);
            this.label11.TabIndex = 0;
            this.label11.Text = "Search item";
            // 
            // POSMainTabControl
            // 
            this.POSMainTabControl.Controls.Add(this.TabPageStore);
            this.POSMainTabControl.Controls.Add(this.TabPageTableStatus);
            this.POSMainTabControl.Controls.Add(this.tabPage1);
            this.POSMainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.POSMainTabControl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.POSMainTabControl.Location = new System.Drawing.Point(0, 0);
            this.POSMainTabControl.Name = "POSMainTabControl";
            this.POSMainTabControl.SelectedIndex = 0;
            this.POSMainTabControl.Size = new System.Drawing.Size(1221, 672);
            this.POSMainTabControl.TabIndex = 1;
            this.POSMainTabControl.SelectedIndexChanged += new System.EventHandler(this.POSMainTabControl_SelectedIndexChanged);
            // 
            // TabPageStore
            // 
            this.TabPageStore.Controls.Add(this.MainSplitContainer);
            this.TabPageStore.Location = new System.Drawing.Point(4, 30);
            this.TabPageStore.Name = "TabPageStore";
            this.TabPageStore.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageStore.Size = new System.Drawing.Size(1213, 638);
            this.TabPageStore.TabIndex = 0;
            this.TabPageStore.Text = "Store";
            this.TabPageStore.UseVisualStyleBackColor = true;
            // 
            // TabPageTableStatus
            // 
            this.TabPageTableStatus.Controls.Add(this.PanelDineInOrdersTableStatus);
            this.TabPageTableStatus.Location = new System.Drawing.Point(4, 30);
            this.TabPageTableStatus.Name = "TabPageTableStatus";
            this.TabPageTableStatus.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageTableStatus.Size = new System.Drawing.Size(1213, 638);
            this.TabPageTableStatus.TabIndex = 1;
            this.TabPageTableStatus.Text = "Tables";
            this.TabPageTableStatus.UseVisualStyleBackColor = true;
            // 
            // PanelDineInOrdersTableStatus
            // 
            this.PanelDineInOrdersTableStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelDineInOrdersTableStatus.Controls.Add(this.FlowLayoutTables);
            this.PanelDineInOrdersTableStatus.Controls.Add(this.panel1);
            this.PanelDineInOrdersTableStatus.Location = new System.Drawing.Point(63, 23);
            this.PanelDineInOrdersTableStatus.Name = "PanelDineInOrdersTableStatus";
            this.PanelDineInOrdersTableStatus.Size = new System.Drawing.Size(1101, 567);
            this.PanelDineInOrdersTableStatus.TabIndex = 0;
            // 
            // FlowLayoutTables
            // 
            this.FlowLayoutTables.AutoScroll = true;
            this.FlowLayoutTables.BackColor = System.Drawing.Color.White;
            this.FlowLayoutTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowLayoutTables.Location = new System.Drawing.Point(0, 62);
            this.FlowLayoutTables.Name = "FlowLayoutTables";
            this.FlowLayoutTables.Size = new System.Drawing.Size(1101, 505);
            this.FlowLayoutTables.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1101, 62);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Red;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(146, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 32);
            this.label3.TabIndex = 3;
            this.label3.Text = "OCCUPIED";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LawnGreen;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(0, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 32);
            this.label4.TabIndex = 2;
            this.label4.Text = "AVAILABLE";
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1213, 638);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "History";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(235, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(137, 21);
            this.label12.TabIndex = 3;
            this.label12.Text = "Search item code";
            // 
            // PanelPOSController
            // 
            this.PanelPOSController.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelPOSController.Location = new System.Drawing.Point(0, 0);
            this.PanelPOSController.Name = "PanelPOSController";
            this.PanelPOSController.Size = new System.Drawing.Size(370, 234);
            this.PanelPOSController.TabIndex = 0;
            // 
            // POSControllerSplitContainer
            // 
            this.POSControllerSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.POSControllerSplitContainer.Name = "POSControllerSplitContainer";
            // 
            // POSControllerSplitContainer.Panel2
            // 
            this.POSControllerSplitContainer.Panel2.Controls.Add(this.PanelPOSController);
            this.POSControllerSplitContainer.Size = new System.Drawing.Size(603, 234);
            this.POSControllerSplitContainer.SplitterDistance = 229;
            this.POSControllerSplitContainer.TabIndex = 0;
            // 
            // FrmMainPOSTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 672);
            this.Controls.Add(this.POSMainTabControl);
            this.Name = "FrmMainPOSTerminal";
            this.Text = "Point of sale terminal";
            this.Load += new System.EventHandler(this.FrmMainPOSTerminal_Load);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.LeftSideSplitInnerContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LeftSideSplitInnerContainer)).EndInit();
            this.LeftSideSplitInnerContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVCartItems)).EndInit();
            this.TopPanelInSplitContainerPanel1.ResumeLayout(false);
            this.TopPanelInSplitContainerPanel1.PerformLayout();
            this.TabControlProductsAndComboMeals.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.RightSideSplitInnerContainer.Panel1.ResumeLayout(false);
            this.RightSideSplitInnerContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RightSideSplitInnerContainer)).EndInit();
            this.RightSideSplitInnerContainer.ResumeLayout(false);
            this.TopPanelInSplitContainerPanel2.ResumeLayout(false);
            this.TopPanelInSplitContainerPanel2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.POSMainTabControl.ResumeLayout(false);
            this.TabPageStore.ResumeLayout(false);
            this.TabPageTableStatus.ResumeLayout(false);
            this.PanelDineInOrdersTableStatus.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.POSControllerSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.POSControllerSplitContainer)).EndInit();
            this.POSControllerSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.Panel TopPanelInSplitContainerPanel1;
        private System.Windows.Forms.Panel TopPanelInSplitContainerPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer LeftSideSplitInnerContainer;
        private System.Windows.Forms.SplitContainer RightSideSplitInnerContainer;
        private System.Windows.Forms.DataGridView DGVCartItems;
        private System.Windows.Forms.FlowLayoutPanel FLPanelProductList;
        private System.Windows.Forms.FlowLayoutPanel FLPanelProductCategories;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TbxSearchProducts;
        private System.Windows.Forms.TabControl POSMainTabControl;
        private System.Windows.Forms.TabPage TabPageStore;
        private System.Windows.Forms.TabPage TabPageTableStatus;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel PanelDineInOrdersTableStatus;
        private System.Windows.Forms.TabControl TabControlProductsAndComboMeals;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox TboxSearchComboMeals;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutComboMealItems;
        private System.Windows.Forms.ListView LVComboMealProducts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button BtnRefreshProductList;
        private System.Windows.Forms.Label LblCurrentProductCategory;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button BtnRefreshComboMealItems;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutTables;
        private System.Windows.Forms.Panel PanelPOSController;
        private System.Windows.Forms.SplitContainer POSControllerSplitContainer;
    }
}