using DataAccess.Data.EmployeeManagement.Contracts;
using Main.Controllers.RequestControllers.ControllerInterface;
using Main.Forms.RequestsForm.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.RequestsForm
{
    public partial class FrmEmployeeRequests : Form
    {
        private readonly Sessions _sessions;
        private readonly IEmployeeData _employeeData;
        private readonly IEmployeeCashAdvanceRequestController _employeeCashAdvanceRequestController;

        public FrmEmployeeRequests(Sessions sessions,
                                    IEmployeeData employeeData,
                                    IEmployeeCashAdvanceRequestController employeeCashAdvanceRequestController)
        {
            InitializeComponent();
            _sessions = sessions;
            _employeeData = employeeData;
            _employeeCashAdvanceRequestController = employeeCashAdvanceRequestController;
        }

        private void CMenuCashAdvance_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;

            if (clickedItem != null && clickedItem.Name == "RequestCashAdvanceMenuItem")
            {
                DisplayRequestCashAdvanceFormControl();
            }
            else if (clickedItem != null && clickedItem.Name == "CashAdvanceApprovalMenuItem")
            {
            }
        }

        public void DisplayRequestCashAdvanceFormControl()
        {
            this.RequestsMainPanel.Controls.Clear();
            var requestControlObj = new RequestCashAdvanceFormControl(_sessions);
            requestControlObj.Location = new Point(this.ClientSize.Width / 2 - requestControlObj.Size.Width / 2, this.ClientSize.Height / 2 - requestControlObj.Size.Height / 2);
            requestControlObj.Anchor = AnchorStyles.None;

            requestControlObj.CashAdvanceSave += HandleSaveCashAdvanceRequest;
            requestControlObj.EnterEmployeeNumber += HandleOnEnterEmployeeNumber;
            requestControlObj.CancelRequest += HandleDeleteCashAdvanceRequest;

            string currEmpNumber = _sessions.CurrentLoggedInUser.UserName;

            requestControlObj.CurrentEmployeeNumber = currEmpNumber;
            requestControlObj.CurrentEmployeeDetails = _employeeData.GetByEmployeeNumber(currEmpNumber);
            requestControlObj.PreviousCashAdvanceRequests = _employeeCashAdvanceRequestController.GetAllByEmployee(currEmpNumber);

            this.RequestsMainPanel.Controls.Add(requestControlObj);
        }

        private void HandleOnEnterEmployeeNumber(object sender, EventArgs e)
        {
            RequestCashAdvanceFormControl requestControlObj = (RequestCashAdvanceFormControl)sender;

            requestControlObj.ResetForm();
            requestControlObj.CurrentEmployeeDetails = _employeeData.GetByEmployeeNumber(requestControlObj.CurrentEmployeeNumber);
            requestControlObj.PreviousCashAdvanceRequests = _employeeCashAdvanceRequestController.GetAllByEmployee(requestControlObj.CurrentEmployeeNumber);
            requestControlObj.DisplayPreviousCashAdvanceRequests();
            requestControlObj.DisplayEmployeeDetails();
        }

        private void HandleSaveCashAdvanceRequest(object sender, EventArgs e)
        {
            RequestCashAdvanceFormControl requestControlObj = (RequestCashAdvanceFormControl)sender;

            var requestDetails = requestControlObj.CashAdvanceRequestToAddUpdate;
            var isNew = requestControlObj.IsSaveNew;

            var saveResults = _employeeCashAdvanceRequestController.Save(requestDetails, isNew);
            string resultMessages = "";
            foreach (var msg in saveResults.Messages)
            {
                resultMessages += msg + "\n";
            }

            if (saveResults.IsSuccess)
            {
                MessageBox.Show(resultMessages, "Submit request details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                requestControlObj.ResetForm();
                requestControlObj.PreviousCashAdvanceRequests = _employeeCashAdvanceRequestController.GetAllByEmployee(requestControlObj.CurrentEmployeeNumber);
                requestControlObj.DisplayPreviousCashAdvanceRequests();
            }
            else
            {
                MessageBox.Show(resultMessages, "Submit request details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HandleDeleteCashAdvanceRequest(object sender, EventArgs e)
        {
            RequestCashAdvanceFormControl requestControlObj = (RequestCashAdvanceFormControl)sender;
            long requestId = requestControlObj.SelectedRequestIdToDelete;

            DialogResult res = MessageBox.Show("Are you sure, you want to cancel this request?", "Cancel confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                var deleteResults = _employeeCashAdvanceRequestController.CancelRequest(requestId);
                string resultMessages = "";
                foreach (var msg in deleteResults.Messages)
                {
                    resultMessages += msg + "\n";
                }

                if (deleteResults.IsSuccess)
                {
                    MessageBox.Show(resultMessages, "Cancel request", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    requestControlObj.ResetForm();
                    requestControlObj.PreviousCashAdvanceRequests = _employeeCashAdvanceRequestController.GetAllByEmployee(requestControlObj.CurrentEmployeeNumber);
                    requestControlObj.DisplayPreviousCashAdvanceRequests();
                }
                else
                {
                    MessageBox.Show(resultMessages, "Cancel request", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }
    }
}
