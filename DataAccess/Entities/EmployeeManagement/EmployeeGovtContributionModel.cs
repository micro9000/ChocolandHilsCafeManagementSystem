using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.EmployeeManagement
{
    [Table("EmployeeGovtContributions")]
    public class EmployeeGovtContributionModel
    {
        private long id;

        [Key]
        public long Id
        {
            get { return id; }
            set { id = value; }
        }


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


        private DateTime createdAt = DateTime.UtcNow;

        public DateTime CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; }
        }

        private DateTime updatedAt = DateTime.UtcNow;

        public DateTime UpdatedAt
        {
            get { return updatedAt; }
            set { updatedAt = value; }
        }

        private DateTime? deletedAt;

        public DateTime? DeletedAt
        {
            get { return deletedAt; }
            set { deletedAt = value; }
        }

        private bool isDeleted;

        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }

    }
}
