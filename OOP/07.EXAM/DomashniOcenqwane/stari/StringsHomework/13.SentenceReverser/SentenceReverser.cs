using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

public class SentenceReverser
{
    public static void Main()
    {
        string sentence = "C# is not C++, not PHP and not Delphi!";

        string regex = @"\s+|\,\s*|\;\s*|\:\s*|\-\s*|\!\s*|\?\s*|\.\s*";

        Stack words = new Stack();
        Queue separators = new Queue();

        foreach (string word in Regex.Split(sentence, regex))
        {
            if (word != "")
            {
                words.Push(word); 
            }
        }

        foreach (Match separator in Regex.Matches(sentence, regex))
        {
            separators.Enqueue(separator);
        }

        StringBuilder reversedSentence = new StringBuilder();

        while (words.Count > 0 && separators.Count > 0)
        {
            reversedSentence.Append(words.Pop());
            reversedSentence.Append(separators.Dequeue());
        }

        Console.WriteLine(reversedSentence.ToString());
    }
}