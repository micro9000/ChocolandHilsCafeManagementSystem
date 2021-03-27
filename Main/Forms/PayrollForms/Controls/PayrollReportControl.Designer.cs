
namespace Main.Forms.PayrollForms.Controls
{
    partial class PayrollReportControl
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
            this.LVEmployeePayslipsHistory = new System.Windows.Forms.ListView();
            this.CHLV_EmpNum = new System.Windows.Forms.ColumnHeader();
            this.CHLV_Fullname = new System.Windows.Forms.ColumnHeader();
            this.CHLV_ShiftRange = new System.Windows.Forms.ColumnHeader();
            this.CHLV_DailyRate = new System.Windows.Forms.ColumnHeader();
            this.CHLV_Late = new System.Windows.Forms.ColumnHeader();
            this.CHLV_LateDeduction = new System.Windows.Forms.ColumnHeader();
            this.CHLV_UT = new System.Windows.Forms.ColumnHeader();
            this.CHLV_UTDeduction = new System.Windows.Forms.ColumnHeader();
            this.CHLV_NetBasicSalary = new System.Windows.Forms.ColumnHeader();
            this.CHLV_BenefitsTotal = new System.Windows.Forms.ColumnHeader();
            this.CHLV_DeductionsTotal = new System.Windows.Forms.ColumnHeader();
            this.CHLV_NetTakeHomePay = new System.Windows.Forms.ColumnHeader();
            this.CHLV_WorkDays = new System.Windows.Forms.ColumnHeader();
            this.CHLV_EmployerContribution = new System.Windows.Forms.ColumnHeader();
            this.BtnFilterPayrollHistory = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CBoxPayslipDates = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnGenerateEmployeePayslipsReportPDF = new System.Windows.Forms.Button();
            this.LblTotalPayment = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(1175, 52);
            this.panel1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Payroll report";
            // 
            // LVEmployeePayslipsHistory
            // 
            this.LVEmployeePayslipsHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CHLV_EmpNum,
            this.CHLV_Fullname,
            this.CHLV_ShiftRange,
            this.CHLV_DailyRate,
            this.CHLV_Late,
            this.CHLV_LateDeduction,
            this.CHLV_UT,
            this.CHLV_UTDeduction,
            this.CHLV_NetBasicSalary,
            this.CHLV_BenefitsTotal,
            this.CHLV_DeductionsTotal,
            this.CHLV_NetTakeHomePay,
            this.CHLV_WorkDays,
            this.CHLV_EmployerContribution});
            this.LVEmployeePayslipsHistory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LVEmployeePayslipsHistory.GridLines = true;
            this.LVEmployeePayslipsHistory.HideSelection = false;
            this.LVEmployeePayslipsHistory.Location = new System.Drawing.Point(0, 120);
            this.LVEmployeePayslipsHistory.Name = "LVEmployeePayslipsHistory";
            this.LVEmployeePayslipsHistory.Size = new System.Drawing.Size(1175, 428);
            this.LVEmployeePayslipsHistory.TabIndex = 9;
            this.LVEmployeePayslipsHistory.UseCompatibleStateImageBehavior = false;
            this.LVEmployeePayslipsHistory.View = System.Windows.Forms.View.Details;
            // 
            // CHLV_EmpNum
            // 
            this.CHLV_EmpNum.Text = "Emp#";
            // 
            // CHLV_Fullname
            // 
            this.CHLV_Fullname.Text = "Fullname";
            this.CHLV_Fullname.Width = 100;
            // 
            // CHLV_ShiftRange
            // 
            this.CHLV_ShiftRange.Text = "Shift Range";
            this.CHLV_ShiftRange.Width = 100;
            // 
            // CHLV_DailyRate
            // 
            this.CHLV_DailyRate.Text = "Daily Rate";
            this.CHLV_DailyRate.Width = 80;
            // 
            // CHLV_Late
            // 
            this.CHLV_Late.Text = "Late";
            // 
            // CHLV_LateDeduction
            // 
            this.CHLV_LateDeduction.Text = "Late Deduction";
            this.CHLV_LateDeduction.Width = 80;
            // 
            // CHLV_UT
            // 
            this.CHLV_UT.Text = "UT";
            // 
            // CHLV_UTDeduction
            // 
            this.CHLV_UTDeduction.Text = "UT Deduction";
            this.CHLV_UTDeduction.Width = 80;
            // 
            // CHLV_NetBasicSalary
            // 
            this.CHLV_NetBasicSalary.Text = "Net Basic Salary";
            this.CHLV_NetBasicSalary.Width = 80;
            // 
            // CHLV_BenefitsTotal
            // 
            this.CHLV_BenefitsTotal.Text = "Benefits";
            this.CHLV_BenefitsTotal.Width = 80;
            // 
            // CHLV_DeductionsTotal
            // 
            this.CHLV_DeductionsTotal.Text = "Deductions";
            this.CHLV_DeductionsTotal.Width = 80;
            // 
            // CHLV_NetTakeHomePay
            // 
            this.CHLV_NetTakeHomePay.Text = "Net Take Home Pay";
            this.CHLV_NetTakeHomePay.Width = 80;
            // 
            // CHLV_WorkDays
            // 
            this.CHLV_WorkDays.Text = "Days";
            this.CHLV_WorkDays.Width = 50;
            // 
            // CHLV_EmployerContribution
            // 
            this.CHLV_EmployerContribution.Text = "Employer Govt Contribution";
            this.CHLV_EmployerContribution.Width = 150;
            // 
            // BtnFilterPayrollHistory
            // 
            this.BtnFilterPayrollHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnFilterPayrollHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFilterPayrollHistory.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnFilterPayrollHistory.ForeColor = System.Drawing.Color.White;
            this.BtnFilterPayrollHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFilterPayrollHistory.Location = new System.Drawing.Point(252, 69);
            this.BtnFilterPayrollHistory.Name = "BtnFilterPayrollHistory";
            this.BtnFilterPayrollHistory.Size = new System.Drawing.Size(69, 29);
            this.BtnFilterPayrollHistory.TabIndex = 55;
            this.BtnFilterPayrollHistory.Text = "Filter";
            this.BtnFilterPayrollHistory.UseVisualStyleBackColor = false;
            this.BtnFilterPayrollHistory.Click += new System.EventHandler(this.BtnFilterPayrollHistory_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(22, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 21);
            this.label1.TabIndex = 53;
            this.label1.Text = "PayDate";
            // 
            // CBoxPayslipDates
            // 
            this.CBoxPayslipDates.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CBoxPayslipDates.FormattingEnabled = true;
            this.CBoxPayslipDates.Location = new System.Drawing.Point(94, 69);
            this.CBoxPayslipDates.Name = "CBoxPayslipDates";
            this.CBoxPayslipDates.Size = new System.Drawing.Size(152, 29);
            this.CBoxPayslipDates.TabIndex = 54;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(801, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 21);
            this.label3.TabIndex = 56;
            this.label3.Text = "Total:";
            // 
            // BtnGenerateEmployeePayslipsReportPDF
            // 
            this.BtnGenerateEmployeePayslipsReportPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnGenerateEmployeePayslipsReportPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGenerateEmployeePayslipsReportPDF.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnGenerateEmployeePayslipsReportPDF.ForeColor = System.Drawing.Color.White;
            this.BtnGenerateEmployeePayslipsReportPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGenerateEmployeePayslipsReportPDF.Location = new System.Drawing.Point(327, 69);
            this.BtnGenerateEmployeePayslipsReportPDF.Name = "BtnGenerateEmployeePayslipsReportPDF";
            this.BtnGenerateEmployeePayslipsReportPDF.Size = new System.Drawing.Size(169, 29);
            this.BtnGenerateEmployeePayslipsReportPDF.TabIndex = 57;
            this.BtnGenerateEmployeePayslipsReportPDF.Text = "Generate PDF Report";
            this.BtnGenerateEmployeePayslipsReportPDF.UseVisualStyleBackColor = false;
            this.BtnGenerateEmployeePayslipsReportPDF.Click += new System.EventHandler(this.BtnGenerateEmployeePayslipsReportPDF_Click);
            // 
            // LblTotalPayment
            // 
            this.LblTotalPayment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTotalPayment.Location = new System.Drawing.Point(852, 72);
            this.LblTotalPayment.Name = "LblTotalPayment";
            this.LblTotalPayment.Size = new System.Drawing.Size(230, 21);
            this.LblTotalPayment.TabIndex = 58;
            this.LblTotalPayment.Text = "00000";
            // 
            // PayrollReportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.LblTotalPayment);
            this.Controls.Add(this.BtnGenerateEmployeePayslipsReportPDF);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnFilterPayrollHistory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBoxPayslipDates);
            this.Controls.Add(this.LVEmployeePayslipsHistory);
            this.Controls.Add(this.panel1);
            this.Name = "PayrollReportControl";
            this.Size = new System.Drawing.Size(1175, 548);
            this.Load += new System.EventHandler(this.PayrollReportControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView LVEmployeePayslipsHistory;
        private System.Windows.Forms.Button BtnFilterPayrollHistory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBoxPayslipDates;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnGenerateEmployeePayslipsReportPDF;
        private System.Windows.Forms.Label LblTotalPayment;
        private System.Windows.Forms.ColumnHeader CHLV_EmpNum;
        private System.Windows.Forms.ColumnHeader CHLV_Fullname;
        private System.Windows.Forms.ColumnHeader CHLV_ShiftRange;
        private System.Windows.Forms.ColumnHeader CHLV_DailyRate;
        private System.Windows.Forms.ColumnHeader CHLV_Late;
        private System.Windows.Forms.ColumnHeader CHLV_LateDeduction;
        private System.Windows.Forms.ColumnHeader CHLV_UT;
        private System.Windows.Forms.ColumnHeader CHLV_UTDeduction;
        private System.Windows.Forms.ColumnHeader CHLV_NetBasicSalary;
        private System.Windows.Forms.ColumnHeader CHLV_BenefitsTotal;
        private System.Windows.Forms.ColumnHeader CHLV_DeductionsTotal;
        private System.Windows.Forms.ColumnHeader CHLV_NetTakeHomePay;
        private System.Windows.Forms.ColumnHeader CHLV_WorkDays;
        private System.Windows.Forms.ColumnHeader CHLV_EmployerContribution;
    }
}
