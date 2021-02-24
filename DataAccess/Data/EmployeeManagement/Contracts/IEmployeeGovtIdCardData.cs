﻿using DapperGenericDataManager;
using DataAccess.Entities.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.EmployeeManagement.Contracts
{
    public interface IEmployeeGovtIdCardData : IDataManagerCRUD<EmployeeGovtIdCardModel>
    {
        List<EmployeeGovtIdCardModel> GetAllByEmployeeNumber(string employeeNumber);

        List<EmployeeGovtIdCardModel> GetAllByGovtAgency(int govtAgencyId);

        EmployeeGovtIdCardModel GetByEmployeeIdNumber(string employeeIdNumber);
    }
}
