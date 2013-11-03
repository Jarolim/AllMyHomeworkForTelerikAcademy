using System;
using System.Linq;

class SortByLength
{
    static void Main()
    {
        string[] unsortedStrings = { "a", "aaaaa", "aaaawd", "a", "12355asdf", "wdasdwe", "fsdfsgsgf" };
        foreach (var item in unsortedStrings.OrderBy(uStrings => uStrings.Length))
        {
            Console.WriteLine(item);
        }
    }
}