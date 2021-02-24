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
    public class EmployeePayslipData : DataManagerCRUD<EmployeePayslipModel>, IEmployeePayslipData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public EmployeePayslipData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<EmployeePayslipModel> GetAllByEmployeeNumberAndShiftDateRange(string employeeNumber, DateTime startShiftDate, DateTime endShiftDate)
        {
            string query = @"SELECT * FROM EmployeePayslips
                            WHERE isDeleted=false AND employeeNumber=@EmployeeNumber AND
                            startShiftDate=@StartShiftDate AND 
                            endShiftDate=@EndShiftDate";

            return this.GetAll(query, new {
                EmployeeNumber = employeeNumber,
                StartShiftDate = startShiftDate,
                EndShiftDate = endShiftDate
            });
        }

        public List<EmployeePayslipModel> GetAllByPaydayDate(DateTime paydayDate)
        {
            string query = @"SELECT * FROM EmployeePayslips
                            WHERE isDeleted=false AND payDate=@PaydayDate";

            return this.GetAll(query, new { PaydayDate = paydayDate });
        }

        public List<EmployeePayslipModel> GetAllByShiftDateRange(DateTime startShiftDate, DateTime endShiftDate)
        {
            string query = @"SELECT * FROM EmployeePayslips
                            WHERE isDeleted=false AND
                            startShiftDate=@StartShiftDate AND 
                            endShiftDate=@EndShiftDate";

            return this.GetAll(query, new
            {
                StartShiftDate = startShiftDate,
                EndShiftDate = endShiftDate
            });
        }
    }
}
