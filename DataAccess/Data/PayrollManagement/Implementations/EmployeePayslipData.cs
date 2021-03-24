using DapperGenericDataManager;
using DataAccess.Data.PayrollManagement.Contracts;
using EntitiesShared.PayrollManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.PayrollManagement.Implementations
{
    public class EmployeePayslipData : DataManagerCRUD<EmployeePayslipModel>, IEmployeePayslipData
    {
        private readonly IDbConnectionFactory _dbConnFactory;
        private readonly IEmployeePayslipBenefitData _employeePayslipBenefitData;
        private readonly IEmployeePayslipDeductionData _employeePayslipDeductionData;

        public EmployeePayslipData(IDbConnectionFactory dbConnFactory,
                                    IEmployeePayslipBenefitData employeePayslipBenefitData,
                                    IEmployeePayslipDeductionData employeePayslipDeductionData) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
            _employeePayslipBenefitData = employeePayslipBenefitData;
            _employeePayslipDeductionData = employeePayslipDeductionData;
        }

        public EmployeePayslipModel GetEmployeePayslipRecordByPaydate(string employeeNumber, DateTime paydate)
        {
            string query = @"SELECT * FROM EmployeePayslips WHERE employeeNumber=@EmployeeNumber AND payDate=@PayDate";

            var payslipRec = this.GetAll(query, new
            {
                EmployeeNumber = employeeNumber,
                PayDate = paydate.ToString("yyyy-MM-dd")
            });

            if (payslipRec != null)
            {
                payslipRec.ForEach(x =>
                {
                    x.Benefits = _employeePayslipBenefitData.GetAllByPayslipIdAndEmployeeNumber(x.Id, x.EmployeeNumber);
                    x.Deductions = _employeePayslipDeductionData.GetAllByPayslipIdAndEmployeeNumber(x.Id, x.EmployeeNumber);
                });
            }

            return payslipRec.FirstOrDefault();
        }
    }
}
