﻿
namespace Main.Forms.EmployeeManagementForms
{
    partial class FrmAddUpdateEmployee
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddUpdateEmployee));
            this.TbxFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSaveEmployee = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TbxLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TbxAddress = new System.Windows.Forms.TextBox();
            this.DTPicBirthDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TbxMobileNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TbxEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TbxBranchAssign = new System.Windows.Forms.TextBox();
            this.PanelAddUpdateEmployee = new System.Windows.Forms.Panel();
            this.GBoxActions = new System.Windows.Forms.GroupBox();
            this.RBtnUpdate = new System.Windows.Forms.RadioButton();
            this.RBtnNew = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.TbxEmployeeNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DTPicHireDate = new System.Windows.Forms.DateTimePicker();
            this.PanelAddUpdateEmployee.SuspendLayout();
            this.GBoxActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // TbxFirstName
            // 
            this.TbxFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbxFirstName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbxFirstName.Location = new System.Drawing.Point(33, 193);
            this.TbxFirstName.Name = "TbxFirstName";
            this.TbxFirstName.Size = new System.Drawing.Size(265, 27);
            this.TbxFirstName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(33, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "First name";
            // 
            // BtnSaveEmployee
            // 
            this.BtnSaveEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSaveEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveEmployee.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveEmployee.ForeColor = System.Drawing.Color.White;
            this.BtnSaveEmployee.Image = ((System.Drawing.Image)(resources.GetObject("BtnSaveEmployee.Image")));
            this.BtnSaveEmployee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveEmployee.Location = new System.Drawing.Point(248, 463);
            this.BtnSaveEmployee.Name = "BtnSaveEmployee";
            this.BtnSaveEmployee.Size = new System.Drawing.Size(134, 48);
            this.BtnSaveEmployee.TabIndex = 11;
            this.BtnSaveEmployee.Text = "Save";
            this.BtnSaveEmployee.UseVisualStyleBackColor = false;
            this.BtnSaveEmployee.Click += new System.EventHandler(this.BtnSaveEmployee_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(35, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Last name";
            // 
            // TbxLastName
            // 
            this.TbxLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbxLastName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbxLastName.Location = new System.Drawing.Point(33, 267);
            this.TbxLastName.Name = "TbxLastName";
            this.TbxLastName.Size = new System.Drawing.Size(265, 27);
            this.TbxLastName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(320, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Address";
            // 
            // TbxAddress
            // 
            this.TbxAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbxAddress.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbxAddress.Location = new System.Drawing.Point(320, 181);
            this.TbxAddress.Multiline = true;
            this.TbxAddress.Name = "TbxAddress";
            this.TbxAddress.Size = new System.Drawing.Size(265, 78);
            this.TbxAddress.TabIndex = 8;
            // 
            // DTPicBirthDate
            // 
            this.DTPicBirthDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DTPicBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPicBirthDate.Location = new System.Drawing.Point(33, 345);
            this.DTPicBirthDate.Name = "DTPicBirthDate";
            this.DTPicBirthDate.Size = new System.Drawing.Size(265, 27);
            this.DTPicBirthDate.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(35, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Date of birth";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(33, 389);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Mobile #";
            // 
            // TbxMobileNumber
            // 
            this.TbxMobileNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbxMobileNumber.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbxMobileNumber.Location = new System.Drawing.Point(33, 417);
            this.TbxMobileNumber.Name = "TbxMobileNumber";
            this.TbxMobileNumber.Size = new System.Drawing.Size(265, 27);
            this.TbxMobileNumber.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(320, 391);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Email";
            // 
            // TbxEmail
            // 
            this.TbxEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbxEmail.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbxEmail.Location = new System.Drawing.Point(320, 419);
            this.TbxEmail.Name = "TbxEmail";
            this.TbxEmail.Size = new System.Drawing.Size(265, 27);
            this.TbxEmail.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(320, 264);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Branch Assign";
            // 
            // TbxBranchAssign
            // 
            this.TbxBranchAssign.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbxBranchAssign.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbxBranchAssign.Location = new System.Drawing.Point(320, 292);
            this.TbxBranchAssign.Multiline = true;
            this.TbxBranchAssign.Name = "TbxBranchAssign";
            this.TbxBranchAssign.Size = new System.Drawing.Size(265, 83);
            this.TbxBranchAssign.TabIndex = 9;
            // 
            // PanelAddUpdateEmployee
            // 
            this.PanelAddUpdateEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(133)))));
            this.PanelAddUpdateEmployee.Controls.Add(this.GBoxActions);
            this.PanelAddUpdateEmployee.Controls.Add(this.label9);
            this.PanelAddUpdateEmployee.Controls.Add(this.TbxEmployeeNumber);
            this.PanelAddUpdateEmployee.Controls.Add(this.label8);
            this.PanelAddUpdateEmployee.Controls.Add(this.DTPicHireDate);
            this.PanelAddUpdateEmployee.Controls.Add(this.BtnSaveEmployee);
            this.PanelAddUpdateEmployee.Controls.Add(this.label3);
            this.PanelAddUpdateEmployee.Controls.Add(this.label4);
            this.PanelAddUpdateEmployee.Controls.Add(this.TbxAddress);
            this.PanelAddUpdateEmployee.Controls.Add(this.label1);
            this.PanelAddUpdateEmployee.Controls.Add(this.label7);
            this.PanelAddUpdateEmployee.Controls.Add(this.TbxFirstName);
            this.PanelAddUpdateEmployee.Controls.Add(this.DTPicBirthDate);
            this.PanelAddUpdateEmployee.Controls.Add(this.TbxMobileNumber);
            this.PanelAddUpdateEmployee.Controls.Add(this.TbxBranchAssign);
            this.PanelAddUpdateEmployee.Controls.Add(this.label5);
            this.PanelAddUpdateEmployee.Controls.Add(this.label2);
            this.PanelAddUpdateEmployee.Controls.Add(this.TbxLastName);
            this.PanelAddUpdateEmployee.Controls.Add(this.label6);
            this.PanelAddUpdateEmployee.Controls.Add(this.TbxEmail);
            this.PanelAddUpdateEmployee.Location = new System.Drawing.Point(12, 12);
            this.PanelAddUpdateEmployee.Name = "PanelAddUpdateEmployee";
            this.PanelAddUpdateEmployee.Size = new System.Drawing.Size(610, 527);
            this.PanelAddUpdateEmployee.TabIndex = 15;
            // 
            // GBoxActions
            // 
            this.GBoxActions.Controls.Add(this.RBtnUpdate);
            this.GBoxActions.Controls.Add(this.RBtnNew);
            this.GBoxActions.ForeColor = System.Drawing.Color.White;
            this.GBoxActions.Location = new System.Drawing.Point(33, 12);
            this.GBoxActions.Name = "GBoxActions";
            this.GBoxActions.Size = new System.Drawing.Size(224, 57);
            this.GBoxActions.TabIndex = 19;
            this.GBoxActions.TabStop = false;
            this.GBoxActions.Text = "Action";
            // 
            // RBtnUpdate
            // 
            this.RBtnUpdate.AutoSize = true;
            this.RBtnUpdate.FlatAppearance.BorderSize = 0;
            this.RBtnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RBtnUpdate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RBtnUpdate.ForeColor = System.Drawing.Color.White;
            this.RBtnUpdate.Location = new System.Drawing.Point(121, 22);
            this.RBtnUpdate.Name = "RBtnUpdate";
            this.RBtnUpdate.Size = new System.Drawing.Size(75, 24);
            this.RBtnUpdate.TabIndex = 1;
            this.RBtnUpdate.TabStop = true;
            this.RBtnUpdate.Text = "Update";
            this.RBtnUpdate.UseVisualStyleBackColor = true;
            this.RBtnUpdate.CheckedChanged += new System.EventHandler(this.RBtnUpdate_CheckedChanged);
            // 
            // RBtnNew
            // 
            this.RBtnNew.AutoSize = true;
            this.RBtnNew.FlatAppearance.BorderSize = 0;
            this.RBtnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RBtnNew.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RBtnNew.ForeColor = System.Drawing.Color.White;
            this.RBtnNew.Location = new System.Drawing.Point(26, 22);
            this.RBtnNew.Name = "RBtnNew";
            this.RBtnNew.Size = new System.Drawing.Size(56, 24);
            this.RBtnNew.TabIndex = 0;
            this.RBtnNew.TabStop = true;
            this.RBtnNew.Text = "New";
            this.RBtnNew.UseVisualStyleBackColor = true;
            this.RBtnNew.CheckedChanged += new System.EventHandler(this.RBtnNew_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(33, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "Employee Number";
            // 
            // TbxEmployeeNumber
            // 
            this.TbxEmployeeNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbxEmployeeNumber.Enabled = false;
            this.TbxEmployeeNumber.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbxEmployeeNumber.Location = new System.Drawing.Point(33, 123);
            this.TbxEmployeeNumber.Name = "TbxEmployeeNumber";
            this.TbxEmployeeNumber.Size = new System.Drawing.Size(265, 27);
            this.TbxEmployeeNumber.TabIndex = 2;
            this.TbxEmployeeNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbxEmployeeNumber_KeyUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(320, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Hire Date";
            // 
            // DTPicHireDate
            // 
            this.DTPicHireDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DTPicHireDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPicHireDate.Location = new System.Drawing.Point(320, 120);
            this.DTPicHireDate.Name = "DTPicHireDate";
            this.DTPicHireDate.Size = new System.Drawing.Size(265, 27);
            this.DTPicHireDate.TabIndex = 7;
            // 
            // FrmAddUpdateEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(638, 554);
            this.Controls.Add(this.PanelAddUpdateEmployee);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAddUpdateEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Update Employee";
            this.Load += new System.EventHandler(this.FrmAddUpdateEmployee_Load);
            this.PanelAddUpdateEmployee.ResumeLayout(false);
            this.PanelAddUpdateEmployee.PerformLayout();
            this.GBoxActions.ResumeLayout(false);
            this.GBoxActions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox TbxFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnSaveEmployee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TbxLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TbxAddress;
        private System.Windows.Forms.DateTimePicker DTPicBirthDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TbxMobileNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TbxEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TbxBranchAssign;
        private System.Windows.Forms.Panel PanelAddUpdateEmployee;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker DTPicHireDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TbxEmployeeNumber;
        private System.Windows.Forms.GroupBox GBoxActions;
        private System.Windows.Forms.RadioButton RBtnUpdate;
        private System.Windows.Forms.RadioButton RBtnNew;
    }
}