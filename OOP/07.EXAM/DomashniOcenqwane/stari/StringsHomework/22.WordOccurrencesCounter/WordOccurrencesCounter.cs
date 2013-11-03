using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class WordOccurrencesCounter
{
    public static void Main()
    {
        string text = @"C# is not C++, not PHP and not Delphi! Write a program that extracts from a given text all palindromes, e.g. ""ABBA"", ""lamal"", ""exe"".";
        //Console.WriteLine("Please enter your text:");
        //string text = Console.ReadLine();

        string regex = @"[A-Z]+";

        Dictionary<string, int> wordOccurrences = new Dictionary<string, int>();
        
        MatchCollection matches = Regex.Matches(text, regex, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

        foreach (Match match in matches)
        {
            if (wordOccurrences.ContainsKey(match.Value))
            {
                wordOccurrences[match.Value]++;
            }
            else
            {
                wordOccurrences.Add(match.Value, 1);
            }
        }

        // var sortedDictionary = (from entry in wordOccurrences orderby entry.Key ascending select entry).ToDictionary(pair => pair.Key, pair => pair.Value);
        List<KeyValuePair<string, int>> sortedDictionary = wordOccurrences.ToList();
        
        sortedDictionary.Sort((x, y) => x.Key.CompareTo(y.Key));

        foreach (KeyValuePair<string, int> wordEntry in sortedDictionary)
        {
            Console.WriteLine("{0}: {1}", wordEntry.Key, wordEntry.Value);
        }
    }
}