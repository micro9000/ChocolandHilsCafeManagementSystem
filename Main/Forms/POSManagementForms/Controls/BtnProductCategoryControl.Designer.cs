
namespace Main.Forms.POSManagementForms.Controls
{
    partial class BtnProductCategoryControl
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
            this.LblCategoryName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblCategoryName
            // 
            this.LblCategoryName.AutoSize = true;
            this.LblCategoryName.BackColor = System.Drawing.Color.Transparent;
            this.LblCategoryName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblCategoryName.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblCategoryName.ForeColor = System.Drawing.Color.White;
            this.LblCategoryName.Location = new System.Drawing.Point(13, 18);
            this.LblCategoryName.Name = "LblCategoryName";
            this.LblCategoryName.Padding = new System.Windows.Forms.Padding(2);
            this.LblCategoryName.Size = new System.Drawing.Size(52, 24);
            this.LblCategoryName.TabIndex = 0;
            this.LblCategoryName.Text = "label1";
            this.LblCategoryName.Click += new System.EventHandler(this.LblCategoryName_Click);
            // 
            // BtnProductCategoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.LblCategoryName);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Name = "BtnProductCategoryControl";
            this.Size = new System.Drawing.Size(170, 68);
            this.Load += new System.EventHandler(this.BtnProductCategoryControl_Load);
            this.Click += new System.EventHandler(this.BtnProductCategoryControl_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblCategoryName;
    }
}
