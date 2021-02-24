using DapperGenericDataManager;
using DataAccess.Entities.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.EmployeeManagement.Contracts
{
    public interface IEmployeePayslipData : IDataManagerCRUD<EmployeePayslipModel>
    {
        List<EmployeePayslipModel> GetAllByEmployeeNumberAndShiftDateRange(string employeeNumber, DateTime startShiftDate, DateTime endShiftDate);
        List<EmployeePayslipModel> GetAllByShiftDateRange(DateTime startShiftDate, DateTime endShiftDate);
        List<EmployeePayslipModel> GetAllByPaydayDate(DateTime paydayDate);
    }
}
