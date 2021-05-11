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
    public class SSSContributionCalculator
    {
        public List<SSSContributionTableRow> GetContributionTable()
        {
            string appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            string sssContributionTablesDirPath = "\\GovContributionCalculator\\GovContributionTables\\SSS\\";

            var directoryInfo = Directory.CreateDirectory($"{appPath}{sssContributionTablesDirPath}");
            string latestTableFileName = $"{DateTime.Now.Year}.json";

            string fullTablePath = $"{appPath}{sssContributionTablesDirPath}{latestTableFileName}";

            if (directoryInfo.Exists && File.Exists(fullTablePath) == false)
            {
                latestTableFileName = $"Default.json";
                fullTablePath = $"{appPath}{latestTableFileName}";
            }

            var jsonString = File.ReadAllText(fullTablePath);
            var sssContributionTable = JsonSerializer.Deserialize<List<SSSContributionTableRow>>(jsonString);

            return sssContributionTable;
        }

        public SharedContributionRate GetEEandERSharedContribution (List<SSSContributionTableRow> SSSContributionTables, decimal employeeMonthlySalary)
        {
            var contributionRow = SSSContributionTables.Where(x => x.salaryStart <= employeeMonthlySalary && x.salaryEnd >= employeeMonthlySalary).FirstOrDefault();

            if (contributionRow == null)
                return null;

            return new SharedContributionRate
            {
                ER = contributionRow.totalContributionEmployer,
                EE = contributionRow.totalContributionEmployee
            };
        }
    }
}
