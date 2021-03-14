using DataAccess.Data.EmployeeManagement.Contracts;
using EntitiesShared.EmployeeManagement;
using Main.Controllers.EmployeeManagementControllers.ControllerInterface;
using Microsoft.Extensions.Logging;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.EmployeeManagementControllers
{
    public class EmployeeBenefitsDeductionsController : IEmployeeBenefitsDeductionsController
    {
        private readonly ILogger<EmployeeBenefitsDeductionsController> _logger;
        private readonly IEmployeeBenefitData _employeeBenefitData;
        private readonly IEmployeeDeductionData _employeeDeductionData;

        public EmployeeBenefitsDeductionsController(ILogger<EmployeeBenefitsDeductionsController> logger,
                                                    IEmployeeBenefitData employeeBenefitData,
                                                    IEmployeeDeductionData employeeDeductionData)
        {
            _logger = logger;
            _employeeBenefitData = employeeBenefitData;
            _employeeDeductionData = employeeDeductionData;
        }

        #region Benefits CRUD

        public EntityResult<string> DeleteBenefit(long benefitId)
        {
            var results = new EntityResult<string>();

            try
            {
                var benefitDetails = _employeeBenefitData.Get(benefitId);

                if (benefitDetails != null)
                {
                    benefitDetails.IsDeleted = true;
                    benefitDetails.DeletedAt = DateTime.Now;

                    results.IsSuccess = _employeeBenefitData.Update(benefitDetails);
                    results.Messages.Add("Benefit deleted");
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


        public EntityResult<EmployeeBenefitModel> SaveBenefit(EmployeeBenefitModel input, bool isNew)
        {
            var results = new EntityResult<EmployeeBenefitModel>();
            results.IsSuccess = false;

            try
            {
                if (isNew)
                {
                    long benefitId = _employeeBenefitData.Add(input);
                    if (benefitId > 0)
                    {
                        var benefitDetails = _employeeBenefitData.Get(benefitId);

                        results.IsSuccess = true;
                        results.Messages.Add("Successfully add new benefit.");
                        results.Data = benefitDetails;
                    }
                    else
                    {
                        results.IsSuccess = false;
                        results.Messages.Add("Unable to add new benefit, kindly check system logs for possible errors.");
                    }
                }
                else
                {
                    var benefitDetails = _employeeBenefitData.Get(input.Id);

                    benefitDetails.Amount = input.Amount;
                    benefitDetails.BenefitTitle = input.BenefitTitle;

                    if (benefitDetails != null)
                    {
                        if (this._employeeBenefitData.Update(benefitDetails))
                        {
                            results.IsSuccess = true;
                            results.Messages.Add("Successfully update benefit details.");
                            results.Data = benefitDetails;
                        }
                        else
                        {
                            results.IsSuccess = false;
                            results.Messages.Add("No changes made.");
                        }
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


        #endregion




        #region Deductions CRUD

        public EntityResult<string> DeleteDeduction(long deductionId)
        {
            var results = new EntityResult<string>();

            try
            {
                var deductionDetails = _employeeDeductionData.Get(deductionId);

                if (deductionDetails != null)
                {
                    deductionDetails.IsDeleted = true;
                    deductionDetails.DeletedAt = DateTime.Now;

                    results.IsSuccess = _employeeDeductionData.Update(deductionDetails);
                    results.Messages.Add("Deduction deleted");
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


        public EntityResult<EmployeeDeductionModel> SaveDeduction(EmployeeDeductionModel input, bool isNew)
        {
            var results = new EntityResult<EmployeeDeductionModel>();
            results.IsSuccess = false;

            try
            {
                if (isNew)
                {
                    long deductinId = _employeeDeductionData.Add(input);
                    if (deductinId > 0)
                    {
                        var deductionDetails = _employeeDeductionData.Get(deductinId);

                        results.IsSuccess = true;
                        results.Messages.Add("Successfully add new deduction.");
                        results.Data = deductionDetails;
                    }
                    else
                    {
                        results.IsSuccess = false;
                        results.Messages.Add("Unable to add new deduction, kindly check system logs for possible errors.");
                    }
                }
                else
                {
                    var deductionDetails = _employeeDeductionData.Get(input.Id);

                    deductionDetails.Amount = input.Amount;
                    deductionDetails.DeductionTitle = input.DeductionTitle;

                    if (deductionDetails != null)
                    {
                        if (this._employeeDeductionData.Update(deductionDetails))
                        {
                            results.IsSuccess = true;
                            results.Messages.Add("Successfully update deduction details.");
                            results.Data = deductionDetails;
                        }
                        else
                        {
                            results.IsSuccess = false;
                            results.Messages.Add("No changes made.");
                        }
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

        #endregion


    }
}
