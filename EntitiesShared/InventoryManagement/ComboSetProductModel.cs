using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.InventoryManagement
{
    [Table("ComboSetProducts")]
    public class ComboSetProductModel : BaseIntModel
    {
        public int ComboSetId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
