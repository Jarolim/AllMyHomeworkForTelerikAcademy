using System;

class Program
{
    static int GetMax(int num1, int num2)
    {
        if (num1 < num2)
        {

            return num2;

        }
        else
        {
            return num1;
        }

    }
    static void Main()
    {

        Console.WriteLine("Two or Three numbers");
        int numbers = int.Parse(Console.ReadLine());

        if (numbers == 2)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine(GetMax(num1, num2));
        }
        else
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            Console.WriteLine(GetMax(GetMax(num1, num2), num3));
        }


    }
}