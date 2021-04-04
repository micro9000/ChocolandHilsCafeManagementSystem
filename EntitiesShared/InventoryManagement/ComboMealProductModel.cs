using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.InventoryManagement
{
    [Table("ComboMealProducts")]
    public class ComboMealProductModel : BaseLongModel
    {
        public long ComboSetId { get; set; }

        public long ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
