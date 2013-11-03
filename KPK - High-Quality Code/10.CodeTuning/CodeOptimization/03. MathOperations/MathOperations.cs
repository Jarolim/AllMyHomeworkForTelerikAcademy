using System;
using System.Linq;

// Conclusions - 
// The fastest operation is square root, the slowest sinus
// Float is faster then double, decimal is slower in times
// Natural logarithm of decimal cause StackOverflowException()
class MathOperations
{
    static void CalculateSquareRoot()
    {
        Console.Write("Square root of float:   ");
        ArithmeticOperations.DisplayExecutionTime(() =>
        {
            float result = 1000000f;
            for (int i = 0; i < 100000; i++)
            {
                result = (float)Math.Sqrt(result);
            }
        });

        Console.Write("Square root of double:  ");
        ArithmeticOperations.DisplayExecutionTime(() =>
        {
            double result = 1000000.0;
            for (int i = 0; i < 100000; i++)
            {
                result = Math.Sqrt(result);
            }
        });

        Console.Write("Square root of decimal: ");
        ArithmeticOperations.DisplayExecutionTime(() =>
        {
            decimal result = 1000000m;
            for (int i = 0; i < 100000; i++)
            {
                result = (decimal)Math.Sqrt((double)result);
            }
        });
    }

    static void CalculateNaturalLogarithm()
    {
        Console.Write("Natural logarithm of float:   ");
        ArithmeticOperations.DisplayExecutionTime(() =>
        {
            float result = 1000000f;
            for (int i = 0; i < 100000; i++)
            {
                result = (float)Math.Log(result, Math.E);
            }
        });

        Console.Write("Natural logarithm of double:  ");
        ArithmeticOperations.DisplayExecutionTime(() =>
        {
            double result = 1000000.0;
            for (int i = 0; i < 100000; i++)
            {
                result = Math.Log(result, Math.E);
            }
        });

        Console.Write("Natural logarithm of decimal: ");
        ArithmeticOperations.DisplayExecutionTime(() =>
        {
            decimal result = 1000000m;
            for (int i = 0; i < 100000; i++)
            {
                //StackOverflowException()
                //result = (decimal)Math.Log((double)result, Math.E);
            }
        });
    }

    static void CalculateSinus()
    {
        Console.Write("Sinus of float:   ");
        ArithmeticOperations.DisplayExecutionTime(() =>
        {
            float result = 1000000f;
            for (int i = 0; i < 100000; i++)
            {
                result = (float)Math.Sin(result);
            }
        });

        Console.Write("Sinus of double:  ");
        ArithmeticOperations.DisplayExecutionTime(() =>
        {
            double result = 1000000.0;
            for (int i = 0; i < 100000; i++)
            {
                result = Math.Sin(result);
            }
        });

        Console.Write("Sinus of decimal: ");
        ArithmeticOperations.DisplayExecutionTime(() =>
        {
            decimal result = 1000000m;
            for (int i = 0; i < 100000; i++)
            {
                result = (decimal)Math.Sin((double)result);
            }
        });
    }

    static void Main()
    {
        CalculateSquareRoot();
        CalculateNaturalLogarithm();
        CalculateSinus();
    }
}