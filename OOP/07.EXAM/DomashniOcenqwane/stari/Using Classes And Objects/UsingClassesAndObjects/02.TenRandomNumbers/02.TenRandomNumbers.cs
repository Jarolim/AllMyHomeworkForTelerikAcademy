using System;

class TenRandomNumbers
{
    static int GenerateNumber(Random randomNum)
    {

        int result = randomNum.Next(100, 201);

        return result;
    }

    static void Main()
    {
        // Write a program that generates and prints to the console 10 random values in the range [100, 200].

        Random randomNum = new Random();

        Console.WriteLine("The ten random numbers are: ");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(GenerateNumber(randomNum));
        }
    }
}