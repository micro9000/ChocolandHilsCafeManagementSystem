using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.InventoryManagement
{
    [Table("Products")]
    public class ProductModel : BaseIntModel
    {
        public int CategoryId { get; set; }

        private ProductCategoryModel category;
        [Write(false)]
        [Computed]
        public ProductCategoryModel Category
        {
            get { return category; }
            set { category = value; }
        }


        public string ProdName { get; set; }

        public decimal PricePerOrder { get; set; }
    }
}
