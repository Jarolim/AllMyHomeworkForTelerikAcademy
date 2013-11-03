using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrapezoidArea
{
    class TrapezoidArea
    {
        static void Main(string[] args)
        {
            float sideA, sideB, height;
            Console.WriteLine("Side a:");
            string unformattedNumber;
            unformattedNumber = Console.ReadLine();
            sideA = float.Parse(unformattedNumber);
            Console.WriteLine("Side b:");
            unformattedNumber = Console.ReadLine();
            sideB = float.Parse(unformattedNumber);
            Console.WriteLine("Height:");
            unformattedNumber = Console.ReadLine();
            height = float.Parse(unformattedNumber);
            Console.WriteLine((sideA+sideB)*height/2);
        }
    }
}
