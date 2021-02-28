using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementUserControls.CustomModels
{
    public class EmployeeGovtIdCardTempModel
    {
        public bool IsExisting { get; set; } = false;

        public bool IsNeedToUpdate { get; set; } = false;

        public EmployeeGovtIdCardModel EmployeeGovtIdCard { get; set; }
    }
}
