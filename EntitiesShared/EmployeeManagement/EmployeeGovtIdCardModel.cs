using Dapper.Contrib.Extensions;
using EntitiesShared.OtherDataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.EmployeeManagement
{
    [Table("EmployeeGovtIdCards")]
    public class EmployeeGovtIdCardModel : BaseModel
    {
        private string employeeNumber;

        public string EmployeeNumber
        {
            get { return employeeNumber; }
            set { employeeNumber = value; }
        }


        private int govtAgencyId;

        public int GovtAgencyId
        {
            get { return govtAgencyId; }
            set { govtAgencyId = value; }
        }

        private GovernmentAgencyModel governmentAgency;
        [Write(false)]
        [Computed]
        public GovernmentAgencyModel GovernmentAgency
        {
            get { return governmentAgency; }
            set { governmentAgency = value; }
        }


        private string employeeIdNumber;

        public string EmployeeIdNumber
        {
            get { return employeeIdNumber; }
            set { employeeIdNumber = value; }
        }

        private decimal employeeContribution;

        public decimal EmployeeContribution
        {
            get { return employeeContribution; }
            set { employeeContribution = value; }
        }

        private decimal employerContribution;

        public decimal EmployerContribution
        {
            get { return employerContribution; }
            set { employerContribution = value; }
        }

        [Write(false)]
        [Computed]
        public decimal TotalContribution {
            get
            {
                return this.EmployeeContribution + this.EmployerContribution;
            }
        }

    }
}
