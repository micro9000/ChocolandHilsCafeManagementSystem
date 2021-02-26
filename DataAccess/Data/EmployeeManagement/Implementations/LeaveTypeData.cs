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
    public class LeaveTypeData : DataManagerCRUD<LeaveTypeModel>, ILeaveTypeData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public LeaveTypeData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<LeaveTypeModel> GetAllByIsActive(bool isActive)
        {
            string query = @"SELECT * FROM LeaveTypeModel WHERE isDeleted=False AND isActive=@IsActive";
            return this.GetAll(query, new { IsActive = isActive });
        }
    }
}
