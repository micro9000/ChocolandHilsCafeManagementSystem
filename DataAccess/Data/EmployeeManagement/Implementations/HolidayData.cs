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
    public class HolidayData : DataManagerCRUD<HolidayModel>, IHolidayData
    {

        private readonly IDbConnectionFactory _dbConnFactory;
        private readonly IEmployeeShiftData _employeeShiftData;

        public HolidayData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<HolidayModel> GetAllNotDeleted()
        {
            string query = "SELECT * FROM Holidays WHERE isDeleted=false";
            return this.GetAll(query);
        }
    }
}
