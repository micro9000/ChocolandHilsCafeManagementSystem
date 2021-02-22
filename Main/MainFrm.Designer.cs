
namespace Main
{
    partial class MainFrm
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
            this.LblCurrentUserName = new System.Windows.Forms.Label();
            this.LblUserRoles = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblCurrentUserName
            // 
            this.LblCurrentUserName.AutoSize = true;
            this.LblCurrentUserName.Location = new System.Drawing.Point(618, 40);
            this.LblCurrentUserName.Name = "LblCurrentUserName";
            this.LblCurrentUserName.Size = new System.Drawing.Size(38, 15);
            this.LblCurrentUserName.TabIndex = 0;
            this.LblCurrentUserName.Text = "label1";
            // 
            // LblUserRoles
            // 
            this.LblUserRoles.AutoSize = true;
            this.LblUserRoles.Location = new System.Drawing.Point(618, 73);
            this.LblUserRoles.Name = "LblUserRoles";
            this.LblUserRoles.Size = new System.Drawing.Size(38, 15);
            this.LblUserRoles.TabIndex = 1;
            this.LblUserRoles.Text = "label1";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LblUserRoles);
            this.Controls.Add(this.LblCurrentUserName);
            this.Name = "MainFrm";
            this.Text = "MainFrm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFrm_FormClosed);
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblCurrentUserName;
        private System.Windows.Forms.Label LblUserRoles;
    }
}