
namespace Main.Forms.EmployeeManagementForms.Controls
{
    partial class EmpPositionWithSalaryRateCRUDControl
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
            this.GboxPositionForm = new System.Windows.Forms.GroupBox();
            this.CboxSingleEmployee = new System.Windows.Forms.CheckBox();
            this.NumUpDwnDailyRate = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnCancelUpdate = new System.Windows.Forms.Button();
            this.BtnSavePosition = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TbxPositionTitle = new System.Windows.Forms.TextBox();
            this.DGVPositionList = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.GboxPositionForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwnDailyRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPositionList)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(959, 59);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Positions with salary rate";
            // 
            // GboxPositionForm
            // 
            this.GboxPositionForm.Controls.Add(this.CboxSingleEmployee);
            this.GboxPositionForm.Controls.Add(this.NumUpDwnDailyRate);
            this.GboxPositionForm.Controls.Add(this.label5);
            this.GboxPositionForm.Controls.Add(this.BtnCancelUpdate);
            this.GboxPositionForm.Controls.Add(this.BtnSavePosition);
            this.GboxPositionForm.Controls.Add(this.label1);
            this.GboxPositionForm.Controls.Add(this.TbxPositionTitle);
            this.GboxPositionForm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GboxPositionForm.Location = new System.Drawing.Point(13, 65);
            this.GboxPositionForm.Name = "GboxPositionForm";
            this.GboxPositionForm.Size = new System.Drawing.Size(277, 391);
            this.GboxPositionForm.TabIndex = 5;
            this.GboxPositionForm.TabStop = false;
            this.GboxPositionForm.Text = "Position";
            // 
            // CboxSingleEmployee
            // 
            this.CboxSingleEmployee.AutoSize = true;
            this.CboxSingleEmployee.Location = new System.Drawing.Point(15, 236);
            this.CboxSingleEmployee.Name = "CboxSingleEmployee";
            this.CboxSingleEmployee.Size = new System.Drawing.Size(144, 25);
            this.CboxSingleEmployee.TabIndex = 53;
            this.CboxSingleEmployee.Text = "Single Employee";
            this.CboxSingleEmployee.UseVisualStyleBackColor = true;
            // 
            // NumUpDwnDailyRate
            // 
            this.NumUpDwnDailyRate.Location = new System.Drawing.Point(15, 188);
            this.NumUpDwnDailyRate.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NumUpDwnDailyRate.Name = "NumUpDwnDailyRate";
            this.NumUpDwnDailyRate.Size = new System.Drawing.Size(245, 29);
            this.NumUpDwnDailyRate.TabIndex = 51;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 21);
            this.label5.TabIndex = 52;
            this.label5.Text = "Daily Rate";
            // 
            // BtnCancelUpdate
            // 
            this.BtnCancelUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelUpdate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelUpdate.ForeColor = System.Drawing.Color.White;
            this.BtnCancelUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelUpdate.Location = new System.Drawing.Point(59, 292);
            this.BtnCancelUpdate.Name = "BtnCancelUpdate";
            this.BtnCancelUpdate.Size = new System.Drawing.Size(98, 47);
            this.BtnCancelUpdate.TabIndex = 48;
            this.BtnCancelUpdate.Text = "Cancel";
            this.BtnCancelUpdate.UseVisualStyleBackColor = false;
            this.BtnCancelUpdate.Visible = false;
            this.BtnCancelUpdate.Click += new System.EventHandler(this.BtnCancelUpdate_Click);
            // 
            // BtnSavePosition
            // 
            this.BtnSavePosition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSavePosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSavePosition.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSavePosition.ForeColor = System.Drawing.Color.White;
            this.BtnSavePosition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSavePosition.Location = new System.Drawing.Point(163, 292);
            this.BtnSavePosition.Name = "BtnSavePosition";
            this.BtnSavePosition.Size = new System.Drawing.Size(98, 47);
            this.BtnSavePosition.TabIndex = 47;
            this.BtnSavePosition.Text = "Save";
            this.BtnSavePosition.UseVisualStyleBackColor = false;
            this.BtnSavePosition.Click += new System.EventHandler(this.BtnSavePosition_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Position Title";
            // 
            // TbxPositionTitle
            // 
            this.TbxPositionTitle.Location = new System.Drawing.Point(15, 93);
            this.TbxPositionTitle.Multiline = true;
            this.TbxPositionTitle.Name = "TbxPositionTitle";
            this.TbxPositionTitle.Size = new System.Drawing.Size(245, 56);
            this.TbxPositionTitle.TabIndex = 44;
            // 
            // DGVPositionList
            // 
            this.DGVPositionList.AllowUserToAddRows = false;
            this.DGVPositionList.AllowUserToDeleteRows = false;
            this.DGVPositionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVPositionList.Location = new System.Drawing.Point(307, 76);
            this.DGVPositionList.Name = "DGVPositionList";
            this.DGVPositionList.ReadOnly = true;
            this.DGVPositionList.RowTemplate.Height = 25;
            this.DGVPositionList.Size = new System.Drawing.Size(640, 380);
            this.DGVPositionList.TabIndex = 6;
            this.DGVPositionList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVPositionList_CellClick);
            // 
            // EmpPositionWithSalaryRateCRUDControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.DGVPositionList);
            this.Controls.Add(this.GboxPositionForm);
            this.Controls.Add(this.panel1);
            this.Name = "EmpPositionWithSalaryRateCRUDControl";
            this.Size = new System.Drawing.Size(959, 469);
            this.Load += new System.EventHandler(this.EmpPositionWithSalaryRateCRUDControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.GboxPositionForm.ResumeLayout(false);
            this.GboxPositionForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwnDailyRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPositionList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GboxPositionForm;
        private System.Windows.Forms.Button BtnCancelUpdate;
        private System.Windows.Forms.Button BtnSavePosition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TbxPositionTitle;
        private System.Windows.Forms.NumericUpDown NumUpDwnDailyRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView DGVPositionList;
        private System.Windows.Forms.CheckBox CboxSingleEmployee;
    }
}
