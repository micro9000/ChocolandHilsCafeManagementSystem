using EntitiesShared.POSManagement;
using EntitiesShared.POSManagement.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.POSControllers.ControllerInterface
{
    public interface IPOSReadController
    {
        List<SaleTransactionModel> GetActiveSalesTransactions();
        List<SaleTransactionModel> GetActiveDineInSalesTransactions();
        List<TableStatusModel> GetTableStatus();

        IEnumerable<SaleTransactionProductModel> GetSaleTranProducts(long saleTransactionId);
        IEnumerable<SaleTransactionComboMealModel> GetSaleTranComboMeals(long saleTransactionId);
    }
}
