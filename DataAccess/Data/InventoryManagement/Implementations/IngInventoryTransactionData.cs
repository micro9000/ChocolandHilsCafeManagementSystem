using DapperGenericDataManager;
using DataAccess.Data.InventoryManagement.Contracts;
using DataAccess.Data.UserManagement.Contracts;
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
        private readonly IUserData _userData;

        public IngInventoryTransactionData(IDbConnectionFactory dbConnFactory, IUserData userData) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
            _userData = userData;
        }

        public List<IngInventoryTransactionModel> GetAllByIngredientAndDateRange(int ingredientId, DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT * FROM IngInventoryTransactions 
                            WHERE isDeleted=false AND ingredientId=@IngredientId AND createdAt BETWEEN @StartDate AND @EndDate
                            ORDER BY id DESC";
            
            var transactions = this.GetAll(query, new { 
                IngredientId = ingredientId,
                StartDate = startDate,
                EndDate = endDate
            });

            if (transactions != null)
            {
                foreach(var item in transactions)
                {
                    item.User = _userData.Get(item.UserId);
                }
            }

            return transactions;
        }
    }
}
