using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string message = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        string words = "PHP, CLR, Microsoft";

        Console.WriteLine(Regex.Replace(message, words.Replace(", ", "|"), m => new String('*', m.Length)));
    }
}