﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.PayrollManagement.Models
{
    public class PaydaySalaryComputationPayslip
    {
        public string Late { get; set; }
        public decimal LateTotalDeduction { get; set; }

        public string UnderTime { get; set; }
        public decimal UnderTimeTotalDeduction { get; set; }

        public string OverTime { get; set; }
        public decimal OverTimeTotalRate { get; set; }

        public string NumberOfDays { get; set; }

        public decimal NetBasicSalary { get; set; }

        public decimal BenefitsTotal { get; set; }

        public decimal DeductionTotal { get; set; }

        public decimal TotalIncome { get; set; }

    }
}