using DapperGenericDataManager;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.EmployeeManagement.Contracts
{
    public interface IEmployeeLeaveData : IDataManagerCRUD<EmployeeLeaveModel>
    {
        List<EmployeeLeaveModel> GetAllByEmployeeNumberAndYear(string employeeNumber, int year);
        List<EmployeeLeaveModel> GetAllByEmployeeNumberAndLeaveId(string employeeNumber, long leaveId, int year);
        List<EmployeeLeaveModel> GetAllByEmployeeNumberAndDateRange(string employeeNumber, int year, DateTime startDate, DateTime endDate);
    }
}
