using System;
using System.Text.RegularExpressions;


    class Program
    {
       
            static void Main()
    {
        string str = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string substr = "in";

        Console.WriteLine(Regex.Matches(str, substr, RegexOptions.IgnoreCase).Count);
    }
        
    }
