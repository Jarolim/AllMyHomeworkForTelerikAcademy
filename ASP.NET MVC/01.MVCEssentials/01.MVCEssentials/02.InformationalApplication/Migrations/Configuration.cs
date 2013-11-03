namespace _02.InformationalApplication.Migrations
{
    using _02.InformationalApplication.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_02.InformationalApplication.Models.RestaurantsDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "_02.InformationalApplication.Models.RestaurantsDb";
        }

        protected override void Seed(_02.InformationalApplication.Models.RestaurantsDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Restaurants.AddOrUpdate(r => r.Name,
               new Restaurant { Name = "Sabatino's", City = "Baltimore", Country = "USA" },
               new Restaurant { Name = "Great Lake", City = "Chicago", Country = "USA" },
               new Restaurant
               {
                   Name = "Smaka",
                   City = "Gothenburg",
                   Country = "Sweden",
                   Reviews =
                       new List<RestaurantReview> { 
                       new RestaurantReview { Rating = 9, Body="Great food!", ReviewerName="Scott" }
                   }
               });

        }
    }
}
