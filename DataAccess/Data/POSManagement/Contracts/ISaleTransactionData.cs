using DapperGenericDataManager;
using EntitiesShared;
using EntitiesShared.POSManagement;
using EntitiesShared.POSManagement.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.POSManagement.Contracts
{
    public interface ISaleTransactionData : IDataManagerCRUD<SaleTransactionModel>
    {
        List<SaleTransactionModel> GetAllByTransactionDate(DateTime transDate, StaticData.POSTransactionStatus POSTransactionStatus);
        List<SaleTransactionModel> GetAllByTransactionDateRange(DateTime startDate, DateTime endDate, StaticData.POSTransactionStatus POSTransactionStatus);
        List<SaleTransactionModel> GetSalesTransactionByStatusAndTransType(StaticData.POSTransactionStatus POSTransactionStatus, StaticData.POSTransactionType posTransactionType);
        List<SaleTransactionModel> GetSalesTransactionByStatus(StaticData.POSTransactionStatus POSTransactionStatus);
        List<SaleTransactionModel> GetSalesTransactionByStatus(StaticData.POSTransactionStatus POSTransactionStatus, DateTime startDate, DateTime endDate);

        decimal GetDayTotalSales(StaticData.POSTransactionStatus POSTransactionStatus, DateTime transDate);
        bool MassSalesTransactionSalesCashout(StaticData.POSTransactionStatus POSTransactionStatus, DateTime transDate);

        List<YearSalesReportModel> GetYearlySalesReport();
        List<YearSalesReportModel> GetYearlySalesReport(int startYear, int endYear);
        List<MonthSalesReportModel> GetMonthlySalesReport(int year);
        List<WeekSalesReportModel> GetWeeklySalesReportByYear(int year);
        List<WeekSalesReportModel> GetWeeklySalesReportByMonth(int month);
        List<DaySalesReportModel> GetDailySalesReportByMonth(int month);

    }
}
