﻿
namespace EmployeeManagementUserControls
{
    partial class GovtAgenciesCRUDUserControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.GBoxLeaveTypeForm = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnCancelUpdate = new System.Windows.Forms.Button();
            this.TbxAgency = new System.Windows.Forms.TextBox();
            this.BtnSaveAgency = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DGVGovernmentAgencies = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.GBoxLeaveTypeForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVGovernmentAgencies)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.GBoxLeaveTypeForm);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(327, 653);
            this.panel1.TabIndex = 1;
            // 
            // GBoxLeaveTypeForm
            // 
            this.GBoxLeaveTypeForm.Controls.Add(this.label9);
            this.GBoxLeaveTypeForm.Controls.Add(this.BtnCancelUpdate);
            this.GBoxLeaveTypeForm.Controls.Add(this.TbxAgency);
            this.GBoxLeaveTypeForm.Controls.Add(this.BtnSaveAgency);
            this.GBoxLeaveTypeForm.ForeColor = System.Drawing.Color.White;
            this.GBoxLeaveTypeForm.Location = new System.Drawing.Point(11, 98);
            this.GBoxLeaveTypeForm.Name = "GBoxLeaveTypeForm";
            this.GBoxLeaveTypeForm.Size = new System.Drawing.Size(299, 221);
            this.GBoxLeaveTypeForm.TabIndex = 47;
            this.GBoxLeaveTypeForm.TabStop = false;
            this.GBoxLeaveTypeForm.Text = "Add New";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(15, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "Agency";
            // 
            // BtnCancelUpdate
            // 
            this.BtnCancelUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelUpdate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelUpdate.ForeColor = System.Drawing.Color.White;
            this.BtnCancelUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelUpdate.Location = new System.Drawing.Point(165, 113);
            this.BtnCancelUpdate.Name = "BtnCancelUpdate";
            this.BtnCancelUpdate.Size = new System.Drawing.Size(115, 47);
            this.BtnCancelUpdate.TabIndex = 46;
            this.BtnCancelUpdate.Text = "Cancel";
            this.BtnCancelUpdate.UseVisualStyleBackColor = false;
            this.BtnCancelUpdate.Visible = false;
            // 
            // TbxAgency
            // 
            this.TbxAgency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbxAgency.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbxAgency.Location = new System.Drawing.Point(15, 64);
            this.TbxAgency.Name = "TbxAgency";
            this.TbxAgency.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TbxAgency.Size = new System.Drawing.Size(265, 27);
            this.TbxAgency.TabIndex = 24;
            // 
            // BtnSaveAgency
            // 
            this.BtnSaveAgency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSaveAgency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveAgency.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveAgency.ForeColor = System.Drawing.Color.White;
            this.BtnSaveAgency.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveAgency.Location = new System.Drawing.Point(15, 113);
            this.BtnSaveAgency.Name = "BtnSaveAgency";
            this.BtnSaveAgency.Size = new System.Drawing.Size(115, 47);
            this.BtnSaveAgency.TabIndex = 2;
            this.BtnSaveAgency.Text = "Save";
            this.BtnSaveAgency.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Government agencies";
            // 
            // DGVGovernmentAgencies
            // 
            this.DGVGovernmentAgencies.AllowUserToAddRows = false;
            this.DGVGovernmentAgencies.AllowUserToDeleteRows = false;
            this.DGVGovernmentAgencies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVGovernmentAgencies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVGovernmentAgencies.Location = new System.Drawing.Point(327, 0);
            this.DGVGovernmentAgencies.Name = "DGVGovernmentAgencies";
            this.DGVGovernmentAgencies.ReadOnly = true;
            this.DGVGovernmentAgencies.RowTemplate.Height = 25;
            this.DGVGovernmentAgencies.Size = new System.Drawing.Size(583, 653);
            this.DGVGovernmentAgencies.TabIndex = 2;
            // 
            // GovtAgenciesCRUDUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DGVGovernmentAgencies);
            this.Controls.Add(this.panel1);
            this.Name = "GovtAgenciesCRUDUserControl";
            this.Size = new System.Drawing.Size(910, 653);
            this.Load += new System.EventHandler(this.GovtAgenciesCRUDUserControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.GBoxLeaveTypeForm.ResumeLayout(false);
            this.GBoxLeaveTypeForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVGovernmentAgencies)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox GBoxLeaveTypeForm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnCancelUpdate;
        private System.Windows.Forms.TextBox TbxAgency;
        private System.Windows.Forms.Button BtnSaveAgency;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DGVGovernmentAgencies;
    }
}