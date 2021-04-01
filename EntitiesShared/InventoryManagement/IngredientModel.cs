using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.InventoryManagement
{
    [Table("Ingredients")]
    public class IngredientModel : BaseIntModel
    {
        public int CategoryId { get; set; }

        public string IngName { get; set; }

        public StaticData.UOM UOM { get; set; }
    }
}
