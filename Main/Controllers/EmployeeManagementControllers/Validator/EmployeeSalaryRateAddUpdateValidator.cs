using EntitiesShared.EmployeeManagement;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.EmployeeManagementControllers.Validator
{
    public class EmployeeSalaryRateAddUpdateValidator : AbstractValidator<EmployeeSalaryRateModel>
    {
        public EmployeeSalaryRateAddUpdateValidator()
        {
            RuleFor(x => x.SalaryRate).GreaterThan(0);
            RuleFor(x => x.HalfMonthRate).GreaterThan(0);
            RuleFor(x => x.DailyRate).GreaterThan(0);
        }
    }
}
