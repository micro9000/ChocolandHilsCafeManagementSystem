﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.InventoryManagement.Models
{
    public class ProductIngredientInventoryDeduction
    {
        public long IngredientId { get; set; }

        public long IngredientInventoryid { get; set; }

        public decimal DeductQtyValue { get; set; }
    }
}