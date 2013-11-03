using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtractingBit
{
    class ExtractingBit
    {
        static void Main()
        {

            int i = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int mask = 1 << b;  
            int nAndMask = i & mask;
            int bit = nAndMask >> b;
            Console.WriteLine(bit);
        }
    }
}
