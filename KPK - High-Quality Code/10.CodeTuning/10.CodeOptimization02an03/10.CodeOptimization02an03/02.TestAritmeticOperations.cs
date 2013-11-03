using System;
using System.Diagnostics;
using System.Linq;

class TestAritmeticOperations
{
	static void Main()
	{
		Add();
		Subtract();
		Increment();
		Multiply();
		Divide();
	}

	public static void DisplayExecutionTime(Action action)
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		action();
		stopwatch.Stop();
		Console.WriteLine("|{0,-15}|", stopwatch.Elapsed);
	}

	static void Add()
	{
		Console.Write("Addition of int:");
		DisplayExecutionTime(() =>
		{
			int sum = 0;
			for (int i = 0; i < 10000000; i++)
			{
				sum += 100;
			}
		});

		Console.Write("Addition of long:");
		DisplayExecutionTime(() =>
		{
			long sum = 0L;
			for (int i = 0; i < 10000000; i++)
			{
				sum += 100L;
			}
		});

		Console.Write("Addition of float:");
		DisplayExecutionTime(() =>
		{
			float sum = 0f;
			for (int i = 0; i < 10000000; i++)
			{
				sum += 100f;
			}
		});

		Console.Write("Addition of double:");
		DisplayExecutionTime(() =>
		{
			double sum = 0.0;
			for (int i = 0; i < 10000000; i++)
			{
				sum += 100.0;
			}
		});

		Console.Write("Addition of decimal:");
		DisplayExecutionTime(() =>
		{
			decimal sum = 0m;
			for (int i = 0; i < 10000000; i++)
			{
				sum += 100m;
			}
		});
	}

	static void Subtract()
	{
		Console.Write("Subtraction of int:");
		DisplayExecutionTime(() =>
		{
			int result = 1000000000;
			for (int i = 0; i < 10000000; i++)
			{
				result -= 100;
			}
		});

		Console.Write("Subtraction of long:");
		DisplayExecutionTime(() =>
		{
			long result = 1000000000L;
			for (int i = 0; i < 10000000; i++)
			{
				result -= 100L;
			}
		});

		Console.Write("Subtraction of float:");
		DisplayExecutionTime(() =>
		{
			float result = 1000000000f;
			for (int i = 0; i < 10000000; i++)
			{
				result -= 100f;
			}
		});

		Console.Write("Subtraction of double:");
		DisplayExecutionTime(() =>
		{
			double result = 1000000000.0;
			for (int i = 0; i < 10000000; i++)
			{
				result -= 100.0;
			}
		});

		Console.Write("Subtraction of decimal:");
		DisplayExecutionTime(() =>
		{
			decimal result = 1000000000m;
			for (int i = 0; i < 10000000; i++)
			{
				result -= 100m;
			}
		});
	}

	static void Increment()
	{
		Console.Write("Increment of int:");
		DisplayExecutionTime(() =>
		{
			int value = 1;
			for (int i = 0; i < 10000000; i++)
			{
				value++;
			}
		});

		Console.Write("Increment of long:");
		DisplayExecutionTime(() =>
		{
			long value = 1L;
			for (int i = 0; i < 10000000; i++)
			{
				value++;
			}
		});

		Console.Write("Increment of float:");
		DisplayExecutionTime(() =>
		{
			float value = 1f;
			for (int i = 0; i < 10000000; i++)
			{
				value++;
			}
		});

		Console.Write("Increment of double:");
		DisplayExecutionTime(() =>
		{
			double value = 1.0;
			for (int i = 0; i < 10000000; i++)
			{
				value++;
			}
		});

		Console.Write("Increment of decimal:");
		DisplayExecutionTime(() =>
		{
			decimal value = 1m;
			for (int i = 0; i < 10000000; i++)
			{
				value++;
			}
		});
	}

	static void Multiply()
	{
		Console.Write("Multiplication of int:");
		DisplayExecutionTime(() =>
		{
			int product = 1;
			for (int i = 0; i < 10000000; i++)
			{
				product *= 1;
			}
		});

		Console.Write("Multiplication of long:");
		DisplayExecutionTime(() =>
		{
			long product = 1L;
			for (int i = 0; i < 10000000; i++)
			{
				product *= 1L;
			}
		});

		Console.Write("Multiplication of float:");
		DisplayExecutionTime(() =>
		{
			float product = 1f;
			for (int i = 0; i < 10000000; i++)
			{
				product *= 1f;
			}
		});

		Console.Write("Multiplication of double:");
		DisplayExecutionTime(() =>
		{
			double product = 1.0;
			for (int i = 0; i < 10000000; i++)
			{
				product *= 1.0;
			}
		});

		Console.Write("Multiplication of decimal:");
		DisplayExecutionTime(() =>
		{
			decimal product = 1m;
			for (int i = 0; i < 10000000; i++)
			{
				product *= 1m;
			}
		});
	}

	static void Divide()
	{
		Console.Write("Division of int:");
		DisplayExecutionTime(() =>
		{
			int result = 1000;
			for (int i = 0; i < 10000000; i++)
			{
				result /= 1;
			}
		});

		Console.Write("Division of long:");
		DisplayExecutionTime(() =>
		{
			long result = 1000L;
			for (int i = 0; i < 10000000; i++)
			{
				result /= 1L;
			}
		});

		Console.Write("Division of float:");
		DisplayExecutionTime(() =>
		{
			float result = 1000f;
			for (int i = 0; i < 10000000; i++)
			{
				result /= 1f;
			}
		});

		Console.Write("Division of double:");
		DisplayExecutionTime(() =>
		{
			double result = 1000.0;
			for (int i = 0; i < 10000000; i++)
			{
				result /= 1.0;
			}
		});

		Console.Write("Division of decimal:");
		DisplayExecutionTime(() =>
		{
			decimal result = 1000m;
			for (int i = 0; i < 10000000; i++)
			{
				result /= 1m;
			}
		});
	}
}

