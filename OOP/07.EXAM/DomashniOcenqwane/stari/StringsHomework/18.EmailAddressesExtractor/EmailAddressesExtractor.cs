using System;
using System.Text.RegularExpressions;

public class EmailAddressesExtractor
{
    public static void Main()
    {
        // <identifier>@<host>…<domain>
        string text = "Surprisingly the first one doesn't break dh.d'h@dh.dh check@gmail.com cantgetsimpler@than.that maybeitcan@abv.bg whynot@yahoo.com couldbe@yahoo.co.uk finally@hotmail.com";

        string regex = @"\b[A-Z0-9._%+-]+@(?:[A-Z0-9-]+\.)+[A-Z]{2,4}\b";

        MatchCollection matches = Regex.Matches(text, regex, RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);

        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
    }
}