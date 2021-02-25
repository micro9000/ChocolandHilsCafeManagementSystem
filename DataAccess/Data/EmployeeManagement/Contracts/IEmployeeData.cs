using DapperGenericDataManager;
using DataAccess.Entities.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.EmployeeManagement.Contracts
{
    public interface IEmployeeData : IDataManagerCRUD<EmployeeModel>
    {
        long GetCountByDateHire(DateTime dateHire);
        EmployeeModel GetByEmployeeNumber(string employeeNumber);
        List<EmployeeModel> GetAllByDateHire(DateTime dateHire);
        List<EmployeeModel> Search(string search);
    }
}
