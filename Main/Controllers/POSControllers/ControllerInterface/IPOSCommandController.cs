using EntitiesShared.POSManagement;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.POSControllers.ControllerInterface
{
    public interface IPOSCommandController
    {
        EntityResult<SaleTransactionModel> InitiateNewTransaction(SaleTransactionModel newSalesTransaction);
        EntityResult<string> SaveSaleTransaction(long saleTransId, List<SaleTransactionProductModel> products, List<SaleTransactionComboMealModel> comboMeals);

        EntityResult<string> CancelSaleTransaction(long saleTransId);
    }
}
