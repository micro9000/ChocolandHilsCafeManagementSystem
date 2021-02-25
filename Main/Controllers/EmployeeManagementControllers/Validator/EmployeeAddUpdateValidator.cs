﻿using DataAccess.Entities.EmployeeManagement;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.EmployeeManagementControllers.Validator
{
    public class EmployeeAddUpdateValidator : AbstractValidator<EmployeeModel>
    {
        public EmployeeAddUpdateValidator()
        {
            RuleFor(e => e.EmployeeNumber).NotEmpty();
            RuleFor(e => e.FirstName).NotEmpty();
            RuleFor(e => e.LastName).NotEmpty();
            RuleFor(e => e.Address).NotEmpty();
            RuleFor(e => e.MobileNumber).NotEmpty();
            RuleFor(e => e.EmailAddress).NotEmpty().EmailAddress();
            RuleFor(e => e.BirthDate).NotEmpty();
            RuleFor(e => e.BranchAssign).NotEmpty();
            RuleFor(e => e.DateHire).NotEmpty();
        }
    }
}
