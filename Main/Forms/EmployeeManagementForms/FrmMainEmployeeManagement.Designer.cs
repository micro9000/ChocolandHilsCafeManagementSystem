
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
            this.components = new System.ComponentModel.Container();
            this.MenuStripEmployeeManagement = new System.Windows.Forms.MenuStrip();
            this.MenuItemEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.EmployeeMenuItemsMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripItem_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripItem_List = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripItem_Details = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripItem_FileLeave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemPayroll = new System.Windows.Forms.ToolStripMenuItem();
            this.PayrollMenuItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AttendanceStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PayslipStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BenefisStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeductionStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SalaryStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LeaveTypesStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemWorkSchedules = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkSchedulesMenItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.WorkShiftsMenItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EmpWorkShiftScheds = new System.Windows.Forms.ToolStripMenuItem();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.FileLeaveSchedStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GovtIdsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListToolStripDDItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddToolStripDDItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripEmployeeManagement.SuspendLayout();
            this.EmployeeMenuItemsMenuStrip.SuspendLayout();
            this.PayrollMenuItems.SuspendLayout();
            this.WorkSchedulesMenItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStripEmployeeManagement
            // 
            this.MenuStripEmployeeManagement.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemEmployee,
            this.MenuItemPayroll,
            this.MenuItemWorkSchedules});
            this.MenuStripEmployeeManagement.Location = new System.Drawing.Point(0, 0);
            this.MenuStripEmployeeManagement.Name = "MenuStripEmployeeManagement";
            this.MenuStripEmployeeManagement.Size = new System.Drawing.Size(800, 24);
            this.MenuStripEmployeeManagement.TabIndex = 3;
            this.MenuStripEmployeeManagement.Text = "Main menu strip";
            // 
            // MenuItemEmployee
            // 
            this.MenuItemEmployee.DropDown = this.EmployeeMenuItemsMenuStrip;
            this.MenuItemEmployee.Name = "MenuItemEmployee";
            this.MenuItemEmployee.Size = new System.Drawing.Size(71, 20);
            this.MenuItemEmployee.Text = "Employee";
            // 
            // EmployeeMenuItemsMenuStrip
            // 
            this.EmployeeMenuItemsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripItem_Add,
            this.ToolStripItem_List,
            this.ToolStripItem_Details,
            this.ToolStripItem_FileLeave});
            this.EmployeeMenuItemsMenuStrip.Name = "EmployeeMenuItems";
            this.EmployeeMenuItemsMenuStrip.OwnerItem = this.MenuItemEmployee;
            this.EmployeeMenuItemsMenuStrip.Size = new System.Drawing.Size(138, 92);
            this.EmployeeMenuItemsMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.EmployeeMenuItemsMenuStrip_ItemClicked);
            // 
            // ToolStripItem_Add
            // 
            this.ToolStripItem_Add.Name = "ToolStripItem_Add";
            this.ToolStripItem_Add.Size = new System.Drawing.Size(137, 22);
            this.ToolStripItem_Add.Text = "Save Details";
            // 
            // ToolStripItem_List
            // 
            this.ToolStripItem_List.Name = "ToolStripItem_List";
            this.ToolStripItem_List.Size = new System.Drawing.Size(137, 22);
            this.ToolStripItem_List.Text = "List";
            // 
            // ToolStripItem_Details
            // 
            this.ToolStripItem_Details.Name = "ToolStripItem_Details";
            this.ToolStripItem_Details.Size = new System.Drawing.Size(137, 22);
            this.ToolStripItem_Details.Text = "View Details";
            // 
            // ToolStripItem_FileLeave
            // 
            this.ToolStripItem_FileLeave.Name = "ToolStripItem_FileLeave";
            this.ToolStripItem_FileLeave.Size = new System.Drawing.Size(137, 22);
            this.ToolStripItem_FileLeave.Text = "File leave";
            // 
            // MenuItemPayroll
            // 
            this.MenuItemPayroll.DropDown = this.PayrollMenuItems;
            this.MenuItemPayroll.Name = "MenuItemPayroll";
            this.MenuItemPayroll.Size = new System.Drawing.Size(55, 20);
            this.MenuItemPayroll.Text = "Payroll";
            // 
            // PayrollMenuItems
            // 
            this.PayrollMenuItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AttendanceStripMenuItem,
            this.PayslipStripMenuItem,
            this.BenefisStripMenuItem,
            this.DeductionStripMenuItem,
            this.SalaryStripMenuItem,
            this.LeaveTypesStripMenuItem});
            this.PayrollMenuItems.Name = "PayrollMenuItems";
            this.PayrollMenuItems.OwnerItem = this.MenuItemPayroll;
            this.PayrollMenuItems.Size = new System.Drawing.Size(137, 136);
            this.PayrollMenuItems.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.PayrollMenuItems_ItemClicked);
            // 
            // AttendanceStripMenuItem
            // 
            this.AttendanceStripMenuItem.Name = "AttendanceStripMenuItem";
            this.AttendanceStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.AttendanceStripMenuItem.Text = "Attendance";
            // 
            // PayslipStripMenuItem
            // 
            this.PayslipStripMenuItem.Name = "PayslipStripMenuItem";
            this.PayslipStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.PayslipStripMenuItem.Text = "Payslip";
            // 
            // BenefisStripMenuItem
            // 
            this.BenefisStripMenuItem.Name = "BenefisStripMenuItem";
            this.BenefisStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.BenefisStripMenuItem.Text = "Benefits";
            // 
            // DeductionStripMenuItem
            // 
            this.DeductionStripMenuItem.Name = "DeductionStripMenuItem";
            this.DeductionStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.DeductionStripMenuItem.Text = "Deductions";
            // 
            // SalaryStripMenuItem
            // 
            this.SalaryStripMenuItem.Name = "SalaryStripMenuItem";
            this.SalaryStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.SalaryStripMenuItem.Text = "Salary";
            // 
            // LeaveTypesStripMenuItem
            // 
            this.LeaveTypesStripMenuItem.Name = "LeaveTypesStripMenuItem";
            this.LeaveTypesStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.LeaveTypesStripMenuItem.Text = "Leave Types";
            // 
            // MenuItemWorkSchedules
            // 
            this.MenuItemWorkSchedules.DropDown = this.WorkSchedulesMenItems;
            this.MenuItemWorkSchedules.Name = "MenuItemWorkSchedules";
            this.MenuItemWorkSchedules.Size = new System.Drawing.Size(103, 20);
            this.MenuItemWorkSchedules.Text = "Work Schedules";
            // 
            // WorkSchedulesMenItems
            // 
            this.WorkSchedulesMenItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WorkShiftsMenItem,
            this.EmpWorkShiftScheds});
            this.WorkSchedulesMenItems.Name = "WorkSchedulesMenItems";
            this.WorkSchedulesMenItems.OwnerItem = this.MenuItemWorkSchedules;
            this.WorkSchedulesMenItems.ShowImageMargin = false;
            this.WorkSchedulesMenItems.Size = new System.Drawing.Size(186, 48);
            this.WorkSchedulesMenItems.Text = "Work Schedules";
            this.WorkSchedulesMenItems.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.WorkSchedulesMenItems_ItemClicked);
            // 
            // WorkShiftsMenItem
            // 
            this.WorkShiftsMenItem.Name = "WorkShiftsMenItem";
            this.WorkShiftsMenItem.Size = new System.Drawing.Size(185, 22);
            this.WorkShiftsMenItem.Text = "Shifts";
            // 
            // EmpWorkShiftScheds
            // 
            this.EmpWorkShiftScheds.Name = "EmpWorkShiftScheds";
            this.EmpWorkShiftScheds.Size = new System.Drawing.Size(185, 22);
            this.EmpWorkShiftScheds.Text = "Employee work schedules";
            // 
            // panelContainer
            // 
            this.panelContainer.AutoScroll = true;
            this.panelContainer.BackColor = System.Drawing.SystemColors.Control;
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 24);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Padding = new System.Windows.Forms.Padding(10);
            this.panelContainer.Size = new System.Drawing.Size(800, 426);
            this.panelContainer.TabIndex = 5;
            // 
            // FileLeaveSchedStripMenuItem
            // 
            this.FileLeaveSchedStripMenuItem.Name = "FileLeaveSchedStripMenuItem";
            this.FileLeaveSchedStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.FileLeaveSchedStripMenuItem.Text = "File leave schedule";
            // 
            // GovtIdsStripMenuItem
            // 
            this.GovtIdsStripMenuItem.Name = "GovtIdsStripMenuItem";
            this.GovtIdsStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.GovtIdsStripMenuItem.Text = "Government Ids";
            // 
            // ListToolStripDDItem
            // 
            this.ListToolStripDDItem.Name = "ListToolStripDDItem";
            this.ListToolStripDDItem.Size = new System.Drawing.Size(172, 22);
            this.ListToolStripDDItem.Text = "List";
            // 
            // AddToolStripDDItem
            // 
            this.AddToolStripDDItem.Name = "AddToolStripDDItem";
            this.AddToolStripDDItem.Size = new System.Drawing.Size(172, 22);
            this.AddToolStripDDItem.Text = "Add";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItem2.Text = "Add";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItem3.Text = "List";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItem4.Text = "Government Ids";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItem5.Text = "File leave schedule";
            // 
            // FrmMainEmployeeManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.MenuStripEmployeeManagement);
            this.MainMenuStrip = this.MenuStripEmployeeManagement;
            this.Name = "FrmMainEmployeeManagement";
            this.Text = "Employee Management";
            this.MenuStripEmployeeManagement.ResumeLayout(false);
            this.MenuStripEmployeeManagement.PerformLayout();
            this.EmployeeMenuItemsMenuStrip.ResumeLayout(false);
            this.PayrollMenuItems.ResumeLayout(false);
            this.WorkSchedulesMenItems.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MenuStripEmployeeManagement;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEmployee;
        private System.Windows.Forms.ToolStripMenuItem MenuItemWorkSchedules;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.ToolStripMenuItem LeaveTypeStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileLeaveSchedStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GovtIdsStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ListToolStripDDItem;
        private System.Windows.Forms.ToolStripMenuItem AddToolStripDDItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ContextMenuStrip EmployeeMenuItemsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ToolStripItem_Add;
        private System.Windows.Forms.ToolStripMenuItem ToolStripItem_List;
        private System.Windows.Forms.ToolStripMenuItem ToolStripItem_FileLeave;
        private System.Windows.Forms.ContextMenuStrip PayrollMenuItems;
        private System.Windows.Forms.ToolStripMenuItem AttendanceStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PayslipStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BenefisStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeductionStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LeaveTypesStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripItem_Details;
        private System.Windows.Forms.ToolStripMenuItem MenuItemPayroll;
        private System.Windows.Forms.ToolStripMenuItem SalaryStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip WorkSchedulesMenItems;
        private System.Windows.Forms.ToolStripMenuItem WorkShiftsMenItem;
        private System.Windows.Forms.ToolStripMenuItem EmpWorkShiftScheds;
    }
}