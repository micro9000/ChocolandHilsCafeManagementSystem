
namespace EmployeeManagementUserControls
{
    partial class DisplayEmployeeListUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayEmployeeListUserControl));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnReloadEmployees = new System.Windows.Forms.Button();
            this.TbxSearchString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DGVEmployees = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1506, 75);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BtnReloadEmployees);
            this.panel3.Controls.Add(this.TbxSearchString);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(915, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(591, 75);
            this.panel3.TabIndex = 43;
            // 
            // BtnReloadEmployees
            // 
            this.BtnReloadEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.BtnReloadEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReloadEmployees.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnReloadEmployees.ForeColor = System.Drawing.Color.White;
            this.BtnReloadEmployees.Image = ((System.Drawing.Image)(resources.GetObject("BtnReloadEmployees.Image")));
            this.BtnReloadEmployees.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnReloadEmployees.Location = new System.Drawing.Point(35, 13);
            this.BtnReloadEmployees.Name = "BtnReloadEmployees";
            this.BtnReloadEmployees.Size = new System.Drawing.Size(89, 47);
            this.BtnReloadEmployees.TabIndex = 24;
            this.BtnReloadEmployees.Text = "Reload";
            this.BtnReloadEmployees.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnReloadEmployees.UseVisualStyleBackColor = false;
            this.BtnReloadEmployees.Click += new System.EventHandler(this.BtnReloadEmployees_Click);
            // 
            // TbxSearchString
            // 
            this.TbxSearchString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbxSearchString.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbxSearchString.Location = new System.Drawing.Point(239, 24);
            this.TbxSearchString.Name = "TbxSearchString";
            this.TbxSearchString.Size = new System.Drawing.Size(331, 27);
            this.TbxSearchString.TabIndex = 23;
            this.TbxSearchString.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbxSearchString_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(170, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Search";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(21, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 25);
            this.label2.TabIndex = 42;
            this.label2.Text = "Employee list";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.DGVEmployees);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1506, 551);
            this.panel1.TabIndex = 2;
            // 
            // DGVEmployees
            // 
            this.DGVEmployees.AllowUserToAddRows = false;
            this.DGVEmployees.AllowUserToDeleteRows = false;
            this.DGVEmployees.BackgroundColor = System.Drawing.Color.White;
            this.DGVEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVEmployees.Location = new System.Drawing.Point(0, 0);
            this.DGVEmployees.Name = "DGVEmployees";
            this.DGVEmployees.ReadOnly = true;
            this.DGVEmployees.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGVEmployees.Size = new System.Drawing.Size(1506, 551);
            this.DGVEmployees.TabIndex = 0;
            this.DGVEmployees.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVEmployees_CellClick);
            this.DGVEmployees.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVEmployees_CellMouseEnter);
            // 
            // DisplayEmployeeListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "DisplayEmployeeListUserControl";
            this.Size = new System.Drawing.Size(1506, 626);
            this.Load += new System.EventHandler(this.DisplayEmployeeListUserControl_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployees)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TbxSearchString;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DGVEmployees;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BtnReloadEmployees;
    }
}
