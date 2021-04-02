using DapperGenericDataManager;
using EntitiesShared.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.InventoryManagement.Contracts
{
    public interface IProductData : IDataManagerCRUD<ProductModel>
    {
        bool MassUpdateProductCategory(int previousCategoryId, int newCategoryId);
        bool MassDeleteProductsByCategory(int categoryId);
        List<ProductModel> GetAllByCategory(int categoryId);
    }
}
