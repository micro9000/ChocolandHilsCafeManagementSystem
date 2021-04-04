using AutoMapper;
using DataAccess.Data.InventoryManagement.Contracts;
using EntitiesShared;
using EntitiesShared.InventoryManagement.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.InventoryControllers
{
    public class IngredientInventoryManager : IIngredientInventoryManager
    {
        private readonly ILogger<ProductCategoryController> _logger;
        private readonly IMapper _mapper;
        private readonly IProductData _productData;
        private readonly IProductIngredientData _productIngredientData;
        private readonly IIngredientData _ingredientData;
        private readonly IIngredientInventoryData _ingredientInventoryData;

        public IngredientInventoryManager(ILogger<ProductCategoryController> logger,
                                            IMapper mapper,
                                            IProductData productData,
                                            IProductIngredientData productIngredientData,
                                            IIngredientData ingredientData,
                                            IIngredientInventoryData ingredientInventoryData)
        {
            _logger = logger;
            _mapper = mapper;
            _productData = productData;
            _productIngredientData = productIngredientData;
            _ingredientData = ingredientData;
            _ingredientInventoryData = ingredientInventoryData;
        }


        private List<ProductIngredientInventoryDeduction> productIngredientInventoryDeductionFromList = new List<ProductIngredientInventoryDeduction>();

        public List<ProductIngredientInventoryDeduction> ProductIngredientInventoryDeductionFromList
        {
            get { return productIngredientInventoryDeductionFromList; }
            set { productIngredientInventoryDeductionFromList = value; }
        }

        public decimal GetActualCostByIngredientQtyValueAndUnitCost(StaticData.UOM uom, decimal ingredientUnitCost)
        {
            decimal actualCost = 0;

            switch (uom) {
                case StaticData.UOM.g:
                    actualCost = ingredientUnitCost / 1000;
                    break;

                case StaticData.UOM.ml:
                    actualCost = ingredientUnitCost / 1000;
                    break;

                case StaticData.UOM.pcs:
                case StaticData.UOM.kg:
                case StaticData.UOM.L:
                    actualCost = ingredientUnitCost;
                    break;

                default:
                    actualCost = 0;
                    break;
            }

            return actualCost;
        }


        public decimal GetProductIngredientCost(int ingredientId, decimal prodIngredientQtyValue, StaticData.UOM prodIngredientUOM)
        {
            ProductIngredientInventoryDeductionFromList = new List<ProductIngredientInventoryDeduction>();
            var ingredeintDetails = _ingredientData.Get(ingredientId);
            if (ingredeintDetails == null)
                return 0;

            var ingredientInventories = _ingredientInventoryData.GetAllByIngredient(ingredientId).OrderBy(x => x.ExpirationDate);

            if (ingredientInventories == null)
                return 0;

            decimal costTotal = 0;
            decimal remainingProdIngredientQtyValue = prodIngredientQtyValue;

            foreach (var inventory in ingredientInventories)
            {
                if (inventory.RemainingQtyValue >= remainingProdIngredientQtyValue && remainingProdIngredientQtyValue > 0)
                {
                    var actualUnitCost = this.GetActualCostByIngredientQtyValueAndUnitCost(prodIngredientUOM, inventory.UnitCost);
                    costTotal += remainingProdIngredientQtyValue * actualUnitCost;

                    remainingProdIngredientQtyValue = 0;

                    ProductIngredientInventoryDeductionFromList.Add(new ProductIngredientInventoryDeduction
                    {
                        IngredientId = ingredeintDetails.Id,
                        IngredientInventoryid = inventory.Id,
                        DeductQtyValue = remainingProdIngredientQtyValue
                    });
                }
                else if (inventory.RemainingQtyValue < remainingProdIngredientQtyValue && remainingProdIngredientQtyValue > 0)
                {
                    var actualUnitCost = this.GetActualCostByIngredientQtyValueAndUnitCost(prodIngredientUOM, inventory.UnitCost);
                    costTotal += inventory.RemainingQtyValue * actualUnitCost;

                    remainingProdIngredientQtyValue = remainingProdIngredientQtyValue - inventory.RemainingQtyValue;

                    ProductIngredientInventoryDeductionFromList.Add(new ProductIngredientInventoryDeduction
                    {
                        IngredientId = ingredeintDetails.Id,
                        IngredientInventoryid = inventory.Id,
                        DeductQtyValue = inventory.RemainingQtyValue
                    });
                }

                if (remainingProdIngredientQtyValue == 0)
                    break;
            }

            return costTotal;
        }
    }
}
