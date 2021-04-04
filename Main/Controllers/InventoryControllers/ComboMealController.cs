using AutoMapper;
using DataAccess.Data.InventoryManagement.Contracts;
using EntitiesShared.InventoryManagement;
using Main.Controllers.InventoryControllers.ControllerInterface;
using Microsoft.Extensions.Logging;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.InventoryControllers
{
    public class ComboMealController : IComboMealController
    {
        private readonly ILogger<LoginFrm> _logger;
        private readonly IMapper _mapper;
        private readonly IComboMealData _comboMealData;
        private readonly IComboMealProductData _comboMealProductData;

        public ComboMealController(ILogger<LoginFrm> logger,
                                    IMapper mapper,
                                    IComboMealData comboMealData,
                                    IComboMealProductData comboMealProductData)
        {
            _logger = logger;
            _mapper = mapper;
            _comboMealData = comboMealData;
            _comboMealProductData = comboMealProductData;
        }

        public EntityResult<ComboMealModel> Save (ComboMealModel comboMeal, List<ComboMealProductModel> products, bool isNew)
        {
            var results = new EntityResult<ComboMealModel>();
            results.IsSuccess = false;

            try
            {
                if (string.IsNullOrWhiteSpace(comboMeal.Title))
                {
                    results.IsSuccess = false;
                    results.Messages.Add("Provide combo meal title");
                    return results;
                }

                if (isNew)
                {
                    //int newComboMealId = _comboMealData.Add(comboMeal);

                    //if (newComboMealId > 0)
                    //{

                    //}
                    //else
                    //{
                    //    results.IsSuccess = false;
                    //    results.Messages.Add("Unable to add new ingredient, kindly check system logs for possible errors.");
                    //}
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add("Internal error, kindly check system logs and report this error to developer.");
            }

            return results;
        }

    }
}
