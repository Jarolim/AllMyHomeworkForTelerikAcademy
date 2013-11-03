using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringOccurrences.Client
{
    internal class StringOccurrencesServiceConsumer
    {
        private static void Main()
        {
            StringOccurrencesServiceClient client = new StringOccurrencesServiceClient();
            int occurrences = client.GetOccurrencesAsync("a", "alabala").Result;

            Console.WriteLine(occurrences);
        }
    }
}
