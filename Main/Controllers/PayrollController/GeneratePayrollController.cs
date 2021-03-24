using DataAccess.Data.EmployeeManagement.Contracts;
using DataAccess.Data.OtherDataManagement.Contracts;
using DataAccess.Data.PayrollManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.PayrollController
{
    public class GeneratePayrollController
    {
        private readonly IEmployeeData _employeeData;
        private readonly IEmployeeAttendanceData _employeeAttendanceData;
        private readonly IEmployeeBenefitData _employeeBenefitData;
        private readonly IEmployeeDeductionData _employeeDeductionData;
        private readonly IEmployeePayslipData _employeePayslipData;
        private readonly IEmployeePayslipBenefitData _employeePayslipBenefitData;
        private readonly IEmployeePayslipDeductionData _employeePayslipDeductionData;
        private readonly IGovernmentAgencyData _governmentAgencyData;
        private readonly IEmployeeGovtIdCardData _employeeGovtIdCardData;
        private readonly IWorkforceScheduleData _workforceScheduleData;
        private readonly IEmployeeLeaveData _employeeLeaveData;

        public GeneratePayrollController(IEmployeeData employeeData, 
                                        IEmployeeAttendanceData employeeAttendanceData,
                                        IEmployeeLeaveData employeeLeaveData,
                                        IEmployeeBenefitData employeeBenefitData,
                                        IEmployeeDeductionData employeeDeductionData,
                                        IEmployeePayslipData employeePayslipData,
                                        IEmployeePayslipBenefitData employeePayslipBenefitData,
                                        IEmployeePayslipDeductionData employeePayslipDeductionData,
                                        IGovernmentAgencyData governmentAgencyData,
                                        IEmployeeGovtIdCardData employeeGovtIdCardData,
                                        IWorkforceScheduleData workforceScheduleData)
        {
            _employeeData = employeeData;
            _employeeAttendanceData = employeeAttendanceData;
            _employeeLeaveData = employeeLeaveData;
            _employeeBenefitData = employeeBenefitData;
            _employeeDeductionData = employeeDeductionData;
            _employeePayslipData = employeePayslipData;
            _employeePayslipBenefitData = employeePayslipBenefitData;
            _employeePayslipDeductionData = employeePayslipDeductionData;
            _governmentAgencyData = governmentAgencyData;
            _employeeGovtIdCardData = employeeGovtIdCardData;
            _workforceScheduleData = workforceScheduleData;
        }

    }
}
