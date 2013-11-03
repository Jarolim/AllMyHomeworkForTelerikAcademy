using System;

class IndexOfLetter
{
    static void Main()
    {
        int n = (int)'Z' - (int)'A' + 1;
        char[] arr = new char[n];

        for (int i = 0; i < n; i++)
        {
            arr[i] = (char)((int)'A'+i);
        }

        string word = Console.ReadLine();

        foreach (char letter in word)
        {
            for (int i = 0; i < n; i++)
            {
                if (letter == arr[i])
                {
                    Console.WriteLine("The index of letter {0} is {1}", letter, i+1);
                    break;
                }
            }
        }
    }
}
