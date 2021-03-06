
namespace Main.Forms.EmployeeManagementForms.Controls
{
    partial class WorkShiftCRUDControl
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
            this.DTPickerShiftStartTime = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CBoxBreakTimes = new System.Windows.Forms.ComboBox();
            this.CboxDisable = new System.Windows.Forms.CheckBox();
            this.BtnCancelUpdate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnSaveWorkShift = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DTPickerShiftBreaktime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TboxShiftTitle = new System.Windows.Forms.TextBox();
            this.DGVWorkShifts = new System.Windows.Forms.DataGridView();
            this.TboxShiftNumberOfHrs = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVWorkShifts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TboxShiftNumberOfHrs)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1199, 94);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Work shifts";
            // 
            // DTPickerShiftStartTime
            // 
            this.DTPickerShiftStartTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DTPickerShiftStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTPickerShiftStartTime.Location = new System.Drawing.Point(152, 95);
            this.DTPickerShiftStartTime.Name = "DTPickerShiftStartTime";
            this.DTPickerShiftStartTime.ShowUpDown = true;
            this.DTPickerShiftStartTime.Size = new System.Drawing.Size(162, 29);
            this.DTPickerShiftStartTime.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TboxShiftNumberOfHrs);
            this.groupBox1.Controls.Add(this.CBoxBreakTimes);
            this.groupBox1.Controls.Add(this.CboxDisable);
            this.groupBox1.Controls.Add(this.BtnCancelUpdate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.BtnSaveWorkShift);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.DTPickerShiftBreaktime);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.TboxShiftTitle);
            this.groupBox1.Controls.Add(this.DTPickerShiftStartTime);
            this.groupBox1.Location = new System.Drawing.Point(11, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 368);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add new";
            // 
            // CBoxBreakTimes
            // 
            this.CBoxBreakTimes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CBoxBreakTimes.Location = new System.Drawing.Point(152, 225);
            this.CBoxBreakTimes.Name = "CBoxBreakTimes";
            this.CBoxBreakTimes.Size = new System.Drawing.Size(162, 29);
            this.CBoxBreakTimes.TabIndex = 8;
            // 
            // CboxDisable
            // 
            this.CboxDisable.AutoSize = true;
            this.CboxDisable.ForeColor = System.Drawing.Color.Black;
            this.CboxDisable.Location = new System.Drawing.Point(152, 22);
            this.CboxDisable.Name = "CboxDisable";
            this.CboxDisable.Size = new System.Drawing.Size(64, 19);
            this.CboxDisable.TabIndex = 49;
            this.CboxDisable.Text = "Disable";
            this.CboxDisable.UseVisualStyleBackColor = true;
            this.CboxDisable.Visible = false;
            // 
            // BtnCancelUpdate
            // 
            this.BtnCancelUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelUpdate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelUpdate.ForeColor = System.Drawing.Color.White;
            this.BtnCancelUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelUpdate.Location = new System.Drawing.Point(199, 307);
            this.BtnCancelUpdate.Name = "BtnCancelUpdate";
            this.BtnCancelUpdate.Size = new System.Drawing.Size(115, 47);
            this.BtnCancelUpdate.TabIndex = 48;
            this.BtnCancelUpdate.Text = "Cancel";
            this.BtnCancelUpdate.UseVisualStyleBackColor = false;
            this.BtnCancelUpdate.Visible = false;
            this.BtnCancelUpdate.Click += new System.EventHandler(this.BtnCancelUpdate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(6, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 21);
            this.label4.TabIndex = 31;
            this.label4.Text = "Shift Hrs";
            // 
            // BtnSaveWorkShift
            // 
            this.BtnSaveWorkShift.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSaveWorkShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveWorkShift.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveWorkShift.ForeColor = System.Drawing.Color.White;
            this.BtnSaveWorkShift.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveWorkShift.Location = new System.Drawing.Point(78, 307);
            this.BtnSaveWorkShift.Name = "BtnSaveWorkShift";
            this.BtnSaveWorkShift.Size = new System.Drawing.Size(115, 47);
            this.BtnSaveWorkShift.TabIndex = 47;
            this.BtnSaveWorkShift.Text = "Save";
            this.BtnSaveWorkShift.UseVisualStyleBackColor = false;
            this.BtnSaveWorkShift.Click += new System.EventHandler(this.BtnSaveWorkShift_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(6, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 21);
            this.label7.TabIndex = 35;
            this.label7.Text = "Breaktime Hours";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(6, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 21);
            this.label5.TabIndex = 33;
            this.label5.Text = "Breaktime";
            // 
            // DTPickerShiftBreaktime
            // 
            this.DTPickerShiftBreaktime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DTPickerShiftBreaktime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTPickerShiftBreaktime.Location = new System.Drawing.Point(152, 182);
            this.DTPickerShiftBreaktime.Name = "DTPickerShiftBreaktime";
            this.DTPickerShiftBreaktime.ShowUpDown = true;
            this.DTPickerShiftBreaktime.Size = new System.Drawing.Size(162, 29);
            this.DTPickerShiftBreaktime.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 21);
            this.label1.TabIndex = 27;
            this.label1.Text = "Start time";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(6, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 21);
            this.label9.TabIndex = 26;
            this.label9.Text = "Shift";
            // 
            // TboxShiftTitle
            // 
            this.TboxShiftTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TboxShiftTitle.Location = new System.Drawing.Point(152, 50);
            this.TboxShiftTitle.Name = "TboxShiftTitle";
            this.TboxShiftTitle.Size = new System.Drawing.Size(162, 29);
            this.TboxShiftTitle.TabIndex = 6;
            // 
            // DGVWorkShifts
            // 
            this.DGVWorkShifts.AllowUserToAddRows = false;
            this.DGVWorkShifts.AllowUserToDeleteRows = false;
            this.DGVWorkShifts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVWorkShifts.Location = new System.Drawing.Point(381, 117);
            this.DGVWorkShifts.Name = "DGVWorkShifts";
            this.DGVWorkShifts.ReadOnly = true;
            this.DGVWorkShifts.RowTemplate.Height = 25;
            this.DGVWorkShifts.Size = new System.Drawing.Size(801, 211);
            this.DGVWorkShifts.TabIndex = 7;
            this.DGVWorkShifts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVWorkShifts_CellClick);
            // 
            // TboxShiftNumberOfHrs
            // 
            this.TboxShiftNumberOfHrs.DecimalPlaces = 2;
            this.TboxShiftNumberOfHrs.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TboxShiftNumberOfHrs.Location = new System.Drawing.Point(152, 136);
            this.TboxShiftNumberOfHrs.Name = "TboxShiftNumberOfHrs";
            this.TboxShiftNumberOfHrs.Size = new System.Drawing.Size(162, 29);
            this.TboxShiftNumberOfHrs.TabIndex = 8;
            // 
            // WorkShiftCRUDControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.DGVWorkShifts);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "WorkShiftCRUDControl";
            this.Size = new System.Drawing.Size(1199, 495);
            this.Load += new System.EventHandler(this.WorkShiftCRUDControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVWorkShifts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TboxShiftNumberOfHrs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DTPickerShiftStartTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DGVWorkShifts;
        private System.Windows.Forms.TextBox TboxShiftTitle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DTPickerShiftBreaktime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnCancelUpdate;
        private System.Windows.Forms.Button BtnSaveWorkShift;
        private System.Windows.Forms.CheckBox CboxDisable;
        private System.Windows.Forms.ComboBox CBoxBreakTimes;
        private System.Windows.Forms.NumericUpDown TboxShiftNumberOfHrs;
    }
}
