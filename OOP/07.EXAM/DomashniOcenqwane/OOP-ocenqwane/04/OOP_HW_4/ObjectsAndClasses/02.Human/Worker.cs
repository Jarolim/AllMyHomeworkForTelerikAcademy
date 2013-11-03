using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HumanGroup
{
    class Worker : Human
    {
        public decimal WeekSalary { get; set; }
        public int WorkHoursPerDay { get; set; }

        public Worker (string pFirstName, string pLastName) 
            : base (pFirstName, pLastName){}

        public Worker (string pFirstName, string pLastName, decimal pWeekSalary, int pWorkHoursPerDay) 
            : this (pFirstName, pLastName)
        {
            if ((pWorkHoursPerDay < 0) || (pWorkHoursPerDay > 24))
                throw new ArgumentOutOfRangeException("Invalid working hours value!");

            this.WeekSalary = pWeekSalary;
            this.WorkHoursPerDay = pWorkHoursPerDay;
        }

        public decimal MoneyPerHour()
        {
            return this.WeekSalary / (this.WorkHoursPerDay * 5);
        }
    }
}
