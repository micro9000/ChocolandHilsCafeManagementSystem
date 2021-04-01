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
    public class IngInventoryTransactionData : DataManagerCRUD<IngInventoryTransactionModel>, IIngInventoryTransactionData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public IngInventoryTransactionData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<IngInventoryTransactionModel> GetAllByIngredient(int ingredientId)
        {
            string query = @"SELECT * FROM IngInventoryTransactions WHERE isDeleted=false AND ingredientId=@IngredientId";
            return this.GetAll(query, new { IngredientId = ingredientId });
        }
    }
}
