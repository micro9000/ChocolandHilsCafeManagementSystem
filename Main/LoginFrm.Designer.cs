﻿
namespace Main
{
    partial class LoginFrm
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
            this.BtnLogin = new System.Windows.Forms.Button();
            this.TbxUsername = new System.Windows.Forms.TextBox();
            this.TbxPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GPanelChooseTerminal = new System.Windows.Forms.GroupBox();
            this.RBtnPOSTerminal = new System.Windows.Forms.RadioButton();
            this.RBtnAdminDashboard = new System.Windows.Forms.RadioButton();
            this.panelSecondaryBanner = new System.Windows.Forms.Panel();
            this.LblRenderedFormTitle = new System.Windows.Forms.Label();
            this.GPanelChooseTerminal.SuspendLayout();
            this.panelSecondaryBanner.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnLogin
            // 
            this.BtnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogin.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnLogin.ForeColor = System.Drawing.Color.White;
            this.BtnLogin.Location = new System.Drawing.Point(108, 319);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(260, 47);
            this.BtnLogin.TabIndex = 0;
            this.BtnLogin.Text = "Login";
            this.BtnLogin.UseVisualStyleBackColor = false;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // TbxUsername
            // 
            this.TbxUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbxUsername.Location = new System.Drawing.Point(111, 102);
            this.TbxUsername.Name = "TbxUsername";
            this.TbxUsername.Size = new System.Drawing.Size(257, 29);
            this.TbxUsername.TabIndex = 1;
            this.TbxUsername.Text = "admin01";
            // 
            // TbxPassword
            // 
            this.TbxPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbxPassword.Location = new System.Drawing.Point(111, 137);
            this.TbxPassword.Name = "TbxPassword";
            this.TbxPassword.PasswordChar = '*';
            this.TbxPassword.Size = new System.Drawing.Size(257, 29);
            this.TbxPassword.TabIndex = 2;
            this.TbxPassword.Text = "raniel";
            this.TbxPassword.UseSystemPasswordChar = true;
            this.TbxPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbxPassword_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(24, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(29, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // GPanelChooseTerminal
            // 
            this.GPanelChooseTerminal.Controls.Add(this.RBtnPOSTerminal);
            this.GPanelChooseTerminal.Controls.Add(this.RBtnAdminDashboard);
            this.GPanelChooseTerminal.Location = new System.Drawing.Point(108, 187);
            this.GPanelChooseTerminal.Name = "GPanelChooseTerminal";
            this.GPanelChooseTerminal.Size = new System.Drawing.Size(260, 118);
            this.GPanelChooseTerminal.TabIndex = 5;
            this.GPanelChooseTerminal.TabStop = false;
            this.GPanelChooseTerminal.Text = "Choose application";
            // 
            // RBtnPOSTerminal
            // 
            this.RBtnPOSTerminal.AutoSize = true;
            this.RBtnPOSTerminal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RBtnPOSTerminal.Location = new System.Drawing.Point(20, 71);
            this.RBtnPOSTerminal.Name = "RBtnPOSTerminal";
            this.RBtnPOSTerminal.Size = new System.Drawing.Size(174, 25);
            this.RBtnPOSTerminal.TabIndex = 1;
            this.RBtnPOSTerminal.TabStop = true;
            this.RBtnPOSTerminal.Text = "Point of sale terminal";
            this.RBtnPOSTerminal.UseVisualStyleBackColor = true;
            // 
            // RBtnAdminDashboard
            // 
            this.RBtnAdminDashboard.AutoSize = true;
            this.RBtnAdminDashboard.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RBtnAdminDashboard.Location = new System.Drawing.Point(20, 33);
            this.RBtnAdminDashboard.Name = "RBtnAdminDashboard";
            this.RBtnAdminDashboard.Size = new System.Drawing.Size(154, 25);
            this.RBtnAdminDashboard.TabIndex = 0;
            this.RBtnAdminDashboard.TabStop = true;
            this.RBtnAdminDashboard.Text = "Admin Dashboard";
            this.RBtnAdminDashboard.UseVisualStyleBackColor = true;
            // 
            // panelSecondaryBanner
            // 
            this.panelSecondaryBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panelSecondaryBanner.Controls.Add(this.LblRenderedFormTitle);
            this.panelSecondaryBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSecondaryBanner.Location = new System.Drawing.Point(0, 0);
            this.panelSecondaryBanner.Name = "panelSecondaryBanner";
            this.panelSecondaryBanner.Size = new System.Drawing.Size(425, 67);
            this.panelSecondaryBanner.TabIndex = 6;
            // 
            // LblRenderedFormTitle
            // 
            this.LblRenderedFormTitle.AutoSize = true;
            this.LblRenderedFormTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblRenderedFormTitle.ForeColor = System.Drawing.Color.White;
            this.LblRenderedFormTitle.Location = new System.Drawing.Point(12, 18);
            this.LblRenderedFormTitle.Name = "LblRenderedFormTitle";
            this.LblRenderedFormTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblRenderedFormTitle.Size = new System.Drawing.Size(162, 30);
            this.LblRenderedFormTitle.TabIndex = 0;
            this.LblRenderedFormTitle.Text = "Welcome back!";
            // 
            // LoginFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 382);
            this.Controls.Add(this.panelSecondaryBanner);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GPanelChooseTerminal);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.TbxPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TbxUsername);
            this.Name = "LoginFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginFrm";
            this.GPanelChooseTerminal.ResumeLayout(false);
            this.GPanelChooseTerminal.PerformLayout();
            this.panelSecondaryBanner.ResumeLayout(false);
            this.panelSecondaryBanner.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.TextBox TbxUsername;
        private System.Windows.Forms.TextBox TbxPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GPanelChooseTerminal;
        private System.Windows.Forms.RadioButton RBtnPOSTerminal;
        private System.Windows.Forms.RadioButton RBtnAdminDashboard;
        private System.Windows.Forms.Panel panelSecondaryBanner;
        private System.Windows.Forms.Label LblRenderedFormTitle;
    }
}