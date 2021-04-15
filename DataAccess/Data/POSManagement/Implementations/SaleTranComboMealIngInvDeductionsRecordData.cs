using DapperGenericDataManager;
using DataAccess.Data.POSManagement.Contracts;
using EntitiesShared.POSManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.POSManagement.Implementations
{
    public class SaleTranComboMealIngInvDeductionsRecordData : DataManagerCRUD<SaleTranComboMealIngInvDeductionsRecordModel>, ISaleTranComboMealIngInvDeductionsRecordData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public SaleTranComboMealIngInvDeductionsRecordData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<SaleTranComboMealIngInvDeductionsRecordModel> GetAllBySaleTranComboMealId(long saleTranComboMealId, long productId, long ingredientId)
        {
            string query = @"SELECT * 
                            FROM SaleTranComboMealIngInvDeductionsRecords
                            WHERE isDeleted=false AND saleTransComboMealId=@SaleTranComboMealId 
                            AND productId=@ProductId AND ingredientId=@IngredientId";

            return this.GetAll(query, new
            {
                SaleTranComboMealId = saleTranComboMealId,
                ProductId = productId,
                IngredientId = ingredientId
            });
        }
    }
}
