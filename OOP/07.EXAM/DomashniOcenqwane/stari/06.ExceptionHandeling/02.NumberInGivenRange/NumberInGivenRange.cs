using System;

    class NumberInGivenRange
    {
        static int ReadNumber(int start, int end)
        { 
        Console.WriteLine("Enter a number ");
        int number = int.Parse(Console.ReadLine());
        if (!(number > start && number < end))
        {
            throw new ArgumentOutOfRangeException();
        }
        return number;
        }
        static void Main()
        {
            int min = 1;
            int max = 100;
            for (int i = 0; i < 10; i++)
            {
                min = ReadNumber(min, max);
            }
        }
    }
