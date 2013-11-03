namespace Bookstore.Logs
{
    using System;

    public class SearchLog
    {
        public int SearchLogId { get; set; }

        public DateTime DateCreatedOn { get; set; }

        public string LogContent { get; set; }
    }
}
