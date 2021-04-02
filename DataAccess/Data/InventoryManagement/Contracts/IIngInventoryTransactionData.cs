using DapperGenericDataManager;
using EntitiesShared.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.InventoryManagement.Contracts
{
    public interface IIngInventoryTransactionData : IDataManagerCRUD<IngInventoryTransactionModel>
    {
        List<IngInventoryTransactionModel> GetAllByIngredientAndDateRange(int ingredientId, DateTime startDate, DateTime endDate);
    }
}
