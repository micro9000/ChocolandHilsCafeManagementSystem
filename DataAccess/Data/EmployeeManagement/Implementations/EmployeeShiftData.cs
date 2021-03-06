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
    public class EmployeeShiftData : DataManagerCRUD<EmployeeShiftModel>, IEmployeeShiftData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public EmployeeShiftData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<EmployeeShiftModel> GetAllNotDeleted ()
        {
            string query = @"SELECT * FROM EmployeeShifts WHERE isDeleted=false";
            return this.GetAll(query);
        }
    }
}
