using System;
using System.Linq;

namespace ReversesDigits
{
    class ReversesDigits
    {
        static void Main(string[] args)
        {
            ReverseNumber(45457);
        }
        static void ReverseNumber(decimal num)
        {           
            while ((int)num!=0)
            {
                Console.Write((int)num % 10);
                num /= 10;
            }          
            Console.WriteLine();
        }
    }
}
