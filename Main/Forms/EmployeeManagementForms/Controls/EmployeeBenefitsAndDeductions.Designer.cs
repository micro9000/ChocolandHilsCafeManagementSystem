
namespace Main.Forms.EmployeeManagementForms.Controls
{
    partial class EmployeeBenefitsAndDeductions
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DGVEmployeeBenefits = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnCancelBenefitUpdate = new System.Windows.Forms.Button();
            this.NumUpDwnBenefitAmount = new System.Windows.Forms.NumericUpDown();
            this.BtnSaveBenefits = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TbxBenefitTitle = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DGVEmployeeDeductions = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnCancelUpdateEmpDeduction = new System.Windows.Forms.Button();
            this.NumUpDwnDeductionAmount = new System.Windows.Forms.NumericUpDown();
            this.BtnSaveEmpDeduction = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TBoxDeductionTitle = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeBenefits)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwnBenefitAmount)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeDeductions)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwnDeductionAmount)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(916, 94);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(306, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Employee benefits and deductions";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.Location = new System.Drawing.Point(0, 94);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(916, 340);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DGVEmployeeBenefits);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(908, 306);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Benefits";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DGVEmployeeBenefits
            // 
            this.DGVEmployeeBenefits.AllowUserToAddRows = false;
            this.DGVEmployeeBenefits.AllowUserToDeleteRows = false;
            this.DGVEmployeeBenefits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVEmployeeBenefits.Location = new System.Drawing.Point(312, 40);
            this.DGVEmployeeBenefits.Name = "DGVEmployeeBenefits";
            this.DGVEmployeeBenefits.ReadOnly = true;
            this.DGVEmployeeBenefits.RowTemplate.Height = 25;
            this.DGVEmployeeBenefits.Size = new System.Drawing.Size(548, 218);
            this.DGVEmployeeBenefits.TabIndex = 1;
            this.DGVEmployeeBenefits.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVEmployeeBenefits_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnCancelBenefitUpdate);
            this.groupBox1.Controls.Add(this.NumUpDwnBenefitAmount);
            this.groupBox1.Controls.Add(this.BtnSaveBenefits);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TbxBenefitTitle);
            this.groupBox1.Location = new System.Drawing.Point(20, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 234);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Save";
            // 
            // BtnCancelBenefitUpdate
            // 
            this.BtnCancelBenefitUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelBenefitUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelBenefitUpdate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelBenefitUpdate.ForeColor = System.Drawing.Color.White;
            this.BtnCancelBenefitUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelBenefitUpdate.Location = new System.Drawing.Point(42, 169);
            this.BtnCancelBenefitUpdate.Name = "BtnCancelBenefitUpdate";
            this.BtnCancelBenefitUpdate.Size = new System.Drawing.Size(98, 47);
            this.BtnCancelBenefitUpdate.TabIndex = 48;
            this.BtnCancelBenefitUpdate.Text = "Cancel";
            this.BtnCancelBenefitUpdate.UseVisualStyleBackColor = false;
            this.BtnCancelBenefitUpdate.Visible = false;
            this.BtnCancelBenefitUpdate.Click += new System.EventHandler(this.BtnCancelBenefitUpdate_Click);
            // 
            // NumUpDwnBenefitAmount
            // 
            this.NumUpDwnBenefitAmount.Location = new System.Drawing.Point(16, 125);
            this.NumUpDwnBenefitAmount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NumUpDwnBenefitAmount.Name = "NumUpDwnBenefitAmount";
            this.NumUpDwnBenefitAmount.Size = new System.Drawing.Size(228, 29);
            this.NumUpDwnBenefitAmount.TabIndex = 44;
            // 
            // BtnSaveBenefits
            // 
            this.BtnSaveBenefits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSaveBenefits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveBenefits.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveBenefits.ForeColor = System.Drawing.Color.White;
            this.BtnSaveBenefits.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveBenefits.Location = new System.Drawing.Point(146, 169);
            this.BtnSaveBenefits.Name = "BtnSaveBenefits";
            this.BtnSaveBenefits.Size = new System.Drawing.Size(98, 47);
            this.BtnSaveBenefits.TabIndex = 47;
            this.BtnSaveBenefits.Text = "Save";
            this.BtnSaveBenefits.UseVisualStyleBackColor = false;
            this.BtnSaveBenefits.Click += new System.EventHandler(this.BtnSaveBenefits_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 21);
            this.label3.TabIndex = 45;
            this.label3.Text = "Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Benefit title";
            // 
            // TbxBenefitTitle
            // 
            this.TbxBenefitTitle.Location = new System.Drawing.Point(16, 56);
            this.TbxBenefitTitle.Name = "TbxBenefitTitle";
            this.TbxBenefitTitle.Size = new System.Drawing.Size(228, 29);
            this.TbxBenefitTitle.TabIndex = 44;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DGVEmployeeDeductions);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(908, 306);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Deductions";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DGVEmployeeDeductions
            // 
            this.DGVEmployeeDeductions.AllowUserToAddRows = false;
            this.DGVEmployeeDeductions.AllowUserToDeleteRows = false;
            this.DGVEmployeeDeductions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVEmployeeDeductions.Location = new System.Drawing.Point(310, 42);
            this.DGVEmployeeDeductions.Name = "DGVEmployeeDeductions";
            this.DGVEmployeeDeductions.ReadOnly = true;
            this.DGVEmployeeDeductions.RowTemplate.Height = 25;
            this.DGVEmployeeDeductions.Size = new System.Drawing.Size(548, 218);
            this.DGVEmployeeDeductions.TabIndex = 3;
            this.DGVEmployeeDeductions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVEmployeeDeductions_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnCancelUpdateEmpDeduction);
            this.groupBox2.Controls.Add(this.NumUpDwnDeductionAmount);
            this.groupBox2.Controls.Add(this.BtnSaveEmpDeduction);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.TBoxDeductionTitle);
            this.groupBox2.Location = new System.Drawing.Point(18, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 234);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Save";
            // 
            // BtnCancelUpdateEmpDeduction
            // 
            this.BtnCancelUpdateEmpDeduction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelUpdateEmpDeduction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelUpdateEmpDeduction.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelUpdateEmpDeduction.ForeColor = System.Drawing.Color.White;
            this.BtnCancelUpdateEmpDeduction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelUpdateEmpDeduction.Location = new System.Drawing.Point(42, 160);
            this.BtnCancelUpdateEmpDeduction.Name = "BtnCancelUpdateEmpDeduction";
            this.BtnCancelUpdateEmpDeduction.Size = new System.Drawing.Size(98, 47);
            this.BtnCancelUpdateEmpDeduction.TabIndex = 49;
            this.BtnCancelUpdateEmpDeduction.Text = "Cancel";
            this.BtnCancelUpdateEmpDeduction.UseVisualStyleBackColor = false;
            this.BtnCancelUpdateEmpDeduction.Visible = false;
            this.BtnCancelUpdateEmpDeduction.Click += new System.EventHandler(this.BtnCancelUpdateEmpDeduction_Click);
            // 
            // NumUpDwnDeductionAmount
            // 
            this.NumUpDwnDeductionAmount.Location = new System.Drawing.Point(16, 125);
            this.NumUpDwnDeductionAmount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NumUpDwnDeductionAmount.Name = "NumUpDwnDeductionAmount";
            this.NumUpDwnDeductionAmount.Size = new System.Drawing.Size(228, 29);
            this.NumUpDwnDeductionAmount.TabIndex = 44;
            // 
            // BtnSaveEmpDeduction
            // 
            this.BtnSaveEmpDeduction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSaveEmpDeduction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveEmpDeduction.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveEmpDeduction.ForeColor = System.Drawing.Color.White;
            this.BtnSaveEmpDeduction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveEmpDeduction.Location = new System.Drawing.Point(146, 160);
            this.BtnSaveEmpDeduction.Name = "BtnSaveEmpDeduction";
            this.BtnSaveEmpDeduction.Size = new System.Drawing.Size(98, 47);
            this.BtnSaveEmpDeduction.TabIndex = 47;
            this.BtnSaveEmpDeduction.Text = "Save";
            this.BtnSaveEmpDeduction.UseVisualStyleBackColor = false;
            this.BtnSaveEmpDeduction.Click += new System.EventHandler(this.BtnSaveEmpDeduction_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 21);
            this.label4.TabIndex = 45;
            this.label4.Text = "Amount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "Deduction Title";
            // 
            // TBoxDeductionTitle
            // 
            this.TBoxDeductionTitle.Location = new System.Drawing.Point(16, 56);
            this.TBoxDeductionTitle.Name = "TBoxDeductionTitle";
            this.TBoxDeductionTitle.Size = new System.Drawing.Size(228, 29);
            this.TBoxDeductionTitle.TabIndex = 44;
            // 
            // EmployeeBenefitsAndDeductions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "EmployeeBenefitsAndDeductions";
            this.Size = new System.Drawing.Size(916, 434);
            this.Load += new System.EventHandler(this.EmployeeBenefitsAndDeductions_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeBenefits)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwnBenefitAmount)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeDeductions)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwnDeductionAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView DGVEmployeeBenefits;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TbxBenefitTitle;
        private System.Windows.Forms.Button BtnSaveBenefits;
        private System.Windows.Forms.NumericUpDown NumUpDwnBenefitAmount;
        private System.Windows.Forms.DataGridView DGVEmployeeDeductions;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown NumUpDwnDeductionAmount;
        private System.Windows.Forms.Button BtnSaveEmpDeduction;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TBoxDeductionTitle;
        private System.Windows.Forms.Button BtnCancelBenefitUpdate;
        private System.Windows.Forms.Button BtnCancelUpdateEmpDeduction;
    }
}
