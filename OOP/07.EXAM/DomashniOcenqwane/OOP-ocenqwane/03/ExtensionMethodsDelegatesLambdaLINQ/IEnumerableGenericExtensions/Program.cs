using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableGenericExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] elements = new int[] { 1, 2, 3, 4, -1, 5 };

            Console.WriteLine(elements.Sum());
            Console.WriteLine(elements.Product());
            Console.WriteLine(elements.Min());
            Console.WriteLine(elements.Max());
            Console.WriteLine(elements.Average());
        }
    }
}
