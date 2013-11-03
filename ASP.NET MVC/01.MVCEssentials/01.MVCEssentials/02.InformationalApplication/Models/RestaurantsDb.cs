using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _02.InformationalApplication.Models
{
    public class RestaurantsDb : DbContext
    {
        public RestaurantsDb() : base("name=DefaultConnection")
        {

        }


        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> Reviews { get; set; }
    }
}