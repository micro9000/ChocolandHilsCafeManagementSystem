﻿
namespace Main.Forms.POSManagementForms.Controls
{
    partial class RestaurantTableItemControl
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
            this.PicBoxTableStatus = new System.Windows.Forms.PictureBox();
            this.LblTableNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTableStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // PicBoxTableStatus
            // 
            this.PicBoxTableStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.PicBoxTableStatus.Location = new System.Drawing.Point(0, 0);
            this.PicBoxTableStatus.Name = "PicBoxTableStatus";
            this.PicBoxTableStatus.Size = new System.Drawing.Size(120, 89);
            this.PicBoxTableStatus.TabIndex = 0;
            this.PicBoxTableStatus.TabStop = false;
            // 
            // LblTableNumber
            // 
            this.LblTableNumber.AutoSize = true;
            this.LblTableNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblTableNumber.Location = new System.Drawing.Point(7, 97);
            this.LblTableNumber.Name = "LblTableNumber";
            this.LblTableNumber.Size = new System.Drawing.Size(51, 21);
            this.LblTableNumber.TabIndex = 1;
            this.LblTableNumber.Text = "label1";
            // 
            // RestaurantTableItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.LblTableNumber);
            this.Controls.Add(this.PicBoxTableStatus);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "RestaurantTableItemControl";
            this.Size = new System.Drawing.Size(120, 128);
            this.Load += new System.EventHandler(this.RestaurantTableItemControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTableStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicBoxTableStatus;
        private System.Windows.Forms.Label LblTableNumber;
    }
}
