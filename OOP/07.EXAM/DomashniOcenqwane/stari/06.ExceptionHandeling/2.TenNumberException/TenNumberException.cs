using System;
class TenNumberException
{
    static int ReadNumber(int start, int end)  
{
        try
        {
            int number = int.Parse(Console.ReadLine());
            if ((number < start) || (number > end))
            {
                throw new ArgumentOutOfRangeException("out of range");
            }
            return number;
        }
        catch (FormatException)
        {
            Console.WriteLine("not a number");
            return -1;
        }
    }
    static void Main()
    {
        Console.Write("please enter start value: ");
        int start = ReadNumber(int.MinValue, int.MaxValue);
        Console.Write("please enter end value: ");
        int end = ReadNumber(int.MinValue, int.MaxValue);
        if (start < 1)
        {
            start = 1;
        }
        if (end > 100)
        {
            end = 100;
        }
        for (int i = 0; i <= 10; i++)
        {
            Console.Write("plese enter number {0} between {1} and {2}: ", i, start, end);
            try
            {
                int res = ReadNumber(start, end);
                start = res;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("argument is out of range {0} and {1}", start, end);
            }
        }
    }
}

