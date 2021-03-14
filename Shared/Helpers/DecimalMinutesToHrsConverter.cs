using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Helpers
{
    public class DecimalMinutesToHrsConverter
    {
        public string Convert(decimal minutes)
        {
            if (minutes < 60)
            {
                return minutes.ToString() + "mins";
            }

            decimal hrsAndMins = minutes / 60;

            int hrsSide = (int)Math.Truncate(hrsAndMins);
            double frac = (double)hrsAndMins % 1;

            int minsSide = (int)Math.Truncate(frac * 60);

            return $"{hrsSide.ToString()}.{minsSide.ToString()}";
        }
    }
}
