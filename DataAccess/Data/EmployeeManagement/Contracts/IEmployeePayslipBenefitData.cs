using DapperGenericDataManager;
using DataAccess.Entities.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.EmployeeManagement.Contracts
{
    public interface IEmployeePayslipBenefitData : IDataManagerCRUD<EmployeePayslipBenefitModel>
    {
        List<EmployeePayslipBenefitModel> GetAllByPayslipId(long payslipId);
        List<EmployeePayslipBenefitModel> GetAllByPayslipIdAndEmployeeNumber(long payslipId, string employeeNumber);
    }
}
