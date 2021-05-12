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
    public class PagIbigContributionCalculator
    {
        public PagIbigContributionSettings GetContributionTable()
        {
            string appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            string govContributionTableDirPath = "\\GovContributionCalculator\\GovContributionTables\\";

            var directoryInfo = Directory.CreateDirectory($"{appPath}{govContributionTableDirPath}");
            string latestTableFileName = $"PagIbigContributionTable.json";

            string fullTablePath = $"{appPath}{govContributionTableDirPath}{latestTableFileName}";

            if (directoryInfo.Exists && File.Exists(fullTablePath) == false)
            {
                return null;
            }

            var jsonString = File.ReadAllText(fullTablePath);
            var pagIbigContributionTable = JsonSerializer.Deserialize<PagIbigContributionSettings>(jsonString);

            return pagIbigContributionTable;
        }

        public SharedContributionRate GetMonthlyContribution (PagIbigContributionSettings pagIbigContributionSettings, decimal monthSalary)
        {
            if (pagIbigContributionSettings == null)
                return null;

            if (monthSalary > 0 && monthSalary <= pagIbigContributionSettings.FirstFixedRate.EqualAndBelowTo)
            {
                var EEContPercentage = pagIbigContributionSettings.FirstFixedRate.Rate.EE / 100;
                var ERContPercentage = pagIbigContributionSettings.FirstFixedRate.Rate.ER / 100;

                decimal eeContTotal = monthSalary * EEContPercentage;
                decimal erContTotal = monthSalary * ERContPercentage;

                // fixed rate
                return new SharedContributionRate
                {
                    ER = erContTotal,
                    EE = eeContTotal
                };
            }

            if (monthSalary > 0 && 
                (monthSalary >= pagIbigContributionSettings.SecondFixedRate.BetweenTo.Min ||
                monthSalary >= pagIbigContributionSettings.SecondFixedRate.BetweenTo.Max))
            {
                var EEContPercentage = pagIbigContributionSettings.SecondFixedRate.Rate.EE / 100;
                var ERContPercentage = pagIbigContributionSettings.SecondFixedRate.Rate.ER / 100;

                decimal eeContTotal = monthSalary * EEContPercentage;
                decimal erContTotal = monthSalary * ERContPercentage;

                // fixed rate
                return new SharedContributionRate
                {
                    ER = erContTotal,
                    EE = eeContTotal
                };
            }

            return new SharedContributionRate
            {
                ER = 0,
                EE = 0
            };
        }
    }
}
