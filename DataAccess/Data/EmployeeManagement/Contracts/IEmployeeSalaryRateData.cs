using DapperGenericDataManager;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.EmployeeManagement.Contracts
{
    public interface IEmployeeSalaryRateData : IDataManagerCRUD<EmployeeSalaryRateModel>
    {
        EmployeeSalaryRateModel GetByEmployeeNumber(string employeeNumber);
        //List<EmployeeSalaryRateModel> GetBySalaryRateRange(decimal startSalary, decimal endSalary);
        //List<EmployeeSalaryRateModel> GetByMonthlyRateRange (decimal startSalary, decimal endSalary);
        //List<EmployeeSalaryRateModel> GetByDailyRateRange(decimal startSalary, decimal endSalary);
    }
}
