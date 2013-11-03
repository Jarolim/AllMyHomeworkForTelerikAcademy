using System;
using System.Diagnostics;
using System.Linq;

class TestMathOperations
{
	static void Main()
	{
		CalculateSquareRoot();
		CalculateNaturalLogarithm();
		CalculateSinus();
	}

	public static void DisplayExecutionTime(Action action)
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		action();
		stopwatch.Stop();
		Console.WriteLine("|{0,-15}|",stopwatch.Elapsed);
	}

	static void CalculateSquareRoot()
	{
		Console.Write("Square root of float: ");
		DisplayExecutionTime(() =>
		{
			float result = 1000000f;
			for (int i = 0; i < 1000000; i++)
			{
				result = (float)Math.Sqrt(result);
			}
		});

		Console.Write("Square root of double: ");
		DisplayExecutionTime(() =>
		{
			double result = 1000000.0;
			for (int i = 0; i < 1000000; i++)
			{
				result = Math.Sqrt(result);
			}
		});

		Console.Write("Square root of decimal: ");
		DisplayExecutionTime(() =>
		{
			decimal result = 1000000m;
			for (int i = 0; i < 1000000; i++)
			{
				result = (decimal)Math.Sqrt((double)result);
			}
		});
	}

	static void CalculateNaturalLogarithm()
	{
		Console.Write("Natural logarithm of float: ");
		DisplayExecutionTime(() =>
		{
			float result = 1000000f;
			for (int i = 0; i < 1000000; i++)
			{
				result = (float)Math.Log(result, Math.E);
			}
		});

		Console.Write("Natural logarithm of double: ");
		DisplayExecutionTime(() =>
		{
			double result = 1000000.0;
			for (int i = 0; i < 1000000; i++)
			{
				result = Math.Log(result, Math.E);
			}
		});

		Console.Write("Natural logarithm of decimal: ");
		DisplayExecutionTime(() =>
		{
			decimal result = 1000000m;
			for (int i = 0; i < 1000000; i++)
			{
				//StackOverflowException()
				//result = (decimal)Math.Log((double)result, Math.E);
			}
		});
	}

	static void CalculateSinus()
	{
		Console.Write("Sinus of float: ");
		DisplayExecutionTime(() =>
		{
			float result = 1000000f;
			for (int i = 0; i < 1000000; i++)
			{
				result = (float)Math.Sin(result);
			}
		});

		Console.Write("Sinus of double:");
		DisplayExecutionTime(() =>
		{
			double result = 1000000.0;
			for (int i = 0; i < 1000000; i++)
			{
				result = Math.Sin(result);
			}
		});

		Console.Write("Sinus of decimal: ");
		DisplayExecutionTime(() =>
		{
			decimal result = 1000000m;
			for (int i = 0; i < 1000000; i++)
			{
				result = (decimal)Math.Sin((double)result);
			}
		});
	}
}

