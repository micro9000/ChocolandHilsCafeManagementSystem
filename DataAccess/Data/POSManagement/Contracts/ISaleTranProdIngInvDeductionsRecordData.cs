using DapperGenericDataManager;
using EntitiesShared.POSManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.POSManagement.Contracts
{
    public interface ISaleTranProdIngInvDeductionsRecordData : IDataManagerCRUD<SaleTranProdIngInvDeductionsRecordModel>
    {
        List<SaleTranProdIngInvDeductionsRecordModel> GetAllBySaleTranProductId(long saleTranProdId, long ingredientId);
    }
}
