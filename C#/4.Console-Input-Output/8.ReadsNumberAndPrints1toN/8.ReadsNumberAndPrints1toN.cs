﻿using System;

class ReadsNumberAndPrints1toN
{
    static void Main()
    {
        /*Write a program that reads an integer number n from the console 
         and prints all the numbers in the interval [1..n], each on a single line.*/
        Console.Write("Pleace enter a positive integer: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine(i);
        }
    }
}

