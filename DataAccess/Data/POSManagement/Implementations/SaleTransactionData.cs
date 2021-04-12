using DapperGenericDataManager;
using DataAccess.Data.POSManagement.Contracts;
using EntitiesShared;
using EntitiesShared.POSManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string query = @"SELECT * FROM SalesTransactions
                                WHERE isDeleted=false AND transStatus=@TransStatus";

            return this.GetAll(query, new { 
                TransStatus = (int)POSTransactionStatus,
                StartDate = startDate.ToString("yyyy-MM-dd"),
                EndDate = endDate.ToString("yyyy-MM-dd")
            });
        }
    }
}
