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
using System.Transactions;
using Shared.CustomExceptions;
using EntitiesShared.EmployeeManagement.Models;

namespace Main.Controllers.EmployeeManagementControllers
{
    public class EmployeeController : IEmployeeController
    {
        private readonly ILogger<LoginFrm> _logger;
        private readonly IMapper _mapper;
        private readonly EmployeeAddUpdateValidator _employeeAddUpdateValidator;
        private readonly EmployeeSalaryRateAddUpdateValidator _employeeSalaryRateValidator;
        private readonly IEmployeeData _employeeData;
        private readonly IEmployeeGovtIdCardData _employeeGovtIdCardData;
        private readonly IEmployeeSalaryRateData _employeeSalaryRateData;

        public EmployeeController(ILogger<LoginFrm> logger,
                                IMapper mapper,
                                EmployeeAddUpdateValidator employeeAddUpdateValidator,
                                EmployeeSalaryRateAddUpdateValidator employeeSalaryRateValidator,
                                IEmployeeData employeeData,
                                IEmployeeGovtIdCardData employeeGovtIdCardData,
                                IEmployeeSalaryRateData employeeSalaryRateData)
        {
            _logger = logger;
            _mapper = mapper;
            _employeeAddUpdateValidator = employeeAddUpdateValidator;
            _employeeSalaryRateValidator = employeeSalaryRateValidator;
            _employeeData = employeeData;
            _employeeGovtIdCardData = employeeGovtIdCardData;
            _employeeSalaryRateData = employeeSalaryRateData;
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


        public EntityResult<EmployeeDetailsModel> SaveEmployeeDetails(bool isNewEmployee, 
                                                                        EmployeeModel employee, 
                                                                        List<EmployeeGovtIdCardTempModel> idCards,
                                                                        EmployeeSalaryRateModel salaryRate)
        {
            var results = new EntityResult<EmployeeDetailsModel>();
            results.Data = new EmployeeDetailsModel();

            try
            {
                using (var transaction = new TransactionScope())
                {
                    var saveBasicInfoResults = this.SaveEmployeeBasicDetails(employee, isNewEmployee);

                    if (saveBasicInfoResults.IsSuccess == false)
                    {
                        string errs = "";
                        foreach (var err in saveBasicInfoResults.Messages)
                        {
                            errs += err + "\n";
                        }
                        throw new ScopeTransactionException(errs);
                    }

                    var saveEmployeeGovtIdCards = this.SaveEmployeeGovtIdCards(idCards, saveBasicInfoResults.Data.EmployeeNumber);

                    if (saveBasicInfoResults.IsSuccess == false)
                    {
                        string errs = "";
                        foreach (var err in saveBasicInfoResults.Messages)
                        {
                            errs += err + "\n";
                        }
                        throw new ScopeTransactionException(errs);
                    }

                    var saveEmployeeSalaryRate = this.SaveEmployeeSalaryRate(salaryRate, saveBasicInfoResults.Data.EmployeeNumber);

                    if (saveEmployeeSalaryRate.IsSuccess == false)
                    {
                        string errs = "";
                        foreach (var err in saveEmployeeSalaryRate.Messages)
                        {
                            errs += err + "\n";
                        }
                        throw new ScopeTransactionException(errs);
                    }

                    // Add additional save transaction here

                    results.IsSuccess = true;
                    results.Messages.Add("Employee details saved successfully.");

                    results.Data.Employee = saveBasicInfoResults.Data; // Employee basic details
                    results.Data.EmployeeGovtIdCards = saveEmployeeGovtIdCards.Data; // Employee govt. id cards
                    results.Data.EmployeeSalary = saveEmployeeSalaryRate.Data;

                    transaction.Complete();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add("Internal error, kindly check system logs and report this error to developer. \n" + ex.Message);
            }

            return results;
        }

        private EntityResult<EmployeeModel> SaveEmployeeBasicDetails(EmployeeModel input, bool isNewEmployee)
        {
            var results = new EntityResult<EmployeeModel>();
            results.IsSuccess = false;

            // If employee number is empty or null, add new employee (assume the user want to add new user)
            if (isNewEmployee)
            {
                DateTime dateHire = input.DateHire == DateTime.MinValue ? DateTime.Now : input.DateHire;
                input.EmployeeNumber = this.GenerateNewEmployeeNumber(dateHire);
                input.EmpNumYear = input.DateHire.Year.ToString();
            }

            ValidationResult validationResult = _employeeAddUpdateValidator.Validate(input);

            if (!validationResult.IsValid)
            {
                foreach (var failure in validationResult.Errors)
                {
                    results.Messages.Add("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
                results.IsSuccess = false;
                return results;
            }

            if (isNewEmployee)
            {
                // Save new employee
                if (_employeeData.Add(input) > 0)
                {
                    var employeeDetails = _employeeData.GetByEmployeeNumber(input.EmployeeNumber);
                    results.IsSuccess = true;
                    results.Messages.Add("Successfully add new employee");
                    results.Data = employeeDetails;
                }
                else
                {
                    throw new Exception("Unable to add new employee, kindly check system logs for possible errors.");
                }
            }
            else
            {
                var employeeDetails = _employeeData.GetByEmployeeNumber(input.EmployeeNumber);

                if (employeeDetails == null)
                {
                    throw new Exception($"Employee with the employee number of { input.EmployeeNumber } not found!");
                }

                results.Data = employeeDetails;

                _mapper.Map(input, employeeDetails);

                // Update employee details
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

            return results;
        }

        public List<EmployeeGovtIdCardTempModel> GetAllEmployeeIdCardsMapToCustomModel(string employeeNumber)
        {
            // id cards in our database
            var employeeIdCardsInDB = _employeeGovtIdCardData.GetAllByEmployeeNumber(employeeNumber);

            // map all id cards into custom model
            // from our user control
            var employeeIdCards = new List<EmployeeGovtIdCardTempModel>();
            foreach (var idCard in employeeIdCardsInDB)
            {
                employeeIdCards.Add(new EmployeeGovtIdCardTempModel
                {
                    IsNeedToUpdate = false,
                    IsExisting = true,
                    EmployeeGovtIdCard = idCard
                });
            }

            return employeeIdCards;
        }


        public EntityResult<EmployeeSalaryRateModel> GetEmployeeSalaryRateByEmployeeNumber(string employeeNumber)
        {
            var results = new EntityResult<EmployeeSalaryRateModel>();

            try
            {
                var salaryRate = _employeeSalaryRateData.GetByEmployeeNumber(employeeNumber);
                results.IsSuccess = true;
                results.Messages.Add("Successfully retrieve employee salary rate.");
                results.Data = salaryRate;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add("Internal error, kindly check system logs and report this error to developer.");
            }

            return results;
        }


        private ListOfEntityResult<EmployeeGovtIdCardTempModel> SaveEmployeeGovtIdCards(List<EmployeeGovtIdCardTempModel> idCards, string employeeNumber)
        {
            var results = new ListOfEntityResult<EmployeeGovtIdCardTempModel>();
            results.IsSuccess = false;

            if (string.IsNullOrEmpty(employeeNumber))
            {
                throw new Exception("Invalid lotnumber");
            }

            var employeeDetails = _employeeData.GetByEmployeeNumber(employeeNumber);

            if (employeeDetails == null)
            {
                throw new Exception("User not found.");
            }

            if (idCards != null)
            {
                foreach (var idCard in idCards)
                {
                    // add the employee number
                    idCard.EmployeeGovtIdCard.EmployeeNumber = employeeNumber;

                    if (idCard.IsExisting == true)
                    {
                        _employeeGovtIdCardData.Update(idCard.EmployeeGovtIdCard);
                    }
                    else
                    {
                        _employeeGovtIdCardData.Add(idCard.EmployeeGovtIdCard);
                    }
                }

                results.IsSuccess = true;
                results.Data = GetAllEmployeeIdCardsMapToCustomModel(employeeNumber);
            }

            return results;
        }


        private EntityResult<EmployeeSalaryRateModel> SaveEmployeeSalaryRate(EmployeeSalaryRateModel salaryRate, string employeeNumber)
        {

            var results = new EntityResult<EmployeeSalaryRateModel>();
            results.IsSuccess = false;


            ValidationResult validationResult = _employeeSalaryRateValidator.Validate(salaryRate);

            if (!validationResult.IsValid)
            {
                foreach (var failure in validationResult.Errors)
                {
                    results.Messages.Add("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
                results.IsSuccess = false;
                return results;
            }

            var existingSalaryRate = _employeeSalaryRateData.GetByEmployeeNumber(employeeNumber);

            if (existingSalaryRate == null)
            {
                salaryRate.EmployeeNumber = employeeNumber;

                if (_employeeSalaryRateData.Add(salaryRate) > 0)
                {
                    existingSalaryRate = _employeeSalaryRateData.GetByEmployeeNumber(employeeNumber);
                    results.IsSuccess = true;
                    results.Messages.Add("Successfully save employee salary rate.");
                    results.Data = existingSalaryRate;
                }
                else
                {
                    throw new Exception("Unable to save employee salary rate, kindly check system logs for possible errors.");
                }
            }
            else
            {
                _mapper.Map(salaryRate, existingSalaryRate);

                if (_employeeSalaryRateData.Update(existingSalaryRate) == true)
                {
                    results.IsSuccess = true;
                    results.Messages.Add("Successfully save employee salary rate.");
                    results.Data = existingSalaryRate;
                }
                else
                {
                    results.IsSuccess = false;
                    results.Messages.Add("No changes made on employee salary rate.");
                }
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



        public EntityResult<EmployeeDetailsModel> GetEmployeeFullInformations(string employeeNumber)
        {
            var results = new EntityResult<EmployeeDetailsModel>();
            results.Data = new EmployeeDetailsModel();

            try
            {
                results.Data.Employee = this._employeeData.GetByEmployeeNumber(employeeNumber);
                results.Data.EmployeeGovtIdCards = this.GetAllEmployeeIdCardsMapToCustomModel(employeeNumber);
                results.Data.EmployeeSalary = this.GetEmployeeSalaryRateByEmployeeNumber(employeeNumber).Data;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } - ${ex.StackTrace}");
                results.Messages.Add("Internal error, kindly check system logs and report this error to developer. \n" + ex.Message);
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
