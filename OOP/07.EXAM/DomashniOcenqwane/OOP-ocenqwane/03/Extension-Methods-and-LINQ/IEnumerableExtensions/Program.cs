using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[5]{1,2,3,4,5};
            Console.WriteLine(arr.SumIEnumerable());
            Console.WriteLine(arr.ProductIEnumerable());
            Console.WriteLine(arr.MinIEnumerable());
            Console.WriteLine(arr.MaxIEnumerable());
            Console.WriteLine(arr.AverageIEnumerable());
        }
    }
}
