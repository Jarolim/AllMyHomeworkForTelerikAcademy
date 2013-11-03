using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bank.API.Models
{
    public class AccountModel
    {
        public int Id { get; set; }

        public string OwnerName { get; set; }

        public decimal Balance { get; set; }
    }
}