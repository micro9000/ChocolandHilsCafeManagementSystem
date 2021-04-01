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
    public class IngredientData : DataManagerCRUD<IngredientModel>, IIngredientData
    {
        private readonly IDbConnectionFactory _dbConnFactory;
        private readonly IIngredientCategoryData _ingredientCategoryData;
        private readonly IIngredientInventoryData _ingredientInventoryData;

        public IngredientData(IDbConnectionFactory dbConnFactory, 
                                IIngredientCategoryData ingredientCategoryData,
                                IIngredientInventoryData ingredientInventoryData) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
            _ingredientCategoryData = ingredientCategoryData;
            _ingredientInventoryData = ingredientInventoryData;
        }

        public bool MassUpdateIngredientsCategory (int previousCategoryId, int newCategoryId)
        {
            var ingredientsUnderPrevCategory = this.GetAllByCategory(previousCategoryId);

            if (ingredientsUnderPrevCategory == null)
                return true;

            if (ingredientsUnderPrevCategory != null && ingredientsUnderPrevCategory.Count == 0)
            {
                return true;
            }

            string query = @"UPDATE Ingredients SET categoryId=@NewCategoryId 
                            WHERE isDeleted=false AND categoryId=@PreviousCategoryId";

            int rowsAffected = 0;
            using (var conn = _dbConnFactory.CreateConnection())
            {
                rowsAffected = conn.Execute(query, 
                        new { 
                            NewCategoryId = newCategoryId, 
                            PreviousCategoryId = previousCategoryId
                        });
                conn.Close();
            }

            return rowsAffected > 0;
        }


        public bool MassDeleteIngredientsByCategory(int categoryId)
        {
            string query = @"UPDATE Ingredients SET isDeleted=true 
                            WHERE isDeleted=false AND categoryId=@Categoryid";

            int rowsAffected = 0;
            using (var conn = _dbConnFactory.CreateConnection())
            {
                rowsAffected = conn.Execute(query,
                        new
                        {
                            Categoryid = categoryId
                        });
                conn.Close();
            }

            return rowsAffected > 0;
        }

        public List<IngredientModel> GetAllByCategory (int categoryId)
        {
            string query = @"SELECT * FROM Ingredients WHERE isDeleted=false AND categoryId=@CategoryId";

            return this.GetAll(query, new { CategoryId = categoryId });
        }

        public List<IngredientModel> GetAllNotDeleted()
        {
            string query = @"SELECT * FROM Ingredients WHERE isDeleted=false";

            var ingredients = this.GetAll(query);

            foreach(var ing in ingredients)
            {
                ing.Category = _ingredientCategoryData.Get(ing.CategoryId);
                ing.RemainingQtyValue = _ingredientInventoryData.GetRemainingQtyValueByIngredient(ing.Id);
            }

            return ingredients;
        }
    }
}
