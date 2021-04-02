using DapperGenericDataManager;
using EntitiesShared.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.InventoryManagement.Contracts
{
    public interface IIngredientInventoryData : IDataManagerCRUD<IngredientInventoryModel>
    {
        decimal GetRemainingQtyValueByIngredient(int ingredientId);
        List<IngredientInventoryModel> GetAllByIngredient(int ingredientId);
        IngredientInventoryModel GetByIdAndIngredient(int ingredientId, long id);
        List<IngredientInventoryModel> GetAllByExpirationDateRange(DateTime startDate, DateTime endDate);
    }
}
