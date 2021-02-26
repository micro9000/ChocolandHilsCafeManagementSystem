using DapperGenericDataManager;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.EmployeeManagement.Contracts
{
    public interface IEmployeeGovtContributionData : IDataManagerCRUD<EmployeeGovtContributionModel>
    {
        List<EmployeeGovtContributionModel> GetAllByEmployeeNumber(string employeeNumber);
    }
}
