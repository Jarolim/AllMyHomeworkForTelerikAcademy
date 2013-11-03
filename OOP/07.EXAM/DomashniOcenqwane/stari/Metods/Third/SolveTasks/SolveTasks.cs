using System;
using System.Text;

class Solve3Tasks
{
    static void ReverseDigit()
    {
        Console.Write("Enter number:");
        int n = int.Parse(Console.ReadLine());
        StringBuilder reverseDigit = new StringBuilder();
        if (n >= 0)
        {
            while (n != 0)
            {
                int lastDigit = n % 10;
                reverseDigit.Append(lastDigit);
                int lastNum = n / 10;
                n = lastNum;

            }
            Console.Write("The number in reverse is:{0}", int.Parse(reverseDigit.ToString()));
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("The input number can NOT be Negative!");
        }


    }

    static void CalculateAvgSum()
    {
        string nStr = string.Empty;
        decimal n;
        string stop = "STOP";
        decimal counter = 0;
        decimal sum = 0;

        Console.WriteLine("Enter your sequence of numbers");
        Console.WriteLine("When you finish write \"stop\"");
        nStr = Console.ReadLine();
        if (nStr != string.Empty)
        {
            while (nStr != stop)
            {
                nStr = Console.ReadLine();
                if (nStr.Equals(stop, StringComparison.OrdinalIgnoreCase))
                {
                    if (nStr == string.Empty)
                    {
                        Console.WriteLine("Input can NOT be Empty String");
                    }
                    break;
                }
                if (decimal.TryParse(nStr, out n))
                {
                    counter++;
                    sum = sum + n;
                }
            }
            decimal avgSum = sum / counter;
            Console.WriteLine("Avg={0:F2}", avgSum);
            Console.WriteLine();
        }
    }

    static void SolveLinearEq()
    {

        Console.Write("a=");
        decimal a = decimal.Parse(Console.ReadLine());
        if (a != 0)
        {
            Console.Write("b=");
            decimal b = decimal.Parse(Console.ReadLine());
            decimal x = b / a;
            Console.WriteLine();
            Console.WriteLine("a * x + b = 0");
            Console.WriteLine("x={0}", x);
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Input 'a' can NOT be Zero!");
        }

    }
    static void PrintMenu()
    {
        Console.WriteLine("                      MENU:");
        Console.WriteLine();
        Console.WriteLine("*** Press 1 *** Reverses the digits of a number ");
        Console.WriteLine("*** Press 2 *** Calculates the average of a sequence of integers ");
        Console.WriteLine("*** Press 3 *** Solves a linear equation a * x + b = 0 ");
        Console.Write("Menu:");
        int menu = int.Parse(Console.ReadLine());
        if (menu == 1)
        {
            ReverseDigit();
        }
        else if (menu == 2)
        {
            CalculateAvgSum();
        }
        else if (menu == 3)
        {
            SolveLinearEq();
        }
        else
        {
            Console.WriteLine("Invalid MENU OPTION!");
        }
    }
    static void Main()
    {
        PrintMenu();
    }
}