﻿using DapperGenericDataManager;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.EmployeeManagement.Contracts
{
    public interface ISpecificEmployeeBenefitData : IDataManagerCRUD<SpecificEmployeeBenefitModel>
    {
        List<SpecificEmployeeBenefitModel> GetAllUnpaid();
        List<SpecificEmployeeBenefitModel> GetAllBySubmissionDateRange(DateTime startDate, DateTime endDate);
        List<SpecificEmployeeBenefitModel> GetAllByPaymentDate(DateTime paymentDate);
    }
}
