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
    public class EmployeeShiftScheduleData : DataManagerCRUD<EmployeeShiftScheduleModel>, IEmployeeShiftScheduleData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public EmployeeShiftScheduleData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public EmployeeShiftScheduleModel GetByEmployeeNumberAndSchedDate(string employeeNumber, DateTime schedDate)
        {
            string query = @"SELECT * FROM EmployeeShiftSchedules
                            isDeleted = false AND 
                            employeeNumber=@EmployeeNumber AND
                           schedDate=@SchedDate";

            return this.GetFirstOrDefault(query, new { EmployeeNumber = employeeNumber, SchedDate = schedDate });
        }

        public List<EmployeeShiftScheduleModel> GetByEmployeeNumberAndSchedDateRange(string employeeNumber, DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT * FROM EmployeeShiftSchedules
                            isDeleted=false AND employeeNumber=@EmployeeNumber AND  
                            schedDate BETWEEN @StartDate AND @EndDate";

            return this.GetAll(query, new
            {
                EmployeeNumber = employeeNumber,
                StartDate = startDate,
                EndDate = endDate
            });
        }

        public List<EmployeeShiftScheduleModel> GetBySchedDateRange(DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT * FROM EmployeeShiftSchedules
                            isDeleted=false AND schedDate BETWEEN @StartDate AND @EndDate";

            return this.GetAll(query, new
            {
                StartDate = startDate,
                EndDate = endDate
            });
        }

        public List<EmployeeShiftScheduleModel> GetByShiftAndSchedDateRange(long shiftId, DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT * FROM EmployeeShiftSchedules
                            isDeleted=false AND shiftId=@ShiftId AND
                            schedDate BETWEEN @StartDate AND @EndDate";

            return this.GetAll(query, new
            {
                ShiftId = shiftId,
                StartDate = startDate,
                EndDate = endDate
            });
        }
    }
}
