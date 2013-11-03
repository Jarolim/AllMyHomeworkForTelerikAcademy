using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Frames
{
    class Program
    {
        static string[] integers;
        List<string> allIntegers = new List<string>();

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            integers = new string[N];

            for (int i = 0; i < N; i++)
            {
                string line = Console.ReadLine();
                string[] characteristics = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                allIntegers.Add(characteristics);
            }

            Console.WriteLine(0);
        }
        
    }
}
