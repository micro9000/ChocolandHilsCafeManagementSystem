
namespace EmployeeManagementUserControls
{
    partial class EmployeePayslipHistoryUserControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblTotalTakeHomePay = new System.Windows.Forms.Label();
            this.LblTotalDeduction = new System.Windows.Forms.Label();
            this.LblTotalIncome = new System.Windows.Forms.Label();
            this.LblTotalBenefits = new System.Windows.Forms.Label();
            this.LblPayday = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ListViewDeductions = new System.Windows.Forms.ListView();
            this.GovtAgency = new System.Windows.Forms.ColumnHeader();
            this.CardNumber = new System.Windows.Forms.ColumnHeader();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ListViewBenefits = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.LblTotalTakeHomePay);
            this.groupBox1.Controls.Add(this.LblTotalDeduction);
            this.groupBox1.Controls.Add(this.LblTotalIncome);
            this.groupBox1.Controls.Add(this.LblTotalBenefits);
            this.groupBox1.Controls.Add(this.LblPayday);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(9, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(793, 164);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payslip";
            // 
            // LblTotalTakeHomePay
            // 
            this.LblTotalTakeHomePay.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTotalTakeHomePay.Location = new System.Drawing.Point(193, 134);
            this.LblTotalTakeHomePay.Name = "LblTotalTakeHomePay";
            this.LblTotalTakeHomePay.Size = new System.Drawing.Size(426, 16);
            this.LblTotalTakeHomePay.TabIndex = 10;
            this.LblTotalTakeHomePay.Text = "10,000";
            // 
            // LblTotalDeduction
            // 
            this.LblTotalDeduction.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTotalDeduction.Location = new System.Drawing.Point(193, 107);
            this.LblTotalDeduction.Name = "LblTotalDeduction";
            this.LblTotalDeduction.Size = new System.Drawing.Size(426, 23);
            this.LblTotalDeduction.TabIndex = 9;
            this.LblTotalDeduction.Text = "10,000";
            // 
            // LblTotalIncome
            // 
            this.LblTotalIncome.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTotalIncome.Location = new System.Drawing.Point(193, 80);
            this.LblTotalIncome.Name = "LblTotalIncome";
            this.LblTotalIncome.Size = new System.Drawing.Size(426, 22);
            this.LblTotalIncome.TabIndex = 8;
            this.LblTotalIncome.Text = "10,000";
            // 
            // LblTotalBenefits
            // 
            this.LblTotalBenefits.AutoEllipsis = true;
            this.LblTotalBenefits.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTotalBenefits.Location = new System.Drawing.Point(193, 51);
            this.LblTotalBenefits.Name = "LblTotalBenefits";
            this.LblTotalBenefits.Size = new System.Drawing.Size(426, 21);
            this.LblTotalBenefits.TabIndex = 7;
            this.LblTotalBenefits.Text = "10,000";
            // 
            // LblPayday
            // 
            this.LblPayday.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblPayday.Location = new System.Drawing.Point(193, 25);
            this.LblPayday.Name = "LblPayday";
            this.LblPayday.Size = new System.Drawing.Size(426, 20);
            this.LblPayday.TabIndex = 6;
            this.LblPayday.Text = "Feb. 05 - Feb. 21";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(18, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Your Net Take Home Pay";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(18, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Total Deduction";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(18, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total income";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(18, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total benefits";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(18, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Paydate";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 462);
            this.panel1.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoEllipsis = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(257, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(426, 21);
            this.label7.TabIndex = 11;
            this.label7.Text = "Select the paydate you want to see";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(9, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Paydate";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(76, 8);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(162, 23);
            this.comboBox1.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.ListViewDeductions);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(411, 224);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(391, 229);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Deductions";
            // 
            // ListViewDeductions
            // 
            this.ListViewDeductions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListViewDeductions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.GovtAgency,
            this.CardNumber});
            this.ListViewDeductions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewDeductions.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ListViewDeductions.FullRowSelect = true;
            this.ListViewDeductions.GridLines = true;
            this.ListViewDeductions.HideSelection = false;
            this.ListViewDeductions.Location = new System.Drawing.Point(3, 25);
            this.ListViewDeductions.Name = "ListViewDeductions";
            this.ListViewDeductions.Size = new System.Drawing.Size(385, 201);
            this.ListViewDeductions.TabIndex = 0;
            this.ListViewDeductions.UseCompatibleStateImageBehavior = false;
            this.ListViewDeductions.View = System.Windows.Forms.View.Details;
            // 
            // GovtAgency
            // 
            this.GovtAgency.Name = "GovtAgency";
            this.GovtAgency.Text = "Deduction";
            this.GovtAgency.Width = 150;
            // 
            // CardNumber
            // 
            this.CardNumber.Name = "CardNumber";
            this.CardNumber.Text = "Amount";
            this.CardNumber.Width = 150;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.ListViewBenefits);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(9, 224);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(383, 229);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Benefits";
            // 
            // ListViewBenefits
            // 
            this.ListViewBenefits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListViewBenefits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewBenefits.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ListViewBenefits.FullRowSelect = true;
            this.ListViewBenefits.GridLines = true;
            this.ListViewBenefits.HideSelection = false;
            this.ListViewBenefits.Location = new System.Drawing.Point(3, 25);
            this.ListViewBenefits.Name = "ListViewBenefits";
            this.ListViewBenefits.Size = new System.Drawing.Size(377, 201);
            this.ListViewBenefits.TabIndex = 0;
            this.ListViewBenefits.UseCompatibleStateImageBehavior = false;
            this.ListViewBenefits.View = System.Windows.Forms.View.Details;
            // 
            // EmployeePayslipHistoryUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Name = "EmployeePayslipHistoryUserControl";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(820, 471);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LblTotalTakeHomePay;
        private System.Windows.Forms.Label LblTotalDeduction;
        private System.Windows.Forms.Label LblTotalIncome;
        private System.Windows.Forms.Label LblTotalBenefits;
        private System.Windows.Forms.Label LblPayday;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView ListViewBenefits;
        public System.Windows.Forms.ColumnHeader GovtAgency;
        private System.Windows.Forms.ColumnHeader CardNumber;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView ListViewDeductions;
        public System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
