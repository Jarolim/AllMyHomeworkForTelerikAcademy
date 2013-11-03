using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.MYRiskWinsRiskLoses
{
    //84 to4ki
    class Program
    {
        static void Main(string[] args)
        {

            string startCombi = Console.ReadLine();
            string endCombi = Console.ReadLine();
            List<string> forbiddenCombi = new List<string>();

            int forbiddenCombiCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < forbiddenCombiCount; i++)
            {
                forbiddenCombi.Add(Console.ReadLine());
            }

            int count = 0;

            for (int i = 0; i < startCombi.Length; i++)
            {
                int startDigit = startCombi[i] - '0';
                int endDigit = endCombi[i] - '0';

                count += Math.Min(Math.Abs(startDigit - endDigit), 10 - Math.Abs(startDigit - endDigit));
            }
            Console.WriteLine(count);

        }
    }
}
