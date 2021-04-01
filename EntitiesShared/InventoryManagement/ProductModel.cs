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

        public string ProdName { get; set; }

        public decimal Price { get; set; }
    }
}
