﻿using EntitiesShared.EmployeeManagement;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.EmployeeManagementControllers.Validator
{
    public class LeaveTypeAddUpdateValidator : AbstractValidator<LeaveTypeModel>
    {
        public LeaveTypeAddUpdateValidator()
        {
            RuleFor(x => x.LeaveType).NotEmpty();
            RuleFor(x => x.NumberOfDays).NotEmpty().NotEqual(0);
        }
    }
}