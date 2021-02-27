
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.WorkDate = new System.Windows.Forms.ColumnHeader();
            this.TimeIn = new System.Windows.Forms.ColumnHeader();
            this.Timeout = new System.Windows.Forms.ColumnHeader();
            this.Late = new System.Windows.Forms.ColumnHeader();
            this.UnderTime = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
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
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1066, 456);
            this.listView1.TabIndex = 0;
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
            this.Name = "EmployeeAttendanceHistoryUserControl";
            this.Size = new System.Drawing.Size(1066, 456);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader WorkDate;
        private System.Windows.Forms.ColumnHeader TimeIn;
        private System.Windows.Forms.ColumnHeader Timeout;
        private System.Windows.Forms.ColumnHeader Late;
        private System.Windows.Forms.ColumnHeader UnderTime;
    }
}
