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
    public class SaleTranProdIngInvDeductionsRecordData : DataManagerCRUD<SaleTranProdIngInvDeductionsRecordModel>, ISaleTranProdIngInvDeductionsRecordData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public SaleTranProdIngInvDeductionsRecordData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }
    }
}
