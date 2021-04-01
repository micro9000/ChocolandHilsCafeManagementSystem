using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared
{
    public class StaticData
    {
        public enum UserRole
        {
            normal,
            admin
        }

        public enum UOM
        {
            kg, // Kilogram
            L, // Liter
            pcs // Pieces
        }

        public enum InventoryTransType
        {
            INC, // Increase
            DEC // Decrease
        }
    }
}
