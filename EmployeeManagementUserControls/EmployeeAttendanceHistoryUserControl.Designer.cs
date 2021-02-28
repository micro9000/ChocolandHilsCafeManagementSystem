
namespace EmployeeManagementUserControls
{
    partial class EmployeeAttendanceHistoryUserControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSaveEmployee = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.WorkDate = new System.Windows.Forms.ColumnHeader();
            this.TimeIn = new System.Windows.Forms.ColumnHeader();
            this.Timeout = new System.Windows.Forms.ColumnHeader();
            this.Late = new System.Windows.Forms.ColumnHeader();
            this.UnderTime = new System.Windows.Forms.ColumnHeader();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BtnSaveEmployee);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1046, 79);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(194, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 19);
            this.label2.TabIndex = 40;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(19, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 19);
            this.label1.TabIndex = 39;
            this.label1.Text = "Start";
            // 
            // BtnSaveEmployee
            // 
            this.BtnSaveEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSaveEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveEmployee.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveEmployee.ForeColor = System.Drawing.Color.White;
            this.BtnSaveEmployee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveEmployee.Location = new System.Drawing.Point(368, 7);
            this.BtnSaveEmployee.Name = "BtnSaveEmployee";
            this.BtnSaveEmployee.Size = new System.Drawing.Size(115, 31);
            this.BtnSaveEmployee.TabIndex = 38;
            this.BtnSaveEmployee.Text = "Submit";
            this.BtnSaveEmployee.UseVisualStyleBackColor = false;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(226, 9);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(119, 29);
            this.dateTimePicker2.TabIndex = 16;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(66, 9);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(119, 29);
            this.dateTimePicker1.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoEllipsis = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(66, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(271, 21);
            this.label7.TabIndex = 14;
            this.label7.Text = "Select the date range you want to see";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.WorkDate,
            this.TimeIn,
            this.Timeout,
            this.Late,
            this.UnderTime});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(10, 89);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1046, 608);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // WorkDate
            // 
            this.WorkDate.Name = "WorkDate";
            this.WorkDate.Text = "Date";
            this.WorkDate.Width = 100;
            // 
            // TimeIn
            // 
            this.TimeIn.Name = "TimeIn";
            this.TimeIn.Text = "Time In";
            this.TimeIn.Width = 100;
            // 
            // Timeout
            // 
            this.Timeout.Name = "Timeout";
            this.Timeout.Text = "Time out";
            this.Timeout.Width = 100;
            // 
            // Late
            // 
            this.Late.Name = "Late";
            this.Late.Text = "Late";
            this.Late.Width = 100;
            // 
            // UnderTime
            // 
            this.UnderTime.Name = "UnderTime";
            this.UnderTime.Text = "UT";
            this.UnderTime.Width = 100;
            // 
            // EmployeeAttendanceHistoryUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel1);
            this.Name = "EmployeeAttendanceHistoryUserControl";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(1066, 707);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader WorkDate;
        private System.Windows.Forms.ColumnHeader TimeIn;
        private System.Windows.Forms.ColumnHeader Timeout;
        private System.Windows.Forms.ColumnHeader Late;
        private System.Windows.Forms.ColumnHeader UnderTime;
        private System.Windows.Forms.Button BtnSaveEmployee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
