﻿using DapperGenericDataManager;
using EntitiesShared.POSManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.POSManagement.Contracts
{
    public interface ISaleTransactionProductData : IDataManagerCRUD<SaleTransactionProductModel>
    {
        IEnumerable<SaleTransactionProductModel> GetAllBySaleTransId(long saleTransactionId);
    }
}
