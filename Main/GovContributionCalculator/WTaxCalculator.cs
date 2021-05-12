using Main.GovContributionCalculator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Main.GovContributionCalculator
{
    public class WTaxCalculator
    {
        public WTaxTable GetMonthlyWTaxTable()
        {
            string appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            string govContributionTablesDirPath = "\\GovContributionCalculator\\GovContributionTables\\";

            var directoryInfo = Directory.CreateDirectory($"{appPath}{govContributionTablesDirPath}");
            string latestTableFileName = $"WithholdingTaxTable.json";

            string fullTablePath = $"{appPath}{govContributionTablesDirPath}{latestTableFileName}";

            if (directoryInfo.Exists && File.Exists(fullTablePath) == false)
            {
                return null;
            }

            var jsonString = File.ReadAllText(fullTablePath);
            var taxTable = JsonSerializer.Deserialize<WTaxTable>(jsonString);

            return taxTable;
        }

        public decimal GetMonthlyWithholdingTax (WTaxTable wTaxTable, decimal monthlyGovContributionTotal, decimal monthlySalary)
        {
            if (monthlyGovContributionTotal > monthlySalary)
                return 0;

            var wTaxItem = wTaxTable.MonthlyWTax
                                .Where(x => 
                                    x.CompensationMinLevel >= monthlySalary && 
                                    x.CompensationMaxLevel <= monthlySalary)
                                .FirstOrDefault();

            if (wTaxItem == null)
                return 0;

            if (wTaxItem.Percentage == 0 || wTaxItem.FixedTax == 0)
                return 0;

            decimal taxableIncome = monthlySalary - monthlyGovContributionTotal;

            // FixedTax is also known Compensation level
            decimal percentOverCompensationLvlTotal = taxableIncome - wTaxItem.FixedTax;

            var percentage = wTaxItem.Percentage / 100;

            decimal totalTax = percentOverCompensationLvlTotal * percentage;

            return totalTax;
        }
    }
}
