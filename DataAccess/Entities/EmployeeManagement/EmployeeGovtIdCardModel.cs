using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.EmployeeManagement
{
    [Table("EmployeeGovtIdCards")]
    public class EmployeeGovtIdCardModel
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
