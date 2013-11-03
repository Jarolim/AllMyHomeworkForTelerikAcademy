using System;

class Program
{
    static void UserName(string name)
    {
        Console.WriteLine("Hello, {0}!", name);
    }

    static void Main()
    {
        Console.WriteLine("Please enter name:");
        string name;
        name = Console.ReadLine();
        UserName(name);
    }
}

