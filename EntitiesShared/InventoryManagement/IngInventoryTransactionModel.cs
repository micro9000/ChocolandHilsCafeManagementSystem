using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.InventoryManagement
{
    [Table("IngInventoryTransactions")]
    public class IngInventoryTransactionModel : BaseIntModel
    {
        public int IngInventoryId { get; set; }

        public StaticData.InventoryTransType TransType { get; set; }

        public decimal QtyVal { get; set; }

        public long UserId { get; set; }

        public string Remarks { get; set; }
    }
}
