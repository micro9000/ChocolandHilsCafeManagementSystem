using DapperGenericDataManager;
using DataAccess.Data.InventoryManagement.Contracts;
using EntitiesShared.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.InventoryManagement.Implementations
{
    public class ProductIngredientData : DataManagerCRUD<ProductIngredientModel>, IProductIngredientData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public ProductIngredientData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }
    }
}
