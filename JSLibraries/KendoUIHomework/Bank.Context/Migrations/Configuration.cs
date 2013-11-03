namespace Bank.Context.Migrations
{
    using Bank.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Bank.Context.BankContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Bank.Context.BankContext context)
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
            var user = new User
            {
                Username="hasankata",
                AuthCode="aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                FullName="ali hasan mustafa"
            };
            var acc = new Account
            {
                Balance=1999,
                CreatedOn=DateTime.Now,
                ExpireDate= DateTime.Now.AddYears(5),
                Owner = user
                
            };
            user.Accounts.Add(acc);
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
