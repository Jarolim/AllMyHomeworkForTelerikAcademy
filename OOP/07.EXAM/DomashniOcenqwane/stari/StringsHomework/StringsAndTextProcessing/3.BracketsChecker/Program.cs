using System;

    class Program
    {
       
             static bool CheckBrackets(string str)
    {
        int stack = 0;

        for (int i = 0; i < str.Length && stack >= 0; i++)
        {
            if (str[i] == '(') stack++;
            if (str[i] == ')') stack--; // else
        }

        return stack == 0;
    }

    static void Main()
    {
        Console.WriteLine(CheckBrackets("((a + b) / 5 - d)"));
        Console.WriteLine(CheckBrackets(")(a+b))"));
    }
}
      