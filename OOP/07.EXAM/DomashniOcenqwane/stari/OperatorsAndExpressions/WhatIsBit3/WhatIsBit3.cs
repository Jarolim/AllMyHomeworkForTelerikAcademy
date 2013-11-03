using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatIsBit3
{
    class WhatIsBit3
    {
        static void Main(string[] args)
        {
            int numberToCheck = 8;
            int mask = 1 << 3;
            int nAndMask = numberToCheck & mask;
            int bit = nAndMask >> 3;
            if (bit == 1)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
    }
}
