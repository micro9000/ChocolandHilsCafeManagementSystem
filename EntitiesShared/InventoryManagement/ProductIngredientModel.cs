using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.InventoryManagement
{
    [Table("ProductIngredients")]
    public class ProductIngredientModel : BaseIntModel
    {
        public int ProductId { get; set; }

        public int IngredientId { get; set; }

        public decimal Measurement { get; set; }
    }
}
