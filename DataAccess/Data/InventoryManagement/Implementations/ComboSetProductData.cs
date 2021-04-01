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
    public class ComboSetProductData : DataManagerCRUD<ComboSetProductModel>, IComboSetProductData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public ComboSetProductData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }
    }
}
