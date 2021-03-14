﻿
namespace Main.Forms.AttendanceTerminal
{
    partial class AttendanceTerminalForm
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
            this.panelSecondaryBanner = new System.Windows.Forms.Panel();
            this.LblCurrentTime = new System.Windows.Forms.Label();
            this.LblCurrentDate = new System.Windows.Forms.Label();
            this.LblRenderedFormTitle = new System.Windows.Forms.Label();
            this.LViewAttendanceHistory = new System.Windows.Forms.ListView();
            this.LVColumnDate = new System.Windows.Forms.ColumnHeader();
            this.LVColumnEmployeeNum = new System.Windows.Forms.ColumnHeader();
            this.LVColumnEmployeeName = new System.Windows.Forms.ColumnHeader();
            this.LVColumnShift = new System.Windows.Forms.ColumnHeader();
            this.LVColumnShiftTime = new System.Windows.Forms.ColumnHeader();
            this.LVColumnFirstHalf = new System.Windows.Forms.ColumnHeader();
            this.LVColumnSecondHalf = new System.Windows.Forms.ColumnHeader();
            this.LVColumnRenderHrs = new System.Windows.Forms.ColumnHeader();
            this.LVColumnLate = new System.Windows.Forms.ColumnHeader();
            this.LVColumnUnderTime = new System.Windows.Forms.ColumnHeader();
            this.LVColumnOvertime = new System.Windows.Forms.ColumnHeader();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TBoxCurrentEmployeeNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RBtnTimeIN = new System.Windows.Forms.RadioButton();
            this.RBtnTimeOUT = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.LblCurrentEmployeeSchedule = new System.Windows.Forms.Label();
            this.DPickerTesting = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BtnFilterAttendance = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.DPickerFilterAttendanceEnd = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.DPickerFilterAttendanceStart = new System.Windows.Forms.DateTimePicker();
            this.panelSecondaryBanner.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSecondaryBanner
            // 
            this.panelSecondaryBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panelSecondaryBanner.Controls.Add(this.LblCurrentTime);
            this.panelSecondaryBanner.Controls.Add(this.LblCurrentDate);
            this.panelSecondaryBanner.Controls.Add(this.LblRenderedFormTitle);
            this.panelSecondaryBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSecondaryBanner.Location = new System.Drawing.Point(0, 0);
            this.panelSecondaryBanner.Name = "panelSecondaryBanner";
            this.panelSecondaryBanner.Size = new System.Drawing.Size(1073, 95);
            this.panelSecondaryBanner.TabIndex = 2;
            // 
            // LblCurrentTime
            // 
            this.LblCurrentTime.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblCurrentTime.ForeColor = System.Drawing.Color.White;
            this.LblCurrentTime.Location = new System.Drawing.Point(771, 19);
            this.LblCurrentTime.Name = "LblCurrentTime";
            this.LblCurrentTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblCurrentTime.Size = new System.Drawing.Size(290, 62);
            this.LblCurrentTime.TabIndex = 2;
            this.LblCurrentTime.Text = "-";
            this.LblCurrentTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblCurrentDate
            // 
            this.LblCurrentDate.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblCurrentDate.ForeColor = System.Drawing.Color.White;
            this.LblCurrentDate.Location = new System.Drawing.Point(12, 51);
            this.LblCurrentDate.Name = "LblCurrentDate";
            this.LblCurrentDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblCurrentDate.Size = new System.Drawing.Size(331, 30);
            this.LblCurrentDate.TabIndex = 1;
            this.LblCurrentDate.Text = "-";
            this.LblCurrentDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblRenderedFormTitle
            // 
            this.LblRenderedFormTitle.AutoSize = true;
            this.LblRenderedFormTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblRenderedFormTitle.ForeColor = System.Drawing.Color.White;
            this.LblRenderedFormTitle.Location = new System.Drawing.Point(12, 9);
            this.LblRenderedFormTitle.Name = "LblRenderedFormTitle";
            this.LblRenderedFormTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblRenderedFormTitle.Size = new System.Drawing.Size(216, 30);
            this.LblRenderedFormTitle.TabIndex = 0;
            this.LblRenderedFormTitle.Text = "Attendance Terminal";
            // 
            // LViewAttendanceHistory
            // 
            this.LViewAttendanceHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LVColumnDate,
            this.LVColumnEmployeeNum,
            this.LVColumnEmployeeName,
            this.LVColumnShift,
            this.LVColumnShiftTime,
            this.LVColumnFirstHalf,
            this.LVColumnSecondHalf,
            this.LVColumnRenderHrs,
            this.LVColumnLate,
            this.LVColumnUnderTime,
            this.LVColumnOvertime});
            this.LViewAttendanceHistory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LViewAttendanceHistory.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LViewAttendanceHistory.GridLines = true;
            this.LViewAttendanceHistory.HideSelection = false;
            this.LViewAttendanceHistory.Location = new System.Drawing.Point(0, 286);
            this.LViewAttendanceHistory.Name = "LViewAttendanceHistory";
            this.LViewAttendanceHistory.Size = new System.Drawing.Size(1073, 347);
            this.LViewAttendanceHistory.TabIndex = 4;
            this.LViewAttendanceHistory.UseCompatibleStateImageBehavior = false;
            this.LViewAttendanceHistory.View = System.Windows.Forms.View.Details;
            // 
            // LVColumnDate
            // 
            this.LVColumnDate.Text = "Date";
            this.LVColumnDate.Width = 70;
            // 
            // LVColumnEmployeeNum
            // 
            this.LVColumnEmployeeNum.Text = "Employee Number";
            this.LVColumnEmployeeNum.Width = 120;
            // 
            // LVColumnEmployeeName
            // 
            this.LVColumnEmployeeName.Text = "Employee";
            this.LVColumnEmployeeName.Width = 120;
            // 
            // LVColumnShift
            // 
            this.LVColumnShift.Text = "Shift";
            this.LVColumnShift.Width = 150;
            // 
            // LVColumnShiftTime
            // 
            this.LVColumnShiftTime.Text = "Shift Time";
            this.LVColumnShiftTime.Width = 150;
            // 
            // LVColumnFirstHalf
            // 
            this.LVColumnFirstHalf.Text = "First half";
            this.LVColumnFirstHalf.Width = 100;
            // 
            // LVColumnSecondHalf
            // 
            this.LVColumnSecondHalf.Text = "Second Half";
            this.LVColumnSecondHalf.Width = 100;
            // 
            // LVColumnRenderHrs
            // 
            this.LVColumnRenderHrs.Text = "Hours";
            // 
            // LVColumnLate
            // 
            this.LVColumnLate.Text = "Late";
            // 
            // LVColumnUnderTime
            // 
            this.LVColumnUnderTime.Text = "UT";
            // 
            // LVColumnOvertime
            // 
            this.LVColumnOvertime.Text = "OT";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TBoxCurrentEmployeeNumber
            // 
            this.TBoxCurrentEmployeeNumber.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TBoxCurrentEmployeeNumber.Location = new System.Drawing.Point(222, 55);
            this.TBoxCurrentEmployeeNumber.Name = "TBoxCurrentEmployeeNumber";
            this.TBoxCurrentEmployeeNumber.Size = new System.Drawing.Size(448, 35);
            this.TBoxCurrentEmployeeNumber.TabIndex = 5;
            this.TBoxCurrentEmployeeNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBoxCurrentEmployeeNumber_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(31, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 30);
            this.label1.TabIndex = 6;
            this.label1.Text = "Employee Number";
            // 
            // RBtnTimeIN
            // 
            this.RBtnTimeIN.AutoSize = true;
            this.RBtnTimeIN.Checked = true;
            this.RBtnTimeIN.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RBtnTimeIN.Location = new System.Drawing.Point(222, 15);
            this.RBtnTimeIN.Name = "RBtnTimeIN";
            this.RBtnTimeIN.Size = new System.Drawing.Size(106, 34);
            this.RBtnTimeIN.TabIndex = 7;
            this.RBtnTimeIN.TabStop = true;
            this.RBtnTimeIN.Text = "Time-IN";
            this.RBtnTimeIN.UseVisualStyleBackColor = true;
            // 
            // RBtnTimeOUT
            // 
            this.RBtnTimeOUT.AutoSize = true;
            this.RBtnTimeOUT.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RBtnTimeOUT.Location = new System.Drawing.Point(347, 15);
            this.RBtnTimeOUT.Name = "RBtnTimeOUT";
            this.RBtnTimeOUT.Size = new System.Drawing.Size(125, 34);
            this.RBtnTimeOUT.TabIndex = 8;
            this.RBtnTimeOUT.TabStop = true;
            this.RBtnTimeOUT.Text = "Time-OUT";
            this.RBtnTimeOUT.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "Shift Schedule";
            // 
            // LblCurrentEmployeeSchedule
            // 
            this.LblCurrentEmployeeSchedule.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblCurrentEmployeeSchedule.Location = new System.Drawing.Point(222, 93);
            this.LblCurrentEmployeeSchedule.Name = "LblCurrentEmployeeSchedule";
            this.LblCurrentEmployeeSchedule.Size = new System.Drawing.Size(448, 45);
            this.LblCurrentEmployeeSchedule.TabIndex = 10;
            this.LblCurrentEmployeeSchedule.Text = "-";
            // 
            // DPickerTesting
            // 
            this.DPickerTesting.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DPickerTesting.Location = new System.Drawing.Point(867, 33);
            this.DPickerTesting.Name = "DPickerTesting";
            this.DPickerTesting.Size = new System.Drawing.Size(112, 29);
            this.DPickerTesting.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(752, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 21);
            this.label3.TabIndex = 11;
            this.label3.Text = "Testing Time";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.Location = new System.Drawing.Point(0, 95);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1073, 185);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.DPickerTesting);
            this.tabPage1.Controls.Add(this.RBtnTimeOUT);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.LblCurrentEmployeeSchedule);
            this.tabPage1.Controls.Add(this.TBoxCurrentEmployeeNumber);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.RBtnTimeIN);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1065, 151);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "IN/OUT";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.BtnFilterAttendance);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.DPickerFilterAttendanceEnd);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.DPickerFilterAttendanceStart);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1065, 151);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Search";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // BtnFilterAttendance
            // 
            this.BtnFilterAttendance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnFilterAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFilterAttendance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnFilterAttendance.ForeColor = System.Drawing.Color.White;
            this.BtnFilterAttendance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFilterAttendance.Location = new System.Drawing.Point(380, 19);
            this.BtnFilterAttendance.Name = "BtnFilterAttendance";
            this.BtnFilterAttendance.Size = new System.Drawing.Size(115, 31);
            this.BtnFilterAttendance.TabIndex = 40;
            this.BtnFilterAttendance.Text = "Search";
            this.BtnFilterAttendance.UseVisualStyleBackColor = false;
            this.BtnFilterAttendance.Click += new System.EventHandler(this.BtnFilterAttendance_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(215, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 21);
            this.label5.TabIndex = 15;
            this.label5.Text = "To";
            // 
            // DPickerFilterAttendanceEnd
            // 
            this.DPickerFilterAttendanceEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPickerFilterAttendanceEnd.Location = new System.Drawing.Point(246, 21);
            this.DPickerFilterAttendanceEnd.Name = "DPickerFilterAttendanceEnd";
            this.DPickerFilterAttendanceEnd.Size = new System.Drawing.Size(112, 29);
            this.DPickerFilterAttendanceEnd.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 21);
            this.label4.TabIndex = 13;
            this.label4.Text = "From";
            // 
            // DPickerFilterAttendanceStart
            // 
            this.DPickerFilterAttendanceStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPickerFilterAttendanceStart.Location = new System.Drawing.Point(83, 21);
            this.DPickerFilterAttendanceStart.Name = "DPickerFilterAttendanceStart";
            this.DPickerFilterAttendanceStart.Size = new System.Drawing.Size(112, 29);
            this.DPickerFilterAttendanceStart.TabIndex = 12;
            // 
            // AttendanceTerminalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1073, 633);
            this.Controls.Add(this.LViewAttendanceHistory);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panelSecondaryBanner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AttendanceTerminalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AttendanceTerminalForm";
            this.Load += new System.EventHandler(this.AttendanceTerminalForm_Load);
            this.panelSecondaryBanner.ResumeLayout(false);
            this.panelSecondaryBanner.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSecondaryBanner;
        private System.Windows.Forms.Label LblCurrentDate;
        private System.Windows.Forms.Label LblRenderedFormTitle;
        private System.Windows.Forms.ListView LViewAttendanceHistory;
        private System.Windows.Forms.ColumnHeader LVColumnEmployeeNum;
        private System.Windows.Forms.ColumnHeader LVColumnEmployeeName;
        private System.Windows.Forms.ColumnHeader LVColumnFirstHalf;
        private System.Windows.Forms.ColumnHeader LVColumnRenderHrs;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label LblCurrentTime;
        private System.Windows.Forms.TextBox TBoxCurrentEmployeeNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton RBtnTimeIN;
        private System.Windows.Forms.RadioButton RBtnTimeOUT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblCurrentEmployeeSchedule;
        private System.Windows.Forms.DateTimePicker DPickerTesting;
        private System.Windows.Forms.ColumnHeader LVColumnSecondHalf;
        private System.Windows.Forms.ColumnHeader LVColumnLate;
        private System.Windows.Forms.ColumnHeader LVColumnUnderTime;
        private System.Windows.Forms.ColumnHeader LVColumnOvertime;
        private System.Windows.Forms.ColumnHeader LVColumnShift;
        private System.Windows.Forms.ColumnHeader LVColumnShiftTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button BtnFilterAttendance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DPickerFilterAttendanceEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DPickerFilterAttendanceStart;
        private System.Windows.Forms.ColumnHeader LVColumnDate;
    }
}