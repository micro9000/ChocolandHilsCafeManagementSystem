using DataAccess.Data.EmployeeManagement.Contracts;
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
using EntitiesShared.EmployeeManagement;

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


        public EntityResult<EmployeeModel> GetByEmployeeNumber(string employeeNumber)
        {
            var results = new EntityResult<EmployeeModel>();
            try
            {
                var employee = _employeeData.GetByEmployeeNumber(employeeNumber);
                if (employee != null)
                {
                    results.IsSuccess = true;
                    results.Messages.Add("Successfully retrieve all employee data");
                    results.Data = employee;
                }
                else
                {
                    results.IsSuccess = false;
                    results.Messages.Add("Employee details not found.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add("Internal error, kindly check system logs and report this error to developer.");
            }

            return results;
        }

        public ListOfEntityResult<EmployeeModel> GetAll()
        {
            var results = new ListOfEntityResult<EmployeeModel>();
            try
            {
                var employees = _employeeData.GetAllNotDeleted();
                results.IsSuccess = true;
                results.Messages.Add("Successfully retrieve all employee data");
                results.Data = employees;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add("Internal error, kindly check system logs and report this error to developer.");
            }

            return results;
        }

        public ListOfEntityResult<EmployeeModel> GetByDateHire(DateTime dateHire)
        {
            var results = new ListOfEntityResult<EmployeeModel>();
            try
            {
                var employees = _employeeData.GetAllByDateHire(dateHire);
                results.IsSuccess = true;
                results.Messages.Add("Successfully retrieve all employee data");
                results.Data = employees;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add("Internal error, kindly check system logs and report this error to developer.");
            }

            return results;
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
                    input.EmpNumYear = input.DateHire.Year.ToString();
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
                    else
                    {
                        results.IsSuccess = false;
                        results.Messages.Add("Unable to add new employee, kindly check system logs for possible errors.");
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
            var results = new ListOfEntityResult<EmployeeModel>();
            try
            {
                var employees = _employeeData.Search(searchString);
                results.IsSuccess = true;
                results.Messages.Add("Successfully retrieve all employee data");
                results.Data = employees;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add("Internal error, kindly check system logs and report this error to developer.");
            }

            return results;
        }


        // helper methods

        public string GenerateNewEmployeeNumber (DateTime dateHire)
        {
            long numberOfEmployeesWithTheSameDateHire = _employeeData.GetCountByEmpNumYear(dateHire);
            numberOfEmployeesWithTheSameDateHire = numberOfEmployeesWithTheSameDateHire > 0 ? 
                                                    numberOfEmployeesWithTheSameDateHire + 1 
                                                    : 1;

            string newEmployeeNumber = dateHire.Year + numberOfEmployeesWithTheSameDateHire.ToString().PadLeft(4, '0');

            return newEmployeeNumber;
        }

    }
}
