
namespace Main.Forms.POSManagementForms.Controls
{
    partial class POSControllerControl
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
            this.TabControlMain = new System.Windows.Forms.TabControl();
            this.TabPageControls = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnNewTransaction = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.TabPageActiveDineInTransactions = new System.Windows.Forms.TabPage();
            this.DGVActiveDineInTransactions = new System.Windows.Forms.DataGridView();
            this.TabPageCheckout = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnSave = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.TboxNumberOfItems = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TboxTicketNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TboxCustomerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TboxTableNumber = new System.Windows.Forms.TextBox();
            this.BtnCancelCurrentTransaction = new System.Windows.Forms.Button();
            this.TabControlMain.SuspendLayout();
            this.TabPageControls.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.TabPageActiveDineInTransactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVActiveDineInTransactions)).BeginInit();
            this.TabPageCheckout.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControlMain
            // 
            this.TabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControlMain.Controls.Add(this.TabPageControls);
            this.TabControlMain.Controls.Add(this.TabPageActiveDineInTransactions);
            this.TabControlMain.Controls.Add(this.TabPageCheckout);
            this.TabControlMain.Location = new System.Drawing.Point(0, 0);
            this.TabControlMain.Name = "TabControlMain";
            this.TabControlMain.SelectedIndex = 0;
            this.TabControlMain.Size = new System.Drawing.Size(509, 308);
            this.TabControlMain.TabIndex = 12;
            this.TabControlMain.SelectedIndexChanged += new System.EventHandler(this.TabControlMain_SelectedIndexChanged);
            // 
            // TabPageControls
            // 
            this.TabPageControls.Controls.Add(this.flowLayoutPanel1);
            this.TabPageControls.Location = new System.Drawing.Point(4, 30);
            this.TabPageControls.Name = "TabPageControls";
            this.TabPageControls.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageControls.Size = new System.Drawing.Size(501, 274);
            this.TabPageControls.TabIndex = 0;
            this.TabPageControls.Text = "Controls";
            this.TabPageControls.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.BtnNewTransaction);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(495, 268);
            this.flowLayoutPanel1.TabIndex = 68;
            // 
            // BtnNewTransaction
            // 
            this.BtnNewTransaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(64)))), ((int)(((byte)(56)))));
            this.BtnNewTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNewTransaction.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnNewTransaction.ForeColor = System.Drawing.Color.White;
            this.BtnNewTransaction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNewTransaction.Location = new System.Drawing.Point(3, 3);
            this.BtnNewTransaction.Name = "BtnNewTransaction";
            this.BtnNewTransaction.Size = new System.Drawing.Size(111, 38);
            this.BtnNewTransaction.TabIndex = 64;
            this.BtnNewTransaction.Text = "NEW";
            this.BtnNewTransaction.UseVisualStyleBackColor = false;
            this.BtnNewTransaction.Click += new System.EventHandler(this.BtnNewTransaction_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(120, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 38);
            this.button1.TabIndex = 66;
            this.button1.Text = "RETURN";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(237, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 38);
            this.button2.TabIndex = 67;
            this.button2.Text = "VOID";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // TabPageActiveDineInTransactions
            // 
            this.TabPageActiveDineInTransactions.Controls.Add(this.DGVActiveDineInTransactions);
            this.TabPageActiveDineInTransactions.Location = new System.Drawing.Point(4, 30);
            this.TabPageActiveDineInTransactions.Name = "TabPageActiveDineInTransactions";
            this.TabPageActiveDineInTransactions.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageActiveDineInTransactions.Size = new System.Drawing.Size(501, 274);
            this.TabPageActiveDineInTransactions.TabIndex = 1;
            this.TabPageActiveDineInTransactions.Text = "ACTIVE DINE-IN";
            this.TabPageActiveDineInTransactions.UseVisualStyleBackColor = true;
            // 
            // DGVActiveDineInTransactions
            // 
            this.DGVActiveDineInTransactions.AllowUserToAddRows = false;
            this.DGVActiveDineInTransactions.AllowUserToDeleteRows = false;
            this.DGVActiveDineInTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVActiveDineInTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVActiveDineInTransactions.Location = new System.Drawing.Point(3, 3);
            this.DGVActiveDineInTransactions.Name = "DGVActiveDineInTransactions";
            this.DGVActiveDineInTransactions.ReadOnly = true;
            this.DGVActiveDineInTransactions.RowTemplate.Height = 25;
            this.DGVActiveDineInTransactions.Size = new System.Drawing.Size(495, 268);
            this.DGVActiveDineInTransactions.TabIndex = 0;
            this.DGVActiveDineInTransactions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVActiveDineInTransactions_CellClick);
            // 
            // TabPageCheckout
            // 
            this.TabPageCheckout.Controls.Add(this.panel1);
            this.TabPageCheckout.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TabPageCheckout.Location = new System.Drawing.Point(4, 30);
            this.TabPageCheckout.Name = "TabPageCheckout";
            this.TabPageCheckout.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageCheckout.Size = new System.Drawing.Size(501, 274);
            this.TabPageCheckout.TabIndex = 2;
            this.TabPageCheckout.Text = "Checkout";
            this.TabPageCheckout.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnCancelCurrentTransaction);
            this.panel1.Controls.Add(this.BtnSave);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.TboxNumberOfItems);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TboxTicketNumber);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TboxCustomerName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TboxTableNumber);
            this.panel1.Location = new System.Drawing.Point(14, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 232);
            this.panel1.TabIndex = 72;
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnSave.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Image = global::Main.Properties.Resources.save_white_26;
            this.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSave.Location = new System.Drawing.Point(152, 163);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(87, 45);
            this.BtnSave.TabIndex = 70;
            this.BtnSave.Text = "SAVE";
            this.BtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = global::Main.Properties.Resources.checkout_white_30;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(266, 163);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 45);
            this.button3.TabIndex = 69;
            this.button3.Text = "CHECKOUT";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // TboxNumberOfItems
            // 
            this.TboxNumberOfItems.Enabled = false;
            this.TboxNumberOfItems.Location = new System.Drawing.Point(110, 15);
            this.TboxNumberOfItems.Name = "TboxNumberOfItems";
            this.TboxNumberOfItems.Size = new System.Drawing.Size(244, 27);
            this.TboxNumberOfItems.TabIndex = 68;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ticket #";
            // 
            // TboxTicketNumber
            // 
            this.TboxTicketNumber.Enabled = false;
            this.TboxTicketNumber.Location = new System.Drawing.Point(110, 52);
            this.TboxTicketNumber.Name = "TboxTicketNumber";
            this.TboxTicketNumber.Size = new System.Drawing.Size(244, 27);
            this.TboxTicketNumber.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 20);
            this.label8.TabIndex = 67;
            this.label8.Text = "Items";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Customer";
            // 
            // TboxCustomerName
            // 
            this.TboxCustomerName.Enabled = false;
            this.TboxCustomerName.Location = new System.Drawing.Point(110, 87);
            this.TboxCustomerName.Name = "TboxCustomerName";
            this.TboxCustomerName.Size = new System.Drawing.Size(244, 27);
            this.TboxCustomerName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Table #";
            // 
            // TboxTableNumber
            // 
            this.TboxTableNumber.Enabled = false;
            this.TboxTableNumber.Location = new System.Drawing.Point(110, 121);
            this.TboxTableNumber.Name = "TboxTableNumber";
            this.TboxTableNumber.Size = new System.Drawing.Size(244, 27);
            this.TboxTableNumber.TabIndex = 5;
            // 
            // BtnCancelCurrentTransaction
            // 
            this.BtnCancelCurrentTransaction.BackColor = System.Drawing.Color.DarkRed;
            this.BtnCancelCurrentTransaction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancelCurrentTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelCurrentTransaction.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelCurrentTransaction.ForeColor = System.Drawing.Color.White;
            this.BtnCancelCurrentTransaction.Image = global::Main.Properties.Resources.save_white_26;
            this.BtnCancelCurrentTransaction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelCurrentTransaction.Location = new System.Drawing.Point(14, 163);
            this.BtnCancelCurrentTransaction.Name = "BtnCancelCurrentTransaction";
            this.BtnCancelCurrentTransaction.Size = new System.Drawing.Size(108, 45);
            this.BtnCancelCurrentTransaction.TabIndex = 71;
            this.BtnCancelCurrentTransaction.Text = "CANCEL";
            this.BtnCancelCurrentTransaction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelCurrentTransaction.UseVisualStyleBackColor = false;
            this.BtnCancelCurrentTransaction.Click += new System.EventHandler(this.BtnCancelCurrentTransaction_Click);
            // 
            // POSControllerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TabControlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "POSControllerControl";
            this.Size = new System.Drawing.Size(509, 308);
            this.Load += new System.EventHandler(this.POSCheckOutControllerControl_Load);
            this.TabControlMain.ResumeLayout(false);
            this.TabPageControls.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.TabPageActiveDineInTransactions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVActiveDineInTransactions)).EndInit();
            this.TabPageCheckout.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl TabControlMain;
        private System.Windows.Forms.TabPage TabPageControls;
        private System.Windows.Forms.TabPage TabPageActiveDineInTransactions;
        private System.Windows.Forms.Button BtnNewTransaction;
        private System.Windows.Forms.DataGridView DGVActiveDineInTransactions;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage TabPageCheckout;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox TboxNumberOfItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TboxTicketNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TboxCustomerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TboxTableNumber;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnCancelCurrentTransaction;
    }
}
