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

namespace Main.Controllers.POSControllers
{
    public class POSCommandController : IPOSCommandController
    {
        private readonly ILogger<POSCommandController> _logger;
        private readonly IMapper _mapper;
        private readonly ISaleTransactionData _salesTransactionData;
        private readonly Sessions _sessions;
        private readonly InitiateNewDineInSalesTransactionValidator _initiateNewDineInSalesTransValidator;
        private readonly InitiateNewTakeOutSalesTransactionValidator _initiateNewTakeOutSalesTransValidator;

        public POSCommandController(ILogger<POSCommandController> logger,
                                IMapper mapper,
                                ISaleTransactionData salesTransactionData,
                                Sessions sessions,
                                InitiateNewDineInSalesTransactionValidator initiateNewDineInSalesTransValidator,
                                InitiateNewTakeOutSalesTransactionValidator initiateNewTakeOutSalesTransValidator)
        {
            _logger = logger;
            _mapper = mapper;
            _salesTransactionData = salesTransactionData;
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
    }
}
