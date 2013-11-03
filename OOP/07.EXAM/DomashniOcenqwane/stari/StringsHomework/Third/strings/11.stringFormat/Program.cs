using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.stringFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the number");
            double number = double.Parse(Console.ReadLine());
            Console.WriteLine("{0,15:x}", (double)number);
            Console.WriteLine("{0,15:p}",(double)number);
            Console.WriteLine("{0,15:e}",number);
            Console.WriteLine("{0,15:#.###}",number);
        }
    }
}
