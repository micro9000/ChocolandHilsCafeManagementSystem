using DapperGenericDataManager;
using EntitiesShared.PayrollManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.PayrollManagement.Contracts
{
    public interface IEmployeeCashAdvanceRequestData : IDataManagerCRUD<EmployeeCashAdvanceRequestModel>
    {
        List<EmployeeCashAdvanceRequestModel> GetAllNotDeletedByEmployee(string employeeNumber);
    }
}
