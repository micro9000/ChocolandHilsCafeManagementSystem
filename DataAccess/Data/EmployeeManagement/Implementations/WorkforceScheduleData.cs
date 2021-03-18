using DapperGenericDataManager;
using DataAccess.Data.EmployeeManagement.Contracts;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DataAccess.Data.EmployeeManagement.Implementations
{
    public class WorkforceScheduleData : DataManagerCRUD<WorkforceScheduleModel>, IWorkforceScheduleData
    {
        private readonly IDbConnectionFactory _dbConnFactory;
        private readonly IEmployeeData _employeeData;
        private readonly IEmployeeShiftData _employeeShiftData;

        public WorkforceScheduleData(IDbConnectionFactory dbConnFactory, 
                                        IEmployeeData employeeData,
                                        IEmployeeShiftData employeeShiftData) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
            _employeeData = employeeData;
            _employeeShiftData = employeeShiftData;
        }

        public WorkforceScheduleModel GetByIdAndWorkdate(long schedId, DateTime workDate)
        {
            string query = @"SELECT * FROM WorkforceSchedules 
                            WHERE isDeleted=false AND isDone = false AND
                                id=@SchedId AND workDate=@WorkDate";

            var results = this.GetFirstOrDefault(query, new
            {
                SchedId = schedId,
                WorkDate = workDate
            });

            if (results != null)
            {
                results.Employee = _employeeData.GetByEmployeeNumber(results.EmployeeNumber);
            }

            return results;

            //string query = @"SELECT * 
            //                FROM WorkforceSchedules AS WFS
            //                JOIN Employees AS E ON E.EmployeeNumber = WFS.employeeNumber
            //                WHERE WFS.isDeleted=false AND WFS.isDone=false AND
            //                WFS.id=@SchedId AND WFS.workDate=@WorkDate";

            //List<WorkforceScheduleModel> results = new List<WorkforceScheduleModel>();

            //using (var conn = _dbConnFactory.CreateConnection())
            //{
            //    results = conn.Query<WorkforceScheduleModel, EmployeeModel, WorkforceScheduleModel>(query,
            //            (WFS, E) => {
            //                WFS.Employee = E;
            //                return WFS;
            //            }).ToList();
            //    conn.Close();
            //}

            //return results.FirstOrDefault();
        }

        public List<WorkforceScheduleModel> GetAllNotYetDone()
        {
            string query = @"SELECT * FROM WorkforceSchedules WHERE isDeleted=false AND isDone = false";

            var results = this.GetAll(query);

            if(results != null)
            {
                foreach(var sched in results)
                {
                    // need to do this, to get also the employee shift
                    sched.Employee = _employeeData.GetByEmployeeNumber(sched.EmployeeNumber);
                }
            }

            return results;

            //string query = @"SELECT *
            //                    FROM WorkforceSchedules AS WFS
            //                    JOIN Employees AS E ON E.EmployeeNumber = WFS.employeeNumber
            //                    WHERE WFS.isDeleted=false AND WFS.isDone = false";

            //List<WorkforceScheduleModel> results = new List<WorkforceScheduleModel>();

            //using (var conn = _dbConnFactory.CreateConnection())
            //{
            //    results = conn.Query<WorkforceScheduleModel, EmployeeModel, WorkforceScheduleModel>(query,
            //            (WFS, E) => {
            //                WFS.Employee = E;
            //                return WFS;
            //            }).ToList();
            //    conn.Close();
            //}

            //return results;
        }

    }
}
