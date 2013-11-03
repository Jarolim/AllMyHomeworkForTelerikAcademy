using System;
using System.Linq;
using System.Data.Entity;

namespace SearchLogsData
{
    public class LogEntities : DbContext
    {
        public DbSet<SearchLog> SearchLogs { get; set; }

        public LogEntities()
            : base("BookstoreLogs")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SearchLog>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
