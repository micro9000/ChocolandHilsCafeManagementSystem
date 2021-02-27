using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.EmployeeManagement.DisplayModels
{
    public class EmployeeDetailsModel
    {
        public EmployeeModel PersonalInfo { get; set; }

        public List<EmployeeGovtIdCardModel> GovtIdCards { get; set; }

        public List<EmployeeAttendanceModel> Attendance { get; set; }

        public List<EmployeePayslipModel> PayslipHistory { get; set; }
    }
}
