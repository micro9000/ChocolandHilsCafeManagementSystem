
namespace Main
{
    partial class HomeControl
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
            this.LblGreetings = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblGreetings
            // 
            this.LblGreetings.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblGreetings.Location = new System.Drawing.Point(0, 0);
            this.LblGreetings.Name = "LblGreetings";
            this.LblGreetings.Size = new System.Drawing.Size(190, 30);
            this.LblGreetings.TabIndex = 0;
            this.LblGreetings.Text = "Wecome back!";
            // 
            // HomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LblGreetings);
            this.Name = "HomeControl";
            this.Size = new System.Drawing.Size(170, 28);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblGreetings;
    }
}
