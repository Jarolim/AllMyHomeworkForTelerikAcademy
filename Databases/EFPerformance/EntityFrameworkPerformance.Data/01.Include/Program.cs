using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityTelerik.Data;

namespace _01.Include
{
    class Program
    {
        static TelerikAcademyEntities context = new TelerikAcademyEntities();

        static void GetInfoWithoutInclude()
        {
            foreach (var employee in context.Employees)
            {
                Console.WriteLine("{0} {1}", employee.FirstName, employee.LastName);
                Console.WriteLine("{0}", employee.Department.Name);
                Console.WriteLine("{0}", employee.Address.Town.Name);
                Console.WriteLine();
            }
            Console.WriteLine(context.Employees.Count());
        }

        static void GetInfoWithInclude()
        {
            foreach (var employee in context.Employees.Include("Address.Town").Include("Department"))
            {
                Console.WriteLine("{0} {1}", employee.FirstName, employee.LastName);
                Console.WriteLine("{0}", employee.Department.Name);
                Console.WriteLine("{0}", employee.Address.Town.Name);
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            GetInfoWithInclude();
            //GetInfoWithoutInclude();
        }

        //Conclusion: made 364 queries, with Include does 1-2. 
    }
}
