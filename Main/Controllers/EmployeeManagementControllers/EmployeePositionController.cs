using AutoMapper;
using DataAccess.Data.EmployeeManagement.Contracts;
using EntitiesShared.EmployeeManagement;
using FluentValidation.Results;
using Main.Controllers.EmployeeManagementControllers.ControllerInterface;
using Main.Controllers.EmployeeManagementControllers.Validator;
using Microsoft.Extensions.Logging;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.EmployeeManagementControllers
{
    public class EmployeePositionController : IEmployeePositionController
    {
        private readonly ILogger<EmployeePositionController> _logger;
        private readonly IMapper _mapper;
        private readonly EmployeePositionAddUpdateValidator _positionValidator;
        private readonly IEmployeePositionData _employeePositionData;

        public EmployeePositionController(ILogger<EmployeePositionController> logger,
                                        IMapper mapper,
                                        EmployeePositionAddUpdateValidator positionValidator,
                                        IEmployeePositionData employeePositionData)
        {
            _logger = logger;
            _mapper = mapper;
            _positionValidator = positionValidator;
            _employeePositionData = employeePositionData;
        }

        public EntityResult<string> Delete(long positionId)
        {
            var results = new EntityResult<string>();

            try
            {
                var positionDetails = _employeePositionData.Get(positionId);

                if (positionDetails != null)
                {
                    positionDetails.IsDeleted = true;
                    positionDetails.DeletedAt = DateTime.Now;

                    results.IsSuccess = _employeePositionData.Update(positionDetails);
                    results.Messages.Add("Position deleted.");
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


        public EntityResult<EmployeePositionModel> Save(EmployeePositionModel input, bool isNew)
        {
            var results = new EntityResult<EmployeePositionModel>();
            results.IsSuccess = false;

            try
            {
                ValidationResult validatorResult = _positionValidator.Validate(input);

                if (!validatorResult.IsValid)
                {
                    foreach (var failure in validatorResult.Errors)
                    {
                        results.Messages.Add("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                    results.IsSuccess = false;
                    return results;
                }

                if (isNew)
                {
                    long itemId = _employeePositionData.Add(input);
                    if (itemId > 0)
                    {
                        var positionDetails = _employeePositionData.Get(itemId);

                        results.IsSuccess = true;
                        results.Messages.Add("Successfully add new position.");
                        results.Data = positionDetails;
                    }
                    else
                    {
                        results.IsSuccess = false;
                        results.Messages.Add("Unable to add new position, kindly check system logs for possible errors.");
                    }
                }
                else
                {
                    var positionDetails = _employeePositionData.Get(input.Id);

                    if (positionDetails == null)
                    {
                        results.IsSuccess = false;
                        results.Messages.Add($"Position not found!");
                        return results;
                    }

                    _mapper.Map(input, positionDetails);

                    if (this._employeePositionData.Update(positionDetails))
                    {
                        results.IsSuccess = true;
                        results.Messages.Add("Successfully update position details.");
                        results.Data = positionDetails;
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
                results.Messages.Add("Internal error, kindly check system logs and report this error to developer.");
            }

            return results;
        }
    }
}
