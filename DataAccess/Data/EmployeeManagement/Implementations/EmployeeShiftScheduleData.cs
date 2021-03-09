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
    public class EmployeeShiftScheduleData : DataManagerCRUD<EmployeeShiftScheduleModel>, IEmployeeShiftScheduleData
    {
        private readonly IDbConnectionFactory _dbConnFactory;
        private readonly IEmployeeShiftData _employeeShiftData;

        public EmployeeShiftScheduleData(IDbConnectionFactory dbConnFactory, IEmployeeShiftData employeeShiftData) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
            _employeeShiftData = employeeShiftData;
        }



        public EmployeeShiftScheduleModel GetByEmployeeNumberAndSchedDate(string employeeNumber, DateTime schedDate)
        {
            string query = @"SELECT * FROM EmployeeShiftSchedules
                            WHERE isDeleted=false AND isDone=false AND employeeNumber=@EmployeeNumber AND 
                            startSchedDate <= @SchedDate AND endSchedDate >= @SchedDate ORDER BY id DESC";

            var shiftSchedDetails = this.GetFirstOrDefault(query, new { EmployeeNumber = employeeNumber, SchedDate = schedDate });

            if (shiftSchedDetails != null)
            {
                shiftSchedDetails.Shift = _employeeShiftData.GetById(shiftSchedDetails.ShiftId);
            }

            return shiftSchedDetails;
        }


        public EmployeeShiftScheduleModel GetByEmployeeNumber(string employeeNumber)
        {
            string query = @"SELECT * FROM EmployeeShiftSchedules
                            WHERE isDeleted=false AND isDone=false AND employeeNumber=@EmployeeNumber ORDER BY id DESC";

            var shiftSchedDetails = this.GetFirstOrDefault(query, new { EmployeeNumber = employeeNumber });

            if (shiftSchedDetails != null)
            {
                shiftSchedDetails.Shift = _employeeShiftData.GetById(shiftSchedDetails.ShiftId);
            }

            return shiftSchedDetails;
        }

        //public List<EmployeeShiftScheduleModel> GetByEmployeeNumberAndSchedDateRange(string employeeNumber, DateTime startDate, DateTime endDate)
        //{
        //    string query = @"SELECT * FROM EmployeeShiftSchedules
        //                    WHERE isDeleted=false AND employeeNumber=@EmployeeNumber AND  
        //                    schedDate BETWEEN @StartDate AND @EndDate";

        //    return this.GetAll(query, new
        //    {
        //        EmployeeNumber = employeeNumber,
        //        StartDate = startDate,
        //        EndDate = endDate
        //    });
        //}

        //public List<EmployeeShiftScheduleModel> GetBySchedDateRange(DateTime startDate, DateTime endDate)
        //{
        //    string query = @"SELECT * FROM EmployeeShiftSchedules
        //                    WHERE isDeleted=false AND schedDate BETWEEN @StartDate AND @EndDate";

        //    return this.GetAll(query, new
        //    {
        //        StartDate = startDate,
        //        EndDate = endDate
        //    });
        //}

        //public List<EmployeeShiftScheduleModel> GetByShiftAndSchedDateRange(long shiftId, DateTime startDate, DateTime endDate)
        //{
        //    string query = @"SELECT * FROM EmployeeShiftSchedules
        //                    WHERE isDeleted=false AND shiftId=@ShiftId AND
        //                    schedDate BETWEEN @StartDate AND @EndDate";

        //    return this.GetAll(query, new
        //    {
        //        ShiftId = shiftId,
        //        StartDate = startDate,
        //        EndDate = endDate
        //    });
        //}
    }
}
