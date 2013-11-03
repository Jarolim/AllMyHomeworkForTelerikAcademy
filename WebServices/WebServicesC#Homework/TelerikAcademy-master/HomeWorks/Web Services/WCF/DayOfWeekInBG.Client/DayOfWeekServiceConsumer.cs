using DayOfWeekInBG.Client.DayOfWeekServiceReference;
using DayOfWeekInBG.Client.StringOccurrencesServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOfWeekInBG.Client
{
    internal class DayOfWeekServiceConsumer
    {
        private static void Main()
        {
            DayOfWeekServiceClient dayOfWeekServiceClient = new DayOfWeekServiceClient();
            Console.WriteLine(dayOfWeekServiceClient.GetDayOfWeekAsync(DateTime.Now).Result);

            StringOccurrencesServiceClient stringOccurrencesClient = new StringOccurrencesServiceClient();
            Console.WriteLine(stringOccurrencesClient.GetOccurrences("a", "alabala"));
        }
    }
}
