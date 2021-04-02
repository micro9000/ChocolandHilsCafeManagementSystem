using DapperGenericDataManager;
using DataAccess.Data.InventoryManagement.Contracts;
using EntitiesShared.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DataAccess.Data.InventoryManagement.Implementations
{
    public class IngredientInventoryData : DataManagerCRUD<IngredientInventoryModel>, IIngredientInventoryData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public IngredientInventoryData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public decimal GetRemainingQtyValueByIngredient(int ingredientId)
        {
            string query = @"SELECT SUM(remainingQtyValue) as remainingQtyValue
                            FROM IngredientInventory
                            WHERE isDeleted=false AND isSoldOut=false AND ingredientId=@IngredientId";

            return this.GetValue<decimal>(query, new { IngredientId = ingredientId });
        }

        public List<IngredientInventoryModel> GetAllByIngredient(int ingredientId)
        {
            string query = @"SELECT * FROM IngredientInventory WHERE isDeleted=false AND ingredientId=@IngredientId";

            var inventories = this.GetAll(query, new { IngredientId = ingredientId });

            return inventories;
        }

        public IngredientInventoryModel GetByIdAndIngredient (int ingredientId, long id)
        {
            string query = @"SELECT * FROM IngredientInventory 
                            WHERE isDeleted=false AND ingredientId=@IngredientId AND id=@Id";

            return this.GetFirstOrDefault(query, new { IngredientId = ingredientId, Id = id });
        }

        public List<IngredientInventoryModel> GetAllByExpirationDateRange (DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT *
                            FROM IngredientInventory AS INGINV
                            JOIN Ingredients AS ING ON INGINV.ingredientId=ING.id
                            WHERE ING.isDeleted=false AND INGINV.isDeleted=false AND INGINV.isSoldOut=false AND 
                                (INGINV.expirationDate BETWEEN @StartDate AND @EndDate OR INGINV.expirationDate <= @StartDate)";

            var results = new List<IngredientInventoryModel>();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<IngredientInventoryModel, IngredientModel, IngredientInventoryModel>(query,
                    (INGINV, ING) =>
                    {
                        INGINV.Ingredient = ING;
                        return INGINV;
                    }, new { StartDate = startDate, EndDate = endDate }).ToList();
            }

            return results;
        }

    }
}
