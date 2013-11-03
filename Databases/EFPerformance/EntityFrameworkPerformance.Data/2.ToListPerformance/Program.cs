using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using EntityTelerik.Data;

namespace _2.ToListPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            TelerikAcademyEntities context = new TelerikAcademyEntities();

            var allEmployees = context.Employees.ToList()
                                      .Select(e => e.Address).ToList()
                                      .Select(e => e.Town).ToList()
                                      .Where(e => e.Name == "Sofia");

            //var allEmployeesOptimized = context.Employees
            //                                   .Select(e => e.Address)
            //                                   .Select(e => e.Town)
            //                                   .Where(e => e.Name == "Sofia").ToList();

            //Conclusion: made 662 queries, with only 1 ToList does 1-2-3. 
        }
    }
}
