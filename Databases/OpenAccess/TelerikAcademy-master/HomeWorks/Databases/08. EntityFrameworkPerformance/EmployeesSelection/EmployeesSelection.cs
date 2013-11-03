using System;
using System.Linq;
using Telerik.OpenAccess.FetchOptimization;
using TelerikAcademyModel;

namespace EmployeesSelection
{
    class EmployeesSelection
    {
        private static void SelectEmployeesNoInclude()
        {
            using (var context = new TelerikAcademyEntities())
            {
                Console.WriteLine("Employees:");
                foreach (var employee in context.Employees)
                {
                    Console.WriteLine(
                        "Name: {0} {1}\nDepartment: {2}\nTown: {3}",
                        employee.FirstName,
                        employee.LastName,
                        employee.Department.Name,
                        employee.Address.Town.Name);
                }
            }
        }

        private static void SelectEmployeesWithStrategy()
        {
            using (var context = new TelerikAcademyEntities())
            {
                var strategy = new FetchStrategy();

                strategy.LoadWith((Employee e) => e.Department);
                strategy.LoadWith((Employee e) => e.Address);
                strategy.LoadWith((Address a) => a.Town);

                context.FetchStrategy = strategy;

                foreach (var employee in context.Employees)
                {
                    Console.WriteLine(
                        "Name: {0} {1}\nDepartment: {2}\nTown: {3}",
                        employee.FirstName,
                        employee.LastName,
                        employee.Department.Name,
                        employee.Address.Town.Name);
                }
            }
        }

        private static void SelectEmployeesUsingToList()
        {
            using (var context = new TelerikAcademyEntities())
            {
                Console.WriteLine("Employees:");

                var employees = context.Employees.ToList()
                    .Select(e => new
                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Address = e.Address.AddressText,
                        TownName = e.Address.Town.Name
                    })
                    .ToList()
                    .Where(e => e.TownName == "Sofia")
                    .ToList();

                foreach (var employee in employees)
                {
                    Console.WriteLine(
                        "Name: {0} {1}\nAddress: {2}\nTown: {3}",
                        employee.FirstName,
                        employee.LastName,
                        employee.Address,
                        employee.TownName);
                }
            }
        }

        private static void SelectEmployees()
        {
            using (var context = new TelerikAcademyEntities())
            {
                Console.WriteLine("Employees:");

                var employees =
                    from e in context.Employees
                    join a in context.Addresses
                      on e.AddressID equals a.AddressID
                    join t in context.Towns
                      on a.TownID equals t.TownID
                    where t.Name == "Sofia"
                    select e;

                foreach (var employee in employees.ToList())
                {
                    Console.WriteLine(
                        "Name: {0} {1}\nAddress: {2}\nTown: {3}",
                        employee.FirstName,
                        employee.LastName,
                        employee.Address.AddressText,
                        employee.Address.Town.Name);
                }
            }
        }

        static void Main()
        {
            //SelectEmployeesNoInclude();
            //SelectEmployeesWithStrategy();
            //SelectEmployeesUsingToList();
            SelectEmployees();
        }
    }
}
