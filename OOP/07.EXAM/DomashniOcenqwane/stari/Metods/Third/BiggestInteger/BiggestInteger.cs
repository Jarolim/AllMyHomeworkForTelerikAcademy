using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiggestInteger
{
    class BiggestInteger
    {
        static void Main(string[] args)
        {
            Console.Write("First number: ");
            int firstInt = int.Parse(Console.ReadLine());
            Console.Write("Second number: ");
            int secondInt = int.Parse(Console.ReadLine());
            Console.Write("Third number: ");
            int thirdInt = int.Parse(Console.ReadLine());
            int biggerNum = GetMax(firstInt, secondInt);
            int biggestNum = GetMax(biggerNum, thirdInt);
            Console.WriteLine("Biggest number: {0}",biggestNum);
        }

        static int GetMax(int num1, int num2)
        {
            int biggerNumber = num1;
            if (num2>num1)
	        {
                biggerNumber = num2;
	        }
            return biggerNumber;
        }
    }
}
