using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipies.Model;

namespace Recipies.Data
{
    public class RecipesContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public RecipesContext()
            : base("RecipesBookDb")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(m => m.MyRecipes)
                .WithRequired(p=>p.Creator)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(m => m.Favorites)
                .WithMany(p => p.Fans)
                .Map(a =>
                {
                    a.ToTable("UsersFavourites");
                    a.MapLeftKey("UserId");
                    a.MapRightKey("Id");
                });

          
        }
    }
}
