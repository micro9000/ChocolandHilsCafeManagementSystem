using DapperGenericDataManager;
using DataAccess.Data.InventoryManagement.Contracts;
using EntitiesShared.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
