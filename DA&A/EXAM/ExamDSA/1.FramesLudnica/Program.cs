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
        

        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string line = Console.ReadLine();
                var moo = sb.Append(line);
            }
            var banana = sb[0];
            var banana2 = sb[2];

            Console.WriteLine(1);
            Console.WriteLine("({1}, {0}) | ({0}, {1})", banana, banana2);
        }

    }
}
