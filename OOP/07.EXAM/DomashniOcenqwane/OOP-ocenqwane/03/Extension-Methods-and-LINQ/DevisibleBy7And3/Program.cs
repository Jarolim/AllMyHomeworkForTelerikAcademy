using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevisibleBy7And3
{
    class Program
    {
        static void PrintDevisiable7and3Lambda(int[] array)
        {
            int[] selected = Array.FindAll(array, x => x % 3 == 0&&x%7==0);
            foreach (var item in selected)
            {
                Console.Write(item+" ");
            }
        }
        static void PrintDevisiable7and3LINQ(int[] array)
        {
            var selected =
            from item in array
            where (item%3==0&&item%7==0)
            select item;
            foreach (var item in selected)
            {
                Console.Write(item + " ");
            }
        }
        static void Main(string[] args)
        {
            int[] array = new int[100];
            for (int i = 0; i < 100; i++)
            {
                array[i] = i;
            }
            Console.WriteLine("----Selected LINQ----");
            PrintDevisiable7and3Lambda(array);
            Console.WriteLine();
            Console.WriteLine("----Selected Lambda----");
            PrintDevisiable7and3LINQ(array);
            Console.WriteLine();
        }
    }
}
