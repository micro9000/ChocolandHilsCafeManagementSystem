﻿using EntitiesShared.InventoryManagement;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.InventoryControllers.ControllerInterface
{
    public interface IIngredientInventoryController
    {
        EntityResult<IngredientInventoryModel> Save(IngredientInventoryModel input, bool isNew, string remarks);
    }
}
