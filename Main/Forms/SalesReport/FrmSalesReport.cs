using DataAccess.Data.POSManagement.Contracts;
using EntitiesShared.POSManagement.CustomModels;
using LiveCharts;
using LiveCharts.Wpf;
using Main.Controllers.POSControllers.ControllerInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.SalesReport
{
    public partial class FrmSalesReport : Form
    {
        private readonly ISaleTransactionData _saleTransactionData;

        private Dictionary<int, string> _months = new Dictionary<int, string>();

        public Dictionary<int, string> Months
        {
            get { return _months; }
            set { _months = value; }
        }

        public FrmSalesReport(ISaleTransactionData saleTransactionData)
        {
            InitializeComponent();


            //SetChart();
            _saleTransactionData = saleTransactionData;

            Months.Add(1, "January");
            Months.Add(2, "February");
            Months.Add(3, "March");
            Months.Add(4, "April");
            Months.Add(5, "May");
            Months.Add(6, "June");
            Months.Add(7, "July");
            Months.Add(8, "August");
            Months.Add(9, "September");
            Months.Add(10, "October");
            Months.Add(11, "November");
            Months.Add(12, "December");
        }



        private void FrmSalesReport_Load(object sender, EventArgs e)
        {
            DisplayYearsInFlowLayout();
            DefaultDisplayValues();
        }

        public void DisplayYearsInFlowLayout()
        {
            List<YearSalesReportModel> salesReports = new List<YearSalesReportModel>();

            salesReports = _saleTransactionData.GetYearlySalesReport();

            foreach(var report in salesReports)
            {
                var chbx = new CheckBox();
                chbx.Name = $"Year_{report.Yr}";
                chbx.Text = $"{report.Yr}";
                FlowLayoutCheckBoxYears.Controls.Add(chbx);
            }
        }

        public int GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }


        public void DefaultDisplayValues()
        {
            DateTime dateNow = DateTime.Now;
            int currentWeekNum = this.GetIso8601WeekOfYear(dateNow);

            GetAndDisplayNumberOfTransaction(dateNow.Year);
            this.GetAndDisplayYearRevenueProfitAndCost(dateNow.Year);
            this.GetAndDisplayMonthlyRevenueProfitAndCost(dateNow.Year, dateNow.Month);
            this.GetAndDisplayWeeklyRevenueProfitAndCost(dateNow.Year, currentWeekNum);

            DisplayMonthlyBarCharByYear(dateNow.Year);
            //DisplayWeeklyBarCharByYear(dateNow.Year);
            //DisplayYearlyBarCharByYear();
        }

        #region Header sales report

        public void GetAndDisplayNumberOfTransaction(int year)
        {
            var transactionsCounter = _saleTransactionData.GetNumberOfValidTransactionsByYear(year, EntitiesShared.StaticData.POSTransactionStatus.Paid);
            this.LblNumberOfTransactionsByYear.Text = transactionsCounter.ToString();
            this.LblNumberOfTransactionsWhatFor.Text = year.ToString();
        }

        public void GetAndDisplayYearRevenueProfitAndCost (int year)
        {
            var report = _saleTransactionData.GetSalesReportByYear(year);

            if (report != null)
            {
                this.LblYearlySaleReportAmount.Text = report.TotalSales.ToString("#,##0.##");
                this.LblYearlySaleReportWhatYear.Text = report.Yr.ToString();

                // profit and cost here
            }
            else
            {
                this.LblYearlySaleReportAmount.Text = "0";
                this.LblYearlySaleReportWhatYear.Text = "Not found!";
            }
        }

        public void GetAndDisplayMonthlyRevenueProfitAndCost (int year, int month)
        {
            var report = _saleTransactionData.GetSalesReportYearAndMonth(year, month);

            if (report != null)
            {
                this.LblMonthlySaleReportAmount.Text = report.TotalSales.ToString("#,##0.##");
                this.LblMonthlySaleReportWhatFor.Text = this.Months[report.Mnth].ToUpper();

                // profit and cost here
            }
            else
            {
                this.LblMonthlySaleReportAmount.Text = "0";
                this.LblMonthlySaleReportWhatFor.Text = "Not found!";
            }
        }

        public void GetAndDisplayWeeklyRevenueProfitAndCost(int year, int week)
        {
            var report = _saleTransactionData.GetWeeklySalesReportByYearAndWeek(year, week);

            if (report != null)
            {
                this.LblWeeklySaleReportAmount.Text = report.TotalSales.ToString("#,##0.##");
                this.LblWeeklySaleReportWhatFor.Text = $"WK-{report.Wk}";

                // profit and cost here
            }
            else
            {
                this.LblWeeklySaleReportAmount.Text = "0";
                this.LblWeeklySaleReportWhatFor.Text = "Not found!";
            }
        }

        #endregion

        public void DisplayMonthlyBarCharByYear(int year)
        {
            List<MonthSalesReportModel> monthSalesReports = new List<MonthSalesReportModel>();

            monthSalesReports = _saleTransactionData.GetMonthlySalesReport(year);

            List<string> months = monthSalesReports.Select(x => this.Months[x.Mnth]).ToList();
            List<decimal> values = monthSalesReports.Select(x => x.TotalSales).ToList();

            var monthlyReportSeries = new ColumnSeries
            {
                Title = year.ToString(),
                Values = new ChartValues<decimal> (values)
            };

            cartesianChart1.Series = new SeriesCollection
            {
                monthlyReportSeries
            };

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Months",
                Labels = months.ToArray()
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Sales",
                LabelFormatter = value => value.ToString("N")
            });
        }


        public void DisplayWeeklyBarCharByYear(int year)
        {
            List<WeekSalesReportModel> salesReports = new List<WeekSalesReportModel>();

            salesReports = _saleTransactionData.GetWeeklySalesReportByYear(year);

            List<string> weeks = salesReports.Select(x => $"W{x.Wk}").ToList();
            List<decimal> values = salesReports.Select(x => x.TotalSales).ToList();

            var monthlyReportSeries = new ColumnSeries
            {
                Title = year.ToString(),
                Values = new ChartValues<decimal>(values)
            };

            cartesianChart1.Series = new SeriesCollection
            {
                monthlyReportSeries
            };

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Weeks",
                Labels = weeks.ToArray()
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Sales",
                LabelFormatter = value => value.ToString("N")
            });
        }


        public void DisplayYearlyBarCharByYear()
        {
            List<YearSalesReportModel> salesReports = new List<YearSalesReportModel>();

            salesReports = _saleTransactionData.GetYearlySalesReport();

            List<string> weeks = salesReports.Select(x => x.Yr.ToString()).ToList();
            List<decimal> values = salesReports.Select(x => x.TotalSales).ToList();

            var monthlyReportSeries = new ColumnSeries
            {
                Title = "Yearly",
                Values = new ChartValues<decimal>(values)
            };

            cartesianChart1.Series = new SeriesCollection
            {
                monthlyReportSeries
            };

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Years",
                Labels = weeks.ToArray()
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Sales",
                LabelFormatter = value => value.ToString("N")
            });
        }

        public void SetChart()
        {

            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2015",
                    Values = new ChartValues<double> { 10, 50, 39, 50 }
                }
            };

            ////adding series will update and animate the chart automatically
            //cartesianChart1.Series.Add(new ColumnSeries
            //{
            //    Title = "2016",
            //    Values = new ChartValues<double> { 11, 56, 42 }
            //});

            //also adding values updates and animates the chart automatically
            //cartesianChart1.Series[1].Values.Add(48d);

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Sales Man",
                Labels = new[] { "Maria", "Susan", "Charles", "Frida" }
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Sold Apps",
                LabelFormatter = value => value.ToString("N")
            });
        }

    }
}
