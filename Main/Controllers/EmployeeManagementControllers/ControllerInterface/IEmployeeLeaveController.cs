using EntitiesShared.EmployeeManagement;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.EmployeeManagementControllers.ControllerInterface
{
    public interface IEmployeeLeaveController
    {
        EntityResult<EmployeeLeaveModel> Save(EmployeeLeaveModel input, bool isNew);
        EntityResult<string> Delete(long empLeaveId, string employeeNumber);

        //EntityResult<EmployeeLeaveModel> GetById(long Id);
        //ListOfEntityResult<EmployeeLeaveModel> GetAllByEmployeeAndYear();
    }
}
