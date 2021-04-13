using DapperGenericDataManager;
using DataAccess.Data.POSManagement.Contracts;
using EntitiesShared.POSManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EntitiesShared.InventoryManagement;

namespace DataAccess.Data.POSManagement.Implementations
{
    public class SaleTransactionProductData : DataManagerCRUD<SaleTransactionProductModel>, ISaleTransactionProductData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public SaleTransactionProductData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public IEnumerable<SaleTransactionProductModel> GetAllBySaleTransId (long saleTransactionId)
        {
            string query = @"SELECT *
                            FROM SalesTransactionProducts AS STPrd
                            JOIN Products AS Prd ON STPrd.productId=Prd.id
                            WHERE STPrd.isDeleted=false AND STPrd.salesTransId=@SaleTransId";

            IEnumerable<SaleTransactionProductModel> results;

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<SaleTransactionProductModel, ProductModel, SaleTransactionProductModel>(query,
                    (STPrd, Prd) => {
                        STPrd.Product = Prd;
                        return STPrd;
                    }, new { SaleTransId = saleTransactionId });

                conn.Close();
            }

            return results;
        }
    }
}
