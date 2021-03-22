
namespace Main.Forms.PayrollForms.Controls
{
    partial class GeneratePayrollControl
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
            this.TabControlDeductions = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.BtnGeneratePayrollInitiate = new System.Windows.Forms.Button();
            this.DTPicShiftEndDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DTPicShiftStartDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.DTPicPaydate = new System.Windows.Forms.DateTimePicker();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BtnSelectAllEmployees = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BtnSaveEmployeeShiftSchedule = new System.Windows.Forms.Button();
            this.DGVEmployeeList = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.DGVGovtAgencies = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.DGVBenefitsList = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.DGVDeductionList = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.DGVSalesRecords = new System.Windows.Forms.DataGridView();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.dataGridView6 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.TabControlDeductions.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeList)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVGovtAgencies)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVBenefitsList)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDeductionList)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSalesRecords)).BeginInit();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(871, 94);
            this.panel1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Generate payroll";
            // 
            // TabControlDeductions
            // 
            this.TabControlDeductions.Controls.Add(this.tabPage6);
            this.TabControlDeductions.Controls.Add(this.tabPage1);
            this.TabControlDeductions.Controls.Add(this.tabPage2);
            this.TabControlDeductions.Controls.Add(this.tabPage3);
            this.TabControlDeductions.Controls.Add(this.tabPage4);
            this.TabControlDeductions.Controls.Add(this.tabPage5);
            this.TabControlDeductions.Controls.Add(this.tabPage7);
            this.TabControlDeductions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlDeductions.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TabControlDeductions.Location = new System.Drawing.Point(0, 94);
            this.TabControlDeductions.Name = "TabControlDeductions";
            this.TabControlDeductions.SelectedIndex = 0;
            this.TabControlDeductions.Size = new System.Drawing.Size(871, 489);
            this.TabControlDeductions.TabIndex = 7;
            this.TabControlDeductions.SelectedIndexChanged += new System.EventHandler(this.TabControlDeductions_SelectedIndexChanged);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.groupBox1);
            this.tabPage6.Location = new System.Drawing.Point(4, 30);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(863, 455);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Generate";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // BtnGeneratePayrollInitiate
            // 
            this.BtnGeneratePayrollInitiate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnGeneratePayrollInitiate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGeneratePayrollInitiate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnGeneratePayrollInitiate.ForeColor = System.Drawing.Color.White;
            this.BtnGeneratePayrollInitiate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGeneratePayrollInitiate.Location = new System.Drawing.Point(248, 160);
            this.BtnGeneratePayrollInitiate.Name = "BtnGeneratePayrollInitiate";
            this.BtnGeneratePayrollInitiate.Size = new System.Drawing.Size(115, 47);
            this.BtnGeneratePayrollInitiate.TabIndex = 65;
            this.BtnGeneratePayrollInitiate.Text = "Initiate";
            this.BtnGeneratePayrollInitiate.UseVisualStyleBackColor = false;
            // 
            // DTPicShiftEndDate
            // 
            this.DTPicShiftEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPicShiftEndDate.Location = new System.Drawing.Point(315, 102);
            this.DTPicShiftEndDate.Name = "DTPicShiftEndDate";
            this.DTPicShiftEndDate.Size = new System.Drawing.Size(117, 29);
            this.DTPicShiftEndDate.TabIndex = 64;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(284, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 21);
            this.label7.TabIndex = 63;
            this.label7.Text = "To";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 21);
            this.label6.TabIndex = 61;
            this.label6.Text = "Shift start from";
            // 
            // DTPicShiftStartDate
            // 
            this.DTPicShiftStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPicShiftStartDate.Location = new System.Drawing.Point(161, 102);
            this.DTPicShiftStartDate.Name = "DTPicShiftStartDate";
            this.DTPicShiftStartDate.Size = new System.Drawing.Size(117, 29);
            this.DTPicShiftStartDate.TabIndex = 60;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 21);
            this.label4.TabIndex = 59;
            this.label4.Text = "Paydate";
            // 
            // DTPicPaydate
            // 
            this.DTPicPaydate.Location = new System.Drawing.Point(161, 56);
            this.DTPicPaydate.Name = "DTPicPaydate";
            this.DTPicPaydate.Size = new System.Drawing.Size(271, 29);
            this.DTPicPaydate.TabIndex = 58;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BtnSelectAllEmployees);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.BtnSaveEmployeeShiftSchedule);
            this.tabPage1.Controls.Add(this.DGVEmployeeList);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(863, 455);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Employees";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // BtnSelectAllEmployees
            // 
            this.BtnSelectAllEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSelectAllEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSelectAllEmployees.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSelectAllEmployees.ForeColor = System.Drawing.Color.White;
            this.BtnSelectAllEmployees.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSelectAllEmployees.Location = new System.Drawing.Point(743, 24);
            this.BtnSelectAllEmployees.Name = "BtnSelectAllEmployees";
            this.BtnSelectAllEmployees.Size = new System.Drawing.Size(87, 24);
            this.BtnSelectAllEmployees.TabIndex = 54;
            this.BtnSelectAllEmployees.Text = "Select all";
            this.BtnSelectAllEmployees.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(34, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 21);
            this.label3.TabIndex = 52;
            this.label3.Text = "Search";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(97, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(281, 29);
            this.textBox1.TabIndex = 51;
            // 
            // BtnSaveEmployeeShiftSchedule
            // 
            this.BtnSaveEmployeeShiftSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSaveEmployeeShiftSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveEmployeeShiftSchedule.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveEmployeeShiftSchedule.ForeColor = System.Drawing.Color.White;
            this.BtnSaveEmployeeShiftSchedule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveEmployeeShiftSchedule.Location = new System.Drawing.Point(715, 389);
            this.BtnSaveEmployeeShiftSchedule.Name = "BtnSaveEmployeeShiftSchedule";
            this.BtnSaveEmployeeShiftSchedule.Size = new System.Drawing.Size(115, 47);
            this.BtnSaveEmployeeShiftSchedule.TabIndex = 50;
            this.BtnSaveEmployeeShiftSchedule.Text = "Next";
            this.BtnSaveEmployeeShiftSchedule.UseVisualStyleBackColor = false;
            // 
            // DGVEmployeeList
            // 
            this.DGVEmployeeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVEmployeeList.Location = new System.Drawing.Point(34, 54);
            this.DGVEmployeeList.Name = "DGVEmployeeList";
            this.DGVEmployeeList.RowTemplate.Height = 25;
            this.DGVEmployeeList.Size = new System.Drawing.Size(796, 329);
            this.DGVEmployeeList.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.DGVGovtAgencies);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(863, 455);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Govt. Contributions";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(603, 385);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 47);
            this.button2.TabIndex = 56;
            this.button2.Text = "Next";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(631, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 24);
            this.button1.TabIndex = 55;
            this.button1.Text = "Select all";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // DGVGovtAgencies
            // 
            this.DGVGovtAgencies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVGovtAgencies.Location = new System.Drawing.Point(123, 46);
            this.DGVGovtAgencies.Name = "DGVGovtAgencies";
            this.DGVGovtAgencies.RowTemplate.Height = 25;
            this.DGVGovtAgencies.Size = new System.Drawing.Size(595, 333);
            this.DGVGovtAgencies.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.DGVBenefitsList);
            this.tabPage3.Location = new System.Drawing.Point(4, 30);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(863, 455);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Benefits";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(603, 388);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 47);
            this.button3.TabIndex = 59;
            this.button3.Text = "Next";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(631, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(87, 24);
            this.button4.TabIndex = 58;
            this.button4.Text = "Select all";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // DGVBenefitsList
            // 
            this.DGVBenefitsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVBenefitsList.Location = new System.Drawing.Point(123, 49);
            this.DGVBenefitsList.Name = "DGVBenefitsList";
            this.DGVBenefitsList.RowTemplate.Height = 25;
            this.DGVBenefitsList.Size = new System.Drawing.Size(595, 333);
            this.DGVBenefitsList.TabIndex = 57;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button5);
            this.tabPage4.Controls.Add(this.button6);
            this.tabPage4.Controls.Add(this.DGVDeductionList);
            this.tabPage4.Location = new System.Drawing.Point(4, 30);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(863, 455);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Deductions";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(602, 387);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(115, 47);
            this.button5.TabIndex = 59;
            this.button5.Text = "Next";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(630, 18);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(87, 24);
            this.button6.TabIndex = 58;
            this.button6.Text = "Select all";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // DGVDeductionList
            // 
            this.DGVDeductionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVDeductionList.Location = new System.Drawing.Point(122, 48);
            this.DGVDeductionList.Name = "DGVDeductionList";
            this.DGVDeductionList.RowTemplate.Height = 25;
            this.DGVDeductionList.Size = new System.Drawing.Size(595, 333);
            this.DGVDeductionList.TabIndex = 57;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.button8);
            this.tabPage5.Controls.Add(this.button7);
            this.tabPage5.Controls.Add(this.DGVSalesRecords);
            this.tabPage5.Location = new System.Drawing.Point(4, 30);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(863, 455);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Sales Bonus";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.Location = new System.Drawing.Point(623, 22);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(87, 24);
            this.button8.TabIndex = 61;
            this.button8.Text = "Select all";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(595, 391);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(115, 47);
            this.button7.TabIndex = 60;
            this.button7.Text = "Next";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // DGVSalesRecords
            // 
            this.DGVSalesRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVSalesRecords.Location = new System.Drawing.Point(121, 52);
            this.DGVSalesRecords.Name = "DGVSalesRecords";
            this.DGVSalesRecords.RowTemplate.Height = 25;
            this.DGVSalesRecords.Size = new System.Drawing.Size(589, 333);
            this.DGVSalesRecords.TabIndex = 58;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.label8);
            this.tabPage7.Controls.Add(this.label5);
            this.tabPage7.Controls.Add(this.label1);
            this.tabPage7.Controls.Add(this.button9);
            this.tabPage7.Controls.Add(this.dataGridView6);
            this.tabPage7.Location = new System.Drawing.Point(4, 30);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(863, 455);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Overview";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 21);
            this.label8.TabIndex = 56;
            this.label8.Text = "Employee Salary";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(682, 339);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 21);
            this.label5.TabIndex = 55;
            this.label5.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(551, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 21);
            this.label1.TabIndex = 52;
            this.label1.Text = "Total payment";
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.Location = new System.Drawing.Point(718, 388);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(115, 47);
            this.button9.TabIndex = 51;
            this.button9.Text = "Okay";
            this.button9.UseVisualStyleBackColor = false;
            // 
            // dataGridView6
            // 
            this.dataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView6.Location = new System.Drawing.Point(22, 55);
            this.dataGridView6.Name = "dataGridView6";
            this.dataGridView6.RowTemplate.Height = 25;
            this.dataGridView6.Size = new System.Drawing.Size(811, 265);
            this.dataGridView6.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnGeneratePayrollInitiate);
            this.groupBox1.Controls.Add(this.DTPicShiftEndDate);
            this.groupBox1.Controls.Add(this.DTPicPaydate);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.DTPicShiftStartDate);
            this.groupBox1.Location = new System.Drawing.Point(177, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 239);
            this.groupBox1.TabIndex = 67;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generate new payroll";
            // 
            // GeneratePayrollControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TabControlDeductions);
            this.Controls.Add(this.panel1);
            this.Name = "GeneratePayrollControl";
            this.Size = new System.Drawing.Size(871, 583);
            this.Load += new System.EventHandler(this.GeneratePayrollControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TabControlDeductions.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeList)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVGovtAgencies)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVBenefitsList)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDeductionList)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVSalesRecords)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl TabControlDeductions;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView DGVEmployeeList;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button BtnSaveEmployeeShiftSchedule;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnSelectAllEmployees;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView DGVGovtAgencies;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView DGVBenefitsList;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView DGVDeductionList;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.DataGridView DGVSalesRecords;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.DataGridView dataGridView6;
        private System.Windows.Forms.DateTimePicker DTPicShiftEndDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DTPicShiftStartDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DTPicPaydate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnGeneratePayrollInitiate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
