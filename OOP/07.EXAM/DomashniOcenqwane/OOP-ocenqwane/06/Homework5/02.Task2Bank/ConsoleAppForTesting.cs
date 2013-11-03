using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Task2Bank
{
    class ConsoleAppForTesting
    {
        static void Main()
        {
            // Testing the task by creating a list of different accounts and a bank
            List < Account > theList= new List<Account>();
            theList.Add(new Deposit(new IndividualClient("Tony Buzan"), 1000, 0.114m));
            theList.Add(new Deposit(new Company("Shell"), 11100000, 0.15m));
            theList.Add(new Mortgage(new IndividualClient("Joe Sobran"),110000,0.20m));
            theList.Add(new Mortgage(new IndividualClient("Hristo Ivanov"), 150000, 0.22m));
            theList.Add(new Mortgage(new Company("Sofarma"), 250000000, 0.15m));
            theList .Add(new Loan(new IndividualClient("Joe Cocker"), 1000000, 0.17m));
            theList.Add(new Loan(new Company("Coca-Cola"), 120000000, 0.12m));
            Bank myNewBank= new Bank("ProCreditBank", theList);
            // Calculate interest for 10 months of each account
            foreach (Account c in myNewBank.ListOfAccounts)
                Console.WriteLine("The interest for 10 months for {0} is {1} {2}", c.ToString(), c.CalculateInterest(10), Environment.NewLine);
            decimal totalSumWithdrawn =0;
            // Withdrawing 1000 from every deposit
            foreach (Deposit c in myNewBank.ListOfAccounts.OfType<Deposit>())
            {
                Console.WriteLine("Withdrawing 1000 from {0} {1}", c.ToString(), Environment.NewLine);
                totalSumWithdrawn += c.DrawSum(1000);

            }
            Console.WriteLine("Total sum withdrawn is {0}", totalSumWithdrawn);
        }
    }
}
