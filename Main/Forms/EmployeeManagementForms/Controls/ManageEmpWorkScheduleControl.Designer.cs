﻿
namespace Main.Forms.EmployeeManagementForms.Controls
{
    partial class ManageEmpWorkScheduleControl
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
            this.DGVEmployeeList = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DGVShiftList = new System.Windows.Forms.DataGridView();
            this.BtnSaveEmployeeShiftSchedule = new System.Windows.Forms.Button();
            this.GroupPanelShiftDays = new System.Windows.Forms.GroupBox();
            this.CBoxSunday = new System.Windows.Forms.CheckBox();
            this.CBoxSaturday = new System.Windows.Forms.CheckBox();
            this.CBoxFriday = new System.Windows.Forms.CheckBox();
            this.CBoxThursday = new System.Windows.Forms.CheckBox();
            this.CBoxWednesday = new System.Windows.Forms.CheckBox();
            this.CBoxMonday = new System.Windows.Forms.CheckBox();
            this.CBoxTuesday = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DGVScheduledWorkforceByDate = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DGVEmployeeListToSchedule = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.BtnGenerateWorkforceSchedule = new System.Windows.Forms.Button();
            this.LViewScheduleDates = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.label4 = new System.Windows.Forms.Label();
            this.DPicWorkScheduleEndTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DPicWorkScheduleStartFrom = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeList)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVShiftList)).BeginInit();
            this.GroupPanelShiftDays.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVScheduledWorkforceByDate)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeListToSchedule)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(1235, 94);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(342, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Employee work schedule management";
            // 
            // DGVEmployeeList
            // 
            this.DGVEmployeeList.AllowUserToAddRows = false;
            this.DGVEmployeeList.AllowUserToDeleteRows = false;
            this.DGVEmployeeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVEmployeeList.Dock = System.Windows.Forms.DockStyle.Right;
            this.DGVEmployeeList.Location = new System.Drawing.Point(508, 3);
            this.DGVEmployeeList.Name = "DGVEmployeeList";
            this.DGVEmployeeList.ReadOnly = true;
            this.DGVEmployeeList.RowTemplate.Height = 25;
            this.DGVEmployeeList.Size = new System.Drawing.Size(716, 623);
            this.DGVEmployeeList.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DGVShiftList);
            this.groupBox2.Controls.Add(this.BtnSaveEmployeeShiftSchedule);
            this.groupBox2.Controls.Add(this.GroupPanelShiftDays);
            this.groupBox2.Location = new System.Drawing.Point(15, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(423, 510);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Shifts";
            // 
            // DGVShiftList
            // 
            this.DGVShiftList.AllowUserToAddRows = false;
            this.DGVShiftList.AllowUserToDeleteRows = false;
            this.DGVShiftList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVShiftList.Dock = System.Windows.Forms.DockStyle.Top;
            this.DGVShiftList.Location = new System.Drawing.Point(3, 19);
            this.DGVShiftList.Name = "DGVShiftList";
            this.DGVShiftList.ReadOnly = true;
            this.DGVShiftList.RowTemplate.Height = 25;
            this.DGVShiftList.Size = new System.Drawing.Size(417, 244);
            this.DGVShiftList.TabIndex = 53;
            this.DGVShiftList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVShiftList_CellClick);
            // 
            // BtnSaveEmployeeShiftSchedule
            // 
            this.BtnSaveEmployeeShiftSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSaveEmployeeShiftSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveEmployeeShiftSchedule.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveEmployeeShiftSchedule.ForeColor = System.Drawing.Color.White;
            this.BtnSaveEmployeeShiftSchedule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveEmployeeShiftSchedule.Location = new System.Drawing.Point(281, 402);
            this.BtnSaveEmployeeShiftSchedule.Name = "BtnSaveEmployeeShiftSchedule";
            this.BtnSaveEmployeeShiftSchedule.Size = new System.Drawing.Size(115, 47);
            this.BtnSaveEmployeeShiftSchedule.TabIndex = 49;
            this.BtnSaveEmployeeShiftSchedule.Text = "Save";
            this.BtnSaveEmployeeShiftSchedule.UseVisualStyleBackColor = false;
            this.BtnSaveEmployeeShiftSchedule.Click += new System.EventHandler(this.BtnSaveEmployeeShiftSchedule_Click);
            // 
            // GroupPanelShiftDays
            // 
            this.GroupPanelShiftDays.Controls.Add(this.CBoxSunday);
            this.GroupPanelShiftDays.Controls.Add(this.CBoxSaturday);
            this.GroupPanelShiftDays.Controls.Add(this.CBoxFriday);
            this.GroupPanelShiftDays.Controls.Add(this.CBoxThursday);
            this.GroupPanelShiftDays.Controls.Add(this.CBoxWednesday);
            this.GroupPanelShiftDays.Controls.Add(this.CBoxMonday);
            this.GroupPanelShiftDays.Controls.Add(this.CBoxTuesday);
            this.GroupPanelShiftDays.Location = new System.Drawing.Point(18, 297);
            this.GroupPanelShiftDays.Name = "GroupPanelShiftDays";
            this.GroupPanelShiftDays.Size = new System.Drawing.Size(378, 74);
            this.GroupPanelShiftDays.TabIndex = 52;
            this.GroupPanelShiftDays.TabStop = false;
            this.GroupPanelShiftDays.Text = "Shift Days";
            // 
            // CBoxSunday
            // 
            this.CBoxSunday.AutoSize = true;
            this.CBoxSunday.Location = new System.Drawing.Point(318, 32);
            this.CBoxSunday.Name = "CBoxSunday";
            this.CBoxSunday.Size = new System.Drawing.Size(46, 19);
            this.CBoxSunday.TabIndex = 56;
            this.CBoxSunday.Tag = "Sun-7";
            this.CBoxSunday.Text = "Sun";
            this.CBoxSunday.UseVisualStyleBackColor = true;
            // 
            // CBoxSaturday
            // 
            this.CBoxSaturday.AutoSize = true;
            this.CBoxSaturday.Location = new System.Drawing.Point(270, 32);
            this.CBoxSaturday.Name = "CBoxSaturday";
            this.CBoxSaturday.Size = new System.Drawing.Size(42, 19);
            this.CBoxSaturday.TabIndex = 55;
            this.CBoxSaturday.Tag = "Sat-6";
            this.CBoxSaturday.Text = "Sat";
            this.CBoxSaturday.UseVisualStyleBackColor = true;
            // 
            // CBoxFriday
            // 
            this.CBoxFriday.AutoSize = true;
            this.CBoxFriday.Location = new System.Drawing.Point(225, 32);
            this.CBoxFriday.Name = "CBoxFriday";
            this.CBoxFriday.Size = new System.Drawing.Size(39, 19);
            this.CBoxFriday.TabIndex = 54;
            this.CBoxFriday.Tag = "Fri-5";
            this.CBoxFriday.Text = "Fri";
            this.CBoxFriday.UseVisualStyleBackColor = true;
            // 
            // CBoxThursday
            // 
            this.CBoxThursday.AutoSize = true;
            this.CBoxThursday.Location = new System.Drawing.Point(173, 32);
            this.CBoxThursday.Name = "CBoxThursday";
            this.CBoxThursday.Size = new System.Drawing.Size(46, 19);
            this.CBoxThursday.TabIndex = 53;
            this.CBoxThursday.Tag = "Thu-4";
            this.CBoxThursday.Text = "Thu";
            this.CBoxThursday.UseVisualStyleBackColor = true;
            // 
            // CBoxWednesday
            // 
            this.CBoxWednesday.AutoSize = true;
            this.CBoxWednesday.Location = new System.Drawing.Point(117, 32);
            this.CBoxWednesday.Name = "CBoxWednesday";
            this.CBoxWednesday.Size = new System.Drawing.Size(50, 19);
            this.CBoxWednesday.TabIndex = 52;
            this.CBoxWednesday.Tag = "Wed-3";
            this.CBoxWednesday.Text = "Wed";
            this.CBoxWednesday.UseVisualStyleBackColor = true;
            // 
            // CBoxMonday
            // 
            this.CBoxMonday.AutoSize = true;
            this.CBoxMonday.Location = new System.Drawing.Point(9, 32);
            this.CBoxMonday.Name = "CBoxMonday";
            this.CBoxMonday.Size = new System.Drawing.Size(51, 19);
            this.CBoxMonday.TabIndex = 50;
            this.CBoxMonday.Tag = "Mon-1";
            this.CBoxMonday.Text = "Mon";
            this.CBoxMonday.UseVisualStyleBackColor = true;
            // 
            // CBoxTuesday
            // 
            this.CBoxTuesday.AutoSize = true;
            this.CBoxTuesday.Location = new System.Drawing.Point(66, 32);
            this.CBoxTuesday.Name = "CBoxTuesday";
            this.CBoxTuesday.Size = new System.Drawing.Size(45, 19);
            this.CBoxTuesday.TabIndex = 51;
            this.CBoxTuesday.Tag = "Tue-2";
            this.CBoxTuesday.Text = "Tue";
            this.CBoxTuesday.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 94);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1235, 657);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.DGVEmployeeList);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1227, 629);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Employee Shift";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1227, 629);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Workforce Schedule";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(1100, 561);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 49);
            this.button3.TabIndex = 52;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Location = new System.Drawing.Point(437, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(768, 538);
            this.panel2.TabIndex = 11;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DGVScheduledWorkforceByDate);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 282);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(768, 256);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Workforce";
            // 
            // DGVScheduledWorkforceByDate
            // 
            this.DGVScheduledWorkforceByDate.AllowUserToAddRows = false;
            this.DGVScheduledWorkforceByDate.AllowUserToDeleteRows = false;
            this.DGVScheduledWorkforceByDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVScheduledWorkforceByDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVScheduledWorkforceByDate.Location = new System.Drawing.Point(3, 19);
            this.DGVScheduledWorkforceByDate.Name = "DGVScheduledWorkforceByDate";
            this.DGVScheduledWorkforceByDate.ReadOnly = true;
            this.DGVScheduledWorkforceByDate.RowTemplate.Height = 25;
            this.DGVScheduledWorkforceByDate.Size = new System.Drawing.Size(762, 234);
            this.DGVScheduledWorkforceByDate.TabIndex = 8;
            this.DGVScheduledWorkforceByDate.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVScheduledWorkforceByDate_CellClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DGVEmployeeListToSchedule);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(768, 285);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Select employee";
            // 
            // DGVEmployeeListToSchedule
            // 
            this.DGVEmployeeListToSchedule.AllowUserToAddRows = false;
            this.DGVEmployeeListToSchedule.AllowUserToDeleteRows = false;
            this.DGVEmployeeListToSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVEmployeeListToSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVEmployeeListToSchedule.Location = new System.Drawing.Point(3, 19);
            this.DGVEmployeeListToSchedule.Name = "DGVEmployeeListToSchedule";
            this.DGVEmployeeListToSchedule.ReadOnly = true;
            this.DGVEmployeeListToSchedule.RowTemplate.Height = 25;
            this.DGVEmployeeListToSchedule.Size = new System.Drawing.Size(762, 263);
            this.DGVEmployeeListToSchedule.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.BtnGenerateWorkforceSchedule);
            this.groupBox1.Controls.Add(this.LViewScheduleDates);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.DPicWorkScheduleEndTo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DPicWorkScheduleStartFrom);
            this.groupBox1.Location = new System.Drawing.Point(18, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 593);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scheduling";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(253, 524);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 30);
            this.button2.TabIndex = 51;
            this.button2.Text = "Generate";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // BtnGenerateWorkforceSchedule
            // 
            this.BtnGenerateWorkforceSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnGenerateWorkforceSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGenerateWorkforceSchedule.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnGenerateWorkforceSchedule.ForeColor = System.Drawing.Color.White;
            this.BtnGenerateWorkforceSchedule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGenerateWorkforceSchedule.Location = new System.Drawing.Point(265, 78);
            this.BtnGenerateWorkforceSchedule.Name = "BtnGenerateWorkforceSchedule";
            this.BtnGenerateWorkforceSchedule.Size = new System.Drawing.Size(89, 30);
            this.BtnGenerateWorkforceSchedule.TabIndex = 50;
            this.BtnGenerateWorkforceSchedule.Text = "Generate";
            this.BtnGenerateWorkforceSchedule.UseVisualStyleBackColor = false;
            this.BtnGenerateWorkforceSchedule.Click += new System.EventHandler(this.BtnGenerateWorkforceSchedule_Click);
            // 
            // LViewScheduleDates
            // 
            this.LViewScheduleDates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.LViewScheduleDates.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LViewScheduleDates.FullRowSelect = true;
            this.LViewScheduleDates.GridLines = true;
            this.LViewScheduleDates.HideSelection = false;
            this.LViewScheduleDates.Location = new System.Drawing.Point(20, 125);
            this.LViewScheduleDates.Name = "LViewScheduleDates";
            this.LViewScheduleDates.Size = new System.Drawing.Size(342, 381);
            this.LViewScheduleDates.TabIndex = 5;
            this.LViewScheduleDates.UseCompatibleStateImageBehavior = false;
            this.LViewScheduleDates.View = System.Windows.Forms.View.Details;
            this.LViewScheduleDates.SelectedIndexChanged += new System.EventHandler(this.LViewScheduleDates_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Date";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Workforce #";
            this.columnHeader2.Width = 100;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(32, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "To";
            // 
            // DPicWorkScheduleEndTo
            // 
            this.DPicWorkScheduleEndTo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DPicWorkScheduleEndTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPicWorkScheduleEndTo.Location = new System.Drawing.Point(91, 81);
            this.DPicWorkScheduleEndTo.Name = "DPicWorkScheduleEndTo";
            this.DPicWorkScheduleEndTo.Size = new System.Drawing.Size(168, 29);
            this.DPicWorkScheduleEndTo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(32, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(91, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Generate Schedule";
            // 
            // DPicWorkScheduleStartFrom
            // 
            this.DPicWorkScheduleStartFrom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DPicWorkScheduleStartFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPicWorkScheduleStartFrom.Location = new System.Drawing.Point(91, 46);
            this.DPicWorkScheduleStartFrom.Name = "DPicWorkScheduleStartFrom";
            this.DPicWorkScheduleStartFrom.Size = new System.Drawing.Size(168, 29);
            this.DPicWorkScheduleStartFrom.TabIndex = 0;
            // 
            // ManageEmpWorkScheduleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "ManageEmpWorkScheduleControl";
            this.Size = new System.Drawing.Size(1235, 751);
            this.Load += new System.EventHandler(this.ManageEmpWorkScheduleControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVShiftList)).EndInit();
            this.GroupPanelShiftDays.ResumeLayout(false);
            this.GroupPanelShiftDays.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVScheduledWorkforceByDate)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeListToSchedule)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DGVEmployeeList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox GroupPanelShiftDays;
        private System.Windows.Forms.CheckBox CBoxSunday;
        private System.Windows.Forms.CheckBox CBoxSaturday;
        private System.Windows.Forms.CheckBox CBoxFriday;
        private System.Windows.Forms.CheckBox CBoxThursday;
        private System.Windows.Forms.CheckBox CBoxWednesday;
        private System.Windows.Forms.CheckBox CBoxMonday;
        private System.Windows.Forms.CheckBox CBoxTuesday;
        private System.Windows.Forms.DataGridView DGVShiftList;
        private System.Windows.Forms.Button BtnSaveEmployeeShiftSchedule;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView DGVScheduledWorkforceByDate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView DGVEmployeeListToSchedule;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView LViewScheduleDates;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DPicWorkScheduleEndTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DPicWorkScheduleStartFrom;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BtnGenerateWorkforceSchedule;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}
