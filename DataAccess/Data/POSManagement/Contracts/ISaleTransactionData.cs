using DapperGenericDataManager;
using EntitiesShared;
using EntitiesShared.POSManagement;
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
    }
}
