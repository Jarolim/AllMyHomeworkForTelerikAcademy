using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Task2Bank
{
    // The class for the whole bank
    public class Bank
    {
        // Fields and properties
        private string name;

        public string Name
        {
            get { return name; }
            protected set {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException("The name of the bank cannot be null or empty.");
                name = value;
            }
        }

        private List<Account> listOfAccounts;

        public List<Account> ListOfAccounts
        {
            get { return listOfAccounts; }
            protected set { listOfAccounts = value; }
        }

        // Two constructors
        public Bank(string name)
        {
            this.Name = name;
            this.ListOfAccounts = new List<Account>();
        }

        public Bank(string name, List<Account> listOfAccounts) :this(name)
        {
            this.ListOfAccounts = listOfAccounts;
        }

        // Methods for adding and removing accounts
        public void AddAccount(Account accountToAdd)
        {
            this.ListOfAccounts.Add(accountToAdd);
        }

        public void AddAccounts(List<Account> listToAdd)
        {
            this.ListOfAccounts.AddRange(listToAdd);
        }

        public void RemoveAccount(Account accountToRemove)
        {
            this.ListOfAccounts.Remove(accountToRemove);
        }

        // Overriding ToString
        public override string ToString()
        {
            StringBuilder str = new StringBuilder(String.Format("Bank: {0} {1}", this.Name, Environment.NewLine));
            foreach (Account acc in this.ListOfAccounts)
                str.AppendLine(acc.ToString());
            return str.ToString();
        }
    }
}
