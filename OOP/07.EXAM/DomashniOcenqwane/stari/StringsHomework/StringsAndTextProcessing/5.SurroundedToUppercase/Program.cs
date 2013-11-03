using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string str = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";

        Console.WriteLine(Regex.Replace(str, "<upcase>(.*?)</upcase>", m => m.Groups[1].Value.ToUpper()));
    }
}