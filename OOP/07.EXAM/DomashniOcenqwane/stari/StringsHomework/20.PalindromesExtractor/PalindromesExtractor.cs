using System;
using System.Text.RegularExpressions;

public class PalindromesExtractor
{
    public static void Main()
    {
        string text = @"C# is not C++, not PHP and not Delphi! Write a program that extracts from a given text all palindromes, e.g. ""ABBA"", ""lamal"", ""exe"".";

        string regex = @"\s+|\,\s*|""\s*|'\s*|\;\s*|\:\s*|\-\s*|\!\s*|\?\s*|\.\s*";

        foreach (string word in Regex.Split(text, regex))
        {
            if (word.Length > 2 && word.ToUpper().Equals(ReverseStringPrinter.ReverseString(word).ToUpper()))
            {
                Console.WriteLine(word);
            }
        }
    }
}