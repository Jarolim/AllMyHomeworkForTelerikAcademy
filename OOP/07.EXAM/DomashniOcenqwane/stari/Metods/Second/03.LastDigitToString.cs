using System;
class Program
{
    static void Main()
    {
        int number;        
        Console.Write("Please write a number:");
        number = (int.Parse(Console.ReadLine())) % 10;
        Console.WriteLine("The lowest digit is {0}", NumToString(number));
    }
    public static string NumToString(int upToNine)
    {
        string numberString;
        switch (upToNine)
        {
            case 1: numberString = "one";
                break;
            case 2: numberString = "two";
                break;
            case 3: numberString = "tree";
                break;
            case 4: numberString = "four";
                break;
            case 5: numberString = "five";
                break;
            case 6: numberString = "six";
                break;
            case 7: numberString = "seven";
                break;
            case 8: numberString = "eight";
                break;
            case 9: numberString = "nine";
                break;
            default: numberString = "";
                break;
        }
    return numberString;
    }
}
