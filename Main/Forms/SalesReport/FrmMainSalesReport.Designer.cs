
namespace Main.Forms.SalesReport
{
    partial class FrmMainSalesReport
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
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabSalesReport = new System.Windows.Forms.TabPage();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerRightSide = new System.Windows.Forms.SplitContainer();
            this.TabProductIngredients = new System.Windows.Forms.TabPage();
            this.splitContainerLeftSide = new System.Windows.Forms.SplitContainer();
            this.tabControl1.SuspendLayout();
            this.TabSalesReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRightSide)).BeginInit();
            this.splitContainerRightSide.Panel1.SuspendLayout();
            this.splitContainerRightSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeftSide)).BeginInit();
            this.splitContainerLeftSide.SuspendLayout();
            this.SuspendLayout();
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartesianChart1.Location = new System.Drawing.Point(0, 0);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(504, 300);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabSalesReport);
            this.tabControl1.Controls.Add(this.TabProductIngredients);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1022, 631);
            this.tabControl1.TabIndex = 1;
            // 
            // TabSalesReport
            // 
            this.TabSalesReport.Controls.Add(this.splitContainerMain);
            this.TabSalesReport.Location = new System.Drawing.Point(4, 30);
            this.TabSalesReport.Name = "TabSalesReport";
            this.TabSalesReport.Padding = new System.Windows.Forms.Padding(3);
            this.TabSalesReport.Size = new System.Drawing.Size(1014, 597);
            this.TabSalesReport.TabIndex = 0;
            this.TabSalesReport.Text = "Sales";
            this.TabSalesReport.UseVisualStyleBackColor = true;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(3, 3);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainerLeftSide);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainerRightSide);
            this.splitContainerMain.Size = new System.Drawing.Size(1008, 591);
            this.splitContainerMain.SplitterDistance = 500;
            this.splitContainerMain.TabIndex = 1;
            // 
            // splitContainerRightSide
            // 
            this.splitContainerRightSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerRightSide.Location = new System.Drawing.Point(0, 0);
            this.splitContainerRightSide.Name = "splitContainerRightSide";
            this.splitContainerRightSide.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerRightSide.Panel1
            // 
            this.splitContainerRightSide.Panel1.Controls.Add(this.cartesianChart1);
            this.splitContainerRightSide.Size = new System.Drawing.Size(504, 591);
            this.splitContainerRightSide.SplitterDistance = 300;
            this.splitContainerRightSide.TabIndex = 0;
            // 
            // TabProductIngredients
            // 
            this.TabProductIngredients.Location = new System.Drawing.Point(4, 30);
            this.TabProductIngredients.Name = "TabProductIngredients";
            this.TabProductIngredients.Padding = new System.Windows.Forms.Padding(3);
            this.TabProductIngredients.Size = new System.Drawing.Size(1014, 597);
            this.TabProductIngredients.TabIndex = 1;
            this.TabProductIngredients.Text = "Products";
            this.TabProductIngredients.UseVisualStyleBackColor = true;
            // 
            // splitContainerLeftSide
            // 
            this.splitContainerLeftSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLeftSide.Location = new System.Drawing.Point(0, 0);
            this.splitContainerLeftSide.Name = "splitContainerLeftSide";
            this.splitContainerLeftSide.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainerLeftSide.Size = new System.Drawing.Size(500, 591);
            this.splitContainerLeftSide.SplitterDistance = 150;
            this.splitContainerLeftSide.TabIndex = 0;
            // 
            // FrmMainSalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 631);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmMainSalesReport";
            this.Text = "Sales report";
            this.tabControl1.ResumeLayout(false);
            this.TabSalesReport.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerRightSide.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRightSide)).EndInit();
            this.splitContainerRightSide.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeftSide)).EndInit();
            this.splitContainerLeftSide.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabSalesReport;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerRightSide;
        private System.Windows.Forms.TabPage TabProductIngredients;
        private System.Windows.Forms.SplitContainer splitContainerLeftSide;
    }
}