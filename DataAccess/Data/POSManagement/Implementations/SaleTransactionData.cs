using DapperGenericDataManager;
using DataAccess.Data.POSManagement.Contracts;
using EntitiesShared;
using EntitiesShared.POSManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DataAccess.Data.POSManagement.Implementations
{
    public class SaleTransactionData : DataManagerCRUD<SaleTransactionModel>, ISaleTransactionData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public SaleTransactionData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<SaleTransactionModel> GetAllByTransactionDate (DateTime transDate, StaticData.POSTransactionStatus POSTransactionStatus)
        {
            string query = "SELECT * FROM SalesTransactions WHERE DATE(createdAt)=@TransactionDate AND transStatus=@TransStatus";
            return this.GetAll(query, 
                    new { 
                        TransactionDate = transDate.ToString("yyyy-MM-dd"),
                        TransStatus = (int)POSTransactionStatus
                    });
        }

        public List<SaleTransactionModel> GetAllByTransactionDateRange(DateTime startDate, DateTime endDate, StaticData.POSTransactionStatus POSTransactionStatus)
        {
            endDate = endDate.AddDays(1);
            string query = "SELECT * FROM SalesTransactions WHERE createdAt BETWEEN @StartDate AND @EndDate AND transStatus=@TransStatus";
            return this.GetAll(query, 
                new { 
                    StartDate = startDate.ToString("yyyy-MM-dd"), 
                    EndDate = endDate.ToString("yyyy-MM-dd"),
                    TransStatus = (int)POSTransactionStatus
                });
        }

        public List<SaleTransactionModel> GetSalesTransactionByStatusAndTransType(StaticData.POSTransactionStatus POSTransactionStatus, StaticData.POSTransactionType posTransactionType)
        {
            string query = @"SELECT * FROM SalesTransactions
                                WHERE isDeleted=false AND transactionType=@TransactionType AND transStatus=@TransStatus";

            return this.GetAll(query, new {
                TransactionType = (int)posTransactionType,
                TransStatus = (int)POSTransactionStatus 
            });
        }

        public List<SaleTransactionModel> GetSalesTransactionByStatus(StaticData.POSTransactionStatus POSTransactionStatus)
        {
            string query = @"SELECT * FROM SalesTransactions
                                WHERE isDeleted=false AND transStatus=@TransStatus";

            return this.GetAll(query, new { TransStatus = (int)POSTransactionStatus });
        }

        public List<SaleTransactionModel> GetSalesTransactionByStatus(StaticData.POSTransactionStatus POSTransactionStatus, DateTime startDate, DateTime endDate)
        {
            endDate = endDate.AddDays(1);

            string query = @"SELECT * FROM SalesTransactions
                                WHERE isDeleted=false AND transStatus=@TransStatus";

            return this.GetAll(query, new { 
                TransStatus = (int)POSTransactionStatus,
                StartDate = startDate.ToString("yyyy-MM-dd"),
                EndDate = endDate.ToString("yyyy-MM-dd")
            });
        }


        public decimal GetDayTotalSales (StaticData.POSTransactionStatus POSTransactionStatus, DateTime transDate)
        {
            string query = @"SELECT SUM(totalAmount) as totalSales 
                            FROM SalesTransactions
                            WHERE isDeleted=false AND isCashOut=false AND transStatus=@TransStatus AND DATE(createdAt)=@TransDate";

            return this.GetValue<decimal>(query,
                new { 
                    TransStatus = POSTransactionStatus, 
                    TransDate = transDate.ToString("yyyy-MM-dd") 
                });
        }

        public bool MassSalesTransactionSalesCashout(StaticData.POSTransactionStatus POSTransactionStatus, DateTime transDate)
        {
            string query = @"UPDATE SalesTransactions SET isCashOut=true 
                            WHERE isDeleted=false AND isCashOut=false AND transStatus=@TransStatus AND DATE(createdAt)=@TransDate";

            int rowsAffected = 0;
            using (var conn = _dbConnFactory.CreateConnection())
            {
                rowsAffected = conn.Execute(query,
                        new { 
                            TransStatus = POSTransactionStatus, 
                            TransDate = transDate.ToString("yyyy-MM-dd") 
                        });
                conn.Close();
            }

            return rowsAffected > 0;
        }
    }
}
