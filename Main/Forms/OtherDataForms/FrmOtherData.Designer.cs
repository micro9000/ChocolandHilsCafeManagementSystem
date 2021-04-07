
namespace Main.Forms.OtherDataForms
{
    partial class FrmOtherData
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
            this.components = new System.ComponentModel.Container();
            this.OtherMenuStrip = new System.Windows.Forms.MenuStrip();
            this.ToolStripItemGovernment = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuGovernmentItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.GovernmentAgencieToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripItemScheduleSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuScheduleSettings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripItemLeaveType = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuBranches = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuBranchesSettings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuBranchesList = new System.Windows.Forms.ToolStripMenuItem();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.OtherMenuStrip.SuspendLayout();
            this.ContextMenuGovernmentItems.SuspendLayout();
            this.ContextMenuScheduleSettings.SuspendLayout();
            this.ContextMenuBranchesSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // OtherMenuStrip
            // 
            this.OtherMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripItemGovernment,
            this.ToolStripItemScheduleSettings,
            this.ToolStripMenuBranches});
            this.OtherMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.OtherMenuStrip.Name = "OtherMenuStrip";
            this.OtherMenuStrip.Size = new System.Drawing.Size(800, 24);
            this.OtherMenuStrip.TabIndex = 0;
            this.OtherMenuStrip.Text = "menuStrip1";
            // 
            // ToolStripItemGovernment
            // 
            this.ToolStripItemGovernment.DropDown = this.ContextMenuGovernmentItems;
            this.ToolStripItemGovernment.Name = "ToolStripItemGovernment";
            this.ToolStripItemGovernment.Size = new System.Drawing.Size(85, 20);
            this.ToolStripItemGovernment.Text = "Government";
            // 
            // ContextMenuGovernmentItems
            // 
            this.ContextMenuGovernmentItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GovernmentAgencieToolStripItem});
            this.ContextMenuGovernmentItems.Name = "ContextMenuGovernmentItems";
            this.ContextMenuGovernmentItems.OwnerItem = this.ToolStripItemGovernment;
            this.ContextMenuGovernmentItems.Size = new System.Drawing.Size(123, 26);
            this.ContextMenuGovernmentItems.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ContextMenuGovernmentItems_ItemClicked);
            // 
            // GovernmentAgencieToolStripItem
            // 
            this.GovernmentAgencieToolStripItem.Name = "GovernmentAgencieToolStripItem";
            this.GovernmentAgencieToolStripItem.Size = new System.Drawing.Size(122, 22);
            this.GovernmentAgencieToolStripItem.Text = "Agencies";
            // 
            // ToolStripItemScheduleSettings
            // 
            this.ToolStripItemScheduleSettings.DropDown = this.ContextMenuScheduleSettings;
            this.ToolStripItemScheduleSettings.Name = "ToolStripItemScheduleSettings";
            this.ToolStripItemScheduleSettings.Size = new System.Drawing.Size(112, 20);
            this.ToolStripItemScheduleSettings.Text = "Schedule Settings";
            // 
            // ContextMenuScheduleSettings
            // 
            this.ContextMenuScheduleSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripItemLeaveType});
            this.ContextMenuScheduleSettings.Name = "ContextMenuScheduleSettings";
            this.ContextMenuScheduleSettings.OwnerItem = this.ToolStripItemScheduleSettings;
            this.ContextMenuScheduleSettings.Size = new System.Drawing.Size(136, 26);
            this.ContextMenuScheduleSettings.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ContextMenuScheduleSettings_ItemClicked);
            // 
            // ToolStripItemLeaveType
            // 
            this.ToolStripItemLeaveType.Name = "ToolStripItemLeaveType";
            this.ToolStripItemLeaveType.Size = new System.Drawing.Size(135, 22);
            this.ToolStripItemLeaveType.Text = "Leave types";
            // 
            // ToolStripMenuBranches
            // 
            this.ToolStripMenuBranches.DropDown = this.ContextMenuBranchesSettings;
            this.ToolStripMenuBranches.Name = "ToolStripMenuBranches";
            this.ToolStripMenuBranches.Size = new System.Drawing.Size(67, 20);
            this.ToolStripMenuBranches.Text = "Branches";
            // 
            // ContextMenuBranchesSettings
            // 
            this.ContextMenuBranchesSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuBranchesList});
            this.ContextMenuBranchesSettings.Name = "ContextMenuBranchesSettings";
            this.ContextMenuBranchesSettings.Size = new System.Drawing.Size(93, 26);
            this.ContextMenuBranchesSettings.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ContextMenuBranchesSettings_ItemClicked);
            // 
            // ToolStripMenuBranchesList
            // 
            this.ToolStripMenuBranchesList.Name = "ToolStripMenuBranchesList";
            this.ToolStripMenuBranchesList.Size = new System.Drawing.Size(92, 22);
            this.ToolStripMenuBranchesList.Text = "List";
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 24);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(800, 426);
            this.panelContainer.TabIndex = 1;
            // 
            // FrmOtherData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.OtherMenuStrip);
            this.MainMenuStrip = this.OtherMenuStrip;
            this.Name = "FrmOtherData";
            this.Text = "OtherDataForm";
            this.OtherMenuStrip.ResumeLayout(false);
            this.OtherMenuStrip.PerformLayout();
            this.ContextMenuGovernmentItems.ResumeLayout(false);
            this.ContextMenuScheduleSettings.ResumeLayout(false);
            this.ContextMenuBranchesSettings.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip OtherMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ToolStripItemGovernment;
        private System.Windows.Forms.ContextMenuStrip ContextMenuGovernmentItems;
        private System.Windows.Forms.ToolStripMenuItem GovernmentAgencieToolStripItem;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.ContextMenuStrip ContextMenuScheduleSettings;
        private System.Windows.Forms.ToolStripMenuItem ToolStripItemScheduleSettings;
        private System.Windows.Forms.ToolStripMenuItem ToolStripItemLeaveType;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuBranches;
        private System.Windows.Forms.ContextMenuStrip ContextMenuBranchesSettings;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuBranchesList;
    }
}