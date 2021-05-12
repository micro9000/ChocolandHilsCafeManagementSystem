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
    public class PhilHealthContributionCalculator
    {
        public PhilHealthContributionSettings GetContributionTable()
        {
            string appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            string govContributionTableDirPath = "\\GovContributionCalculator\\GovContributionTables\\";

            var directoryInfo = Directory.CreateDirectory($"{appPath}{govContributionTableDirPath}");
            string latestTableFileName = $"PhilHealthContributionTable.json";

            string fullTablePath = $"{appPath}{govContributionTableDirPath}{latestTableFileName}";

            if (directoryInfo.Exists && File.Exists(fullTablePath) == false)
            {
                return null;
            }

            var jsonString = File.ReadAllText(fullTablePath);
            var philHealthContributionTable = JsonSerializer.Deserialize<PhilHealthContributionSettings>(jsonString);

            return philHealthContributionTable;
        }

        public SharedContributionRate GetKinsenasContribution (PhilHealthContributionSettings philHealthContributionSettings, decimal monthlySalary)
        {
            if (philHealthContributionSettings == null)
                return null;

            if (monthlySalary <= philHealthContributionSettings.FirstFixedRate.EqualAndBelowTo)
            {
                // fixed rate
                return new SharedContributionRate
                {
                    ER = philHealthContributionSettings.FirstFixedRate.Rate.ER,
                    EE = philHealthContributionSettings.FirstFixedRate.Rate.EE
                };
            }

            if (monthlySalary >= philHealthContributionSettings.SecondFixedRate.EqualOrAboveTo)
            {
                // fixed rate
                return new SharedContributionRate
                {
                    ER = philHealthContributionSettings.SecondFixedRate.Rate.ER,
                    EE = philHealthContributionSettings.SecondFixedRate.Rate.EE
                };
            }

            var percentage = philHealthContributionSettings.PercentageForInBetween / 100;

            decimal monthlyContribution = monthlySalary * percentage;
            decimal sharedERandEEContribution = monthlyContribution / 2;

            return new SharedContributionRate
            {
                ER = sharedERandEEContribution,
                EE = sharedERandEEContribution
            };
        }
    }
}
