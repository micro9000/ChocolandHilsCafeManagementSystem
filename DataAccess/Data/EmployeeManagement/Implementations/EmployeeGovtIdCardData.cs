using DapperGenericDataManager;
using DataAccess.Data.EmployeeManagement.Contracts;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.EmployeeManagement.Implementations
{
    public class EmployeeGovtIdCardData : DataManagerCRUD<EmployeeGovtIdCardModel>, IEmployeeGovtIdCardData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public EmployeeGovtIdCardData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<EmployeeGovtIdCardModel> GetAllByEmployeeNumber(string employeeNumber)
        {
            string query = @"SELECT * FROM EmployeeGovtIdCards
                            WHERE isDeleted=false AND employeeNumber=@EmployeeNumber";

            return this.GetAll(query, new { EmployeeNumber = employeeNumber });
        }

        public List<EmployeeGovtIdCardModel> GetAllByGovtAgency(int govtAgencyId)
        {
            string query = @"SELECT * FROM EmployeeGovtIdCards
                            WHERE isDeleted=false AND govtAgencyId=@GovtAgencyId";

            return this.GetAll(query, new { GovtAgencyId = govtAgencyId });
        }

        public EmployeeGovtIdCardModel GetByEmployeeIdNumber(string employeeIdNumber)
        {
            string query = @"SELECT * FROM EmployeeGovtIdCards
                            WHERE isDeleted=false AND employeeIdNumber=@EmployeeIdNumber";

            return this.GetFirstOrDefault(query, new { EmployeeIdNumber = employeeIdNumber });
        }
    }
}
