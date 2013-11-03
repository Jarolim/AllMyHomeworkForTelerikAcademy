using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsPrime
{
    class IsPrime
    {
        static void Main(string[] args)
        {
            int n;
            string unformattedNumber;
            unformattedNumber = Console.ReadLine();
            n = int.Parse(unformattedNumber);
            Console.WriteLine(n==2|n==3|n==5|n==7|n==11|n==13|n==17|n==19|n==23|n==29|n==31|n==37|n==41|n==43|n==47|n==53|n==59|n==61|n==67|n==71|n==73|n==79|n==83|n==89|n==97);
        }
    }
}
