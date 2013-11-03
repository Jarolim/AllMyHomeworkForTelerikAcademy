using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitAtPossitionPIs1
{
    class BitAtPossitionPIs1
    {
        static void Main()
        {
            int p = int.Parse(Console.ReadLine());
            int v = int.Parse(Console.ReadLine());
            int mask = 1 << p;
            int vAndMask = v & mask;
            int bit = vAndMask >> p;
            Console.WriteLine(bit == 1);
        }
    }
}
