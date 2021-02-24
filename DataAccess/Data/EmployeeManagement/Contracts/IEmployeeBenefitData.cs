using DapperGenericDataManager;
using DataAccess.Entities.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.EmployeeManagement.Contracts
{
    public interface IEmployeeBenefitData : IDataManagerCRUD<EmployeeBenefitModel>
    {
        List<EmployeeBenefitModel> GetAllByIsEnabled(bool isEnabled);
        List<EmployeeBenefitModel> GetByPaySched(StaticData.EmployeeBenefitsPaySched paySchedType);
        List<EmployeeBenefitModel> GetAllBySpecificMonthAndDay(int month, int day);
    }
}
