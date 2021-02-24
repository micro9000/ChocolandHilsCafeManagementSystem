using DapperGenericDataManager;
using DataAccess.Entities.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.EmployeeManagement.Contracts
{
    public interface IEmployeeShiftScheduleData : IDataManagerCRUD<EmployeeShiftScheduleModel>
    {
        EmployeeShiftScheduleModel GetByEmployeeNumberAndSchedDate(string employeeNumber, DateTime schedDate);
        List<EmployeeShiftScheduleModel> GetByShiftAndSchedDateRange(long shiftId, DateTime startDate, DateTime endDate);
        List<EmployeeShiftScheduleModel> GetByEmployeeNumberAndSchedDateRange (string employeeNumber, DateTime startDate, DateTime endDate);
        List<EmployeeShiftScheduleModel> GetBySchedDateRange(DateTime startDate, DateTime endDate);
    }
}
