using System;
using System.Linq;

namespace PrintName
{
    class PrintName
    {             
        static void Main(string[] args)
        {
            if (GetName().All(char.IsLetter))
            {
             
            }
            else
            {
               Console.WriteLine("Format is not valid!");
            }
            
        }

        static string GetName()
        {           
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Hello {0}!", name); 
            return name;
        }
    }
}
