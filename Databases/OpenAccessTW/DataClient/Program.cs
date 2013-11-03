using OpenAccessModel9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.OpenAccess;
using System.Linq.Dynamic;
using Telerik.OpenAccess.FetchOptimization;

namespace DataClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new EntitiesModel())
            {
                context.Log = Console.Out;

                 //SimpleLinq(context);

               //LinqWithFetchStrategy(context);

                //DynamicLinq(context);

                //CommonLinqMistakes(context);

                //BulkUpdate(context);

                //BulkDelete(context);
            }
        }

        private static void SimpleLinq(EntitiesModel context)
        {
            Console.WriteLine("No Fetch optimization:");
            var query1 = context.Cars.Where(c => c.CarYear < 2000).ToList();
            Console.WriteLine("Car\tCategory");
            foreach (var car in query1)
            {
                Console.WriteLine("{0}\t{1}", car.CarID, car.Category.CategoryName);
            }
        }

        private static void LinqWithFetchStrategy(EntitiesModel context)
        {
            Console.WriteLine("With fetch optimization:");

            FetchStrategy strategy = new FetchStrategy();
            strategy.LoadWith<Car>(c => c.Category);
            strategy.LoadWith<Category>(cat => cat.RentalRates);
            // set the strategy to the context
            context.FetchStrategy = strategy;

            var query2 = context.Cars//.Include(c => c.Category)
                                     //.Include(c => c.Category.RentalRates.Select(r=>r.SubRates))
                                     .Where(c => c.CarYear < 2000).ToList();
            Console.WriteLine("Car\tCategory");
            foreach (var car in query2)
            {
                Console.WriteLine("{0}\t{1}", car.CarID, car.Category.CategoryName);
                
            }

            // remove the strategy
            context.FetchStrategy = null;
        }

        private static void DynamicLinq(EntitiesModel context)
        {
            // strongly typed dynamic LINQ
            Console.WriteLine("Dynamic strongly typed LINQ Where:");
            var query1 = context.Cars.Where("CarYear < @0", 2000).ToList();
            Console.WriteLine("Car\tCategory");
            foreach (var car in query1)
            {
                Console.WriteLine("{0}\t{1}", car.CarID, car.Category.CategoryName);
            }

            // weakly typed dynamic LINQ with projection
            Console.WriteLine("Dynamic weakly typed LINQ Where and Select:");
            var objList = context.GetAll("OpenAccessModel9.Car").Where("CarYear < @0", 2000)
                .Select("new (CarID as Id, CarYear)")
                .Cast<object>().ToList();
            foreach (object objCar in objList)
            {
                Console.WriteLine(objCar);
            }
        }

        private static void CommonLinqMistakes(EntitiesModel context)
        {
            Console.WriteLine("Common mistakes:");

            Console.WriteLine("Calling .ToList too early:");
            var query1 = context.Cars.ToList().Where(c => c.Make == "VW");
            Console.WriteLine("************");

            Console.WriteLine("Calling CLR method in Where:");
            var query2 = context.Cars.Where(c => SomeMethod(c) == "42");
            string query2Text = query2.ToString();
            var query2Result = query2.ToList();
             Console.WriteLine("************");

            Console.WriteLine("Using projection will not fill the L1 and L2 caches");
            var query3 = context.Cars.Select(c => new { Id = c.CarID, Name = c.Make + c.Model });
            var query3Text = query3.ToString();
            Console.WriteLine("************");

            Console.WriteLine("Getting too much data:");
            var query4 = context.Cars.Where(c => c.Make == "BMW");
            var query4Text = query4.ToString();
            var query4Result = query4.ToList().Count(); // we don't need the whole list of fully loaded cars to count them!
            Console.WriteLine("************");

            Console.WriteLine("Using constants and other non-cacheable pieces instead of parameters:");
            string make = "BMW";
            Console.WriteLine("With parameter:");
            var query5 = context.Cars.Where(c => c.Make == make); // make is converted into parameter and the query is cached properly
            var query5Text = query5.ToString();
            Console.WriteLine("Without parameter:");
            var query6 = context.Cars.Where(c => c.Make == "BMW"); // "BMW" cannot be converted to parameter and the query will not be reused if "BMW' is changed to "VW"
            var query6Text = query6.ToString();
            
            Console.WriteLine("************");

            Console.WriteLine("Disposing context before enumerating the query result");
            IQueryable<Car> query7 = null;
            using (EntitiesModel ctx = new EntitiesModel())
            {
                query7 = ctx.Cars.Where(c => c.Make == "BMW");
            }
            Console.WriteLine("Car\tCategory");
            foreach (var car in query7)
            {
                Console.WriteLine("{0}\t{1}", car.CarID, car.Category.CategoryName);
            }
            Console.WriteLine("************");
        }

        private static string SomeMethod(Car car)
        {
            return string.Empty;
        }

        private static void BulkUpdate(EntitiesModel context)
        {
            string tooOldName = "Too old";
            Category tooOldCategory = context.Categories.FirstOrDefault(c => c.CategoryName == tooOldName);
            if (tooOldCategory == null)
            {
                tooOldCategory = new Category();
                tooOldCategory.CategoryName = tooOldName;
                context.Add(tooOldCategory);
                context.SaveChanges();
            }

            var query = context.GetAll<Car>().Where(c => c.CarYear < 2000);

            int updated = query.UpdateAll(u => u.Set(c => c.Category, c => tooOldCategory)
                                                .Set(c => c.Available, c => false));

            Console.WriteLine("Updated cars: {0}", updated);
        }

        private static void BulkDelete(EntitiesModel context)
        {
            // avoid showing the INSERT statements that populate the data
            context.Log = null;

            for (int i = 0; i < 10; i++)
            {
                Car car = new Car() { Make = "BMW", Model = "1020", CarYear = 2018, Available = true, CategoryID = 1, TagNumber = i.ToString()};
                context.Add(car);
            }
            context.SaveChanges();

            // show the delete statements
            context.Log = Console.Out;

            var query = context.GetAll<Car>().Where(c => c.CarYear > DateTime.Now.Year);
            int deleted = query.DeleteAll();
            Console.WriteLine("Deleted cars: {0}", deleted);
        }
    }
}