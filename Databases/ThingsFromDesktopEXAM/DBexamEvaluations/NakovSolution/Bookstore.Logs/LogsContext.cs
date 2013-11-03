using System;
using System.Data.Entity;

namespace Bookstore.Logs
{
    public class LogsContext : DbContext
    {
        public LogsContext()
			: base("LogsContext")
        {
        }

        public DbSet<SearchLog> SearchLogs { get; set; }

		public static void AppendToSearchLogs(string text)
		{
			LogsContext context = new LogsContext();
			SearchLog log = new SearchLog();
			log.DateCreatedOn = DateTime.Now;
			log.LogContent = text;
			context.SearchLogs.Add(log);
			context.SaveChanges();
		}
    }
}
