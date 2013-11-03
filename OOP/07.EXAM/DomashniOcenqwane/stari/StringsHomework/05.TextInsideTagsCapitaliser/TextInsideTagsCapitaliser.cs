using System;
using System.Text.RegularExpressions;

public class TextInsideTagsCapitaliser
{
    public static void Main()
    {
        string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";

        string regex = @"<upcase>(?<capitalise>(.|\s)*?)</upcase>";

        Console.WriteLine(Regex.Replace(text, regex, m => m.Groups["capitalise"].Value.ToUpper()));
    }
}