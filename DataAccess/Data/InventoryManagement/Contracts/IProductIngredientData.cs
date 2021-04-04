﻿using DapperGenericDataManager;
using EntitiesShared.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.InventoryManagement.Contracts
{
    public interface IProductIngredientData : IDataManagerCRUD<ProductIngredientModel>
    {
        List<ProductIngredientModel> GetAllByProduct(int productId);
        List<ProductIngredientModel> GetAllByIngredient(int ingredientId);
    }
}
