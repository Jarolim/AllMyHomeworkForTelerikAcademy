/*Write a program that reads N integers from the console and reverses
  them using a stack. Use the Stack<int> class.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.ReverseUsingStack
{
    class ReverseUsingStack
    {
        static void Main(string[] args)
        {
            var numberContainer = new Stack<int>();

            Console.WriteLine("Please input the numbers: ");

            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine == string.Empty)
                {
                    break;
                }

                else
                {
                    numberContainer.Push(int.Parse(inputLine));
                }
            }

            Console.WriteLine(string.Join(" ", numberContainer));
        }
    }
}
