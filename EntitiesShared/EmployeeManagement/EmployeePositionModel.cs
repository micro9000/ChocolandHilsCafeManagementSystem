﻿using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.EmployeeManagement
{
    [Table("EmployeePositions")]
    public class EmployeePositionModel : BaseLongModel
    {
        public string Title { get; set; }

        public decimal SalaryRate
        {
            get;set;
        }

        public decimal HalfMonthRate
        {
            get; set;
        }

        public decimal DailyRate
        {
            get; set;
        }
    }
}
