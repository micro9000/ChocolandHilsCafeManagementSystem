using EntitiesShared.PayrollManagement;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.RequestControllers.ControllerInterface
{
    public interface IEmployeeCashAdvanceRequestController
    {
        EntityResult<string> CancelRequest(long requestId);
        EntityResult<EmployeeCashAdvanceRequestModel> Save(EmployeeCashAdvanceRequestModel input, bool isNew);

        List<EmployeeCashAdvanceRequestModel> GetAllByEmployee(string employeeNumber);
    }
}
