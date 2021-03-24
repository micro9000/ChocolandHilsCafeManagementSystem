using EntitiesShared.EmployeeManagement;
using EntitiesShared.OtherDataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.PayrollManagement.Models
{
    public class EmployeePayslipGeneration
    {

        public DateTime PayDate { get; set; }

        public DateTime ShiftStartDate { get; set; }

        public DateTime ShiftEndDate { get; set; }


        private EmployeeModel employee;

        public EmployeeModel Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        private PaydaySalaryComputationPayslip paydaySalaryComputation;

        public PaydaySalaryComputationPayslip PaydaySalaryComputation
        {
            get { return paydaySalaryComputation; }
            set { paydaySalaryComputation = value; }
        }

        private List<EmployeeAttendanceModel> attendanceHistory;

        public List<EmployeeAttendanceModel> AttendanceHistory
        {
            get { return attendanceHistory; }
            set { attendanceHistory = value; }
        }

        private List<GovernmentAgencyModel> selectedGovtAgencies;

        public List<GovernmentAgencyModel> SelectedGovtAgencies
        {
            get { return selectedGovtAgencies; }
            set { selectedGovtAgencies = value; }
        }

        private List<EmployeeBenefitModel> selectedBenefits;

        public List<EmployeeBenefitModel> SelectedBenefits
        {
            get { return selectedBenefits; }
            set { selectedBenefits = value; }
        }

        private List<EmployeeDeductionModel> selectedDeductions;
        public List<EmployeeDeductionModel> SelectedDeductions
        {
            get { return selectedDeductions; }
            set { selectedDeductions = value; }
        }

    }
}
