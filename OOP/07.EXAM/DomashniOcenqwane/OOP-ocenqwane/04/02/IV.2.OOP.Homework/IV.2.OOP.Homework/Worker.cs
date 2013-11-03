using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV._2.OOP.Homework
{
    class Worker: Human
    {
        private decimal weekSalary;
        private int workHrsPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, int workHrsPerDay)
            : base(firstName, lastName)
        {
            this.weekSalary = weekSalary;
            this.workHrsPerDay = workHrsPerDay;
        }

        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            private set
            {
                if (weekSalary >= 0)
                {
                    this.weekSalary = value;
                }
                else
                {
                    throw new ArgumentException("The weekly salary can not be negative number!");
                }
            }
        }

        public int WorkHrsPerDay
        {
            get { return this.workHrsPerDay; }
            private set
            {
                if (workHrsPerDay >= 0)
                {
                    this.workHrsPerDay = value;
                }
                else
                {
                    throw new ArgumentException("The working hours per day can not be negative number!");
                }
            }
        }

        public decimal MoneyPerHour()
        {
            decimal result = this.weekSalary / (5 * this.workHrsPerDay);
            return result;
        }
    }
}
