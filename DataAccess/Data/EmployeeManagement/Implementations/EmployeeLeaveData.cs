using DapperGenericDataManager;
using DataAccess.Data.EmployeeManagement.Contracts;
using DataAccess.Entities.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.EmployeeManagement.Implementations
{
    public class EmployeeLeaveData : DataManagerCRUD<EmployeeLeaveModel>, IEmployeeLeaveData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public EmployeeLeaveData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<EmployeeLeaveModel> GetAllByEmployeeNumberAndLeaveId(string employeeNumber, long leaveId, int year)
        {
            string query = @"SELECT * FROM EmployeeLeaves
                            WHERE isDeleted=false AND leaveId=@LeaveId AND
                            employeeNumber=@EmployeeNumber AND currentYear=@Year";

            return this.GetAll(query, new
            {
                LeaveId = leaveId,
                EmployeeNumber = employeeNumber,
                Year = year
            });
        }

        public List<EmployeeLeaveModel> GetAllByEmployeeNumberAndYear(string employeeNumber, int year)
        {
            string query = @"SELECT * FROM EmployeeLeaves
                            WHERE isDeleted=false AND employeeNumber=@EmployeeNumber AND currentYear=@Year";

            return this.GetAll(query, new
            {
                EmployeeNumber = employeeNumber,
                Year = year
            });
        }
    }
}
