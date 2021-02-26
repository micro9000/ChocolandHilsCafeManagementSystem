using DapperGenericDataManager;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.EmployeeManagement.Contracts
{
    public interface IEmployeeAttendanceData : IDataManagerCRUD<EmployeeAttendanceModel>
    {
        List<EmployeeAttendanceModel> GetAllByEmployeeNumberAndWorkDateRange(string employeeNumber, DateTime startDate, DateTime endDate);
        List<EmployeeAttendanceModel> GetAllByWorkDateRange(DateTime startDate, DateTime endDate);
        List<EmployeeAttendanceModel> GetAllByShiftIdAndWorkDateRange(long shiftSchedId, DateTime startDate, DateTime endDate);
        List<EmployeeAttendanceModel> GetAllLateEmployeesByWorkDateRange(DateTime startDate, DateTime endDate);
        List<EmployeeAttendanceModel> GetAllEmployeesWithUndertimeByWorkDateRange(DateTime startDate, DateTime endDate);
    }
}
