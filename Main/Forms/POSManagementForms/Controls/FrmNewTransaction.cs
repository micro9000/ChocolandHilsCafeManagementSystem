using EntitiesShared.POSManagement.CustomModels;
using Main.Controllers.POSControllers.ControllerInterface;
using Shared.CustomModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntitiesShared;
using EntitiesShared.POSManagement;

namespace Main.Forms.POSManagementForms.Controls
{
    public partial class FrmNewTransaction : Form
    {
        private readonly IPOSCommandController _iPOSCommandController;
        private readonly List<TableStatusModel> _tableStatuses;

        public FrmNewTransaction(IPOSCommandController iPOSCommandController, List<TableStatusModel> tableStatuses)
        {
            InitializeComponent();
            _iPOSCommandController = iPOSCommandController;
            _tableStatuses = tableStatuses;
        }

        public bool IsCancelled { get; set; }
        public bool IsInitiateSuccessful { get; set; }

        private SaleTransactionModel _newSalesTransaction;

        public SaleTransactionModel NewSalesTransaction
        {
            get { return _newSalesTransaction; }
            set { _newSalesTransaction = value; }
        }

        private void FrmNewTransaction_Load(object sender, EventArgs e)
        {
            NewSalesTransaction = null;

            this.CboxAvailableTables.Items.Clear();
            if (this._tableStatuses != null)
            {
                var availableTables = this._tableStatuses.Where(x => x.Status == StaticData.TableStatus.Available).ToList();
                ComboboxItem item;
                foreach (var table in availableTables)
                {
                    item = new ComboboxItem();
                    item.Text = table.TableTitle;
                    item.Value = table.TableNumber;
                    this.CboxAvailableTables.Items.Add(item);
                }
            }

            TboxCustomerName.Focus();
        }

        private void BtnContinueToCreateNewTrans_Click(object sender, EventArgs e)
        {
            StaticData.POSTransactionType transType = StaticData.POSTransactionType.DineIn;

            if (RBtnDineIn.Checked)
            {
                transType = StaticData.POSTransactionType.DineIn;
            }

            if (RBtnTakeOut.Checked)
            {
                transType = StaticData.POSTransactionType.TakeOut;
            }

            string customerName = string.IsNullOrEmpty(TboxCustomerName.Text) ? "NA" : TboxCustomerName.Text;

            int tableNumber = 0;
            var selectedTable = this.CboxAvailableTables.SelectedItem as ComboboxItem;
            if (selectedTable == null && transType == StaticData.POSTransactionType.DineIn)
            {
                MessageBox.Show("Kindly choose table.", "Initiate new transaction.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (selectedTable != null && transType == StaticData.POSTransactionType.DineIn)
            {
                tableNumber = int.Parse(selectedTable.Value.ToString());
            }

            var newTrans = new SaleTransactionModel
            {
                TransactionType = transType,
                CustomerName = customerName,
                TableNumber = tableNumber
            };

            var initiateResult = _iPOSCommandController.InitiateNewTransaction(newTrans);

            string resultMessages = "";
            foreach (var msg in initiateResult.Messages)
            {
                resultMessages += msg + "\n";
            }

            if (initiateResult.IsSuccess == false)
            {
                MessageBox.Show(resultMessages, $"Initiate {transType}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            NewSalesTransaction = initiateResult.Data;

            this.IsCancelled = false;
            this.IsInitiateSuccessful = true;
            this.Close();
        }

        private void BtnCancelCreateNewTrans_Click(object sender, EventArgs e)
        {
            this.NewSalesTransaction = null;
            this.IsCancelled = true;
            this.IsInitiateSuccessful = false;
            this.Close();
        }
    }
}
