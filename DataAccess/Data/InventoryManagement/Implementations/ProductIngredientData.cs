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
    public class ProductIngredientData : DataManagerCRUD<ProductIngredientModel>, IProductIngredientData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public ProductIngredientData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<ProductIngredientModel> GetAllByProduct (int productId)
        {
            string query = @"SELECT *
                            FROM ProductIngredients AS PI
                            JOIN Ingredients AS ING ON PI.ingredientId=ING.id
                            WHERE PI.isDeleted=false AND PI.productId=@ProductId";

            var results = new List<ProductIngredientModel>();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<ProductIngredientModel, IngredientModel, ProductIngredientModel>(query,
                    (PI, ING) =>
                    {
                        PI.Ingredient = ING;
                        return PI;
                    }, new { ProductId = productId }).ToList();
            }

            return results;
        }

    }
}
