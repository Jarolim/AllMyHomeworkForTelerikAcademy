using System;
using System.Text.RegularExpressions;

public class SentencesExtractor
{
    public static void Main()
    {
        string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

        string regex = @"\s*(?<sentence>[^\.]*?\bin\b(.|\s)*?\.)";

        MatchCollection matches = Regex.Matches(text, regex, RegexOptions.IgnoreCase);

        foreach (Match match in matches)
        {
            Console.WriteLine(match.Groups["sentence"].Value);
        }
    }
}