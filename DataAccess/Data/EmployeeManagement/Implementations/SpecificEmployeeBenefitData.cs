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
    public class SpecificEmployeeBenefitData : DataManagerCRUD<SpecificEmployeeBenefitModel>, ISpecificEmployeeBenefitData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public SpecificEmployeeBenefitData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<SpecificEmployeeBenefitModel> GetAllUnpaid()
        {
            string query = @"SELECT * FROM SpecificEmployeeBenefits WHERE isDeleted=false AND isPaid=false";
            return this.GetAll(query);
        }

        public List<SpecificEmployeeBenefitModel> GetAllBySubmissionDateRange(DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT * 
                            FROM SpecificEmployeeBenefits 
                            WHERE isDeleted=false AND isPaid=false AND createdAt BETWEEN @StartDate AND @EndDate";

            return this.GetAll(query, new
            {
                StartDate = startDate,
                EndDate = endDate
            });
        }

        public List<SpecificEmployeeBenefitModel> GetAllByPaymentDate(DateTime paymentDate)
        {
            string query = @"SELECT * 
                            FROM SpecificEmployeeBenefits 
                            WHERE isDeleted=false AND isPaid=false AND DATE(paymentDate)=@PaymentDate";

            return this.GetAll(query, new
            {
                PaymentDate = paymentDate.ToString("yyyy-MM-dd")
            });
        }

    }
}
