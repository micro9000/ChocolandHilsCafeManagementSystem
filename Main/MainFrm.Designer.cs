
namespace Main
{
    partial class MainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblCurrentUserRoles = new System.Windows.Forms.Label();
            this.LblCurrentUserName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnUserLogout = new System.Windows.Forms.Button();
            this.BtnSettingsSystem = new System.Windows.Forms.Button();
            this.BtnSalesReportSystem = new System.Windows.Forms.Button();
            this.BtnInventorySystem = new System.Windows.Forms.Button();
            this.BtnPayrollSystem = new System.Windows.Forms.Button();
            this.BtnEmployeeManagementMenuItem = new System.Windows.Forms.Button();
            this.panelMainBanner = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelSecondaryBanner = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.LblRenderedFormTitle = new System.Windows.Forms.Label();
            this.panelMainBody = new System.Windows.Forms.Panel();
            this.EmployeeManagementToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSidebar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelMainBanner.SuspendLayout();
            this.panelSecondaryBanner.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelSidebar.Controls.Add(this.panel1);
            this.panelSidebar.Controls.Add(this.BtnSettingsSystem);
            this.panelSidebar.Controls.Add(this.BtnSalesReportSystem);
            this.panelSidebar.Controls.Add(this.BtnInventorySystem);
            this.panelSidebar.Controls.Add(this.BtnPayrollSystem);
            this.panelSidebar.Controls.Add(this.BtnEmployeeManagementMenuItem);
            this.panelSidebar.Controls.Add(this.panelMainBanner);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(220, 641);
            this.panelSidebar.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LblCurrentUserRoles);
            this.panel1.Controls.Add(this.LblCurrentUserName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.BtnUserLogout);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 509);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 132);
            this.panel1.TabIndex = 0;
            // 
            // LblCurrentUserRoles
            // 
            this.LblCurrentUserRoles.AutoSize = true;
            this.LblCurrentUserRoles.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblCurrentUserRoles.ForeColor = System.Drawing.Color.White;
            this.LblCurrentUserRoles.Location = new System.Drawing.Point(63, 45);
            this.LblCurrentUserRoles.Name = "LblCurrentUserRoles";
            this.LblCurrentUserRoles.Size = new System.Drawing.Size(24, 21);
            this.LblCurrentUserRoles.TabIndex = 10;
            this.LblCurrentUserRoles.Text = "__";
            // 
            // LblCurrentUserName
            // 
            this.LblCurrentUserName.AutoSize = true;
            this.LblCurrentUserName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblCurrentUserName.ForeColor = System.Drawing.Color.White;
            this.LblCurrentUserName.Location = new System.Drawing.Point(63, 12);
            this.LblCurrentUserName.Name = "LblCurrentUserName";
            this.LblCurrentUserName.Size = new System.Drawing.Size(24, 21);
            this.LblCurrentUserName.TabIndex = 9;
            this.LblCurrentUserName.Text = "__";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Roles:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "User:";
            // 
            // BtnUserLogout
            // 
            this.BtnUserLogout.BackColor = System.Drawing.Color.Transparent;
            this.BtnUserLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnUserLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnUserLogout.FlatAppearance.BorderSize = 0;
            this.BtnUserLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnUserLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnUserLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUserLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnUserLogout.ForeColor = System.Drawing.Color.White;
            this.BtnUserLogout.Image = ((System.Drawing.Image)(resources.GetObject("BtnUserLogout.Image")));
            this.BtnUserLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUserLogout.Location = new System.Drawing.Point(0, 82);
            this.BtnUserLogout.Name = "BtnUserLogout";
            this.BtnUserLogout.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnUserLogout.Size = new System.Drawing.Size(220, 50);
            this.BtnUserLogout.TabIndex = 7;
            this.BtnUserLogout.Text = "Sign-out";
            this.BtnUserLogout.UseVisualStyleBackColor = false;
            this.BtnUserLogout.Click += new System.EventHandler(this.BtnUserLogout_Click);
            // 
            // BtnSettingsSystem
            // 
            this.BtnSettingsSystem.BackColor = System.Drawing.Color.Transparent;
            this.BtnSettingsSystem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSettingsSystem.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnSettingsSystem.FlatAppearance.BorderSize = 0;
            this.BtnSettingsSystem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSettingsSystem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSettingsSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSettingsSystem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSettingsSystem.ForeColor = System.Drawing.Color.White;
            this.BtnSettingsSystem.Image = ((System.Drawing.Image)(resources.GetObject("BtnSettingsSystem.Image")));
            this.BtnSettingsSystem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSettingsSystem.Location = new System.Drawing.Point(0, 272);
            this.BtnSettingsSystem.Name = "BtnSettingsSystem";
            this.BtnSettingsSystem.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnSettingsSystem.Size = new System.Drawing.Size(220, 50);
            this.BtnSettingsSystem.TabIndex = 6;
            this.BtnSettingsSystem.Text = "Settings";
            this.BtnSettingsSystem.UseVisualStyleBackColor = false;
            // 
            // BtnSalesReportSystem
            // 
            this.BtnSalesReportSystem.BackColor = System.Drawing.Color.Transparent;
            this.BtnSalesReportSystem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSalesReportSystem.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnSalesReportSystem.FlatAppearance.BorderSize = 0;
            this.BtnSalesReportSystem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSalesReportSystem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSalesReportSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalesReportSystem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSalesReportSystem.ForeColor = System.Drawing.Color.White;
            this.BtnSalesReportSystem.Image = ((System.Drawing.Image)(resources.GetObject("BtnSalesReportSystem.Image")));
            this.BtnSalesReportSystem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalesReportSystem.Location = new System.Drawing.Point(0, 222);
            this.BtnSalesReportSystem.Name = "BtnSalesReportSystem";
            this.BtnSalesReportSystem.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnSalesReportSystem.Size = new System.Drawing.Size(220, 50);
            this.BtnSalesReportSystem.TabIndex = 5;
            this.BtnSalesReportSystem.Text = "Sales Report";
            this.BtnSalesReportSystem.UseVisualStyleBackColor = false;
            // 
            // BtnInventorySystem
            // 
            this.BtnInventorySystem.BackColor = System.Drawing.Color.Transparent;
            this.BtnInventorySystem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnInventorySystem.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnInventorySystem.FlatAppearance.BorderSize = 0;
            this.BtnInventorySystem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnInventorySystem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnInventorySystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnInventorySystem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnInventorySystem.ForeColor = System.Drawing.Color.White;
            this.BtnInventorySystem.Image = ((System.Drawing.Image)(resources.GetObject("BtnInventorySystem.Image")));
            this.BtnInventorySystem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnInventorySystem.Location = new System.Drawing.Point(0, 172);
            this.BtnInventorySystem.Name = "BtnInventorySystem";
            this.BtnInventorySystem.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnInventorySystem.Size = new System.Drawing.Size(220, 50);
            this.BtnInventorySystem.TabIndex = 4;
            this.BtnInventorySystem.Text = "Inventory";
            this.BtnInventorySystem.UseVisualStyleBackColor = false;
            // 
            // BtnPayrollSystem
            // 
            this.BtnPayrollSystem.BackColor = System.Drawing.Color.Transparent;
            this.BtnPayrollSystem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPayrollSystem.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnPayrollSystem.FlatAppearance.BorderSize = 0;
            this.BtnPayrollSystem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnPayrollSystem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnPayrollSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPayrollSystem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnPayrollSystem.ForeColor = System.Drawing.Color.White;
            this.BtnPayrollSystem.Image = ((System.Drawing.Image)(resources.GetObject("BtnPayrollSystem.Image")));
            this.BtnPayrollSystem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPayrollSystem.Location = new System.Drawing.Point(0, 122);
            this.BtnPayrollSystem.Name = "BtnPayrollSystem";
            this.BtnPayrollSystem.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnPayrollSystem.Size = new System.Drawing.Size(220, 50);
            this.BtnPayrollSystem.TabIndex = 3;
            this.BtnPayrollSystem.Text = "Payroll";
            this.BtnPayrollSystem.UseVisualStyleBackColor = false;
            this.BtnPayrollSystem.Click += new System.EventHandler(this.BtnPayrollSystem_Click);
            // 
            // BtnEmployeeManagementMenuItem
            // 
            this.BtnEmployeeManagementMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.BtnEmployeeManagementMenuItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEmployeeManagementMenuItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnEmployeeManagementMenuItem.FlatAppearance.BorderSize = 0;
            this.BtnEmployeeManagementMenuItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnEmployeeManagementMenuItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnEmployeeManagementMenuItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEmployeeManagementMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnEmployeeManagementMenuItem.ForeColor = System.Drawing.Color.White;
            this.BtnEmployeeManagementMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("BtnEmployeeManagementMenuItem.Image")));
            this.BtnEmployeeManagementMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEmployeeManagementMenuItem.Location = new System.Drawing.Point(0, 72);
            this.BtnEmployeeManagementMenuItem.Name = "BtnEmployeeManagementMenuItem";
            this.BtnEmployeeManagementMenuItem.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnEmployeeManagementMenuItem.Size = new System.Drawing.Size(220, 50);
            this.BtnEmployeeManagementMenuItem.TabIndex = 2;
            this.BtnEmployeeManagementMenuItem.Text = "Employees";
            this.BtnEmployeeManagementMenuItem.UseVisualStyleBackColor = false;
            this.BtnEmployeeManagementMenuItem.Click += new System.EventHandler(this.BtnEmployeeManagementMenuItem_Click);
            // 
            // panelMainBanner
            // 
            this.panelMainBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panelMainBanner.Controls.Add(this.label1);
            this.panelMainBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMainBanner.Location = new System.Drawing.Point(0, 0);
            this.panelMainBanner.Name = "panelMainBanner";
            this.panelMainBanner.Size = new System.Drawing.Size(220, 72);
            this.panelMainBanner.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chocoland Hils Cafe";
            // 
            // panelSecondaryBanner
            // 
            this.panelSecondaryBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panelSecondaryBanner.Controls.Add(this.button1);
            this.panelSecondaryBanner.Controls.Add(this.LblRenderedFormTitle);
            this.panelSecondaryBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSecondaryBanner.Location = new System.Drawing.Point(220, 0);
            this.panelSecondaryBanner.Name = "panelSecondaryBanner";
            this.panelSecondaryBanner.Size = new System.Drawing.Size(884, 72);
            this.panelSecondaryBanner.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(95, 72);
            this.button1.TabIndex = 7;
            this.button1.Text = "Home";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // LblRenderedFormTitle
            // 
            this.LblRenderedFormTitle.AutoSize = true;
            this.LblRenderedFormTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblRenderedFormTitle.ForeColor = System.Drawing.Color.White;
            this.LblRenderedFormTitle.Location = new System.Drawing.Point(117, 23);
            this.LblRenderedFormTitle.Name = "LblRenderedFormTitle";
            this.LblRenderedFormTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblRenderedFormTitle.Size = new System.Drawing.Size(205, 30);
            this.LblRenderedFormTitle.TabIndex = 0;
            this.LblRenderedFormTitle.Text = "Rendered form title";
            // 
            // panelMainBody
            // 
            this.panelMainBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainBody.Location = new System.Drawing.Point(220, 72);
            this.panelMainBody.Name = "panelMainBody";
            this.panelMainBody.Size = new System.Drawing.Size(884, 569);
            this.panelMainBody.TabIndex = 2;
            // 
            // EmployeeManagementToolStrip
            // 
            this.EmployeeManagementToolStrip.Name = "EmployeeManagementToolStrip";
            this.EmployeeManagementToolStrip.Size = new System.Drawing.Size(200, 22);
            this.EmployeeManagementToolStrip.Text = "Employee Management";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 641);
            this.Controls.Add(this.panelMainBody);
            this.Controls.Add(this.panelSecondaryBanner);
            this.Controls.Add(this.panelSidebar);
            this.Name = "MainFrm";
            this.Text = "Admin form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFrm_FormClosed);
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelMainBanner.ResumeLayout(false);
            this.panelMainBanner.PerformLayout();
            this.panelSecondaryBanner.ResumeLayout(false);
            this.panelSecondaryBanner.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelSecondaryBanner;
        private System.Windows.Forms.Panel panelMainBody;
        private System.Windows.Forms.Button BtnEmployeeManagementMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EmployeeManagementToolStrip;
        private System.Windows.Forms.Panel panelMainBanner;
        private System.Windows.Forms.Button BtnSalesReportSystem;
        private System.Windows.Forms.Button BtnInventorySystem;
        private System.Windows.Forms.Button BtnPayrollSystem;
        private System.Windows.Forms.Button BtnSettingsSystem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblCurrentUserRoles;
        private System.Windows.Forms.Label LblCurrentUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnUserLogout;
        private System.Windows.Forms.Label LblRenderedFormTitle;
        private System.Windows.Forms.Button button1;
    }
}