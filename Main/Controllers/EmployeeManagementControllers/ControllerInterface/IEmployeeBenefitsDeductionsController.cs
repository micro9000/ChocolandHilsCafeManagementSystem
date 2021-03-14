using EntitiesShared.EmployeeManagement;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.EmployeeManagementControllers.ControllerInterface
{
    public interface IEmployeeBenefitsDeductionsController
    {
        EntityResult<string> DeleteBenefit(long benefitId);
        EntityResult<EmployeeBenefitModel> SaveBenefit(EmployeeBenefitModel input, bool isNew);

        EntityResult<string> DeleteDeduction(long deductionId);
        EntityResult<EmployeeDeductionModel> SaveDeduction(EmployeeDeductionModel input, bool isNew);
    }
}
