
namespace Main
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnSaveSubmitTimeINorOut = new System.Windows.Forms.Button();
            this.TBoxCurrentEmployeeNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LViewAttendanceHistoryForToday = new System.Windows.Forms.ListView();
            this.LVColumnEmployeeNum = new System.Windows.Forms.ColumnHeader();
            this.LVColumnEmployeeName = new System.Windows.Forms.ColumnHeader();
            this.LVColumnEmpTimeIn = new System.Windows.Forms.ColumnHeader();
            this.LVColumnTimeOut = new System.Windows.Forms.ColumnHeader();
            this.LVColumnRenderHrs = new System.Windows.Forms.ColumnHeader();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelSecondaryBanner.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.panelSecondaryBanner.Size = new System.Drawing.Size(690, 95);
            this.panelSecondaryBanner.TabIndex = 2;
            // 
            // LblCurrentTime
            // 
            this.LblCurrentTime.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblCurrentTime.ForeColor = System.Drawing.Color.White;
            this.LblCurrentTime.Location = new System.Drawing.Point(388, 19);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnSaveSubmitTimeINorOut);
            this.groupBox1.Controls.Add(this.TBoxCurrentEmployeeNumber);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(666, 104);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Employee Time IN and OUT";
            // 
            // BtnSaveSubmitTimeINorOut
            // 
            this.BtnSaveSubmitTimeINorOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSaveSubmitTimeINorOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveSubmitTimeINorOut.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveSubmitTimeINorOut.ForeColor = System.Drawing.Color.White;
            this.BtnSaveSubmitTimeINorOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveSubmitTimeINorOut.Location = new System.Drawing.Point(524, 38);
            this.BtnSaveSubmitTimeINorOut.Name = "BtnSaveSubmitTimeINorOut";
            this.BtnSaveSubmitTimeINorOut.Size = new System.Drawing.Size(91, 35);
            this.BtnSaveSubmitTimeINorOut.TabIndex = 48;
            this.BtnSaveSubmitTimeINorOut.Text = "Submit";
            this.BtnSaveSubmitTimeINorOut.UseVisualStyleBackColor = false;
            this.BtnSaveSubmitTimeINorOut.Click += new System.EventHandler(this.BtnSaveSubmitTimeINorOut_Click);
            // 
            // TBoxCurrentEmployeeNumber
            // 
            this.TBoxCurrentEmployeeNumber.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TBoxCurrentEmployeeNumber.Location = new System.Drawing.Point(212, 38);
            this.TBoxCurrentEmployeeNumber.Name = "TBoxCurrentEmployeeNumber";
            this.TBoxCurrentEmployeeNumber.Size = new System.Drawing.Size(306, 35);
            this.TBoxCurrentEmployeeNumber.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(21, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee Number";
            // 
            // LViewAttendanceHistoryForToday
            // 
            this.LViewAttendanceHistoryForToday.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LVColumnEmployeeNum,
            this.LVColumnEmployeeName,
            this.LVColumnEmpTimeIn,
            this.LVColumnTimeOut,
            this.LVColumnRenderHrs});
            this.LViewAttendanceHistoryForToday.GridLines = true;
            this.LViewAttendanceHistoryForToday.HideSelection = false;
            this.LViewAttendanceHistoryForToday.Location = new System.Drawing.Point(12, 211);
            this.LViewAttendanceHistoryForToday.Name = "LViewAttendanceHistoryForToday";
            this.LViewAttendanceHistoryForToday.Size = new System.Drawing.Size(666, 215);
            this.LViewAttendanceHistoryForToday.TabIndex = 4;
            this.LViewAttendanceHistoryForToday.UseCompatibleStateImageBehavior = false;
            this.LViewAttendanceHistoryForToday.View = System.Windows.Forms.View.Details;
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
            // LVColumnEmpTimeIn
            // 
            this.LVColumnEmpTimeIn.Text = "Time IN";
            this.LVColumnEmpTimeIn.Width = 100;
            // 
            // LVColumnTimeOut
            // 
            this.LVColumnTimeOut.Text = "Time Out";
            this.LVColumnTimeOut.Width = 100;
            // 
            // LVColumnRenderHrs
            // 
            this.LVColumnRenderHrs.Text = "Hours";
            this.LVColumnRenderHrs.Width = 100;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AttendanceTerminalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 438);
            this.Controls.Add(this.LViewAttendanceHistoryForToday);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelSecondaryBanner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AttendanceTerminalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AttendanceTerminalForm";
            this.panelSecondaryBanner.ResumeLayout(false);
            this.panelSecondaryBanner.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSecondaryBanner;
        private System.Windows.Forms.Label LblCurrentDate;
        private System.Windows.Forms.Label LblRenderedFormTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TBoxCurrentEmployeeNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView LViewAttendanceHistoryForToday;
        private System.Windows.Forms.ColumnHeader LVColumnEmployeeNum;
        private System.Windows.Forms.ColumnHeader LVColumnEmployeeName;
        private System.Windows.Forms.ColumnHeader LVColumnEmpTimeIn;
        private System.Windows.Forms.ColumnHeader LVColumnTimeOut;
        private System.Windows.Forms.ColumnHeader LVColumnRenderHrs;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label LblCurrentTime;
        private System.Windows.Forms.Button BtnSaveSubmitTimeINorOut;
    }
}