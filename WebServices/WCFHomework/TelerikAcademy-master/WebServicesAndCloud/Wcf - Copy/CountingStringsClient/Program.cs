using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountingStringsClient.ServiceReference1;

namespace CountingStringsClient
{
    class Program
    {
        static void Main()
        {
            StringCounterClient client = new StringCounterClient();
            int numberOfAppears = client.CountHowMuchTimesStringApersInOtherString("Something, something, something, DARK SIDE", "something");
            Console.WriteLine(numberOfAppears);
        }
    }
}
