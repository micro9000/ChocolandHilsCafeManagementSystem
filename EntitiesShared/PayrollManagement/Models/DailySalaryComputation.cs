using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.PayrollManagement.Models
{
    public class DailySalaryComputation
    {
        public decimal LateTotalDeduction { get; set; }

        public decimal UnderTimeTotalDeduction { get; set; }

        public decimal OverTimeTotalDeduction { get; set; }

        public decimal TotalDailySalary { get; set; }
    }
}
