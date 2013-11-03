using System;
using System.Collections.Generic;
using System.Linq;


class ReadNumberException
{
    static void Main()
    {
        Console.WriteLine("Enter 10 integer numbers in the range 1-100,\nevery number should be bigger than the previous: ");
        
        int start = 1;

        try
        {
            for (int i = 0; i < 10; i++)
            {
                start = ReadNumber(start, 100);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Variable different than integer!");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Integer different than than −2,147,483,648 to 2,147,483,647!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Integer different from the task: 1 <a1 <a2 <a3 <an< 100 !");
        }
       
    }

    static int ReadNumber(int start, int end)
    {
        int num = int.Parse(Console.ReadLine());

        if (!(start < num && num < end))
        {
            throw new ArgumentOutOfRangeException();
        }

        return num;
    }
}

