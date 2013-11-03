using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bank.API.Models
{
    public class FullAccountModel
    {
        public int Id { get; set; }

        public decimal Balance { get; set; }

        public LoggedUserModel Owner { get; set; }

        public IEnumerable<TransactionLogModel> Transactions { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ExpireDate { get; set; }

        public FullAccountModel()
        {
            this.Transactions = new HashSet<TransactionLogModel>();
        }
    }
}