
namespace Main.Forms.EmployeeManagementForms
{
    partial class FrmMainEmployeeManagement
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
            this.MenuStripEmployeeManagement = new System.Windows.Forms.MenuStrip();
            this.MenuItemEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.AddToolStripDDItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListToolStripDDItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GovtIdsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileLeaveSchedStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemPayroll = new System.Windows.Forms.ToolStripMenuItem();
            this.AttendanceStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PayslipStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BenefitStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeductionStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SalaryStipMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LeaveCatStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemWorkSchedules = new System.Windows.Forms.ToolStripMenuItem();
            this.ShiftsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.LeaveCategoryStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemGovernment = new System.Windows.Forms.ToolStripMenuItem();
            this.AgenciesStirpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSecondaryBanner = new System.Windows.Forms.Panel();
            this.LblRenderedFormTitle = new System.Windows.Forms.Label();
            this.PanelEmpMgmtMainBody = new System.Windows.Forms.Panel();
            this.MenuStripEmployeeManagement.SuspendLayout();
            this.panelSecondaryBanner.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStripEmployeeManagement
            // 
            this.MenuStripEmployeeManagement.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemEmployee,
            this.MenuItemPayroll,
            this.MenuItemWorkSchedules,
            this.MenuItemGovernment});
            this.MenuStripEmployeeManagement.Location = new System.Drawing.Point(0, 0);
            this.MenuStripEmployeeManagement.Name = "MenuStripEmployeeManagement";
            this.MenuStripEmployeeManagement.Size = new System.Drawing.Size(800, 24);
            this.MenuStripEmployeeManagement.TabIndex = 3;
            this.MenuStripEmployeeManagement.Text = "Main menu strip";
            // 
            // MenuItemEmployee
            // 
            this.MenuItemEmployee.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToolStripDDItem,
            this.ListToolStripDDItem,
            this.GovtIdsStripMenuItem,
            this.FileLeaveSchedStripMenuItem});
            this.MenuItemEmployee.Name = "MenuItemEmployee";
            this.MenuItemEmployee.Size = new System.Drawing.Size(71, 20);
            this.MenuItemEmployee.Text = "Employee";
            // 
            // AddToolStripDDItem
            // 
            this.AddToolStripDDItem.Name = "AddToolStripDDItem";
            this.AddToolStripDDItem.Size = new System.Drawing.Size(172, 22);
            this.AddToolStripDDItem.Text = "Add";
            // 
            // ListToolStripDDItem
            // 
            this.ListToolStripDDItem.Name = "ListToolStripDDItem";
            this.ListToolStripDDItem.Size = new System.Drawing.Size(172, 22);
            this.ListToolStripDDItem.Text = "List";
            // 
            // GovtIdsStripMenuItem
            // 
            this.GovtIdsStripMenuItem.Name = "GovtIdsStripMenuItem";
            this.GovtIdsStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.GovtIdsStripMenuItem.Text = "Government Ids";
            // 
            // FileLeaveSchedStripMenuItem
            // 
            this.FileLeaveSchedStripMenuItem.Name = "FileLeaveSchedStripMenuItem";
            this.FileLeaveSchedStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.FileLeaveSchedStripMenuItem.Text = "File leave schedule";
            // 
            // MenuItemPayroll
            // 
            this.MenuItemPayroll.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AttendanceStripMenuItem,
            this.PayslipStripMenuItem,
            this.BenefitStripMenuItem,
            this.DeductionStripMenuItem,
            this.SalaryStipMenuItem,
            this.LeaveCatStripMenuItem});
            this.MenuItemPayroll.Name = "MenuItemPayroll";
            this.MenuItemPayroll.Size = new System.Drawing.Size(55, 20);
            this.MenuItemPayroll.Text = "Payroll";
            // 
            // AttendanceStripMenuItem
            // 
            this.AttendanceStripMenuItem.Name = "AttendanceStripMenuItem";
            this.AttendanceStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.AttendanceStripMenuItem.Text = "Attendance";
            // 
            // PayslipStripMenuItem
            // 
            this.PayslipStripMenuItem.Name = "PayslipStripMenuItem";
            this.PayslipStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.PayslipStripMenuItem.Text = "Payslip";
            // 
            // BenefitStripMenuItem
            // 
            this.BenefitStripMenuItem.Name = "BenefitStripMenuItem";
            this.BenefitStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.BenefitStripMenuItem.Text = "Employee Benefits";
            // 
            // DeductionStripMenuItem
            // 
            this.DeductionStripMenuItem.Name = "DeductionStripMenuItem";
            this.DeductionStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.DeductionStripMenuItem.Text = "Employee Deductions";
            // 
            // SalaryStipMenuItem
            // 
            this.SalaryStipMenuItem.Name = "SalaryStipMenuItem";
            this.SalaryStipMenuItem.Size = new System.Drawing.Size(189, 22);
            this.SalaryStipMenuItem.Text = "Employee Salary";
            // 
            // LeaveCatStripMenuItem
            // 
            this.LeaveCatStripMenuItem.Name = "LeaveCatStripMenuItem";
            this.LeaveCatStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.LeaveCatStripMenuItem.Text = "Leave Category";
            // 
            // MenuItemWorkSchedules
            // 
            this.MenuItemWorkSchedules.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShiftsStripMenuItem,
            this.toolStripMenuItem1,
            this.LeaveCategoryStripMenuItem});
            this.MenuItemWorkSchedules.Name = "MenuItemWorkSchedules";
            this.MenuItemWorkSchedules.Size = new System.Drawing.Size(103, 20);
            this.MenuItemWorkSchedules.Text = "Work Schedules";
            // 
            // ShiftsStripMenuItem
            // 
            this.ShiftsStripMenuItem.Name = "ShiftsStripMenuItem";
            this.ShiftsStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.ShiftsStripMenuItem.Text = "Shifts";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(207, 22);
            this.toolStripMenuItem1.Text = "Employee shift schedules";
            // 
            // LeaveCategoryStripMenuItem
            // 
            this.LeaveCategoryStripMenuItem.Name = "LeaveCategoryStripMenuItem";
            this.LeaveCategoryStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.LeaveCategoryStripMenuItem.Text = "Leave category";
            // 
            // MenuItemGovernment
            // 
            this.MenuItemGovernment.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AgenciesStirpMenuItem});
            this.MenuItemGovernment.Name = "MenuItemGovernment";
            this.MenuItemGovernment.Size = new System.Drawing.Size(85, 20);
            this.MenuItemGovernment.Text = "Government";
            // 
            // AgenciesStirpMenuItem
            // 
            this.AgenciesStirpMenuItem.Name = "AgenciesStirpMenuItem";
            this.AgenciesStirpMenuItem.Size = new System.Drawing.Size(122, 22);
            this.AgenciesStirpMenuItem.Text = "Agencies";
            // 
            // panelSecondaryBanner
            // 
            this.panelSecondaryBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panelSecondaryBanner.Controls.Add(this.LblRenderedFormTitle);
            this.panelSecondaryBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSecondaryBanner.Location = new System.Drawing.Point(0, 24);
            this.panelSecondaryBanner.Name = "panelSecondaryBanner";
            this.panelSecondaryBanner.Size = new System.Drawing.Size(800, 56);
            this.panelSecondaryBanner.TabIndex = 4;
            // 
            // LblRenderedFormTitle
            // 
            this.LblRenderedFormTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblRenderedFormTitle.AutoSize = true;
            this.LblRenderedFormTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblRenderedFormTitle.ForeColor = System.Drawing.Color.White;
            this.LblRenderedFormTitle.Location = new System.Drawing.Point(12, 11);
            this.LblRenderedFormTitle.Name = "LblRenderedFormTitle";
            this.LblRenderedFormTitle.Size = new System.Drawing.Size(205, 30);
            this.LblRenderedFormTitle.TabIndex = 0;
            this.LblRenderedFormTitle.Text = "Rendered form title";
            // 
            // PanelEmpMgmtMainBody
            // 
            this.PanelEmpMgmtMainBody.Location = new System.Drawing.Point(59, 166);
            this.PanelEmpMgmtMainBody.Name = "PanelEmpMgmtMainBody";
            this.PanelEmpMgmtMainBody.Size = new System.Drawing.Size(634, 226);
            this.PanelEmpMgmtMainBody.TabIndex = 5;
            // 
            // FrmMainEmployeeManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PanelEmpMgmtMainBody);
            this.Controls.Add(this.panelSecondaryBanner);
            this.Controls.Add(this.MenuStripEmployeeManagement);
            this.MainMenuStrip = this.MenuStripEmployeeManagement;
            this.Name = "FrmMainEmployeeManagement";
            this.Text = "Employee Management";
            this.MenuStripEmployeeManagement.ResumeLayout(false);
            this.MenuStripEmployeeManagement.PerformLayout();
            this.panelSecondaryBanner.ResumeLayout(false);
            this.panelSecondaryBanner.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MenuStripEmployeeManagement;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEmployee;
        private System.Windows.Forms.ToolStripMenuItem AddToolStripDDItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemWorkSchedules;
        private System.Windows.Forms.Panel panelSecondaryBanner;
        private System.Windows.Forms.Label LblRenderedFormTitle;
        private System.Windows.Forms.Panel PanelEmpMgmtMainBody;
        private System.Windows.Forms.ToolStripMenuItem ListToolStripDDItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemPayroll;
        private System.Windows.Forms.ToolStripMenuItem GovtIdsStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShiftsStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem LeaveCategoryStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemGovernment;
        private System.Windows.Forms.ToolStripMenuItem AgenciesStirpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AttendanceStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PayslipStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BenefitStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeductionStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SalaryStipMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LeaveCatStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileLeaveSchedStripMenuItem;
    }
}