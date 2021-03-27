using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class PayrollSettings
    {
        public string FirstPayDayOfTheMonth { get; set; }

        public string SecondPayDayOfTheMonth { get; set; }

        public string GeneratedPDFLoc { get; set; }
    }
}
