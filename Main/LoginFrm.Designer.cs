
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
            this.BtnOpenAttendanceTerminal = new System.Windows.Forms.Button();
            this.GPanelChooseTerminal.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnLogin
            // 
            this.BtnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnLogin.Location = new System.Drawing.Point(124, 280);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(260, 47);
            this.BtnLogin.TabIndex = 0;
            this.BtnLogin.Text = "Login";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // TbxUsername
            // 
            this.TbxUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbxUsername.Location = new System.Drawing.Point(127, 41);
            this.TbxUsername.Name = "TbxUsername";
            this.TbxUsername.Size = new System.Drawing.Size(257, 29);
            this.TbxUsername.TabIndex = 1;
            this.TbxUsername.Text = "admin01";
            // 
            // TbxPassword
            // 
            this.TbxPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbxPassword.Location = new System.Drawing.Point(127, 98);
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
            this.label1.Location = new System.Drawing.Point(40, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(45, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // GPanelChooseTerminal
            // 
            this.GPanelChooseTerminal.Controls.Add(this.RBtnPOSTerminal);
            this.GPanelChooseTerminal.Controls.Add(this.RBtnAdminDashboard);
            this.GPanelChooseTerminal.Location = new System.Drawing.Point(124, 148);
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
            // BtnOpenAttendanceTerminal
            // 
            this.BtnOpenAttendanceTerminal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnOpenAttendanceTerminal.Location = new System.Drawing.Point(124, 333);
            this.BtnOpenAttendanceTerminal.Name = "BtnOpenAttendanceTerminal";
            this.BtnOpenAttendanceTerminal.Size = new System.Drawing.Size(260, 47);
            this.BtnOpenAttendanceTerminal.TabIndex = 6;
            this.BtnOpenAttendanceTerminal.Text = "Open Attendance Terminal";
            this.BtnOpenAttendanceTerminal.UseVisualStyleBackColor = true;
            this.BtnOpenAttendanceTerminal.Click += new System.EventHandler(this.BtnOpenAttendanceTerminal_Click);
            // 
            // LoginFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 400);
            this.Controls.Add(this.BtnOpenAttendanceTerminal);
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
        private System.Windows.Forms.Button BtnOpenAttendanceTerminal;
    }
}