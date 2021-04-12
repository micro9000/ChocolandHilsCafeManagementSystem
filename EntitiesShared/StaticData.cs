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

        public enum AttendanceRecordType
        {
            timeInOut = 6,
            off = 5,
            holiday = 4,
            leave = 3,
            awol = 2,
            error = 1
        }

        public enum TableStatus
        {
            Available = 1,
            Occupied = 2
        }

        public enum POSTransactionType
        {
            DineIn = 1,
            TakeOut = 2
        }

        public enum POSTransactionStatus
        {
            OnGoing = 1,
            Paid = 2,
            Cancelled = 3
        }

    }
}
