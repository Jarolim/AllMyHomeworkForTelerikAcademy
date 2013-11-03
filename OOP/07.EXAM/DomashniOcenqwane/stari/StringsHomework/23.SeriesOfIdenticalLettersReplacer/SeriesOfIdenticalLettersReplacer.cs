using System;
using System.Text.RegularExpressions;

public class SeriesOfIdenticalLettersReplacer
{
    public static void Main()
    {
        string text = @"aaaaabbbbbcdddeeeedssaa something likeeeee!! tttthhiiissss";
        
        string regex = @"(?<letter>[A-Z])\1+";

        Console.WriteLine(Regex.Replace(text, regex, m => m.Groups["letter"].Value, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace));
    }
}