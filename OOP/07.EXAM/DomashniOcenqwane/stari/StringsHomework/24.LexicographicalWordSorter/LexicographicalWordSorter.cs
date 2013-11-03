using System;

public class LexicographicalWordSorter
{
    public static void Main()
    {
        string list = "word ball gym fox red brown jump over fence quick silver surfer fantastic four";

        string[] words = list.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Array.Sort(words);

        for (int index = 0; index < words.Length; index++)
        {
            Console.WriteLine(words[index]);
        }
    }
}