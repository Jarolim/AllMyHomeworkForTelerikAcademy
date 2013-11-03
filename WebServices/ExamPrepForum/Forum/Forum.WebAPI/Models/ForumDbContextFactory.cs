using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using DataLayer;

namespace Forum.WebAPI.Models
{
    public class ForumDbContextFactory: IDbContextFactory<DbContext>
    {
        public DbContext Create() 
        {
            return new ForumContext();
        }
    }
}