using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
                            //Write a program that reads two numbers N and K and generates
                            //all the variations of K elements from the set [1..N]
namespace task20
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter N: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("enter K: ");
            int k = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j ==k ; j++)
                {
                    Console.Write(@"{");
                    Console.Write("{0} ,{1} ",i,j);
                    Console.Write(@"}  ");
                    Console.WriteLine();
                }
            }

        }
    }
}
