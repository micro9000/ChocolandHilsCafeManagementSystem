using Dapper;
using DapperGenericDataManager;
using DataAccess.Data.POSManagement.Contracts;
using EntitiesShared.InventoryManagement;
using EntitiesShared.POSManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.POSManagement.Implementations
{
    public class SaleTransactionComboMealData : DataManagerCRUD<SaleTransactionComboMealModel>, ISaleTransactionComboMealData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public SaleTransactionComboMealData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public IEnumerable<SaleTransactionComboMealModel> GetAllBySaleTranId (long saleTransactionId)
        {
            string query = @"SELECT *
                            FROM SalesTransactionComboMeals AS STComMl
                            JOIN ComboMeals AS ComMl ON STComMl.comboMealId = ComMl.id
                            WHERE STComMl.isDeleted=false AND STComMl.salesTransId=@SaleTransId";

            IEnumerable<SaleTransactionComboMealModel> results;

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<SaleTransactionComboMealModel, ComboMealModel, SaleTransactionComboMealModel>(query,
                    (STComMl, ComMl) => {
                        STComMl.ComboMeal = ComMl;
                        return STComMl;
                    }, new { SaleTransId = saleTransactionId });

                conn.Close();
            }

            return results;
        }
    }
}
