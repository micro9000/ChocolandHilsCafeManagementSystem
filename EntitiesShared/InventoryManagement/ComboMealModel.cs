using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.InventoryManagement
{
    [Table("ComboMeals")]
    public class ComboMealModel : BaseLongModel
    {
        public string Title { get; set; }

        public decimal Price { get; set; }

        private List<ComboMealProductModel> products;
        [Write(false)]
        [Computed]
        public List<ComboMealProductModel> Products
        {
            get { return products; }
            set { products = value; }
        }

    }
}
