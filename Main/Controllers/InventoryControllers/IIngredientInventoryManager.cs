using EntitiesShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.InventoryControllers
{
    public interface IIngredientInventoryManager
    {
        decimal GetProductIngredientCost(int ingredientId, decimal prodIngredientQtyValue, StaticData.UOM prodIngredientUOM);
    }
}
