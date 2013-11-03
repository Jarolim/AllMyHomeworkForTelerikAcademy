using System;
using System.Linq;
using Bank.Common;

namespace TestBanks
{
    class TestBanks
    {
        static void Main()
        {
            IndividualCustomer cst = new IndividualCustomer("Ivo","Pavlev","Andonov","083472221");
            DepositAccount depositAcc = new DepositAccount(cst, 1000, 0.5m);
            Console.WriteLine(depositAcc);
            //  depositAcc.WithDraw(20);
            Console.WriteLine("New balance:{0}", depositAcc.Balance);
            // depositAcc.Deposit(100000);
            Console.WriteLine("New balance:{0}", depositAcc.Balance);
            Console.WriteLine("{0:0.0}", depositAcc.CalculateInterestAmount(12));
            //------------------------------------------------------------------------------
            Console.WriteLine();

            IndividualCustomer cst1 = new IndividualCustomer("Ivo", "Pavlev", "Andonov", "083472221");
            LoanAccount loanAcc = new LoanAccount(cst1, 1000, 1m);
            Console.WriteLine(loanAcc);
            loanAcc.Deposit(50);
            //  depositAcc.WithDraw(20);
            // depositAcc.Deposit(100000);
            Console.WriteLine("New balance:{0}", loanAcc.Balance);
            Console.WriteLine("{0:0.0}", loanAcc.CalculateInterestAmount(5));
            //------------------------------------------------------------------------------
            Console.WriteLine();

            IndividualCustomer cst2 = new IndividualCustomer("Ivo", "Pavlev", "Andonov", "083472221");
            MortgageAccount mortageAcc = new MortgageAccount(cst2, 1000, 1m);
            Console.WriteLine(mortageAcc);
            mortageAcc.Deposit(50);
            //  depositAcc.WithDraw(20);
            // depositAcc.Deposit(100000);
            Console.WriteLine("New balance:{0}", mortageAcc.Balance);
            Console.WriteLine("{0:0.0}", mortageAcc.CalculateInterestAmount(7));

            //------------------------------------------------------------------------------
            Console.WriteLine();
            CompanyCustomer cst3 = new CompanyCustomer("Masson","083472221");
            MortgageAccount mortageAcc1 = new MortgageAccount(cst3, 10000, 1m);
            Console.WriteLine(mortageAcc1);
            mortageAcc1.Deposit(50);
            //  depositAcc.WithDraw(20);
            // depositAcc.Deposit(100000);
            Console.WriteLine("New balance:{0}", mortageAcc1.Balance);
            Console.WriteLine("{0:0.0}", mortageAcc1.CalculateInterestAmount(24));

        }
    }
}