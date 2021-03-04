
namespace Main.Forms.PayrollForms
{
    partial class FrmPayroll
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
            this.menuStripPayroll = new System.Windows.Forms.MenuStrip();
            this.SuspendLayout();
            // 
            // menuStripPayroll
            // 
            this.menuStripPayroll.Location = new System.Drawing.Point(0, 0);
            this.menuStripPayroll.Name = "menuStripPayroll";
            this.menuStripPayroll.Size = new System.Drawing.Size(800, 24);
            this.menuStripPayroll.TabIndex = 0;
            this.menuStripPayroll.Text = "menuStrip1";
            // 
            // FrmPayroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStripPayroll);
            this.MainMenuStrip = this.menuStripPayroll;
            this.Name = "FrmPayroll";
            this.Text = "PayrollForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripPayroll;
    }
}