using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string str = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string word = "in";

        foreach (Match sentence in Regex.Matches(str, @"\s*([^\.]*\b" + word + @"\b.*?\.)"))
            Console.WriteLine(sentence.Groups[1]);
    }
}
