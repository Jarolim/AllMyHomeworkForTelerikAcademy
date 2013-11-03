using System;
using System.Text.RegularExpressions;

public class LettersOccurrencesCounter
{
    public static void Main()
    {
        string text = @"C# is not C++, not PHP and not Delphi! Write a program that extracts from a given text all palindromes, e.g. ""ABBA"", ""lamal"", ""exe"".";

        string regex = @"[^A-Z]+?";

        string textAlphabetOnly = Regex.Replace(text, regex, String.Empty, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace).ToUpper();

        byte[] letters = new byte[26];

        for (int index = 0; index < textAlphabetOnly.Length; index++)
        {
            letters[textAlphabetOnly[index] - 65]++;
        }
        
        for (byte letter = 0; letter < 26; letter++)
        {
            if (letters[letter] != 0)
            {
                Console.WriteLine("{0} {1}", (char)(letter + 65), letters[letter]);
            }
        }
    }
}