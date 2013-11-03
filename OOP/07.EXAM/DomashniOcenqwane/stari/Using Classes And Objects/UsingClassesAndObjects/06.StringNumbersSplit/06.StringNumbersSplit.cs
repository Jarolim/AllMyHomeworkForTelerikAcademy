using System;

class StringNumbersSplit
{
    static uint SumNumbers(string[] str)
    {
        uint sum = 0;
        for (int i = 0; i < str.Length; i++)
        {
            sum += Convert.ToUInt32(str[i]);
        }

        return sum;
    }

    static void Main()
    {
        // You are given a sequence of positive integer values written into a string, separated by spaces. 
        // Write a function that reads these values from given string and calculates their sum. Example:
        // string = "43 68 9 23 318"  result = 461

        // string input = "43 68 9 23 318";

        Console.WriteLine("Enter positiv ints, separated by spaces: ");
        string input = Console.ReadLine();
        string[] numbers = input.Split(' ');

        Console.WriteLine("The sum of the numbers is: {0}", SumNumbers(numbers));
    }
}