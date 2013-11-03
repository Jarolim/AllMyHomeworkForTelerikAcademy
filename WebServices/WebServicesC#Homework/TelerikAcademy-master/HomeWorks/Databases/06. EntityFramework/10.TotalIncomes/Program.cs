using System;
using System.Linq;
using Northwind.Model;

namespace TotalIncomes
{
    class TotalIncomes
    {
        static void Main(string[] args)
        {
            
            using(var context = new NorthwindEntities())
            {
                var result = context.usp_FindTotalIncome(new DateTime(1994, 1, 1), new DateTime(2000, 12, 31), "Exotic Liquids").First();

                Console.WriteLine("All Income are {0}",result);
            }
        }

    }
}
