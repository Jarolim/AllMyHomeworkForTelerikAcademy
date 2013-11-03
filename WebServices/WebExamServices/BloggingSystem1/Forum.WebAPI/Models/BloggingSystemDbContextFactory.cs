using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace BloggingSystem.WebAPI.Models
{
    public class BloggingSystemDbContextFactory:IDbContextFactory<DbContext>
    {
        public DbContext Create()
        {
            return new BloggingSystemContext();
        }
    }
}