/*You are given a sequence of positive integer values
written into a string, separated by spaces. Write a
function that reads these values from given string 
and calculates their sum. Example:
		string = "43 68 9 23 318"  result = 461*/

using System;

class SumOfStringOfIntigers
{
    static void Main()
    {
        Console.WriteLine("Enter a sequence of positive integer numbers, separeted by spaces: ");
        string sequence = Console.ReadLine();
        string[] numbers = sequence.Split(' ');
        int sum = 0;
        for (int index = 0; index < numbers.Length; index++)
        {
            if (numbers[index] != "")
            {
                sum = sum + Int32.Parse(numbers[index]);
            }
            
        }
        Console.WriteLine("The sum is: {0}", sum);
    }
}
