using EntitiesShared.PayrollManagement;
using Microsoft.Extensions.Options;
using Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;

namespace PDFReportGenerators
{
    public class EmployeePayslipPDFReport : IEmployeePayslipPDFReport
    {
        private readonly IConverter _converter;
        private readonly PayrollSettings _payrollSettings;

        public EmployeePayslipPDFReport(IConverter converter, IOptions<PayrollSettings> payrollSettings)
        {
            _converter = converter;
            _payrollSettings = payrollSettings.Value;
        }

        public void GenerateEmployeePayslips(List<EmployeePayslipModel> payslips)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"<!DOCTYPE html> 
                            <html> 
                            <header>
                                <style>
                                    th, td{
                                        padding: 5px;
                                    }

                                    table#parent-table thead{
                                        text-align: left;
                                    }

                                    table {
                                        width: 100%;
                                        border-collapse: collapse;
                                    }
                                </style>
                            </header>
                            <body>");


            foreach (var payslip in payslips)
            {
                sb.Append(this.ConvertPayslipToHtml(payslip));
            }

            sb.Append(@"</body>
                  </html>");

            this.GeneratePdfReport(sb.ToString(), $"Payslip-{DateTime.Now.ToString("yyyy-MM-dd")}");
        }

        public void GenerateEmployeePayslip(EmployeePayslipModel payslip)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"<!DOCTYPE html> 
                            <html> 
                            <header>
                                <style>
                                    th, td{
                                        padding: 5px;
                                    }

                                    table#parent-table thead{
                                        text-align: left;
                                    }

                                    table {
                                        width: 100%;
                                        border-collapse: collapse;
                                    }
                                </style>
                            </header>
                            <body>");

            sb.Append(this.ConvertPayslipToHtml(payslip));

            sb.Append(@"</body>
                  </html>");

            this.GeneratePdfReport(sb.ToString(), payslip.EmployeeNumber);
        }

        private string ConvertPayslipToHtml(EmployeePayslipModel payslip)
        {
            StringBuilder sb = new StringBuilder();

            StringBuilder header = new StringBuilder();
            header.Append($@"<hr/>
                            <table id='parent-table'>
                            <thead>
                                <tr style='border-bottom: 1px solid gray;'>
                                    <th> Employee: {payslip.Employee.FullName}</th>
                                    <th> ID No: {payslip.EmployeeNumber} </th>
                                </tr>
                                <tr style='border-bottom: 1px solid gray; text-align: center;'>
                                    <th colspan='2'>Shift from {payslip.StartShiftDate.ToLongDateString()} to {payslip.EndShiftDate.ToLongDateString()}</th>
                                </tr>
                           </thead>");


            StringBuilder earnings = new StringBuilder();
            string lateDeductions = payslip.LateTotalDeduction > 0 ? 
                            $@"<tr> 
                                    <td>Less Late</td> 
                                    <td>{payslip.Late}</td> 
                                    <td>{payslip.LateTotalDeduction}</td> 
                            </tr>" : "";

            string underTimeDeductions = payslip.UnderTimeTotalDeduction > 0 ?
                            $@"<tr> 
                                    <td>Less Undertime</td> 
                                    <td>{payslip.UnderTime}</td> 
                                    <td>{payslip.UnderTimeTotalDeduction}</td> 
                            </tr>" : "";


            StringBuilder benefits = new StringBuilder();
            if (payslip.Benefits != null)
            {
                foreach(var item in payslip.Benefits)
                {
                    benefits.Append($@"<tr> 
                                    <td>{item.BenefitTitle}</td> 
                                    <td></td> 
                                    <td>{item.Amount}</td> 
                            </tr>");
                }
            }

            StringBuilder deductions = new StringBuilder();

            deductions.Append(@"<table>
                        <thead>
                            <tr>
                                <th>Deductions</th>
                                <th>Amount</th>
                            </tr>
                        </thead>
                        <tbody>");

            if (payslip.EmployeeGovContributions != null)
            {
                foreach (var contrib in payslip.EmployeeGovContributions)
                {
                    deductions.Append($@"<tr> 
                                    <td>{contrib.GovContributionEnumVal}</td> 
                                    <td>{contrib.EmployeeContribution}</td> 
                            </tr>");
                }
            }

            if (payslip.Deductions != null)
            {
                foreach (var item in payslip.Deductions)
                {
                    deductions.Append($@"<tr> 
                                    <td>{item.DeductionTitle}</td> 
                                    <td>{item.Amount}</td> 
                            </tr>");
                }
            }


            deductions.Append(@"</tbody></table>");


            earnings.Append($@"
                    <table style='border-right: 1px solid gray;'>
                        <thead>
                            <tr>
                                <th>Earnings</th>
                                <th>Multipler</th>
                                <th>Amount</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Daily Rate</td>
                                <td></td>
                                <td>{payslip.DailyRate}</td>
                            </tr>
                            {lateDeductions}
                            {underTimeDeductions}
                            <tr>
                                <td>Net Basic Salary</td>
                                <td>{payslip.NumOfDays}</td>
                                <td>{payslip.NetBasicSalary}</td>
                            </tr>
                            {benefits}
                        </tbody>
                    </table>
            ");

            StringBuilder body = new StringBuilder();
            body.Append($@"
                 <tbody>
                    <tr><td>{earnings}</td> <td>{deductions}</td></tr>
                </tbody>
            ");


            StringBuilder footer = new StringBuilder();
            footer.Append($@"
                <tfoot>
                    <tr>
                        <th>Total income: {payslip.TotalIncome}</th>
                        <th>Total Deductions: {payslip.DeductionTotal}</th>
                    </tr>
                    <tr style='text-align: center !important; '>
                          <th colspan='2'>Your net take home pay >>> {payslip.NetTakeHomePay}</th>
                    </tr>
               </tfoot>
                </table>
                <hr/>
               ");

            sb.Append(header);
            sb.Append(body);
            sb.Append(footer);

            return sb.ToString();
        }

        private void GeneratePdfReport(string html, string fileName)
        {

            GlobalSettings globalSettings = new GlobalSettings();
            globalSettings.ColorMode = ColorMode.Color;
            globalSettings.Orientation = Orientation.Portrait;
            globalSettings.PaperSize = PaperKind.A4;
            globalSettings.Margins = new MarginSettings { Top = 10, Bottom = 10 };
            globalSettings.Out = $@"{_payrollSettings.GeneratedPDFLoc}{fileName}.pdf";

            ObjectSettings objectSettings = new ObjectSettings();
            objectSettings.PagesCount = true;
            objectSettings.HtmlContent = html;

            WebSettings webSettings = new WebSettings();
            webSettings.DefaultEncoding = "utf-8";

            //HeaderSettings headerSettings = new HeaderSettings();
            //headerSettings.FontSize = 15;
            //headerSettings.FontName = "Ariel";
            //headerSettings.Right = "Page [page] of [toPage]";
            //headerSettings.Line = true;

            //FooterSettings footerSettings = new FooterSettings();
            //footerSettings.FontSize = 12;
            //footerSettings.FontName = "Ariel";
            //footerSettings.Center = "This is for demonstration purposes only.";
            //footerSettings.Line = true;


            //objectSettings.HeaderSettings = headerSettings;
            //objectSettings.FooterSettings = footerSettings;
            objectSettings.WebSettings = webSettings;

            HtmlToPdfDocument htmlToPdfDocument = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings },
            };
            _converter.Convert(htmlToPdfDocument);
        }
    }
}
