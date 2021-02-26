using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.EmployeeManagement
{
    [Table("EmployeeGovtContributions")]
    public class EmployeeGovtContributionModel : BaseModel
    {
        private string employeeNumber;

        public string EmployeeNumber
        {
            get { return employeeNumber; }
            set { employeeNumber = value; }
        }

        private long employeeGovtIdCardId;

        public long EmployeeGovtIdCardId
        {
            get { return employeeGovtIdCardId; }
            set { employeeGovtIdCardId = value; }
        }


        private EmployeeGovtIdCardModel employeeGovtIdCard;

        public EmployeeGovtIdCardModel EmployeeGovtIdCard
        {
            get { return employeeGovtIdCard; }
            set { employeeGovtIdCard = value; }
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

        public decimal TotalContribution
        {
            get
            {
                return this.EmployeeContribution + this.EmployerContribution;
            }
        }

    }
}
