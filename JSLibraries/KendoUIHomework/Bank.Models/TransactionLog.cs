using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class TransactionLog
    {
        public int Id { get; set; }

        public string LogText { get; set; }

        public DateTime LogDate { get; set; }

        public Account Account { get; set; }
    }
}
