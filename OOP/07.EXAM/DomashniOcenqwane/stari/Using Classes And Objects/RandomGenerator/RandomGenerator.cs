/*Write a program that generates and prints to the 
console 10 random values in the range [100, 200].*/

using System;

class RandomGenerator
{
    static void Main()
    {
        Random generator = new Random();
        for (int counter = 0; counter < 10; counter++)
        {
            int randomNumber = generator.Next(100, 201);
            Console.WriteLine(randomNumber);
        }
    }
}

