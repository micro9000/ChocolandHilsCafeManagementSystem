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

        private IngredientCategoryModel _category;
        [Write(false)]
        [Computed]
        public IngredientCategoryModel Category
        {
            get { return _category; }
            set { _category = value; }
        }


        public string IngName { get; set; }

        public StaticData.UOM UOM { get; set; }

        private List<IngredientInventoryModel> inventories;
        [Write(false)]
        [Computed]
        public List<IngredientInventoryModel> Inventories
        {
            get { return inventories; }
            set { inventories = value; }
        }

        [Write(false)]
        [Computed]
        public decimal CurrentQtyValue 
        { 
            get
            {
                if (this.Inventories != null)
                {
                    decimal qtyValue = this.Inventories.Sum(x => x.CurrentQtyValue);
                    return qtyValue;
                }

                return 0;
            }
        }
    }
}
