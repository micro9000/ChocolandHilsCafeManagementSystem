using EntitiesShared.OtherDataManagement;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.OtherDataController.Validator
{
    public class GovernmentAgencyAddUpdateValidator : AbstractValidator<GovernmentAgencyModel>
    {
        public GovernmentAgencyAddUpdateValidator()
        {
            RuleFor(x => x.GovtAgency).NotEmpty();
        }
    }
}
