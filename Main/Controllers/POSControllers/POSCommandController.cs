using AutoMapper;
using DataAccess.Data.POSManagement.Contracts;
using EntitiesShared.POSManagement;
using FluentValidation.Results;
using Main.Controllers.POSControllers.ControllerInterface;
using Main.Controllers.POSControllers.Validators;
using Microsoft.Extensions.Logging;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesShared;
using DataAccess.Data.InventoryManagement.Contracts;
using Main.Controllers.InventoryControllers;
using System.Transactions;
using EntitiesShared.InventoryManagement;

namespace Main.Controllers.POSControllers
{
    public class POSCommandController : IPOSCommandController
    {
        private readonly ILogger<POSCommandController> _logger;
        private readonly IMapper _mapper;
        private readonly ISaleTransactionData _salesTransactionData;
        private readonly ISaleTransactionProductData _saleTransactionProductData;
        private readonly ISaleTransactionComboMealData _saleTransactionComboMealData;
        private readonly ISaleTranProdIngInvDeductionsRecordData _saleTranProdIngInvDeductionsRecordData;
        private readonly IProductData _productData;
        private readonly IProductIngredientData _productIngredientData;
        private readonly IIngredientInventoryData _ingredientInventoryData;
        private readonly IIngredientInventoryManager _ingredientInventoryManager;
        private readonly Sessions _sessions;
        private readonly InitiateNewDineInSalesTransactionValidator _initiateNewDineInSalesTransValidator;
        private readonly InitiateNewTakeOutSalesTransactionValidator _initiateNewTakeOutSalesTransValidator;

        public POSCommandController(ILogger<POSCommandController> logger,
                                IMapper mapper,
                                ISaleTransactionData salesTransactionData,
                                ISaleTransactionProductData saleTransactionProductData,
                                ISaleTransactionComboMealData saleTransactionComboMealData,
                                ISaleTranProdIngInvDeductionsRecordData saleTranProdIngInvDeductionsRecordData,
                                IProductData productData,
                                IProductIngredientData productIngredientData,
                                IIngredientInventoryData ingredientInventoryData,
                                IIngredientInventoryManager ingredientInventoryManager,
                                Sessions sessions,
                                InitiateNewDineInSalesTransactionValidator initiateNewDineInSalesTransValidator,
                                InitiateNewTakeOutSalesTransactionValidator initiateNewTakeOutSalesTransValidator)
        {
            _logger = logger;
            _mapper = mapper;
            _salesTransactionData = salesTransactionData;
            _saleTransactionProductData = saleTransactionProductData;
            _saleTransactionComboMealData = saleTransactionComboMealData;
            _saleTranProdIngInvDeductionsRecordData = saleTranProdIngInvDeductionsRecordData;
            _productData = productData;
            _productIngredientData = productIngredientData;
            _ingredientInventoryData = ingredientInventoryData;
            _ingredientInventoryManager = ingredientInventoryManager;
            _sessions = sessions;
            _initiateNewDineInSalesTransValidator = initiateNewDineInSalesTransValidator;
            _initiateNewTakeOutSalesTransValidator = initiateNewTakeOutSalesTransValidator;
        }

        public string GetTicketNumber()
        {
            return DateTime.Now.ToString("yyMMddHHmmssffft");
        }

        public EntityResult<SaleTransactionModel> InitiateNewTransaction(SaleTransactionModel newSalesTransaction)
        {
            var results = new EntityResult<SaleTransactionModel>();
            results.IsSuccess = false;

            try
            {
                newSalesTransaction.TicketNumber = GetTicketNumber();
                newSalesTransaction.CurrentUser = _sessions.CurrentLoggedInUser.FullName;
                newSalesTransaction.TransStatus = StaticData.POSTransactionStatus.OnGoing;

                if (newSalesTransaction.TransactionType == StaticData.POSTransactionType.DineIn)
                {
                    ValidationResult validationResult = _initiateNewDineInSalesTransValidator.Validate(newSalesTransaction);

                    if (!validationResult.IsValid)
                    {
                        foreach (var failure in validationResult.Errors)
                        {
                            results.Messages.Add("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                        }
                        results.IsSuccess = false;
                        return results;
                    }
                }


                if (newSalesTransaction.TransactionType == StaticData.POSTransactionType.TakeOut)
                {
                    ValidationResult validationResult = _initiateNewTakeOutSalesTransValidator.Validate(newSalesTransaction);

                    if (!validationResult.IsValid)
                    {
                        foreach (var failure in validationResult.Errors)
                        {
                            results.Messages.Add("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                        }
                        results.IsSuccess = false;
                        return results;
                    }
                }


                long newSalesTransId = _salesTransactionData.Add(newSalesTransaction);

                if (newSalesTransId > 0)
                {
                    var salesTransDetails = _salesTransactionData.Get(newSalesTransId);

                    results.IsSuccess = true;
                    results.Messages.Add("Successfully initiate sales transaction.");
                    results.Data = salesTransDetails;
                }
                else
                {
                    results.IsSuccess = false;
                    results.Messages.Add("Unable to initiate new sales transaction, kindly check system logs for possible errors.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add("Internal error, kindly check system logs and report this error to developer.");
            }

            return results;
        }


        //public void SaveSaleTransaction(SaleTransactionModel newSalesTransaction)
        //{

        //}

        public EntityResult<string> SaveSaleTransactionProducts(long saleTransactionId, List<SaleTransactionProductModel> products)
        {
            var results = new EntityResult<string>();
            results.IsSuccess = false;

            try
            {
                // NOTE for TODO next: we will return the qty value to last ingredient's inventory
                var existingSaleTranProducts = _saleTransactionProductData.GetAllBySaleTransId(saleTransactionId).ToList();

                // transaction scope for better handling of inventory
                using var transaction = new TransactionScope();

                foreach(var item in products)
                {
                    var productInfo = _productData.Get(item.ProductId);

                    if (productInfo == null)
                        throw new Exception($"{item.Product.ProdName}: Product not found.");

                    item.SaleTransId = saleTransactionId;

                    if (existingSaleTranProducts != null && existingSaleTranProducts.Count > 0)
                    {
                        var saleTranProd = existingSaleTranProducts.Where(x => x.ProductId == item.ProductId).FirstOrDefault();

                        if (saleTranProd != null)
                        {
                            if (saleTranProd.Qty > item.Qty)
                            {
                                // get removed qty by the user
                                int qtyDiff = saleTranProd.Qty - item.Qty;
                                saleTranProd.Qty = item.Qty;

                                // meaning, the user decrease the qty of existing prod
                            }

                            if (saleTranProd.Qty < item.Qty)
                            {
                                // get added qty by the user
                                int qtyDiff = item.Qty - saleTranProd.Qty;

                                saleTranProd.Qty = item.Qty; // replace the existing qty to new

                                this.DeductRequiredIngredientsFromInventory(productInfo, qtyDiff, saleTranProd.Id);
                                // the user increase the qty of existing prod
                            }
                        }
                    }

                    if (existingSaleTranProducts == null)
                    {
                        var saleTransProdId = _saleTransactionProductData.Add(item);
                        this.DeductRequiredIngredientsFromInventory(productInfo, item.Qty, saleTransProdId);
                    }
                    

                    

                }

                // Commit all changes
                transaction.Complete();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add(ex.Message);
            }

            return results;
        }


        public void DeductRequiredIngredientsFromInventory(ProductModel productInfo, int orderQty, long saleTransProdId)
        {
            // Get all needed ingredients for current product
            var productIngredients = _productIngredientData.GetAllByProduct(productInfo.Id);
            foreach (var prodIngredient in productIngredients)
            {
                // Qty Value we need to deduct based on number of orders
                var productQtyWeNeedToDeduct = prodIngredient.QtyValue * orderQty; // ex. 500ml * 5 orders

                // we need the list of inventories we can deduct the product's ingredient qty value
                // because, in single ingredient, we can have multiple inventory
                var inventoriesWhereWeCanDeductProductIngredientQtyValue = _ingredientInventoryManager
                                                                            .GetWhereInventoryThisProductIngredientToDeduct(prodIngredient.IngredientId, prodIngredient.QtyValue, prodIngredient.UOM);

                // deduct require qty value in our ingredient's inventories
                foreach (var inventory in inventoriesWhereWeCanDeductProductIngredientQtyValue)
                {
                    var inventoryDetails = _ingredientInventoryData.GetByIdAndIngredient(inventory.IngredientId, inventory.IngredientInventoryid);
                    inventoryDetails.RemainingQtyValue = (inventoryDetails.RemainingQtyValue - inventory.DeductQtyValue);

                    _ingredientInventoryData.Update(inventoryDetails);

                    // store above data so we can use it in case we need to revert all deductions
                    _saleTranProdIngInvDeductionsRecordData.Add(new SaleTranProdIngInvDeductionsRecordModel
                    {
                        SaleTransProductId = saleTransProdId,
                        IngredientId = prodIngredient.IngredientId,
                        IngredientInventoryId = inventory.IngredientInventoryid,
                        IngredientUOM = prodIngredient.Ingredient.UOM,
                        UsedUOM = prodIngredient.UOM,
                        DeductedQtyValue = inventory.DeductQtyValue,
                        IngInvCurrentUnitCost = inventoryDetails.UnitCost
                    });
                }
            }
        }

    }
}
