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
        List<EmployeeAttendanceModel> GetAllAttendanceRecordByWorkDate(DateTime workDate);
        EmployeeAttendanceModel GetEmployeeAttendanceByWorkDate(string employeeNumber, DateTime workDate);
    }
}
