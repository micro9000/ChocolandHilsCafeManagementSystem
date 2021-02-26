﻿using DataAccess.Data.EmployeeManagement.Contracts;
using DataAccess.Entities.EmployeeManagement;
using Main.Controllers.EmployeeManagementControllers.ControllerInterface;
using Main.Controllers.EmployeeManagementControllers.Validator;
using Microsoft.Extensions.Logging;
using Shared.ResponseModels;
using System;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using AutoMapper;

namespace Main.Controllers.EmployeeManagementControllers
{
    public class EmployeeController : IEmployeeController
    {
        private readonly ILogger<LoginFrm> _logger;
        private readonly IMapper _mapper;
        private readonly EmployeeAddUpdateValidator _employeeAddUpdateValidator;
        private readonly IEmployeeData _employeeData;

        public EmployeeController(ILogger<LoginFrm> logger,
                                IMapper mapper,
                                EmployeeAddUpdateValidator employeeAddUpdateValidator,
                                IEmployeeData employeeData)
        {
            _logger = logger;
            _mapper = mapper;
            _employeeAddUpdateValidator = employeeAddUpdateValidator;
            _employeeData = employeeData;
        }


        public EmployeeModel GetByEmployeeNumber(string employeeNumber)
        {
            return _employeeData.GetByEmployeeNumber(employeeNumber);
        }

        public ListOfEntityResult<EmployeeModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ListOfEntityResult<EmployeeModel> GetByDateHire(DateTime dateHire)
        {
            throw new NotImplementedException();
        }

        public EntityResult<EmployeeModel> Save(EmployeeModel input, bool isNewEmployee)
        {
            var results = new EntityResult<EmployeeModel>();
            results.IsSuccess = false;

            try
            {
                // If employee number is empty or null, add new employee (assume the user want to add new user)
                if (isNewEmployee)
                {
                    DateTime dateHire = input.DateHire == DateTime.MinValue ? DateTime.Now : input.DateHire;
                    input.EmployeeNumber = this.GenerateNewEmployeeNumber(dateHire);
                }

                ValidationResult validatorResult = _employeeAddUpdateValidator.Validate(input);

                if (!validatorResult.IsValid)
                {
                    foreach (var failure in validatorResult.Errors)
                    {
                        results.Messages.Add("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                    results.IsSuccess = false;
                    return results;
                }

                if (isNewEmployee)
                {
                    if (_employeeData.Add(input) > 0)
                    {
                        var employeeDetails = _employeeData.GetByEmployeeNumber(input.EmployeeNumber);
                        results.IsSuccess = true;
                        results.Messages.Add("Successfully add new employee");
                        results.Data = employeeDetails;
                    }
                }
                else
                {
                    var employeeDetails = _employeeData.GetByEmployeeNumber(input.EmployeeNumber);

                    if (employeeDetails == null)
                    {
                        results.IsSuccess = false;
                        results.Messages.Add($"Employee with the employee number of { input.EmployeeNumber } not found!");
                        return results;
                    }

                    _mapper.Map(input, employeeDetails);

                    if (this._employeeData.Update(employeeDetails))
                    {
                        results.IsSuccess = true;
                        results.Messages.Add("Successfully update employee");
                        results.Data = employeeDetails;
                    }
                    else
                    {
                        results.IsSuccess = false;
                        results.Messages.Add("No changes made.");
                    }
                }

            }
            catch(Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add("Internal error, kindly check system logs and report this error to developer.");
            }

            return results;
        }

        public ListOfEntityResult<EmployeeModel> Search(string searchString)
        {
            throw new NotImplementedException();
        }


        // helper methods

        public string GenerateNewEmployeeNumber (DateTime dateHire)
        {
            long numberOfEmployeesWithTheSameDateHire = _employeeData.GetCountByDateHire(dateHire);
            numberOfEmployeesWithTheSameDateHire = numberOfEmployeesWithTheSameDateHire > 0 ? 
                                                    numberOfEmployeesWithTheSameDateHire + 1 
                                                    : 1;

            string newEmployeeNumber = dateHire.Year + numberOfEmployeesWithTheSameDateHire.ToString().PadLeft(4, '0');

            return newEmployeeNumber;
        }

    }
}