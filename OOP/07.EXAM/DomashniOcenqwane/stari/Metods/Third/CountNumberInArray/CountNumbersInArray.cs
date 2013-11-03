using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountNumberInArray
{
   public class CountNumbersInArray
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1,1,2,2,3,3,5,5,4,4,4,7,8,8,9,9,9 };
            Console.WriteLine(CountNumber(9, numbers));
        }
        public static int CountNumber(int n, params int [] numbers)
        {
            int counter = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (n == numbers[i])
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
