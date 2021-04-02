using AutoMapper;
using DataAccess.Data.InventoryManagement.Contracts;
using EntitiesShared.InventoryManagement;
using FluentValidation.Results;
using Main.Controllers.InventoryControllers.ControllerInterface;
using Main.Controllers.InventoryControllers.Validator;
using Microsoft.Extensions.Logging;
using Shared.ResponseModels;
using System;
using EntitiesShared;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.InventoryControllers
{
    public class IngredientInventoryController : IIngredientInventoryController
    {
        private readonly ILogger<IngredientInventoryController> _logger;
        private readonly IMapper _mapper;
        private readonly Sessions _sessions;
        private readonly IIngredientInventoryData _ingredientInventoryData;
        private readonly IIngInventoryTransactionData _ingInventoryTransactionData;
        private readonly IngredientInventoryAddUpdateValidator _ingredientInventoryAddUpdateValidator;

        public IngredientInventoryController(ILogger<IngredientInventoryController> logger,
                                            IMapper mapper,
                                            Sessions sessions,
                                            IIngredientInventoryData ingredientInventoryData,
                                            IIngInventoryTransactionData ingInventoryTransactionData,
                                            IngredientInventoryAddUpdateValidator ingredientInventoryAddUpdateValidator)
        {
            _logger = logger;
            _mapper = mapper;
            _sessions = sessions;
            _ingredientInventoryData = ingredientInventoryData;
            _ingInventoryTransactionData = ingInventoryTransactionData;
            _ingredientInventoryAddUpdateValidator = ingredientInventoryAddUpdateValidator;
        }


        public EntityResult<string> Delete (int ingredeintId, long inventoryId, string remarks)
        {
            var results = new EntityResult<string>();

            try
            {
                var details = _ingredientInventoryData.GetByIdAndIngredient(ingredeintId, inventoryId);

                if (details != null)
                {
                    details.IsDeleted = true;
                    details.DeletedAt = DateTime.Now;

                    results.IsSuccess = _ingredientInventoryData.Update(details);
                    results.Messages.Add("Inventory deleted.");

                    _ingInventoryTransactionData.Add(new IngInventoryTransactionModel
                    {
                        IngredientId = details.IngredientId,
                        TransType = StaticData.InventoryTransType.DELETE,
                        QtyVal = details.InitialQtyValue,
                        UnitCost = details.UnitCost,
                        ExpirationDate = details.ExpirationDate,
                        UserId = _sessions.CurrentLoggedInUser.Id,
                        Remarks = remarks
                    });

                }
                else
                {
                    results.IsSuccess = false;
                    results.Messages.Add("No changes made.");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add("Internal error, kindly check system logs and report this error to developer.");
            }

            return results;
        }

        public EntityResult<IngredientInventoryModel> Save (IngredientInventoryModel input, bool isNew, string remarks)
        {

            var results = new EntityResult<IngredientInventoryModel>();
            results.IsSuccess = false;

            try
            {
                if (input == null)
                {
                    throw new Exception("Empty object for ingredient inventory.");
                }

                ValidationResult validationResult = _ingredientInventoryAddUpdateValidator.Validate(input);

                if (!validationResult.IsValid)
                {
                    foreach (var failure in validationResult.Errors)
                    {
                        results.Messages.Add("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                    results.IsSuccess = false;
                    return results;
                }

                if (isNew)
                {
                    long newInventoryId = _ingredientInventoryData.Add(input);
                    if (newInventoryId > 0)
                    {
                        var inventoryDetails = _ingredientInventoryData.Get(newInventoryId);

                        _ingInventoryTransactionData.Add(new IngInventoryTransactionModel {
                            IngredientId = inventoryDetails.IngredientId,
                            TransType = StaticData.InventoryTransType.NEW,
                            QtyVal = inventoryDetails.InitialQtyValue,
                            UnitCost = inventoryDetails.UnitCost,
                            ExpirationDate = inventoryDetails.ExpirationDate,
                            UserId = _sessions.CurrentLoggedInUser.Id,
                            Remarks = remarks
                        });

                        results.IsSuccess = true;
                        results.Messages.Add("Successfully add inventory");
                        results.Data = inventoryDetails;
                    }
                    else
                    {
                        throw new Exception("Unable to add new employee, kindly check system logs for possible errors.");
                    }
                }
                else
                {
                    var existingInventory = _ingredientInventoryData.Get(input.Id);

                    if (existingInventory == null)
                    {
                        throw new Exception("Existing inventory details not found.");
                    }

                    _mapper.Map(input, existingInventory);


                    // Update employee details
                    if (this._ingredientInventoryData.Update(existingInventory))
                    {
                        _ingInventoryTransactionData.Add(new IngInventoryTransactionModel
                        {
                            IngredientId = existingInventory.IngredientId,
                            TransType = StaticData.InventoryTransType.UPDATE,
                            QtyVal = existingInventory.InitialQtyValue,
                            UnitCost = existingInventory.UnitCost,
                            ExpirationDate = existingInventory.ExpirationDate,
                            UserId = _sessions.CurrentLoggedInUser.Id,
                            Remarks = remarks
                        });

                        results.IsSuccess = true;
                        results.Messages.Add("Successfully update inventory details");
                        results.Data = existingInventory;
                    }
                    else
                    {
                        results.IsSuccess = false;
                        results.Messages.Add("No changes made.");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add(ex.Message);
            }

            return results;
        }

    }
}
