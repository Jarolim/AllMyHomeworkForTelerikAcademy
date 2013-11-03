using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class Account
    {
        public int Id { get; set; }

        public decimal Balance { get; set; }

        public User Owner { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ExpireDate { get; set; }

        public ICollection<TransactionLog> Transactions { get; set; }

        public Account()
        {
            this.Transactions = new HashSet<TransactionLog>();
        }
    }
}
