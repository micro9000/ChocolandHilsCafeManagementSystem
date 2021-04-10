
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
            this.POSControllerSplitContainer = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnCancelAllEmployeePayslip = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TopPanelInSplitContainerPanel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RightSideSplitInnerContainer = new System.Windows.Forms.SplitContainer();
            this.FLPanelProductList = new System.Windows.Forms.FlowLayoutPanel();
            this.FLPanelProductCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.TopPanelInSplitContainerPanel2 = new System.Windows.Forms.Panel();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabPageStore = new System.Windows.Forms.TabPage();
            this.TabPageActiveDineInOrders = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftSideSplitInnerContainer)).BeginInit();
            this.LeftSideSplitInnerContainer.Panel1.SuspendLayout();
            this.LeftSideSplitInnerContainer.Panel2.SuspendLayout();
            this.LeftSideSplitInnerContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCartItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.POSControllerSplitContainer)).BeginInit();
            this.POSControllerSplitContainer.Panel2.SuspendLayout();
            this.POSControllerSplitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.TopPanelInSplitContainerPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RightSideSplitInnerContainer)).BeginInit();
            this.RightSideSplitInnerContainer.Panel1.SuspendLayout();
            this.RightSideSplitInnerContainer.Panel2.SuspendLayout();
            this.RightSideSplitInnerContainer.SuspendLayout();
            this.TopPanelInSplitContainerPanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TabPageStore.SuspendLayout();
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
            this.MainSplitContainer.Panel2.Controls.Add(this.RightSideSplitInnerContainer);
            this.MainSplitContainer.Panel2.Controls.Add(this.TopPanelInSplitContainerPanel2);
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
            // 
            // LeftSideSplitInnerContainer.Panel2
            // 
            this.LeftSideSplitInnerContainer.Panel2.Controls.Add(this.POSControllerSplitContainer);
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
            // 
            // POSControllerSplitContainer
            // 
            this.POSControllerSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.POSControllerSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.POSControllerSplitContainer.Name = "POSControllerSplitContainer";
            // 
            // POSControllerSplitContainer.Panel2
            // 
            this.POSControllerSplitContainer.Panel2.Controls.Add(this.panel1);
            this.POSControllerSplitContainer.Size = new System.Drawing.Size(603, 234);
            this.POSControllerSplitContainer.SplitterDistance = 231;
            this.POSControllerSplitContainer.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.BtnCancelAllEmployeePayslip);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textBox5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 234);
            this.panel1.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(204, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 38);
            this.button1.TabIndex = 62;
            this.button1.Text = "CHECK OUT";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // BtnCancelAllEmployeePayslip
            // 
            this.BtnCancelAllEmployeePayslip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelAllEmployeePayslip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelAllEmployeePayslip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelAllEmployeePayslip.ForeColor = System.Drawing.Color.White;
            this.BtnCancelAllEmployeePayslip.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelAllEmployeePayslip.Location = new System.Drawing.Point(80, 170);
            this.BtnCancelAllEmployeePayslip.Name = "BtnCancelAllEmployeePayslip";
            this.BtnCancelAllEmployeePayslip.Size = new System.Drawing.Size(88, 27);
            this.BtnCancelAllEmployeePayslip.TabIndex = 61;
            this.BtnCancelAllEmployeePayslip.Text = "VIEW TABLES";
            this.BtnCancelAllEmployeePayslip.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(13, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "TABLES AVAILABLE";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 139);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(155, 25);
            this.comboBox1.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(196, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Due";
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox5.Location = new System.Drawing.Point(196, 139);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(119, 25);
            this.textBox5.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(196, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Change";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox2.Location = new System.Drawing.Point(196, 31);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(119, 25);
            this.textBox2.TabIndex = 4;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox4.Location = new System.Drawing.Point(196, 82);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(119, 25);
            this.textBox4.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(196, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cash";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(17, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Customer name";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(13, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(155, 25);
            this.textBox1.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox3.Location = new System.Drawing.Point(13, 82);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(155, 25);
            this.textBox3.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(13, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Document number";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // RightSideSplitInnerContainer
            // 
            this.RightSideSplitInnerContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightSideSplitInnerContainer.Location = new System.Drawing.Point(0, 54);
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
            this.RightSideSplitInnerContainer.Size = new System.Drawing.Size(600, 578);
            this.RightSideSplitInnerContainer.SplitterDistance = 340;
            this.RightSideSplitInnerContainer.TabIndex = 2;
            // 
            // FLPanelProductList
            // 
            this.FLPanelProductList.AutoScroll = true;
            this.FLPanelProductList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FLPanelProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLPanelProductList.Location = new System.Drawing.Point(0, 0);
            this.FLPanelProductList.Name = "FLPanelProductList";
            this.FLPanelProductList.Size = new System.Drawing.Size(600, 340);
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
            this.FLPanelProductCategories.Size = new System.Drawing.Size(600, 234);
            this.FLPanelProductCategories.TabIndex = 0;
            // 
            // TopPanelInSplitContainerPanel2
            // 
            this.TopPanelInSplitContainerPanel2.Controls.Add(this.textBox6);
            this.TopPanelInSplitContainerPanel2.Controls.Add(this.label2);
            this.TopPanelInSplitContainerPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanelInSplitContainerPanel2.Location = new System.Drawing.Point(0, 0);
            this.TopPanelInSplitContainerPanel2.Name = "TopPanelInSplitContainerPanel2";
            this.TopPanelInSplitContainerPanel2.Size = new System.Drawing.Size(600, 54);
            this.TopPanelInSplitContainerPanel2.TabIndex = 1;
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox6.Location = new System.Drawing.Point(127, 17);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(284, 29);
            this.textBox6.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(25, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Search item";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabPageStore);
            this.tabControl1.Controls.Add(this.TabPageActiveDineInOrders);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1221, 672);
            this.tabControl1.TabIndex = 1;
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
            // TabPageActiveDineInOrders
            // 
            this.TabPageActiveDineInOrders.Location = new System.Drawing.Point(4, 30);
            this.TabPageActiveDineInOrders.Name = "TabPageActiveDineInOrders";
            this.TabPageActiveDineInOrders.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageActiveDineInOrders.Size = new System.Drawing.Size(1213, 638);
            this.TabPageActiveDineInOrders.TabIndex = 1;
            this.TabPageActiveDineInOrders.Text = "Active D-IN Orders";
            this.TabPageActiveDineInOrders.UseVisualStyleBackColor = true;
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
            // FrmMainPOSTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 672);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmMainPOSTerminal";
            this.Text = "Point of sale terminal";
            this.Load += new System.EventHandler(this.FrmMainPOSTerminal_Load);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.LeftSideSplitInnerContainer.Panel1.ResumeLayout(false);
            this.LeftSideSplitInnerContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LeftSideSplitInnerContainer)).EndInit();
            this.LeftSideSplitInnerContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVCartItems)).EndInit();
            this.POSControllerSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.POSControllerSplitContainer)).EndInit();
            this.POSControllerSplitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TopPanelInSplitContainerPanel1.ResumeLayout(false);
            this.TopPanelInSplitContainerPanel1.PerformLayout();
            this.RightSideSplitInnerContainer.Panel1.ResumeLayout(false);
            this.RightSideSplitInnerContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RightSideSplitInnerContainer)).EndInit();
            this.RightSideSplitInnerContainer.ResumeLayout(false);
            this.TopPanelInSplitContainerPanel2.ResumeLayout(false);
            this.TopPanelInSplitContainerPanel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.TabPageStore.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer POSControllerSplitContainer;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BtnCancelAllEmployeePayslip;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabPageStore;
        private System.Windows.Forms.TabPage TabPageActiveDineInOrders;
        private System.Windows.Forms.TabPage tabPage1;
    }
}