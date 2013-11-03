using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MoviesApp.Models
{
    public class MoviesDb : DbContext
    {
        public MoviesDb()
            : base("DefaultConnection")
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
    }
}