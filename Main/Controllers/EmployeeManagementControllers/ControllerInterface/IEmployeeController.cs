﻿using EmployeeManagementUserControls.CustomModels;
using EntitiesShared.EmployeeManagement;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.EmployeeManagementControllers.ControllerInterface
{
    public interface IEmployeeController
    {
        EntityResult<EmployeeDetailsModel> SaveEmployeeDetails(bool isNewEmployee, EmployeeModel employee, List<EmployeeGovtIdCardTempModel> idCards);
        List<EmployeeGovtIdCardTempModel> GetAllEmployeeIdCardsMapToCustomModel(string employeeNumber);

        EntityResult<EmployeeModel> GetByEmployeeNumber(string employeeNumber);
        ListOfEntityResult<EmployeeModel> GetAll();
        ListOfEntityResult<EmployeeModel> Search(string searchString);
        ListOfEntityResult<EmployeeModel> GetByDateHire(DateTime dateHire);

        string GenerateNewEmployeeNumber(DateTime dateHire);
    }
}
