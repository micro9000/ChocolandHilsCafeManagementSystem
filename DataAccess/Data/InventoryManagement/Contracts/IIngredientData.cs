using DapperGenericDataManager;
using EntitiesShared.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.InventoryManagement.Contracts
{
    public interface IIngredientData : IDataManagerCRUD<IngredientModel>
    {
        bool MassDeleteIngredientsByCategory(int categoryId);
        bool MassUpdateIngredientsCategory(int previousCategoryId, int newCategoryId);
        List<IngredientModel> GetAllByCategory(int categoryId);
        List<IngredientModel> GetAllNotDeleted();
    }
}
