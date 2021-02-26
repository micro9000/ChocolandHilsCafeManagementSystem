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
    public class EmployeePayslipDeductionData : DataManagerCRUD<EmployeePayslipDeductionModel>, IEmployeePayslipDeductionData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public EmployeePayslipDeductionData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<EmployeePayslipDeductionModel> GetAllByPayslipId(long payslipId)
        {
            string query = @"SELECT * FROM EmployeePayslipDeductions
                             WHERE isDeleted=false AND payslipId=@PayslipId";

            return this.GetAll(query, new { PayslipId = payslipId });
        }

        public List<EmployeePayslipDeductionModel> GetAllByPayslipIdAndEmployeeNumber(long payslipId, string employeeNumber)
        {
            string query = @"SELECT * FROM EmployeePayslipDeductions
                             WHERE isDeleted=false AND payslipId=@PayslipId AND 
                            employeeNumber=@EmployeeNumber";

            return this.GetAll(query, new  { 
                PayslipId = payslipId, 
                EmployeeNumber = employeeNumber
            });
        }
    }
}
