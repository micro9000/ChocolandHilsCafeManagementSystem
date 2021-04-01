using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.InventoryManagement
{
    [Table("ComboSets")]
    public class ComboSetModel : BaseIntModel
    {
        public string SetName { get; set; }
    }
}
