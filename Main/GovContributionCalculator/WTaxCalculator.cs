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

        //public decimal GetMonthlyWithholdingTax ()
    }
}
