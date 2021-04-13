using EntitiesShared.POSManagement;
using EntitiesShared.POSManagement.CustomModels;
using Main.Controllers.POSControllers.ControllerInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.POSManagementForms.Controls
{
    public partial class POSControllerControl : UserControl
    {
        private readonly IPOSCommandController _iPOSCommandController;
        private readonly IPOSReadController _pOSReadController;
        private readonly POSState _pOSState;

        public POSControllerControl(IPOSCommandController iPOSCommandController, IPOSReadController pOSReadController, POSState pOSState)
        {
            InitializeComponent();
            _iPOSCommandController = iPOSCommandController;
            _pOSReadController = pOSReadController;
            _pOSState = pOSState;
        }



        private List<SaleTransactionModel> _activedineInTransactions;

        public List<SaleTransactionModel> ActiveDineInTransactions
        {
            get { return _activedineInTransactions; }
            set { _activedineInTransactions = value; }
        }


        private void POSCheckOutControllerControl_Load(object sender, EventArgs e)
        {
            SetDGVActiveDineInTransactionsFontAndColors();

            _pOSState.PropertyChanged += HandleOnCurrentSaleTransactionChanged;
        }

        public void HandleOnCurrentSaleTransactionChanged(object sender, PropertyChangedEventArgs e)
        {
            DisplayCurrentSaleTransaction();
            this.TabControlMain.SelectedIndex = this.TabControlMain.TabPages.IndexOf(TabPageCheckout);
        }

        private void DisplayCurrentSaleTransaction()
        {
            this.ClearCheckOutForm();
            if (_pOSState.CurrentSaleTransaction != null)
            {
                this.TboxNumberOfItems.Text = "";
                this.TboxTicketNumber.Text = _pOSState.CurrentSaleTransaction.TicketNumber;
                this.TboxCustomerName.Text = _pOSState.CurrentSaleTransaction.CustomerName;
                this.TboxTableNumber.Text = _pOSState.CurrentSaleTransaction.TableNumber.ToString();
            }
        }

        private void ClearCheckOutForm()
        {
            this.TboxNumberOfItems.Text = "";
            this.TboxTicketNumber.Text = "";
            this.TboxCustomerName.Text = "";
            this.TboxTableNumber.Text = "";
        }

        private void SetDGVActiveDineInTransactionsFontAndColors()
        {
            this.DGVActiveDineInTransactions.BackgroundColor = Color.White;
            this.DGVActiveDineInTransactions.DefaultCellStyle.Font = new Font("Century Gothic", 11);
            this.DGVActiveDineInTransactions.RowHeadersVisible = false;
            this.DGVActiveDineInTransactions.RowTemplate.Height = 35;
            this.DGVActiveDineInTransactions.RowTemplate.Resizable = DataGridViewTriState.True;
            this.DGVActiveDineInTransactions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVActiveDineInTransactions.AllowUserToResizeRows = false;
            this.DGVActiveDineInTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVActiveDineInTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 11);
            this.DGVActiveDineInTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVActiveDineInTransactions.MultiSelect = false;
        }

        private void BtnNewTransaction_Click(object sender, EventArgs e)
        {
            if (_pOSState.CurrentSaleTransaction != null)
            {
                MessageBox.Show("Please save current transaction before creating new.", "Creating new transaction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenFrmNewTransaction();
        }

        public void OpenFrmNewTransaction()
        {
            _pOSState.CurrentSaleTransactionProducts = new List<SaleTransactionProductModel>();
            _pOSState.CurrentSaleTransactionComboMeals = new List<SaleTransactionComboMealModel>();

            var tableStatuses = _pOSReadController.GetTableStatus();
            FrmNewTransaction frmNewTransaction = new(_iPOSCommandController, tableStatuses);
            frmNewTransaction.ShowDialog();

            bool isCancelled = frmNewTransaction.IsCancelled;
            bool isInitiateSuccessful = frmNewTransaction.IsInitiateSuccessful;

            if (isCancelled == false && isInitiateSuccessful == true)
            {
                _pOSState.Transaction = POSStateTransaction.New;
                _pOSState.CurrentSaleTransaction = frmNewTransaction.NewSalesTransaction;
            }
        }

        private void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControlMain.SelectedTab == TabControlMain.TabPages[1])
            {
                var activeDineInTransactions = _pOSReadController.GetActiveDineInSalesTransaction();
                this.DisplayActiveDineInTransactions(activeDineInTransactions);
            }
        }

        private void DisplayActiveDineInTransactions(List<SaleTransactionModel> dineInSalesTransactions)
        {
            ActiveDineInTransactions = dineInSalesTransactions;

            this.DGVActiveDineInTransactions.Rows.Clear();
            if (dineInSalesTransactions != null)
            {
                this.DGVActiveDineInTransactions.ColumnCount = 4;

                this.DGVActiveDineInTransactions.Columns[0].Name = "TransactionId";
                this.DGVActiveDineInTransactions.Columns[0].Visible = false;

                this.DGVActiveDineInTransactions.Columns[1].Name = "TicketNumber";
                this.DGVActiveDineInTransactions.Columns[1].HeaderText = "Ticket";

                this.DGVActiveDineInTransactions.Columns[2].Name = "CustomerName";
                this.DGVActiveDineInTransactions.Columns[2].HeaderText = "Customer";

                this.DGVActiveDineInTransactions.Columns[3].Name = "TableNumber";
                this.DGVActiveDineInTransactions.Columns[3].HeaderText = "Table";

                DataGridViewImageColumn btnViewDetailsImg = new DataGridViewImageColumn();
                btnViewDetailsImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnViewDetailsImg.Image = Image.FromFile("./Resources/view-details-24.png");
                this.DGVActiveDineInTransactions.Columns.Add(btnViewDetailsImg);

                foreach(var tran in dineInSalesTransactions)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGVActiveDineInTransactions);

                    row.Cells[0].Value = tran.Id;
                    row.Cells[1].Value = tran.TicketNumber;
                    row.Cells[2].Value = tran.CustomerName;
                    row.Cells[3].Value = $"T-{tran.TableNumber}";

                    DGVActiveDineInTransactions.Rows.Add(row);
                }
            }
        }


        public event EventHandler CheckOutDineInTransaction;
        protected virtual void OnCheckOutDineInTransaction(EventArgs e)
        {
            CheckOutDineInTransaction?.Invoke(this, e);
        }


        private void DGVActiveDineInTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // view details button
            if ((e.ColumnIndex == 4) && e.RowIndex > -1)
            {
                if (DGVActiveDineInTransactions.CurrentRow != null && this.ActiveDineInTransactions != null)
                {
                    long selectedDineInTransactionId = long.Parse(DGVActiveDineInTransactions.CurrentRow.Cells[0].Value.ToString());

                    this.DisplayOrderDetailsOfSelectedDineInTransaction(selectedDineInTransactionId);
                }
            }
        }

        private void DisplayOrderDetailsOfSelectedDineInTransaction(long selectedDineInTransactionId)
        {
            var selectedDineInTransaction = this.ActiveDineInTransactions.Where(x => x.Id == selectedDineInTransactionId).FirstOrDefault();

            if (_pOSState.CurrentSaleTransaction != null && selectedDineInTransaction != _pOSState.CurrentSaleTransaction)
            {
                // TODO: ask the user if need to save current transaction
            }

            _pOSState.Transaction = POSStateTransaction.Existing;
            _pOSState.CurrentSaleTransactionProducts = new List<SaleTransactionProductModel>();
            _pOSState.CurrentSaleTransactionComboMeals = new List<SaleTransactionComboMealModel>();
            _pOSState.CurrentSaleTransaction = selectedDineInTransaction;
        }

        private void BtnCancelCurrentTransaction_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Continue to cancel current transaction?", "Cancel current transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                _pOSState.Transaction = POSStateTransaction.Existing;
                _pOSState.CurrentSaleTransactionProducts = new List<SaleTransactionProductModel>();
                _pOSState.CurrentSaleTransactionComboMeals = new List<SaleTransactionComboMealModel>();
                _pOSState.CurrentSaleTransaction = null;


                // TODO: revert all deduction in inventory
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
