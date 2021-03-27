using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.EmployeeManagement
{
    [Table("Employees")]
    public class EmployeeModel : BaseModel
    {
        private string employeeNumber;

        public string EmployeeNumber
        {
            get { return employeeNumber; }
            set { employeeNumber = value; }
        }

        private string empNumYear;

        public string EmpNumYear
        {
            get { return empNumYear; }
            set { empNumYear = value; }
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string middleName;

        public string MiddleName
        {
            get { return middleName; }
            set { middleName = value; }
        }


        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        [Write(false)]
        [Computed]
        public string FullName
        {
            get
            {
                return $"{this.FirstName} {this.MiddleName} {this.LastName}";
            }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }


        private DateTime birthDate;

        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }


        private string mobileNumber;

        public string MobileNumber
        {
            get { return mobileNumber; }
            set { mobileNumber = value; }
        }

        private string emailAddress;

        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        private string position;

        public string Position
        {
            get { return position; }
            set { position = value; }
        }


        private string branchAssign;

        public string BranchAssign
        {
            get { return branchAssign; }
            set { branchAssign = value; }
        }

        private DateTime dateHire;

        public DateTime DateHire
        {
            get { return dateHire; }
            set { dateHire = value; }
        }

        private long shiftId;

        public long ShiftId
        {
            get { return shiftId; }
            set { shiftId = value; }
        }

        public bool IsQuit { get; set; }

        public DateTime QuitDate { get; set; }

        private EmployeeShiftModel shift;
        [Write(false)]
        [Computed]
        public EmployeeShiftModel Shift
        {
            get { return shift; }
            set { shift = value; }
        }

        private string imageFileName;

        public string ImageFileName
        {
            get { return imageFileName; }
            set { imageFileName = value; }
        }


        private EmployeeSalaryRateModel salaryRates;
        [Write(false)]
        [Computed]
        public EmployeeSalaryRateModel SalaryRates
        {
            get { return salaryRates; }
            set { salaryRates = value; }
        }
    }
}
