
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnGenerateEmployeeWorkSched = new System.Windows.Forms.Button();
            this.DPickerWorkEndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.DPickerWorkStartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVGeneratedWorkSchedules = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVGeneratedWorkSchedules)).BeginInit();
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
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.BtnGenerateEmployeeWorkSched);
            this.groupBox1.Controls.Add(this.DPickerWorkEndDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DPickerWorkStartDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1235, 92);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generate schedule";
            // 
            // BtnGenerateEmployeeWorkSched
            // 
            this.BtnGenerateEmployeeWorkSched.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnGenerateEmployeeWorkSched.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGenerateEmployeeWorkSched.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnGenerateEmployeeWorkSched.ForeColor = System.Drawing.Color.White;
            this.BtnGenerateEmployeeWorkSched.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGenerateEmployeeWorkSched.Location = new System.Drawing.Point(714, 32);
            this.BtnGenerateEmployeeWorkSched.Name = "BtnGenerateEmployeeWorkSched";
            this.BtnGenerateEmployeeWorkSched.Size = new System.Drawing.Size(115, 35);
            this.BtnGenerateEmployeeWorkSched.TabIndex = 48;
            this.BtnGenerateEmployeeWorkSched.Text = "Generate";
            this.BtnGenerateEmployeeWorkSched.UseVisualStyleBackColor = false;
            this.BtnGenerateEmployeeWorkSched.Click += new System.EventHandler(this.BtnGenerateEmployeeWorkSched_Click);
            // 
            // DPickerWorkEndDate
            // 
            this.DPickerWorkEndDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DPickerWorkEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPickerWorkEndDate.Location = new System.Drawing.Point(484, 38);
            this.DPickerWorkEndDate.Name = "DPickerWorkEndDate";
            this.DPickerWorkEndDate.Size = new System.Drawing.Size(200, 29);
            this.DPickerWorkEndDate.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(369, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 21);
            this.label3.TabIndex = 30;
            this.label3.Text = "End work date";
            // 
            // DPickerWorkStartDate
            // 
            this.DPickerWorkStartDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DPickerWorkStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPickerWorkStartDate.Location = new System.Drawing.Point(142, 40);
            this.DPickerWorkStartDate.Name = "DPickerWorkStartDate";
            this.DPickerWorkStartDate.Size = new System.Drawing.Size(200, 29);
            this.DPickerWorkStartDate.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(19, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 21);
            this.label1.TabIndex = 28;
            this.label1.Text = "Start Work date";
            // 
            // DGVGeneratedWorkSchedules
            // 
            this.DGVGeneratedWorkSchedules.AllowUserToAddRows = false;
            this.DGVGeneratedWorkSchedules.AllowUserToDeleteRows = false;
            this.DGVGeneratedWorkSchedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVGeneratedWorkSchedules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVGeneratedWorkSchedules.Location = new System.Drawing.Point(0, 186);
            this.DGVGeneratedWorkSchedules.Name = "DGVGeneratedWorkSchedules";
            this.DGVGeneratedWorkSchedules.ReadOnly = true;
            this.DGVGeneratedWorkSchedules.RowTemplate.Height = 25;
            this.DGVGeneratedWorkSchedules.Size = new System.Drawing.Size(1235, 435);
            this.DGVGeneratedWorkSchedules.TabIndex = 7;
            // 
            // ManageEmpWorkScheduleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DGVGeneratedWorkSchedules);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "ManageEmpWorkScheduleControl";
            this.Size = new System.Drawing.Size(1235, 621);
            this.Load += new System.EventHandler(this.ManageEmpWorkScheduleControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVGeneratedWorkSchedules)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker DPickerWorkEndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DPickerWorkStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnGenerateEmployeeWorkSched;
        private System.Windows.Forms.DataGridView DGVGeneratedWorkSchedules;
    }
}
