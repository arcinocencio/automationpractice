using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Resource
{
    public static class Utility
    {
        public static string Day {get; set;}
        public static string Month { get; set; }
        public static string Year { get; set; }

        public static void ParseDate(string date)
        {
            DateTime birthday = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Year = Convert.ToString(birthday.Year);
            Month = Convert.ToString(birthday.Month);
            Day = Convert.ToString(birthday.Day);
        }
    }
}
