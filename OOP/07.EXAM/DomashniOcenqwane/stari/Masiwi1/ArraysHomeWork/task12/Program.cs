using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
                                                                //Write a program that creates an array containing all letters
                                                                //from the alphabet (A-Z). Read a word from the console
                                                                //and print the index of each of its letters in the array.

namespace task12
{
    class Program
    {
        static void Main(string[] args)
        {
            int n=26;
            char[] alphabet = new char[n];
            char letterIndex='A';
            for (int i = 0; i < n; i++,letterIndex++)
            {
                alphabet[i] = letterIndex;
            }
            Console.WriteLine("Type a word : ");
            string word = (Console.ReadLine().ToUpper());
            foreach (var letter in word)
            {
                for (int i = 0; i < n; i++)
                {
                    if (letter==alphabet[i])
                    {
                        Console.WriteLine("The letter : {0} is at array index: {1}", letter , i);
                    }
                }
            }
        }
    }
}
