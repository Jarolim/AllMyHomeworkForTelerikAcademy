using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NVP
{
    class NumberValuePosision
    {
        static void Main()
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter V: ");
            int v = int.Parse(Console.ReadLine());
            Console.Write("Enter P: ");
            int p = int.Parse(Console.ReadLine());
            
            //How to set the bit at position p to 0?
            //int p = 5;
            //int n = 35;                 // 00000000 00100011
            //int mask = ~(1 << p);       // 11111111 11011111
            //int result = n & mask;      // 00000000 00000011
            //Console.WriteLine(result);  // 3
  
            //How to set the bit at position p to 1?
            //int p = 4;
            //int n = 35;                 // 00000000 00100011
            //int mask = 1 << p;          // 00000000 00010000
            //int result = n | mask;      // 00000000 00110011
            //Console.WriteLine(result);  // 3
            if (v == 0)
            {
                int mask = ~(1 << p);
                n = n & mask;
                //Console.WriteLine(Convert.ToString(n, 2));

            }

            else
            {
                int mask = (1 << p);
                n = n | mask;
                //Console.WriteLine(Convert.ToString(n, 2));
            }
        }
    }
}
