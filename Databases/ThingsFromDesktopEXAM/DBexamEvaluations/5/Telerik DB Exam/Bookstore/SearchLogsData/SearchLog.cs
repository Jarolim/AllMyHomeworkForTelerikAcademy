using System;
using System.Linq;

namespace SearchLogsData
{
    public class SearchLog
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string QueryXml { get; set; }
    }
}
