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
            L, // Liter,
            pcs, // Pieces
            pc,
            g, // grams
            ml,
        }

        public enum InventoryTransType
        {
            NEW,
            UPDATE,
            INCREASE,
            DECREASE,
            DELETE
        }

        public static Dictionary<UOM, string> GetUnitOfMeasurements 
        {
            get
            {
                var uoms = new Dictionary<UOM, string>();

                uoms.Add(UOM.kg, "Kilogram (kg)");
                uoms.Add(UOM.L, "Liter (L)");
                uoms.Add(UOM.pcs, "Piece (pc)");

                return uoms;
            }
        }
    }
}
