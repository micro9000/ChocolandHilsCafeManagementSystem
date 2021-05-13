﻿using DataAccess.Data.EmployeeManagement.Contracts;
using DataAccess.Data.PayrollManagement.Contracts;
using DataAccess.Data.POSManagement.Contracts;
using EntitiesShared;
using EntitiesShared.EmployeeManagement;
using EntitiesShared.OtherDataManagement;
using EntitiesShared.PayrollManagement;
using EntitiesShared.PayrollManagement.Models;
using EntitiesShared.POSManagement;
using GovContributionCalculators.GovContributionCalculator;
using GovContributionCalculators.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PDFReportGenerators;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PayrollGenerator.Services
{
    public class PayslipGenerator : IPayslipGenerator
    {

        public DateTime PayDate { get; set; }
        public DateTime ShiftStartDate { get; set; }
        public DateTime ShiftEndDate { get; set; }


        private readonly ILogger<PayslipGenerator> _log;
        private readonly PayrollSettings _payrollSettings;
        private readonly IEmployeeData _employeeData;
        private readonly IEmployeeAttendanceData _employeeAttendanceData;
        private readonly IEmployeeBenefitData _employeeBenefitData;
        private readonly IEmployeeDeductionData _employeeDeductionData;
        private readonly IEmployeeLeaveData _employeeLeaveData;
        private readonly IEmployeePayslipBenefitData _employeePayslipBenefitData;
        private readonly IEmployeePayslipData _employeePayslipData;
        private readonly IEmployeePayslipDeductionData _employeePayslipDeductionData;
        private readonly IEmployeeShiftData _employeeShiftData;
        private readonly IEmployeeShiftDayData _employeeShiftDayData;
        private readonly IEmployeeGovtIdCardData _employeeGovtIdCardData;
        private readonly ICashRegisterCashOutTransactionData _cashRegisterCashOutTransactionData;
        private readonly IEmployeeCashAdvanceRequestData _employeeCashAdvanceRequestData;
        private readonly IEmployeePayslipPDFReport _employeePayslipPDFReport;
        private readonly IPayrollPDFReport _payrollPDFReport;
        private readonly SSSContributionCalculator _sssContributionCalculator;
        private readonly WTaxCalculator _wTaxCalculator;
        private readonly PhilHealthContributionCalculator _philHealthContributionCalculator;
        private readonly PagIbigContributionCalculator _pagIbigContributionCalculator;
        private readonly IEmployeeGovernmentContributionData _employeeGovernmentContributionData;

        public PayslipGenerator(ILogger<PayslipGenerator> log,
                                IOptions<PayrollSettings> payrollSettings,
                                IEmployeeData employeeData,
                                IEmployeeAttendanceData employeeAttendanceData,
                                IEmployeeBenefitData employeeBenefitData,
                                IEmployeeDeductionData employeeDeductionData,
                                IEmployeeLeaveData employeeLeaveData,
                                IEmployeePayslipBenefitData employeePayslipBenefitData,
                                IEmployeePayslipData employeePayslipData,
                                IEmployeePayslipDeductionData employeePayslipDeductionData,
                                IEmployeeShiftData employeeShiftData,
                                IEmployeeShiftDayData employeeShiftDayData,
                                IEmployeeGovtIdCardData employeeGovtIdCardData,
                                ICashRegisterCashOutTransactionData cashRegisterCashOutTransactionData,
                                IEmployeeCashAdvanceRequestData employeeCashAdvanceRequestData,
                                IEmployeePayslipPDFReport employeePayslipPDFReport,
                                IPayrollPDFReport payrollPDFReport,
                               SSSContributionCalculator sssContributionCalculator,
                               WTaxCalculator wTaxCalculator,
                               PhilHealthContributionCalculator philHealthContributionCalculator,
                               PagIbigContributionCalculator pagIbigContributionCalculator,
                               IEmployeeGovernmentContributionData employeeGovernmentContributionData)
        {
            _log = log;
            _payrollSettings = payrollSettings.Value;
            _employeeData = employeeData;
            _employeeAttendanceData = employeeAttendanceData;
            _employeeBenefitData = employeeBenefitData;
            _employeeDeductionData = employeeDeductionData;
            _employeeLeaveData = employeeLeaveData;
            _employeePayslipBenefitData = employeePayslipBenefitData;
            _employeePayslipData = employeePayslipData;
            _employeePayslipDeductionData = employeePayslipDeductionData;
            _employeeShiftData = employeeShiftData;
            _employeeShiftDayData = employeeShiftDayData;
            _employeeGovtIdCardData = employeeGovtIdCardData;
            _cashRegisterCashOutTransactionData = cashRegisterCashOutTransactionData;
            _employeeCashAdvanceRequestData = employeeCashAdvanceRequestData;
            _employeePayslipPDFReport = employeePayslipPDFReport;
            _payrollPDFReport = payrollPDFReport;
            _sssContributionCalculator = sssContributionCalculator;
            _wTaxCalculator = wTaxCalculator;
            _philHealthContributionCalculator = philHealthContributionCalculator;
            _pagIbigContributionCalculator = pagIbigContributionCalculator;
            _employeeGovernmentContributionData = employeeGovernmentContributionData;
        }

        private List<SSSContributionTableRow> sssContributionTable;

        public List<SSSContributionTableRow> SSSContributionTable
        {
            get { return sssContributionTable; }
            set { sssContributionTable = value; }
        }

        public WTaxTable WTaxTable { get; set; }
        public PhilHealthContributionSettings PhilHealthContributionTable { get; set; }
        public PagIbigContributionSettings PagIbigContributionTable { get; set; }

        public bool SetShiftRange()
        {

            DateTime todayDate = DateTime.Now;
            int todayDayNum = todayDate.Day;

            if (todayDayNum == _payrollSettings.FirstPayDayOfTheMonth)
            {
                this.PayDate = todayDate;
                this.ShiftStartDate = new DateTime(todayDate.Year, todayDate.Month, 1);
                this.ShiftEndDate = todayDate;

                return true;
            }

            if (todayDayNum == _payrollSettings.SecondPayDayOfTheMonth)
            {
                this.PayDate = todayDate;
                this.ShiftStartDate = new DateTime(todayDate.Year, todayDate.Month, (_payrollSettings.FirstPayDayOfTheMonth + 1));
                this.ShiftEndDate = new DateTime(todayDate.Year, todayDate.Month, DateTime.DaysInMonth(todayDate.Year, todayDate.Month));
                //new DateTime(todayDate.Year, todayDate.Month, _payrollSettings.SecondPayDayOfTheMonth);

                return true;
            }

            this.SSSContributionTable = _sssContributionCalculator.GetContributionTable(_payrollSettings.GovernmentContributionTablesPath);
            this.WTaxTable = _wTaxCalculator.GetMonthlyWTaxTable(_payrollSettings.GovernmentContributionTablesPath);
            this.PhilHealthContributionTable = _philHealthContributionCalculator.GetContributionTable(_payrollSettings.GovernmentContributionTablesPath);
            this.PagIbigContributionTable = _pagIbigContributionCalculator.GetContributionTable(_payrollSettings.GovernmentContributionTablesPath);

            return false;
        }


        public PaydaySalaryComputationPayslip GetEmpAttendanceRecSalaryComputation(EmployeeModel employee, 
                                                List<EmployeeAttendanceModel> empAttendanceRec,
                                                List<EmployeeLeaveModel> empLeaveRec)
        {
            if (employee == null)
                return null;

            if (empAttendanceRec != null)
            {
                decimal totalDays = empAttendanceRec.Count;
                decimal totalLeaveDays = 0;

                if (empLeaveRec != null && empLeaveRec.Count > 0)
                {
                    totalLeaveDays = empLeaveRec.Sum(x => x.NumberOfDays);
                }
                totalDays += totalLeaveDays;

                if (employee.Position == null)
                    throw new Exception($"{employee.FullName} don't have salary rate. Kindly update employee details");

                decimal netBasicSalary = empAttendanceRec.Sum(x => x.TotalDailySalary);
                netBasicSalary += employee.Position.DailyRate * totalLeaveDays;

                // no need to deduct this in netBasicSalary, since we already deduct late and undertime upon inserting the data in time-in and out terminal
                decimal lateDeductions = empAttendanceRec.Sum(x => x.LateTotalDeduction);
                decimal underTimeDeductions = empAttendanceRec.Sum(x => x.UnderTimeTotalDeduction);

                return new PaydaySalaryComputationPayslip
                {
                    Late = empAttendanceRec.Sum(x => x.TotalLate).ToString() + "m",
                    LateTotalDeduction = lateDeductions,
                    UnderTime = empAttendanceRec.Sum(x => x.TotalUnderTime).ToString() + "m",
                    UnderTimeTotalDeduction = underTimeDeductions,
                    NumberOfDays = totalDays.ToString() + "d",
                    NetBasicSalary = netBasicSalary
                };
            }

            return null;
        }


        public void GeneratePayslip()
        {
            if (SetShiftRange() == false)
            {
                return;
            }

            try
            {
                var employees = _employeeData.GetAllNotDeleted();

                if (employees != null)
                {

                    var cashRegisterSalesReport = _cashRegisterCashOutTransactionData.GetByDateRange(_payrollSettings.SaleAmoutForADayToGetSpecialBonus, this.ShiftStartDate, this.ShiftEndDate);
                    var benefits = _employeeBenefitData.GetAllNotDeleted();
                    var deductions = _employeeDeductionData.GetAllNotDeleted();

                    var empCashAdvanceRequests = _employeeCashAdvanceRequestData.GetAllByCashReleaseDateRange(this.ShiftStartDate, this.ShiftEndDate);

                    var allEmployeesAttendanceRecord = _employeeAttendanceData.GetAllUnpaidAttendanceRecordByWorkDateRange(this.ShiftStartDate, this.ShiftEndDate);

                    var employeeNumbersWithAttendance = (allEmployeesAttendanceRecord != null) ? allEmployeesAttendanceRecord.Select(x => x.EmployeeNumber).ToArray() : new string[] { };
                    var employeeLeaveHistory = _employeeLeaveData.GetAllUnpaidByDateRange(this.ShiftStartDate.Year, this.ShiftStartDate, this.ShiftEndDate);


                    using var transaction = new TransactionScope();

                    foreach (var empNum in employeeNumbersWithAttendance)
                    {
                        var empDetails = employees.Where(x => x.EmployeeNumber == empNum).FirstOrDefault();

                        //_employeeAttendanceData.GetAllUnpaidAttendanceRecordByWorkDateRange(empNum, this.ShiftStartDate, this.ShiftEndDate);
                        var currEmpAttendanceRec = allEmployeesAttendanceRecord.Where(x => x.EmployeeNumber == empNum).ToList();

                        if (currEmpAttendanceRec == null || currEmpAttendanceRec.Count <= 0)
                        {
                            continue;
                        }

                        var currEmpLeaveRec = employeeLeaveHistory == null ? null : employeeLeaveHistory.Where(x => x.EmployeeNumber == empNum).ToList(); //_employeeLeaveData.GetAllByEmployeeNumberAndYear(empNum, this.PayDate.Year);

                        PaydaySalaryComputationPayslip empPaydateComputation = this.GetEmpAttendanceRecSalaryComputation(empDetails, currEmpAttendanceRec, currEmpLeaveRec);

                        Console.WriteLine($"{empNum} - {empDetails.FullName} {empPaydateComputation.NumberOfDays}");

                        // generation
                        var newPayslipRec = new EmployeePayslipModel
                        {
                            EmployeeNumber = empNum,
                            StartShiftDate = this.ShiftStartDate,
                            EndShiftDate = this.ShiftEndDate,
                            PayDate = this.PayDate,
                            DailyRate = empDetails.Position.DailyRate,
                            NumOfDays = empPaydateComputation.NumberOfDays,
                            Late = empPaydateComputation.Late,
                            LateTotalDeduction = empPaydateComputation.LateTotalDeduction,
                            UnderTime = empPaydateComputation.UnderTime,
                            UnderTimeTotalDeduction = empPaydateComputation.UnderTimeTotalDeduction,
                            OverTime = empPaydateComputation.OverTime,
                            OverTimeTotalRate = empPaydateComputation.OverTimeTotalRate,
                            NetBasicSalary = empPaydateComputation.NetBasicSalary
                        };

                        var payslipId = _employeePayslipData.Add(newPayslipRec);

                        var payslipData = _employeePayslipData.Get(payslipId);

                        if (payslipData != null)
                        {
                            decimal empTotalDeductions = 0;
                            decimal empTotalBenefits = 0;
                            decimal empTotalIncome = newPayslipRec.NetBasicSalary;
                            decimal empNetTakeHomePay = 0;
                            decimal employeeGovtContributionTotal = 0;
                            decimal empMonthlySalary = empDetails.Position.MonthlyRate;

                            List<EmployeePayslipBenefitModel> employeePayslipBenefitsList = new List<EmployeePayslipBenefitModel>();
                            // Benefits
                            foreach (EmployeeBenefitModel benefit in benefits)
                            {
                                employeePayslipBenefitsList.Add(new EmployeePayslipBenefitModel
                                {
                                    PayslipId = payslipId,
                                    EmployeeNumber = empNum,
                                    BenefitTitle = benefit.BenefitTitle,
                                    Amount = benefit.Amount
                                });

                                empTotalBenefits += benefit.Amount;
                            }

                            // Sales bonus here
                            foreach (CashRegisterCashOutTransactionModel salesReport in cashRegisterSalesReport)
                            {
                                employeePayslipBenefitsList.Add(new EmployeePayslipBenefitModel
                                {
                                    PayslipId = payslipId,
                                    EmployeeNumber = empNum,
                                    BenefitTitle = $"Special bonus from sales: {salesReport.CreatedAt.ToShortDateString()}",
                                    Amount = _payrollSettings.EmployeeBonusFromSaleSpecialBonus
                                });

                                empTotalBenefits += _payrollSettings.EmployeeBonusFromSaleSpecialBonus;
                            }



                            List<EmployeePayslipDeductionModel> employeePayslipDeductionsList = new List<EmployeePayslipDeductionModel>();


                            #region SSS contribution
                            var sssMonthContribution = _sssContributionCalculator
                                                                    .GetEEandERSharedContribution(this.sssContributionTable, empMonthlySalary);

                            if (sssMonthContribution != null)
                            {
                                decimal empContributionKinsenas = (sssMonthContribution.EE / 2);
                                decimal emprContributionKinsenas = (sssMonthContribution.ER / 2);

                                _employeeGovernmentContributionData.Add(new EmployeeGovernmentContributionModel
                                {
                                    PayslipId = payslipId,
                                    EmployeeNumber = empNum,
                                    Agency = StaticData.GovContributions.SSS.ToString(),
                                    GovContributionEnumVal = StaticData.GovContributions.SSS,
                                    EmployeeContribution = empContributionKinsenas,
                                    EmployerContribution = emprContributionKinsenas
                                });

                                employeeGovtContributionTotal += sssMonthContribution.EE;
                                empTotalDeductions += empContributionKinsenas;
                            }
                            #endregion

                            #region PhilHealth contribution

                            var philHealthMonthlyContribution = _philHealthContributionCalculator
                                                                            .GetKinsenasContribution(this.PhilHealthContributionTable, empMonthlySalary);

                            if (philHealthMonthlyContribution != null)
                            {
                                decimal empContributionKinsenas = (philHealthMonthlyContribution.EE / 2);
                                decimal emprContributionKinsenas = (philHealthMonthlyContribution.ER / 2);

                                _employeeGovernmentContributionData.Add(new EmployeeGovernmentContributionModel
                                {
                                    PayslipId = payslipId,
                                    EmployeeNumber = empNum,
                                    Agency = StaticData.GovContributions.PhilHealth.ToString(),
                                    GovContributionEnumVal = StaticData.GovContributions.PhilHealth,
                                    EmployeeContribution = empContributionKinsenas,
                                    EmployerContribution = emprContributionKinsenas
                                });

                                employeeGovtContributionTotal += philHealthMonthlyContribution.EE;
                                empTotalDeductions += empContributionKinsenas;
                            }

                            #endregion

                            #region PagIbig contribution

                            var pagIbigMonthlyContribution = _pagIbigContributionCalculator
                                                                        .GetMonthlyContribution(this.PagIbigContributionTable, empMonthlySalary);

                            if (pagIbigMonthlyContribution != null)
                            {
                                decimal empContributionKinsenas = (pagIbigMonthlyContribution.EE / 2);
                                decimal emprContributionKinsenas = (pagIbigMonthlyContribution.ER / 2);

                                _employeeGovernmentContributionData.Add(new EmployeeGovernmentContributionModel
                                {
                                    PayslipId = payslipId,
                                    EmployeeNumber = empNum,
                                    Agency = StaticData.GovContributions.PagIbig.ToString(),
                                    GovContributionEnumVal = StaticData.GovContributions.PagIbig,
                                    EmployeeContribution = empContributionKinsenas,
                                    EmployerContribution = emprContributionKinsenas
                                });

                                employeeGovtContributionTotal += pagIbigMonthlyContribution.EE;
                                empTotalDeductions += empContributionKinsenas;
                            }

                            #endregion

                            #region Withholding tax

                            decimal monthlyWithholdingTax = _wTaxCalculator
                                                                        .GetMonthlyWithholdingTax(this.WTaxTable, employeeGovtContributionTotal, empMonthlySalary);

                            if (monthlyWithholdingTax > 0)
                            {
                                decimal empContributionKinsenas = (monthlyWithholdingTax / 2);

                                _employeeGovernmentContributionData.Add(new EmployeeGovernmentContributionModel
                                {
                                    PayslipId = payslipId,
                                    EmployeeNumber = empNum,
                                    Agency = StaticData.GovContributions.PagIbig.ToString(),
                                    GovContributionEnumVal = StaticData.GovContributions.PagIbig,
                                    EmployeeContribution = empContributionKinsenas,
                                    EmployerContribution = 0
                                });
                                empTotalDeductions += empContributionKinsenas;
                            }

                            #endregion

                            var currEmployeeCashAdvanceRequests = empCashAdvanceRequests.Where(x => x.EmployeeNumber == empNum).ToList();
                            if (currEmployeeCashAdvanceRequests != null && currEmployeeCashAdvanceRequests.Count > 0)
                            {
                                foreach(var cashAdvance in currEmployeeCashAdvanceRequests)
                                {
                                    employeePayslipDeductionsList.Add(new EmployeePayslipDeductionModel
                                    {
                                        PayslipId = payslipId,
                                        EmployeeNumber = empNum,
                                        DeductionTitle = $"Cash advance, release:{cashAdvance.CashReleaseDate.ToShortDateString()}",
                                        Amount = cashAdvance.Amount
                                    });

                                    empTotalDeductions += cashAdvance.Amount;
                                }
                            }

                            // Deductions
                            foreach (EmployeeDeductionModel deduction in deductions)
                            {
                                employeePayslipDeductionsList.Add(new EmployeePayslipDeductionModel
                                {
                                    PayslipId = payslipId,
                                    EmployeeNumber = empNum,
                                    DeductionTitle = deduction.DeductionTitle,
                                    Amount = deduction.Amount
                                });

                                empTotalDeductions += deduction.Amount;
                            }


                            empTotalIncome += empTotalBenefits;

                            empNetTakeHomePay = (empTotalIncome - empTotalDeductions);

                            payslipData.TotalIncome = empTotalIncome;
                            payslipData.BenefitsTotal = empTotalBenefits;
                            // we already deduction the ff. deductions in total income
                            // upon time-out daily salary computation
                            //empTotalDeductions += payslipData.LateTotalDeduction;
                            //empTotalDeductions += payslipData.UnderTimeTotalDeduction;
                            payslipData.DeductionTotal = empTotalDeductions;
                            payslipData.NetTakeHomePay = empNetTakeHomePay;



                            // insert deductions
                            _employeePayslipDeductionData.AddRange(employeePayslipDeductionsList);
                            // insert benefits
                            _employeePayslipBenefitData.AddRange(employeePayslipBenefitsList);

                            _employeePayslipData.Update(payslipData);

                            // Mark employee leave as paid
                            if (currEmpLeaveRec != null && currEmpLeaveRec.Count > 0)
                            {
                                currEmpLeaveRec.ForEach(x =>
                                {
                                    x.IsPaid = true;
                                    x.PayslipId = payslipId;
                                });
                                _employeeLeaveData.Update(currEmpLeaveRec);
                            }

                            // Mark attendance as paid and store the payslip id
                            currEmpAttendanceRec.ForEach(x =>
                            {
                                x.IsPaid = true;
                                x.PayslipId = payslipId;
                            });
                            _employeeAttendanceData.Update(currEmpAttendanceRec);

                        }
                    }


                    transaction.Complete();
                }
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message);
            }

            GeneratePDFPayslip();
        }

        private void GeneratePDFPayslip()
        {
            var payslips = _employeePayslipData.GetAllEmpPayslipByPaydate(this.PayDate);

            if (payslips != null)
            {
                _payrollPDFReport.GenerateEmployeePayslipsReport(payslips, this.PayDate);
                _employeePayslipPDFReport.GenerateEmployeePayslips(payslips);
            }
        }
    }
}
