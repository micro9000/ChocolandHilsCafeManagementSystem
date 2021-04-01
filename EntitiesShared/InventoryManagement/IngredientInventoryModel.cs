using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.InventoryManagement
{
    [Table("IngredientInventory")]
    public class IngredientInventoryModel : BaseIntModel
    {
        public int IngredientId { get; set; }

        public decimal InitialQtyValue { get; set; }

        public decimal CurrentQtyValue { get; set; }

        [Write(false)]
        [Computed]
        public decimal RemainingQtyValue
        {
            get
            {
                return InitialQtyValue - CurrentQtyValue;
            }
        }

        public decimal UnitCost { get; set; }

        public bool IsSoldOut { get; set; }
    }
}
