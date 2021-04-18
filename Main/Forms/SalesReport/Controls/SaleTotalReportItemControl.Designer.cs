
namespace Main.Forms.SalesReport.Controls
{
    partial class SaleTotalReportItemControl
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
            this.LblSaleReportType = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblAmount = new System.Windows.Forms.Label();
            this.LblSaleReportForThe = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblSaleReportType
            // 
            this.LblSaleReportType.AutoSize = true;
            this.LblSaleReportType.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblSaleReportType.Location = new System.Drawing.Point(12, 36);
            this.LblSaleReportType.Name = "LblSaleReportType";
            this.LblSaleReportType.Size = new System.Drawing.Size(69, 30);
            this.LblSaleReportType.TabIndex = 0;
            this.LblSaleReportType.Text = "Yearly";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.LblSaleReportForThe);
            this.panel1.Controls.Add(this.LblAmount);
            this.panel1.Controls.Add(this.LblSaleReportType);
            this.panel1.Location = new System.Drawing.Point(7, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 100);
            this.panel1.TabIndex = 1;
            // 
            // LblAmount
            // 
            this.LblAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblAmount.Location = new System.Drawing.Point(87, 24);
            this.LblAmount.Name = "LblAmount";
            this.LblAmount.Size = new System.Drawing.Size(143, 25);
            this.LblAmount.TabIndex = 1;
            this.LblAmount.Text = "0.00";
            // 
            // LblSaleReportForThe
            // 
            this.LblSaleReportForThe.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblSaleReportForThe.Location = new System.Drawing.Point(87, 49);
            this.LblSaleReportForThe.Name = "LblSaleReportForThe";
            this.LblSaleReportForThe.Size = new System.Drawing.Size(143, 25);
            this.LblSaleReportForThe.TabIndex = 2;
            this.LblSaleReportForThe.Text = "2021";
            // 
            // SaleTotalReportItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.panel1);
            this.Name = "SaleTotalReportItemControl";
            this.Size = new System.Drawing.Size(256, 112);
            this.Load += new System.EventHandler(this.SaleTotalReportItemControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblSaleReportType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblSaleReportForThe;
        private System.Windows.Forms.Label LblAmount;
    }
}
