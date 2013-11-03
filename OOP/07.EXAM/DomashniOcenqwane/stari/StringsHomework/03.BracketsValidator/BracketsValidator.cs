using System;
//using System.Text.RegularExpressions;

public class BracketsValidator
{
    public static bool ValidateBrackets(string input)
    {
        int numberOfBrackets = 0;

        for (int index = 0; index < input.Length; index++)
        {
            if (input[index] == '(')
            {
                numberOfBrackets++;
            }
            else if (input[index] == ')')
            {
                numberOfBrackets--;
            }

            if (numberOfBrackets < 0)
            {
                return false;
            }
        }

        return numberOfBrackets == 0;
    }

    public static void Main()
    {
        // string regex = new Regex(@"[^\)]* \( ( ?: [^()] | (?<open>\() | (?<-open>\)) ) (?(open)(?!)) \)", RegexOptions.IgnorePatternWhitespace).ToString(); // Not working properly
        string firstInput = "((a+b)/5-d)";
        string secondInput = ")(a+b))";

        Console.WriteLine(ValidateBrackets(firstInput));
        Console.WriteLine(ValidateBrackets(secondInput));
    }
}