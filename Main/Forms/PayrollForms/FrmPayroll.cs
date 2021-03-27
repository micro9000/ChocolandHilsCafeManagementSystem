using DataAccess.Data.EmployeeManagement.Contracts;
using DataAccess.Data.OtherDataManagement.Contracts;
using DataAccess.Data.PayrollManagement.Contracts;
using EntitiesShared.PayrollManagement;
using Main.Controllers.EmployeeManagementControllers.ControllerInterface;
using Main.Forms.PayrollForms.Controls;
using Main.Reports;
using Microsoft.Extensions.Logging;
using Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace Main.Forms.PayrollForms
{
    public partial class FrmPayroll : Form
    {
        private readonly ILogger<FrmPayroll> _logger;
        private readonly IEmployeeData _employeeData;
        private readonly IEmployeeAttendanceData _employeeAttendanceData;
        private readonly IEmployeeLeaveData _employeeLeaveData;
        private readonly IEmployeeController _employeeController;
        private readonly IGovernmentAgencyData _governmentAgencyData;
        private readonly IEmployeeGovtIdCardData _employeeGovtIdCardData;
        private readonly IEmployeeBenefitData _employeeBenefitData;
        private readonly IEmployeeDeductionData _employeeDeductionData;
        private readonly IEmployeePayslipData _employeePayslipData;
        private readonly IEmployeePayslipBenefitData _employeePayslipBenefitData;
        private readonly IEmployeePayslipDeductionData _employeePayslipDeductionData;
        private readonly DecimalMinutesToHrsConverter _decimalMinutesToHrsConverter;
        private readonly IEmployeePayslipPDFReport _employeePayslipPDFReport;

        public FrmPayroll(ILogger<FrmPayroll> logger,
                            IEmployeeData employeeData,
                            IEmployeeAttendanceData employeeAttendanceData, 
                           IEmployeeLeaveData employeeLeaveData,
                           IEmployeeController employeeController,
                           IGovernmentAgencyData governmentAgencyData,
                           IEmployeeGovtIdCardData employeeGovtIdCardData,
                           IEmployeeBenefitData employeeBenefitData,
                           IEmployeeDeductionData employeeDeductionData,
                           IEmployeePayslipData employeePayslipData,
                           IEmployeePayslipBenefitData employeePayslipBenefitData,
                           IEmployeePayslipDeductionData employeePayslipDeductionData,
                           DecimalMinutesToHrsConverter decimalMinutesToHrsConverter,
                           IEmployeePayslipPDFReport employeePayslipPDFReport)
        {
            InitializeComponent();
            _logger = logger;
            _employeeData = employeeData;
            _employeeAttendanceData = employeeAttendanceData;
            _employeeLeaveData = employeeLeaveData;
            _employeeController = employeeController;
            _governmentAgencyData = governmentAgencyData;
            _employeeGovtIdCardData = employeeGovtIdCardData;
            _employeeBenefitData = employeeBenefitData;
            _employeeDeductionData = employeeDeductionData;
            _employeePayslipData = employeePayslipData;
            _employeePayslipBenefitData = employeePayslipBenefitData;
            _employeePayslipDeductionData = employeePayslipDeductionData;
            _decimalMinutesToHrsConverter = decimalMinutesToHrsConverter;
            _employeePayslipPDFReport = employeePayslipPDFReport;
        }

        private void CMStripPayroll_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;

            if (clickedItem != null && clickedItem.Name == "TStripMenuItemGenerate")
            {
                DisplayGeneratePayrollControl();

            }
            else if (clickedItem != null && clickedItem.Name == "TStripMenuItemHistory")
            {
                DisplayPayrollHistoryControl();
            }
        }

        #region Generate payroll
        public void DisplayGeneratePayrollControl()
        {
            this.panelContainer.Controls.Clear();
            var generatePayrollControlObj = new GeneratePayrollControl(_decimalMinutesToHrsConverter);
            generatePayrollControlObj.Location = new Point(this.ClientSize.Width / 2 - generatePayrollControlObj.Size.Width / 2, this.ClientSize.Height / 2 - generatePayrollControlObj.Size.Height / 2);
            generatePayrollControlObj.Anchor = AnchorStyles.None;

            generatePayrollControlObj.GovernmentAgencies = _governmentAgencyData.GetAllNotDeleted();
            generatePayrollControlObj.Benefits = _employeeBenefitData.GetAllNotDeleted();
            generatePayrollControlObj.Deductions = _employeeDeductionData.GetAllNotDeleted();

            generatePayrollControlObj.InitiatePayrollGeneration += HandleInitiatePayrollGeneration;
            generatePayrollControlObj.GenerateEmployeePayslip += GenerateEmployeePayslip;
            generatePayrollControlObj.ViewEmployeePayslip += HandleViewEmployeePayslip;
            generatePayrollControlObj.CancelAllEmployeePayslip += HandleCancelAllEmployeeGeneratedPayslip;
            generatePayrollControlObj.CancelSelectedEmployeePayslip += HandleCancelSelectedEmployeeGeneratedPayslip;

            this.panelContainer.Controls.Add(generatePayrollControlObj);
        }

        private void HandleInitiatePayrollGeneration(object sender, EventArgs e)
        {
            GeneratePayrollControl generatePayrollControlObj = (GeneratePayrollControl)sender;

            var paydate = generatePayrollControlObj.PayDate;
            var shiftStartDate = generatePayrollControlObj.ShiftStartDate;
            var shiftEndDate = generatePayrollControlObj.ShiftEndDate;

            generatePayrollControlObj.Employees = _employeeController.GetAll().Data;
            generatePayrollControlObj.AttendanceHistory = _employeeAttendanceData.GetAllUnpaidAttendanceRecordByWorkDateRange(shiftStartDate, shiftEndDate);
            generatePayrollControlObj.EmployeeLeaveHistory = _employeeLeaveData.GetAllUnpaidByDateRange(shiftStartDate.Year, shiftStartDate, shiftEndDate);
            generatePayrollControlObj.DisplayEmployeeWithAttendanceRecordAndSalary(generatePayrollControlObj.Employees);

        }

        private void GenerateEmployeePayslip(object sender, EventArgs e)
        {
            try
            {
                GeneratePayrollControl generatePayrollControlObj = (GeneratePayrollControl)sender;
                var employeePayslipGenerationData = generatePayrollControlObj.EmployeePayslipGenerations;

                if (employeePayslipGenerationData != null)
                {
                    bool isContinueToGenerate = true;
                    foreach (var empPayslipGen in employeePayslipGenerationData)
                    {
                        string employeeNumber = empPayslipGen.Employee.EmployeeNumber;
                        var payslipWithTheSameDate = _employeePayslipData.GetEmployeePayslipRecordByPaydate(employeeNumber, empPayslipGen.PayDate);

                        if (payslipWithTheSameDate != null)
                        {
                            MessageBox.Show($"{empPayslipGen.Employee.FullName} have existing payslip for paydate: {empPayslipGen.PayDate.ToShortDateString()}",
                                            "Generate payslip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            isContinueToGenerate = false;
                            return;
                        }
                    }

                    if (isContinueToGenerate == false)
                        return;

                    using (var transaction = new TransactionScope())
                    {
                        foreach (var empPayslipGen in employeePayslipGenerationData)
                        {
                            string employeeNumber = empPayslipGen.Employee.EmployeeNumber;

                            var newPayslipRec = new EmployeePayslipModel
                            {
                                EmployeeNumber = employeeNumber,
                                StartShiftDate = empPayslipGen.ShiftStartDate,
                                EndShiftDate = empPayslipGen.ShiftEndDate,
                                PayDate = empPayslipGen.PayDate,
                                SalaryRate = empPayslipGen.Employee.SalaryRates.SalaryRate,
                                HalfMonthRate = empPayslipGen.Employee.SalaryRates.HalfMonthRate,
                                DailyRate = empPayslipGen.Employee.SalaryRates.DailyRate,
                                NumOfDays = empPayslipGen.PaydaySalaryComputation.NumberOfDays,
                                Late = empPayslipGen.PaydaySalaryComputation.Late,
                                LateTotalDeduction = empPayslipGen.PaydaySalaryComputation.LateTotalDeduction,
                                UnderTime = empPayslipGen.PaydaySalaryComputation.UnderTime,
                                UnderTimeTotalDeduction = empPayslipGen.PaydaySalaryComputation.UnderTimeTotalDeduction,
                                OverTime = empPayslipGen.PaydaySalaryComputation.OverTime,
                                OverTimeTotalRate = empPayslipGen.PaydaySalaryComputation.OverTimeTotalRate,
                                NetBasicSalary = empPayslipGen.PaydaySalaryComputation.NetBasicSalary
                            };

                            var payslipId = _employeePayslipData.Add(newPayslipRec);
                            var payslipData = _employeePayslipData.Get(payslipId);

                            if (payslipData != null)
                            {
                                var employeeGovtIds = _employeeGovtIdCardData.GetAllByEmployeeNumber(employeeNumber);

                                decimal empTotalDeductions = 0;
                                decimal empTotalBenefits = 0;
                                decimal empTotalIncome = newPayslipRec.NetBasicSalary;
                                decimal empNetTakeHomePay = 0;


                                // loop thru govt. agencies and retrieve employee and employer govt. id contribution
                                foreach (var govtAgency in empPayslipGen.SelectedGovtAgencies)
                                {
                                    var empGovtId = employeeGovtIds.Where(x => x.GovtAgencyId == govtAgency.Id).FirstOrDefault();
                                    if (empGovtId != null)
                                    {
                                        _employeePayslipDeductionData.Add(new EmployeePayslipDeductionModel
                                        {
                                            PayslipId = payslipId,
                                            EmployeeNumber = employeeNumber,
                                            DeductionTitle = empGovtId.GovernmentAgency.GovtAgency,
                                            Amount = empGovtId.EmployeeContribution
                                        });

                                        empTotalDeductions += empGovtId.EmployeeContribution;
                                    }
                                }

                                // Benefits
                                foreach (var benefit in empPayslipGen.SelectedBenefits)
                                {
                                    _employeePayslipBenefitData.Add(new EmployeePayslipBenefitModel
                                    {
                                        PayslipId = payslipId,
                                        EmployeeNumber = employeeNumber,
                                        BenefitTitle = benefit.BenefitTitle,
                                        Amount = benefit.Amount
                                    });

                                    empTotalBenefits += benefit.Amount;
                                }

                                empTotalIncome += empTotalBenefits;

                                // Deductions
                                foreach (var deduction in empPayslipGen.SelectedDeductions)
                                {
                                    _employeePayslipDeductionData.Add(new EmployeePayslipDeductionModel
                                    {
                                        PayslipId = payslipId,
                                        EmployeeNumber = employeeNumber,
                                        DeductionTitle = deduction.DeductionTitle,
                                        Amount = deduction.Amount
                                    });

                                    empTotalDeductions += deduction.Amount;
                                }

                                // Sales bonus here

                                empNetTakeHomePay = (empTotalIncome - empTotalDeductions);

                                payslipData.TotalIncome = empTotalIncome;
                                payslipData.BenefitsTotal = empTotalBenefits;

                                // we already deduction the ff. deductions in total income
                                // upon time-out daily salary computation
                                //empTotalDeductions += payslipData.LateTotalDeduction;
                                //empTotalDeductions += payslipData.UnderTimeTotalDeduction;
                                payslipData.DeductionTotal = empTotalDeductions;

                                payslipData.NetTakeHomePay = empNetTakeHomePay;

                                _employeePayslipData.Update(payslipData);


                                // Mark employee leave as paid
                                empPayslipGen.EmployeeLeaves.ForEach(x =>
                                {
                                    x.IsPaid = true;
                                    x.PayslipId = payslipId;
                                });
                                _employeeLeaveData.Update(empPayslipGen.EmployeeLeaves);


                                // Mark attendance as paid and store the payslip id
                                empPayslipGen.AttendanceHistory.ForEach(x => {
                                    x.IsPaid = true;
                                    x.PayslipId = payslipId;
                                });
                                _employeeAttendanceData.Update(empPayslipGen.AttendanceHistory);

                            }

                        }

                        transaction.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                MessageBox.Show("Internal error, kindly check system logs and report this error to developer.");
            }
        }


        private void HandleViewEmployeePayslip(object sender, EventArgs e)
        {
            GeneratePayrollControl generatePayrollControlObj = (GeneratePayrollControl)sender;
            string empNum = generatePayrollControlObj.SelectedEmployeeNumberToViewPayslip;

            var employeeDetails = _employeeData.GetByEmployeeNumber(empNum);
            var payslip = _employeePayslipData.GetEmployeePayslipRecordByPaydate(empNum, generatePayrollControlObj.PayDate);

            generatePayrollControlObj.DisplayEmployeePayslip(employeeDetails, payslip);
        }


        private void HandleCancelAllEmployeeGeneratedPayslip(object sender, EventArgs e)
        {
            GeneratePayrollControl generatePayrollControlObj = (GeneratePayrollControl)sender;

            var paydate = generatePayrollControlObj.PayDate;
            var shiftStartDate = generatePayrollControlObj.ShiftStartDate;
            var shiftEndDate = generatePayrollControlObj.ShiftEndDate;

            if (CancelAllEmployeePayslipByPaydate(paydate))
            {
                generatePayrollControlObj.Employees = _employeeController.GetAll().Data;
                generatePayrollControlObj.AttendanceHistory = _employeeAttendanceData.GetAllUnpaidAttendanceRecordByWorkDateRange(shiftStartDate, shiftEndDate);
                generatePayrollControlObj.EmployeeLeaveHistory = _employeeLeaveData.GetAllUnpaidByDateRange(shiftStartDate.Year, shiftStartDate, shiftEndDate);
                generatePayrollControlObj.DisplayEmployeeWithAttendanceRecordAndSalary(generatePayrollControlObj.Employees);

                generatePayrollControlObj.ClearDGVEmployeeListForOverview();
            }
        }

        private void HandleCancelSelectedEmployeeGeneratedPayslip(object sender, EventArgs e)
        {
            GeneratePayrollControl generatePayrollControlObj = (GeneratePayrollControl)sender;

            var paydate = generatePayrollControlObj.PayDate;
            var shiftStartDate = generatePayrollControlObj.ShiftStartDate;
            var shiftEndDate = generatePayrollControlObj.ShiftEndDate;

            var employeeNumber = generatePayrollControlObj.SelectedEmployeeNumberToViewPayslip;
                
            if (CancelEmployeePayslipByPaydate(paydate, employeeNumber))
            {
                generatePayrollControlObj.Employees = _employeeController.GetAll().Data;
                generatePayrollControlObj.AttendanceHistory = _employeeAttendanceData.GetAllUnpaidAttendanceRecordByWorkDateRange(shiftStartDate, shiftEndDate);
                generatePayrollControlObj.EmployeeLeaveHistory = _employeeLeaveData.GetAllUnpaidByDateRange(shiftStartDate.Year, shiftStartDate, shiftEndDate);
                generatePayrollControlObj.DisplayEmployeeWithAttendanceRecordAndSalary(generatePayrollControlObj.Employees);

                generatePayrollControlObj.ClearDGVEmployeeListForOverview();
            }
        }

        #endregion


        #region Payroll history
        public void DisplayPayrollHistoryControl()
        {
            this.panelContainer.Controls.Clear();
            var payslipHistoryControl = new PayslipHistoryControl();
            payslipHistoryControl.Location = new Point(this.ClientSize.Width / 2 - payslipHistoryControl.Size.Width / 2, this.ClientSize.Height / 2 - payslipHistoryControl.Size.Height / 2);
            payslipHistoryControl.Anchor = AnchorStyles.None;

            payslipHistoryControl.PayslipDateList = _employeePayslipData.GetPayslipPaydatesList();
            payslipHistoryControl.RetrieveEmployeePayslip += HandleRetrieveEmployeePayslip;
            payslipHistoryControl.CancelAllEmployeePayslip += HandleCancelAllEmployeePayslip;
            payslipHistoryControl.CancelSelectedEmployeePayslip += HandleCancelSelectedEmployeePayslip;

            this.panelContainer.Controls.Add(payslipHistoryControl);
        }

        private void HandleRetrieveEmployeePayslip(object sender, EventArgs e)
        {
            PayslipHistoryControl payslipHistoryControlObj = (PayslipHistoryControl)sender;

            var paydate = payslipHistoryControlObj.SelectedPayslipPayDate;

            var payslips = _employeePayslipData.GetAllEmpPayslipByPaydate(paydate);
            payslipHistoryControlObj.EmployeePayslipsByPaydate = payslips;
            payslipHistoryControlObj.DisplayEmployeesInDGV();

            if (payslips != null)
            {
                _employeePayslipPDFReport.GenerateEmployeePayslips(payslips);
            }
        }


        private void HandleCancelAllEmployeePayslip(object sender, EventArgs e)
        {
            PayslipHistoryControl payslipHistoryControlObj = (PayslipHistoryControl)sender;

            var paydate = payslipHistoryControlObj.SelectedPayslipPayDate;

            if (this.CancelAllEmployeePayslipByPaydate(paydate))
            {
                payslipHistoryControlObj.PayslipDateList = _employeePayslipData.GetPayslipPaydatesList();
                payslipHistoryControlObj.DisplayPayslipPaydateList();
                payslipHistoryControlObj.EmployeePayslipsByPaydate = _employeePayslipData.GetAllEmpPayslipByPaydate(paydate);
                payslipHistoryControlObj.DisplayEmployeesInDGV();
                payslipHistoryControlObj.ClearPayslipContainer();
            }
        }

        private void HandleCancelSelectedEmployeePayslip(object sender, EventArgs e)
        {
            PayslipHistoryControl payslipHistoryControlObj = (PayslipHistoryControl)sender;

            var paydate = payslipHistoryControlObj.SelectedPayslipPayDate;
            var employeeNumber = payslipHistoryControlObj.SelectedEmployeeNumberToCancel;

            if (this.CancelEmployeePayslipByPaydate(paydate, employeeNumber))
            {
                payslipHistoryControlObj.PayslipDateList = _employeePayslipData.GetPayslipPaydatesList();
                payslipHistoryControlObj.DisplayPayslipPaydateList();
                payslipHistoryControlObj.EmployeePayslipsByPaydate = _employeePayslipData.GetAllEmpPayslipByPaydate(paydate);
                payslipHistoryControlObj.DisplayEmployeesInDGV();
                payslipHistoryControlObj.ClearPayslipContainer();
            }
        }

        #endregion


        public bool CancelAllEmployeePayslipByPaydate(DateTime paydate)
        {
            try
            {
                var employeePayslips = _employeePayslipData.GetAllEmpPayslipByPaydate(paydate);

                if (employeePayslips != null)
                {
                    employeePayslips.ForEach(x => x.IsCancel = true);

                    using (var transaction = new TransactionScope())
                    {
                        foreach (var payslip in employeePayslips)
                        {
                            var attendanceRecordUnderPayslip = _employeeAttendanceData.GetEmployeeAttendanceByPayslipId(payslip.EmployeeNumber, payslip.Id);

                            attendanceRecordUnderPayslip.ForEach(x =>
                            {
                                x.IsPaid = false;
                                x.PayslipId = 0;
                            });

                            _employeeAttendanceData.Update(attendanceRecordUnderPayslip);

                            var employeeLeaveUnderPayslip = _employeeLeaveData.GetEmployeeLeavesByPayslipId(payslip.EmployeeNumber, payslip.Id);

                            employeeLeaveUnderPayslip.ForEach(x =>
                            {
                                x.IsPaid = false;
                                x.PayslipId = 0;
                            });

                            _employeeLeaveData.Update(employeeLeaveUnderPayslip);
                        }

                        _employeePayslipData.Update(employeePayslips);

                        transaction.Complete();
                    }

                    MessageBox.Show("Successfully cancel all employee payslip.", "Cancel employee payslip", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                MessageBox.Show("Internal error, kindly check system logs and report this error to developer.");
            }

            return false;
        }

        public bool CancelEmployeePayslipByPaydate(DateTime paydate, string employeeNumber)
        {
            try
            {
                var employeePayslips = _employeePayslipData.GetEmployeePayslipRecordByPaydate(employeeNumber, paydate);

                if (employeePayslips != null)
                {
                    employeePayslips.IsCancel = true;

                    using (var transaction = new TransactionScope())
                    {
                        var attendanceRecordUnderPayslip = _employeeAttendanceData.GetEmployeeAttendanceByPayslipId(employeePayslips.EmployeeNumber, employeePayslips.Id);

                        attendanceRecordUnderPayslip.ForEach(x =>
                        {
                            x.IsPaid = false;
                            x.PayslipId = 0;
                        });

                        _employeeAttendanceData.Update(attendanceRecordUnderPayslip);

                        var employeeLeaveUnderPayslip = _employeeLeaveData.GetEmployeeLeavesByPayslipId(employeePayslips.EmployeeNumber, employeePayslips.Id);

                        employeeLeaveUnderPayslip.ForEach(x =>
                        {
                            x.IsPaid = false;
                            x.PayslipId = 0;
                        });

                        _employeeLeaveData.Update(employeeLeaveUnderPayslip);


                        _employeePayslipData.Update(employeePayslips);

                        transaction.Complete();
                    }

                    MessageBox.Show("Successfully cancel employee payslip.", "Cancel employee payslip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                MessageBox.Show("Internal error, kindly check system logs and report this error to developer.");
            }

            return false;
        }
    }
}
