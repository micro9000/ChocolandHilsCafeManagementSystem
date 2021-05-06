using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.EmployeeManagementForms.Controls
{
    public partial class EmployeeBenefitsAndDeductions : UserControl
    {
        public EmployeeBenefitsAndDeductions()
        {
            InitializeComponent();
        }

        private void EmployeeBenefitsAndDeductions_Load(object sender, EventArgs e)
        {
            this.DGVEmployeeBenefits.BackgroundColor = Color.White;
            this.DGVEmployeeBenefits.DefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVEmployeeBenefits.RowHeadersVisible = false;
            this.DGVEmployeeBenefits.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVEmployeeBenefits.AllowUserToResizeRows = false;
            this.DGVEmployeeBenefits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVEmployeeBenefits.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVEmployeeBenefits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVEmployeeBenefits.MultiSelect = false;
            this.DGVEmployeeBenefits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVEmployeeBenefits.ColumnHeadersHeight = 30;

            DisplayBenefitsInDGV();

            this.DGVEmployeeDeductions.BackgroundColor = Color.White;
            this.DGVEmployeeDeductions.DefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVEmployeeDeductions.RowHeadersVisible = false;
            this.DGVEmployeeDeductions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVEmployeeDeductions.AllowUserToResizeRows = false;
            this.DGVEmployeeDeductions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVEmployeeDeductions.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVEmployeeDeductions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVEmployeeDeductions.MultiSelect = false;
            this.DGVEmployeeDeductions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVEmployeeDeductions.ColumnHeadersHeight = 30;

            DisplayDeductionsInDGV();

        }


        private List<EmployeeBenefitModel> benefits;

        public List<EmployeeBenefitModel> Benefits
        {
            get { return benefits; }
            set { benefits = value; }
        }


        private List<EmployeeDeductionModel> deductions;

        public List<EmployeeDeductionModel> Deductions
        {
            get { return deductions; }
            set { deductions = value; }
        }




        private EmployeeBenefitModel benefitToSave;

        public EmployeeBenefitModel BenefitToSave
        {
            get { return benefitToSave; }
            set { benefitToSave = value; }
        }

        private EmployeeDeductionModel deductionModel;

        public EmployeeDeductionModel DeductionToSave
        {
            get { return deductionModel; }
            set { deductionModel = value; }
        }

        public bool BenefitIsSaveNew { get; set; } = true;
        public bool DeductionIsSaveNew { get; set; } = true;

        public event EventHandler SaveBenefit;
        protected virtual void OnSaveBenefit(EventArgs e)
        {
            SaveBenefit?.Invoke(this, e);
        }

        public event EventHandler SaveDeduction;
        protected virtual void OnSaveDeduction(EventArgs e)
        {
            SaveDeduction?.Invoke(this, e);
        }


        public void ResetBenefitForm()
        {
            this.BenefitIsSaveNew = true;
            this.TbxBenefitTitle.Text = "";
            this.NumUpDwnBenefitAmount.Value = 0;
            BtnCancelBenefitUpdate.Visible = false;
        }

        public void ResetDeductionForm()
        {
            this.DeductionIsSaveNew = true;
            this.TBoxDeductionTitle.Text = "";
            this.NumUpDwnDeductionAmount.Value = 0;
            BtnCancelUpdateEmpDeduction.Visible = false;
        }

        private void BtnSaveBenefits_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.TbxBenefitTitle.Text))
            {
                MessageBox.Show("Enter benefit title", "Save benefit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.NumUpDwnBenefitAmount.Value <= 0)
            {
                MessageBox.Show("Enter benefit amount", "Save benefit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.BenefitIsSaveNew == false && BenefitToSave != null)
            {
                if (this.Benefits != null)
                {
                    var existingBenefit = this.Benefits
                                                .Where(x => x.BenefitTitle.ToLower() == this.TbxBenefitTitle.Text.ToLower() && x.Id != BenefitToSave.Id)
                                                .FirstOrDefault();
                    if (existingBenefit != null)
                    {
                        MessageBox.Show("Duplicate benefit!", "Save benefit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                BenefitToSave.BenefitTitle = this.TbxBenefitTitle.Text;
                BenefitToSave.Amount = this.NumUpDwnBenefitAmount.Value;
            }
            else
            {
                if (this.Benefits != null)
                {
                    var existingBenefit = this.Benefits
                                                .Where(x => x.BenefitTitle.ToLower() == this.TbxBenefitTitle.Text.ToLower())
                                                .FirstOrDefault();
                    if (existingBenefit != null)
                    {
                        MessageBox.Show("Duplicate benefit!", "Save benefit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                BenefitToSave = new EmployeeBenefitModel
                {
                    BenefitTitle = this.TbxBenefitTitle.Text,
                    Amount = this.NumUpDwnBenefitAmount.Value
                };
            }

            OnSaveBenefit(EventArgs.Empty);
        }


        public void DisplayBenefitsInDGV()
        {
            this.DGVEmployeeBenefits.Rows.Clear();
            if (this.Benefits != null)
            {
                this.DGVEmployeeBenefits.ColumnCount = 3;

                this.DGVEmployeeBenefits.Columns[0].Name = "benefitId";
                this.DGVEmployeeBenefits.Columns[0].Visible = false;

                this.DGVEmployeeBenefits.Columns[1].Name = "BenefitTitle";
                this.DGVEmployeeBenefits.Columns[1].HeaderText = "Title";

                this.DGVEmployeeBenefits.Columns[2].Name = "BenefitAmount";
                this.DGVEmployeeBenefits.Columns[2].HeaderText = "Default amount";

                // Update button
                DataGridViewImageColumn btnUpdateLeaveTypeImg = new DataGridViewImageColumn();
                //btnUpdateLeaveTypeImg.Name = "";
                btnUpdateLeaveTypeImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnUpdateLeaveTypeImg.Image = Image.FromFile("./Resources/edit-24.png");
                this.DGVEmployeeBenefits.Columns.Add(btnUpdateLeaveTypeImg);

                // Delete button
                DataGridViewImageColumn btnDeleteLeaveTypeImg = new DataGridViewImageColumn();
                //btnDeleteLeaveTypeImg.Name = "";
                btnDeleteLeaveTypeImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnDeleteLeaveTypeImg.Image = Image.FromFile("./Resources/remove-24.png");
                this.DGVEmployeeBenefits.Columns.Add(btnDeleteLeaveTypeImg);

                foreach(var benefit in this.Benefits)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGVEmployeeBenefits);

                    row.Cells[0].Value = benefit.Id;
                    row.Cells[1].Value = benefit.BenefitTitle;
                    row.Cells[2].Value = benefit.Amount;

                    DGVEmployeeBenefits.Rows.Add(row);
                }

            }
        }

        public void DisplayDeductionsInDGV()
        {
            this.DGVEmployeeDeductions.Rows.Clear();
            if (this.Deductions != null)
            {
                this.DGVEmployeeDeductions.ColumnCount = 3;

                this.DGVEmployeeDeductions.Columns[0].Name = "benefitId";
                this.DGVEmployeeDeductions.Columns[0].Visible = false;

                this.DGVEmployeeDeductions.Columns[1].Name = "DeductionTitle";
                this.DGVEmployeeDeductions.Columns[1].HeaderText = "Title";

                this.DGVEmployeeDeductions.Columns[2].Name = "DeductionAmount";
                this.DGVEmployeeDeductions.Columns[2].HeaderText = "Default amount";

                // Update button
                DataGridViewImageColumn btnUpdateLeaveTypeImg = new DataGridViewImageColumn();
                //btnUpdateLeaveTypeImg.Name = "";
                btnUpdateLeaveTypeImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnUpdateLeaveTypeImg.Image = Image.FromFile("./Resources/edit-24.png");
                this.DGVEmployeeDeductions.Columns.Add(btnUpdateLeaveTypeImg);

                // Delete button
                DataGridViewImageColumn btnDeleteLeaveTypeImg = new DataGridViewImageColumn();
                //btnDeleteLeaveTypeImg.Name = "";
                btnDeleteLeaveTypeImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnDeleteLeaveTypeImg.Image = Image.FromFile("./Resources/remove-24.png");
                this.DGVEmployeeDeductions.Columns.Add(btnDeleteLeaveTypeImg);

                foreach (var deduction in this.Deductions)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGVEmployeeDeductions);

                    row.Cells[0].Value = deduction.Id;
                    row.Cells[1].Value = deduction.DeductionTitle;
                    row.Cells[2].Value = deduction.Amount;

                    DGVEmployeeDeductions.Rows.Add(row);
                }

            }
        }


        public void DisplaySelectedBenefit()
        {
            if (this.BenefitToSave != null)
            {
                BtnCancelBenefitUpdate.Visible = true;
                this.BenefitIsSaveNew = false;

                this.TbxBenefitTitle.Text = this.BenefitToSave.BenefitTitle;
                this.NumUpDwnBenefitAmount.Value = this.BenefitToSave.Amount;
            }
        }


        public event EventHandler BtnUpdateBenefitClicked;
        protected virtual void OnBtnUpdateBenefitClicked(EventArgs e)
        {
            BtnUpdateBenefitClicked?.Invoke(this, e);
        }

        public event EventHandler BtnDeleteBenefitClicked;
        protected virtual void OnBtnDeleteBenefitClicked(EventArgs e)
        {
            BtnDeleteBenefitClicked?.Invoke(this, e);
        }


        private long benefitIdToDeleteOrUpdate;

        public long BenefitIdToDeleteOrUpdate
        {
            get { return benefitIdToDeleteOrUpdate; }
            set { benefitIdToDeleteOrUpdate = value; }
        }



        private void DGVEmployeeBenefits_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // update button
            if ((e.ColumnIndex == 3) && e.RowIndex > -1)
            {
                string benefitIdStr = DGVEmployeeBenefits.CurrentRow.Cells[0].Value.ToString();
                
                if (long.TryParse(benefitIdStr, out long benefitId))
                {
                    BenefitIdToDeleteOrUpdate = benefitId;
                    OnBtnUpdateBenefitClicked(EventArgs.Empty);
                }
            }

            // delete button
            if ((e.ColumnIndex == 4) && e.RowIndex > -1)
            {
                string benefitIdStr = DGVEmployeeBenefits.CurrentRow.Cells[0].Value.ToString();
                
                if (long.TryParse(benefitIdStr, out long benefitId))
                {
                    BenefitIdToDeleteOrUpdate = benefitId;
                    OnBtnDeleteBenefitClicked(EventArgs.Empty);
                }
            }
        }

        private void BtnCancelBenefitUpdate_Click(object sender, EventArgs e)
        {
            ResetBenefitForm();
        }

        private void BtnSaveEmpDeduction_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(this.TBoxDeductionTitle.Text))
            {
                MessageBox.Show("Enter deduction title", "Save deduction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.NumUpDwnDeductionAmount.Value <= 0)
            {
                MessageBox.Show("Enter deduction amount", "Save deduction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.DeductionIsSaveNew == false && DeductionToSave != null)
            {
                if (this.Deductions != null)
                {
                    var existingDeduction = this.Deductions
                                                .Where(x => x.DeductionTitle.ToLower() == this.TBoxDeductionTitle.Text.ToLower() && x.Id != DeductionToSave.Id)
                                                .FirstOrDefault();
                    if (existingDeduction != null)
                    {
                        MessageBox.Show("Duplicate deduction!", "Save deduction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                DeductionToSave.DeductionTitle = this.TBoxDeductionTitle.Text;
                DeductionToSave.Amount = this.NumUpDwnDeductionAmount.Value;
            }
            else
            {
                if (this.Deductions != null)
                {
                    var existingDeduction = this.Deductions
                                                .Where(x => x.DeductionTitle.ToLower() == this.TBoxDeductionTitle.Text.ToLower())
                                                .FirstOrDefault();
                    if (existingDeduction != null)
                    {
                        MessageBox.Show("Duplicate deduction!", "Save deduction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                DeductionToSave = new EmployeeDeductionModel
                {
                    DeductionTitle = this.TBoxDeductionTitle.Text,
                    Amount = this.NumUpDwnDeductionAmount.Value
                };
            }

            OnSaveDeduction(EventArgs.Empty);
        }

        private void BtnCancelUpdateEmpDeduction_Click(object sender, EventArgs e)
        {
            ResetDeductionForm();
        }

        public void DisplaySelectedDeduction()
        {
            if (this.DeductionToSave != null)
            {
                BtnCancelUpdateEmpDeduction.Visible = true;
                this.DeductionIsSaveNew = false;

                this.TBoxDeductionTitle.Text = this.DeductionToSave.DeductionTitle;
                this.NumUpDwnDeductionAmount.Value = this.DeductionToSave.Amount;
            }
        }


        public event EventHandler BtnUpdateDeductionClicked;
        protected virtual void OnBtnUpdateDeductionClicked(EventArgs e)
        {
            BtnUpdateDeductionClicked?.Invoke(this, e);
        }

        public event EventHandler BtnDeleteDeductionClicked;
        protected virtual void OnBtnDeleteDeductionClicked(EventArgs e)
        {
            BtnDeleteDeductionClicked?.Invoke(this, e);
        }

        private long deductionIdToDeleteOrUpdate;

        public long DeductionIdToDeleteOrUpdate
        {
            get { return deductionIdToDeleteOrUpdate; }
            set { deductionIdToDeleteOrUpdate = value; }
        }


        private void DGVEmployeeDeductions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // update button
            if ((e.ColumnIndex == 3) && e.RowIndex > -1)
            {
                string deductionIdStr = DGVEmployeeDeductions.CurrentRow.Cells[0].Value.ToString();

                if (long.TryParse(deductionIdStr, out long deductionId))
                {
                    DeductionIdToDeleteOrUpdate = deductionId;
                    OnBtnUpdateDeductionClicked(EventArgs.Empty);
                }
            }

            // delete button
            if ((e.ColumnIndex == 4) && e.RowIndex > -1)
            {
                string deductionIdStr = DGVEmployeeDeductions.CurrentRow.Cells[0].Value.ToString();

                if (long.TryParse(deductionIdStr, out long deductionId))
                {
                    DeductionIdToDeleteOrUpdate = deductionId;
                    OnBtnDeleteDeductionClicked(EventArgs.Empty);
                }
            }
        }
    }
}
