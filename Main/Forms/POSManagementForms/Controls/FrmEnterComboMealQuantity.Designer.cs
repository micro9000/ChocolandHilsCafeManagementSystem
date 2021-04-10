
namespace Main.Forms.POSManagementForms.Controls
{
    partial class FrmEnterComboMealQuantity
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
            this.label2 = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.NumUpDownOrderQty = new System.Windows.Forms.NumericUpDown();
            this.LblComboMealPrice = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblComboMealName = new System.Windows.Forms.Label();
            this.PicBoxComboMealImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDownOrderQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxComboMealImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(38, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 37);
            this.label2.TabIndex = 71;
            this.label2.Text = "Quantity";
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancel.Location = new System.Drawing.Point(249, 215);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(103, 44);
            this.BtnCancel.TabIndex = 70;
            this.BtnCancel.Text = "CANCEL";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // NumUpDownOrderQty
            // 
            this.NumUpDownOrderQty.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.NumUpDownOrderQty.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumUpDownOrderQty.Location = new System.Drawing.Point(163, 158);
            this.NumUpDownOrderQty.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumUpDownOrderQty.Name = "NumUpDownOrderQty";
            this.NumUpDownOrderQty.Size = new System.Drawing.Size(189, 43);
            this.NumUpDownOrderQty.TabIndex = 69;
            this.NumUpDownOrderQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUpDownOrderQty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NumUpDownOrderQty_KeyUp);
            // 
            // LblComboMealPrice
            // 
            this.LblComboMealPrice.AutoSize = true;
            this.LblComboMealPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblComboMealPrice.Location = new System.Drawing.Point(216, 90);
            this.LblComboMealPrice.Name = "LblComboMealPrice";
            this.LblComboMealPrice.Size = new System.Drawing.Size(19, 21);
            this.LblComboMealPrice.TabIndex = 68;
            this.LblComboMealPrice.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(149, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 67;
            this.label1.Text = "Price:";
            // 
            // LblComboMealName
            // 
            this.LblComboMealName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblComboMealName.Location = new System.Drawing.Point(149, 31);
            this.LblComboMealName.Name = "LblComboMealName";
            this.LblComboMealName.Size = new System.Drawing.Size(221, 59);
            this.LblComboMealName.TabIndex = 66;
            this.LblComboMealName.Text = "Combo meal title";
            // 
            // PicBoxComboMealImage
            // 
            this.PicBoxComboMealImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicBoxComboMealImage.Location = new System.Drawing.Point(33, 31);
            this.PicBoxComboMealImage.Name = "PicBoxComboMealImage";
            this.PicBoxComboMealImage.Padding = new System.Windows.Forms.Padding(3);
            this.PicBoxComboMealImage.Size = new System.Drawing.Size(110, 110);
            this.PicBoxComboMealImage.TabIndex = 65;
            this.PicBoxComboMealImage.TabStop = false;
            // 
            // FrmEnterComboMealQuantity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(162)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(394, 275);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.NumUpDownOrderQty);
            this.Controls.Add(this.LblComboMealPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblComboMealName);
            this.Controls.Add(this.PicBoxComboMealImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmEnterComboMealQuantity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEnterComboMealQuantity";
            this.Load += new System.EventHandler(this.FrmEnterComboMealQuantity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDownOrderQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxComboMealImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.NumericUpDown NumUpDownOrderQty;
        private System.Windows.Forms.Label LblComboMealPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblComboMealName;
        private System.Windows.Forms.PictureBox PicBoxComboMealImage;
    }
}