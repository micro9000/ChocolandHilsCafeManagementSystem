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

        public enum LeaveDurationType
        { 
            FullDay,
            FirstHalfDay,
            SecondHalfDay
        }

        public static Dictionary<LeaveDurationType, string> GetLeaveDurationTypes
        {
            get
            {
                var uoms = new Dictionary<LeaveDurationType, string>();

                uoms.Add(LeaveDurationType.FullDay, "Whole Day");
                uoms.Add(LeaveDurationType.FirstHalfDay, "First Halfday");
                uoms.Add(LeaveDurationType.SecondHalfDay, "Second Halfday");

                return uoms;
            }
        }

        public enum EmployeeRequestApprovalStatus
        {
            Pending,
            Approved,
            Disapproved,
            Cancelled
        }

        public enum GovContributions
        {
            SSS,
            PhilHealth,
            PagIbig,
            WithHoldingTax
        }

        public static Dictionary<GovContributions, string> GetGovContributions
        {
            get
            {
                var uoms = new Dictionary<GovContributions, string>();

                uoms.Add(GovContributions.SSS, "SSS");
                uoms.Add(GovContributions.PhilHealth, "PhilHealth");
                uoms.Add(GovContributions.PagIbig, "PagIbig");
                uoms.Add(GovContributions.WithHoldingTax, "Withholding tax");

                return uoms;
            }
        }

        public enum Months
        {
            Jan = 1,
            Feb = 2,
            Mar = 3,
            Apr = 4,
            May = 5,
            Jun = 6,
            Jul = 7,
            Aug = 8,
            Sep = 9,
            Oct = 10,
            Nov = 11,
            Dec = 12
        }
    }
}
