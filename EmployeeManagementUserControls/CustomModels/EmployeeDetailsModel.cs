using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementUserControls.CustomModels
{
    public class EmployeeDetailsModel
    {
        private EmployeeModel employee = new EmployeeModel();

        public EmployeeModel Employee
        {
            get { return employee = new EmployeeModel(); }
            set { employee = value; }
        }


        private List<EmployeeGovtIdCardTempModel> employeeGovtIdCards = new List<EmployeeGovtIdCardTempModel>();

        public List<EmployeeGovtIdCardTempModel> EmployeeGovtIdCards
        {
            get { return employeeGovtIdCards; }
            set { employeeGovtIdCards = value; }
        }


        private EmployeeSalaryRateModel employeeSalary = new EmployeeSalaryRateModel();

        public EmployeeSalaryRateModel EmployeeSalary
        {
            get { return employeeSalary; }
            set { employeeSalary = value; }
        }

    }
}
