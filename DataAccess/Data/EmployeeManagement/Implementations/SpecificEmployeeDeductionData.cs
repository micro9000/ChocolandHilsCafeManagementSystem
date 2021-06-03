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
    public class SpecificEmployeeDeductionData : DataManagerCRUD<SpecificEmployeeDeductionModel>, ISpecificEmployeeDeductionData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public SpecificEmployeeDeductionData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }


        public List<SpecificEmployeeDeductionModel> GetAllPending()
        {
            string query = @"SELECT * FROM SpecificEmployeeDeductions WHERE isDeleted=false AND isDeducted=false";
            return this.GetAll(query);
        }

        public List<SpecificEmployeeDeductionModel> GetAllBySubmissionDateRange(DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT * 
                            FROM SpecificEmployeeDeductions 
                            WHERE isDeleted=false AND isDeducted=false AND createdAt BETWEEN @StartDate AND @EndDate";

            return this.GetAll(query, new
            {
                StartDate = startDate,
                EndDate = endDate
            });
        }

        public List<SpecificEmployeeDeductionModel> GetAllByPaymentDate(DateTime paymentDate)
        {
            string query = @"SELECT * 
                            FROM SpecificEmployeeDeductions 
                            WHERE isDeleted=false AND isDeducted=false AND DATE(paymentDate)=@PaymentDate";

            return this.GetAll(query, new
            {
                PaymentDate = paymentDate.ToString("yyyy-MM-dd")
            });
        }

    }
}
