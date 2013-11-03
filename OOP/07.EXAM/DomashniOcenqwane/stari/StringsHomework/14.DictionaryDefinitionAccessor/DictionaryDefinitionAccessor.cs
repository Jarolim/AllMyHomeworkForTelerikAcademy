using System;
using System.Text.RegularExpressions;

public class DictionaryDefinitionAccessor
{
    public static void Main()
    {
        string dictionary = @".NET – platform for applications from Microsoft
                              CLR – managed execution environment for .NET
                              namespace – hierarchical organization of classes
                             ";

        string searchWord = "clr";

        string regex = searchWord + @"(\s+?)\–(\s+?)(?<definition>((.|\s)*?))\r";

        MatchCollection matches = Regex.Matches(dictionary, regex, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

        if (matches.Count > 0)
        {
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups["definition"]);
            }
        }
        else
        {
            Console.WriteLine("This word does not exist in the dictionary.");
        }
    }
}