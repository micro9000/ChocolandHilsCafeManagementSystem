using EntitiesShared.EmployeeManagement.Models;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.EmployeeManagementControllers.ControllerInterface
{
    public interface IWorkforceScheduleController
    {
        WorkforceScheduling GetWorkforceSchedule();
        EntityResult<string> Delete(long scheduleId, DateTime workDate);
        EntityResult<WorkforceScheduling> Save(WorkforceScheduling workForceSchedule);
    }
}
