using System;
class Program
{
    static void Main()
    {
        int number;
        Console.Write("Write number:");
        number = int.Parse(Console.ReadLine());
        Console.WriteLine("First number is {0} second is {1}",number,ReversNum(number));
    }

    public static int ReversNum(int number)
    {
        int revNumber;
        int revHundreds = number % 10;
        int revDecimal = (number % 100) / 10;
        int revToTen = (number / 100);
        revNumber =revHundreds*100+revDecimal*10+revToTen;
        return revNumber;
    }
}
