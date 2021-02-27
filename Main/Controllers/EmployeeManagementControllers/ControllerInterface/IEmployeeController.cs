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
        /// <summary>
        /// Will insert new or update existing employee record
        /// </summary>
        /// <param name="input"></param>
        /// <returns>EntityResult<EmployeeModel></returns>
        EntityResult<EmployeeModel> Save(EmployeeModel input, bool isNewEmployee);
        EntityResult<EmployeeModel> GetByEmployeeNumber(string employeeNumber);
        ListOfEntityResult<EmployeeModel> GetAll();
        ListOfEntityResult<EmployeeModel> Search(string searchString);
        ListOfEntityResult<EmployeeModel> GetByDateHire(DateTime dateHire);

        string GenerateNewEmployeeNumber(DateTime dateHire);
    }
}
