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
    public class EmployeeAttendanceData : DataManagerCRUD<EmployeeAttendanceModel>, IEmployeeAttendanceData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public EmployeeAttendanceData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<EmployeeAttendanceModel> GetAllByEmployeeNumberAndWorkDateRange(string employeeNumber, DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT * FROM EmployeeAttendance
                             WHERE isDeleted=false AND employeeNumber=@EmployeeNumber AND
                                workDate BETWEEN @StartDate AND @EndDate";

            return this.GetAll(query, new {
                EmployeeNumber = employeeNumber,
                StartDate = startDate,
                EndDate = endDate
            });
        }

        public List<EmployeeAttendanceModel> GetAllByShiftIdAndWorkDateRange(long shiftSchedId, DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT * FROM EmployeeAttendance
                             WHERE isDeleted=false AND shiftSchedId=@ShiftSchedId AND
                                workDate BETWEEN @StartDate AND @EndDate";

            return this.GetAll(query, new
            {
                ShiftSchedId = shiftSchedId,
                StartDate = startDate,
                EndDate = endDate
            });
        }

        public List<EmployeeAttendanceModel> GetAllByWorkDateRange(DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT * FROM EmployeeAttendance
                             WHERE isDeleted=false AND workDate BETWEEN @StartDate AND @EndDate";

            return this.GetAll(query, new
            {
                StartDate = startDate,
                EndDate = endDate
            });
        }

        public List<EmployeeAttendanceModel> GetAllEmployeesWithUndertimeByWorkDateRange(DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT * FROM EmployeeAttendance
                             WHERE isDeleted=false AND lateMins > 0 AND workDate BETWEEN @StartDate AND @EndDate";

            return this.GetAll(query, new
            {
                StartDate = startDate,
                EndDate = endDate
            });
        }

        public List<EmployeeAttendanceModel> GetAllLateEmployeesByWorkDateRange(DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT * FROM EmployeeAttendance
                             WHERE isDeleted=false AND underTimeMins > 0 AND workDate BETWEEN @StartDate AND @EndDate";

            return this.GetAll(query, new
            {
                StartDate = startDate,
                EndDate = endDate
            });
        }
    }
}
