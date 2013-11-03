using System;

class Program
{
    static void Reverse(decimal number)
    {

        string str = number.ToString();

        char[] Arr = str.ToCharArray();

        Array.Reverse(Arr);

        for (int i = 0; i < Arr.Length; i++)
        {
            Console.Write(Arr[i]);

        }

        Console.WriteLine("");
    }
    static void Main()
    {

        decimal num = decimal.Parse(Console.ReadLine());
        Reverse(num);// TRY whith  decimal max   79228162514264337593543950335
    }
}