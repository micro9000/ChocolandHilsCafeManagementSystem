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
        bool MassDeleteIngredientsByCategory(long categoryId);
        bool MassUpdateIngredientsCategory(long previousCategoryId, long newCategoryId);
        List<IngredientModel> GetAllByCategory(long categoryId);
        List<IngredientModel> GetAllNotDeleted();
    }
}
