using System;
using System.Linq;
using Northwind.Model;
using System.Data.Linq;

namespace NorthwindTwin
{
    public partial class Inheritance
    {
        private static void Main(string[] args)
        {
            using (var northwindDbContext = new NorthwindEntities())
            {
                foreach (var territory in northwindDbContext.Employees.First().TerritoriesSet)
                {
                    Console.WriteLine(territory);
                }
            }
        }
    }
}
