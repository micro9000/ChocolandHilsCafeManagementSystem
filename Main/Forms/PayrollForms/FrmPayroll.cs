using DataAccess.Data.EmployeeManagement.Contracts;
using Main.Controllers.EmployeeManagementControllers.ControllerInterface;
using Main.Forms.PayrollForms.Controls;
using Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.PayrollForms
{
    public partial class FrmPayroll : Form
    {
        private readonly IEmployeeAttendanceData _employeeAttendanceData;
        private readonly IEmployeeLeaveData _employeeLeaveData;
        private readonly IEmployeeController _employeeController;
        private readonly DecimalMinutesToHrsConverter _decimalMinutesToHrsConverter;

        public FrmPayroll(IEmployeeAttendanceData employeeAttendanceData, 
                           IEmployeeLeaveData employeeLeaveData,
                           IEmployeeController employeeController,
                           DecimalMinutesToHrsConverter decimalMinutesToHrsConverter)
        {
            InitializeComponent();
            _employeeAttendanceData = employeeAttendanceData;
            _employeeLeaveData = employeeLeaveData;
            _employeeController = employeeController;
            _decimalMinutesToHrsConverter = decimalMinutesToHrsConverter;
        }

        private void CMStripPayroll_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;

            if (clickedItem != null && clickedItem.Name == "TStripMenuItemGenerate")
            {
                DisplayGeneratePayrollControl();
            }
        }

        public void DisplayGeneratePayrollControl()
        {
            this.panelContainer.Controls.Clear();
            var controlToDisplay = new GeneratePayrollControl(_decimalMinutesToHrsConverter);
            controlToDisplay.Location = new Point(this.ClientSize.Width / 2 - controlToDisplay.Size.Width / 2, this.ClientSize.Height / 2 - controlToDisplay.Size.Height / 2);
            controlToDisplay.Anchor = AnchorStyles.None;

            controlToDisplay.InitiatePayrollGeneration += HandleInitiatePayrollGeneration;

            this.panelContainer.Controls.Add(controlToDisplay);
        }

        private void HandleInitiatePayrollGeneration(object sender, EventArgs e)
        {
            GeneratePayrollControl generatePayrollControlObj = (GeneratePayrollControl)sender;

            var paydate = generatePayrollControlObj.PayDate;
            var shiftStartDate = generatePayrollControlObj.ShiftStartDate;
            var shiftEndDate = generatePayrollControlObj.ShiftEndDate;

            generatePayrollControlObj.Employees = _employeeController.GetAll().Data;
            generatePayrollControlObj.AttendanceHistory = _employeeAttendanceData.GetAllAttendanceRecordByWorkDateRange(shiftStartDate, shiftEndDate);
            generatePayrollControlObj.EmployeeLeaveHistory = _employeeLeaveData.GetAllByDateRange(shiftStartDate.Year, shiftStartDate, shiftEndDate);
            generatePayrollControlObj.DisplayEmployeeWithAttendanceRecordAndSalary();

            MessageBox.Show(paydate.ToString());

        }
    }
}
