using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Bank.Models;

namespace Bank.Context
{
    public partial class BankContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TransactionLog> TransactionLogs { get; set; }

        public BankContext() : base("BankContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

    }
}
