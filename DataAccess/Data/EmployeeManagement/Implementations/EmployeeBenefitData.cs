using DapperGenericDataManager;
using DataAccess.Data.EmployeeManagement.Contracts;
using EntitiesShared;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.EmployeeManagement.Implementations
{
    public class EmployeeBenefitData : DataManagerCRUD<EmployeeBenefitModel>, IEmployeeBenefitData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public EmployeeBenefitData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<EmployeeBenefitModel> GetAllByIsEnabled(bool isEnabled)
        {
            string query = @"SELECT * FROM EmployeeBenefits
                            WHERE isDeleted=false AND isEnabled=@IsEnabled";

            return this.GetAll(query, new { IsEnabled = isEnabled });
        }

        public List<EmployeeBenefitModel> GetAllBySpecificMonthAndDay(int month, int day)
        {
            string query = @"SELECT * FROM EmployeeBenefits
                            WHERE isDeleted=false AND isEnabled=true AND 
                            payMonth=@Month AND payDay=@Day";
            return this.GetAll(query, new { Month = month, Day = day });
        }

        public List<EmployeeBenefitModel> GetByPaySched(StaticData.EmployeeBenefitsPaySched paySchedType)
        {
            string query = @"SELECT * FROM EmployeeBenefits
                            WHERE isDeleted=false AND isEnabled=true AND paySched=@PaySched";
            return this.GetAll(query, new { PaySched = paySchedType.ToString() });
        }
    }
}
