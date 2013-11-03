using System;
using System.Text.RegularExpressions;

public class HtmlParser
{
    public static void Main()
    {
        string html = @"<html>
                        <head>
                            <title>News</title>
                        </head>
                        <body>
                            <p>
                                <a href=""http://academy.telerik.com"">
                                    Telerik Academy
                                </a>
                                aims to provide free real-world practical training for young people who want to turn into skillful .NET software engineers.
                            </p>
                        </body>
                        </html>";

        // Bleh, no time to think of a better regex, still works pretty well, but could be improved
        string regex = @"[^>]*>\s*(?<text>(.|\s)*?)\s*<";

        MatchCollection text = Regex.Matches(html, regex, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

        foreach (Match match in text)
        {
            Console.WriteLine(match.Groups["text"].Value);
        }
    }
}