using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.brackets
{
    class Program
    {

        static bool Brackets(string expression)
        {
            int open = 0;
            int closing = 0;
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == ')')
                {
                    if (open == 0)
                    {
                        return false;
                    }
                    else
                    {
                        closing = closing + 1;
                    }
                }
                else
                {
                    open = open + 1;
                }
            }
            if ((open - closing == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Input the expression");
            string expression = Console.ReadLine();
            Console.WriteLine(Brackets(expression));



        }
    }
}
