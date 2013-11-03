using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class DateExtractor
{
    public static void Main()
    {
        // Copied from the book
        string text = "I was born at 14.06.1980. My sister was born at 3.7.1984. In 5/1999 I graduated my high school. The law says (see section 7.3.12) that we are allowed to do this (section 7.4.2.9).";

        string regex = @"((((0?[1-9])|[12][0-9]|3[01])\.((0?[13578])|(1[02])))|(((0?[1-9])|[12][0-9]|30)\.((0?[469])|11))|(((0?[1-9])|[12][0-9])\.(0?2)))\.\d{4}";

        MatchCollection matches = Regex.Matches(text, regex, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

        foreach (Match match in matches)
        {
            // Console.WriteLine(match.Value);
            Console.WriteLine(DateTime.Parse(match.Value).ToString(CultureInfo.GetCultureInfo("en-CA")));
        }
    }
}