using Main.Controllers.POSControllers.ControllerInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.POSManagementForms.Controls
{
    public partial class FrmCheckOut : Form
    {
        private readonly IPOSCommandController _iPOSCommandController;
        private readonly POSState _pOSState;

        public FrmCheckOut(IPOSCommandController iPOSCommandController, POSState pOSState)
        {
            InitializeComponent();
            _iPOSCommandController = iPOSCommandController;
            _pOSState = pOSState;
        }



        public decimal Total { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Discount { get; set; }

        public bool IsDiscountPercentage { get; set; }

        public decimal DiscountPercent { get; set; }

        public decimal CashTotal { get; set; }

        public decimal ChangeTotal { get; set; }

        public decimal DueTotal { get; set; }

        public bool IsSuccessfulCheckout { get; set; }

        private void FrmCheckOut_Load(object sender, EventArgs e)
        {
            NumUpDnCustomerCash.Focus();

            bool isContinue = true;
            if (_pOSState.CurrentSaleTransaction == null)
            {
                MessageBox.Show("Error: Current transaction is empty", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isContinue = false;
                this.Close();
            }

            if (_pOSState.CurrentSaleTransactionProducts == null && _pOSState.CurrentSaleTransactionComboMeals == null)
            {
                MessageBox.Show("No item selected", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isContinue = false;
                this.Close();
            }

            if (_pOSState.CurrentSaleTransactionProducts.Count == 0 && _pOSState.CurrentSaleTransactionComboMeals.Count == 0)
            {
                MessageBox.Show("No item selected", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isContinue = false;
                this.Close();
            }

            if (isContinue)
            {
                Total = _pOSState.SubTotal;
                SubTotal = _pOSState.SubTotal;

                var currentTrans = _pOSState.CurrentSaleTransaction;

                TboxSubTotal.Text = _pOSState.ToStringSubTotal;
                TboxTicketNum.Text = currentTrans.TicketNumber;
                TboxCustomer.Text = currentTrans.CustomerName;
                TboxTableNumber.Text = $"T-{currentTrans.TableNumber}";
                LblTotal.Text = _pOSState.ToStringSubTotal;
            }

            NumUpDownDiscountValue.Click += TextBoxOnClick;
            NumUpDnCustomerCash.Click += TextBoxOnClick;
        }

        private void TextBoxOnClick(object sender, EventArgs eventArgs)
        {
            var textBox = (NumericUpDown)sender;
            textBox.Select(0, textBox.Value.ToString().Length);
            textBox.Focus();
        }

        private void BtnCancelCheckout_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ComputeTotalWithDiscount()
        {
            IsDiscountPercentage = CBoxUsePercentageInDiscount.Checked;
            Discount = NumUpDownDiscountValue.Value;

            if (IsDiscountPercentage)
            {
                var discountPercentage = Discount / 100;

                DiscountPercent = discountPercentage;
                Discount = SubTotal * discountPercentage;
            }

            if (Discount > SubTotal)
            {
                MessageBox.Show("Invalid dicount", "Compute discount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Total = SubTotal - Discount;
            LblTotal.Text = Total.ToString("#,##0.##");
            LblDiscountTotal.Text = Discount.ToString("#,##0.##");

            CashTotal = NumUpDnCustomerCash.Value;

            decimal dueTotal = Total - CashTotal;
            decimal changeTotal = CashTotal - Total;

            DueTotal = dueTotal > 0 ? dueTotal : 0;
            ChangeTotal = changeTotal > 0 ? changeTotal : 0;

            TboxChange.Text = ChangeTotal.ToString("#,##0.##");
            TboxDue.Text =  DueTotal.ToString("#,##0.##");
        }

        private void NumUpDownDiscountValue_KeyUp(object sender, KeyEventArgs e)
        {
            ComputeTotalWithDiscount();
        }

        private void CBoxUsePercentageInDiscount_CheckedChanged(object sender, EventArgs e)
        {
            ComputeTotalWithDiscount();
        }

        private void NumUpDnCustomerCash_KeyUp(object sender, KeyEventArgs e)
        {
            ComputeTotalWithDiscount();
        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            if (this.CashTotal == 0 || this.DueTotal > 0)
            {
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Continue on checkout?", "Checkout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                _pOSState.CurrentSaleTransaction.SubTotalAmount = this.SubTotal;
                _pOSState.CurrentSaleTransaction.DiscountAmount = this.Discount;
                _pOSState.CurrentSaleTransaction.DiscountIsPercentage = this.IsDiscountPercentage;
                _pOSState.CurrentSaleTransaction.DiscountPercent = this.DiscountPercent;
                _pOSState.CurrentSaleTransaction.TotalAmount = this.Total;
                _pOSState.CurrentSaleTransaction.CustomerCashAmount = this.CashTotal;
                _pOSState.CurrentSaleTransaction.CustomerChangeAmount = this.ChangeTotal;
                _pOSState.CurrentSaleTransaction.CustomerDueAmount = this.DueTotal;

                var checkoutResults = _iPOSCommandController.Checkout(_pOSState.CurrentSaleTransaction);

                string resMsg = "";
                foreach (var msg in checkoutResults.Messages)
                {
                    resMsg += msg;
                }

                if (checkoutResults.IsSuccess)
                {
                    MessageBox.Show(resMsg, "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.IsSuccessfulCheckout = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(resMsg, "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.IsSuccessfulCheckout = false;
                }
            }
        }
    }
}
