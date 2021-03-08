
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
            this.DGVGeneratedWorkSchedules = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.GroupPanelShiftDays = new System.Windows.Forms.GroupBox();
            this.CBoxSunday = new System.Windows.Forms.CheckBox();
            this.CBoxSaturday = new System.Windows.Forms.CheckBox();
            this.CBoxFriday = new System.Windows.Forms.CheckBox();
            this.CBoxThursday = new System.Windows.Forms.CheckBox();
            this.CBoxWednesday = new System.Windows.Forms.CheckBox();
            this.CBoxMonday = new System.Windows.Forms.CheckBox();
            this.CBoxTuesday = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BtnCancelUpdate = new System.Windows.Forms.Button();
            this.BtnSaveWorkShift = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVGeneratedWorkSchedules)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.GroupPanelShiftDays.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            // DGVGeneratedWorkSchedules
            // 
            this.DGVGeneratedWorkSchedules.AllowUserToAddRows = false;
            this.DGVGeneratedWorkSchedules.AllowUserToDeleteRows = false;
            this.DGVGeneratedWorkSchedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVGeneratedWorkSchedules.Dock = System.Windows.Forms.DockStyle.Right;
            this.DGVGeneratedWorkSchedules.Location = new System.Drawing.Point(433, 94);
            this.DGVGeneratedWorkSchedules.Name = "DGVGeneratedWorkSchedules";
            this.DGVGeneratedWorkSchedules.ReadOnly = true;
            this.DGVGeneratedWorkSchedules.RowTemplate.Height = 25;
            this.DGVGeneratedWorkSchedules.Size = new System.Drawing.Size(802, 527);
            this.DGVGeneratedWorkSchedules.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.GroupPanelShiftDays);
            this.groupBox2.Location = new System.Drawing.Point(22, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(395, 394);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Shifts";
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
            this.GroupPanelShiftDays.Location = new System.Drawing.Point(6, 314);
            this.GroupPanelShiftDays.Name = "GroupPanelShiftDays";
            this.GroupPanelShiftDays.Size = new System.Drawing.Size(378, 74);
            this.GroupPanelShiftDays.TabIndex = 52;
            this.GroupPanelShiftDays.TabStop = false;
            this.GroupPanelShiftDays.Text = "Shift Days";
            // 
            // CBoxSunday
            // 
            this.CBoxSunday.AutoSize = true;
            this.CBoxSunday.Enabled = false;
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
            this.CBoxSaturday.Enabled = false;
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
            this.CBoxFriday.Enabled = false;
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
            this.CBoxThursday.Enabled = false;
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
            this.CBoxWednesday.Enabled = false;
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
            this.CBoxMonday.Enabled = false;
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
            this.CBoxTuesday.Enabled = false;
            this.CBoxTuesday.Location = new System.Drawing.Point(66, 32);
            this.CBoxTuesday.Name = "CBoxTuesday";
            this.CBoxTuesday.Size = new System.Drawing.Size(45, 19);
            this.CBoxTuesday.TabIndex = 51;
            this.CBoxTuesday.Tag = "Tue-2";
            this.CBoxTuesday.Text = "Tue";
            this.CBoxTuesday.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(3, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(389, 244);
            this.dataGridView1.TabIndex = 53;
            // 
            // BtnCancelUpdate
            // 
            this.BtnCancelUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.BtnCancelUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelUpdate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelUpdate.ForeColor = System.Drawing.Color.White;
            this.BtnCancelUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelUpdate.Location = new System.Drawing.Point(181, 535);
            this.BtnCancelUpdate.Name = "BtnCancelUpdate";
            this.BtnCancelUpdate.Size = new System.Drawing.Size(115, 47);
            this.BtnCancelUpdate.TabIndex = 50;
            this.BtnCancelUpdate.Text = "Cancel";
            this.BtnCancelUpdate.UseVisualStyleBackColor = false;
            this.BtnCancelUpdate.Visible = false;
            // 
            // BtnSaveWorkShift
            // 
            this.BtnSaveWorkShift.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSaveWorkShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveWorkShift.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveWorkShift.ForeColor = System.Drawing.Color.White;
            this.BtnSaveWorkShift.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveWorkShift.Location = new System.Drawing.Point(302, 535);
            this.BtnSaveWorkShift.Name = "BtnSaveWorkShift";
            this.BtnSaveWorkShift.Size = new System.Drawing.Size(115, 47);
            this.BtnSaveWorkShift.TabIndex = 49;
            this.BtnSaveWorkShift.Text = "Save";
            this.BtnSaveWorkShift.UseVisualStyleBackColor = false;
            // 
            // ManageEmpWorkScheduleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnCancelUpdate);
            this.Controls.Add(this.BtnSaveWorkShift);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.DGVGeneratedWorkSchedules);
            this.Controls.Add(this.panel1);
            this.Name = "ManageEmpWorkScheduleControl";
            this.Size = new System.Drawing.Size(1235, 621);
            this.Load += new System.EventHandler(this.ManageEmpWorkScheduleControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVGeneratedWorkSchedules)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.GroupPanelShiftDays.ResumeLayout(false);
            this.GroupPanelShiftDays.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DGVGeneratedWorkSchedules;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox GroupPanelShiftDays;
        private System.Windows.Forms.CheckBox CBoxSunday;
        private System.Windows.Forms.CheckBox CBoxSaturday;
        private System.Windows.Forms.CheckBox CBoxFriday;
        private System.Windows.Forms.CheckBox CBoxThursday;
        private System.Windows.Forms.CheckBox CBoxWednesday;
        private System.Windows.Forms.CheckBox CBoxMonday;
        private System.Windows.Forms.CheckBox CBoxTuesday;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BtnCancelUpdate;
        private System.Windows.Forms.Button BtnSaveWorkShift;
    }
}
