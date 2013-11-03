using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Human
{
    class Worker:Human
    {
        private double weekSalary;
        private double workHoursPerDay;
        private double moneyPerHour;

        public double WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            set
            {
                this.weekSalary = value;
            }
        }
        public double WorkHoursPerDay
        {   
            get
            {
                return this.workHoursPerDay;
            }
            set
            {
                this.workHoursPerDay = value;
            }
        }

        public double MoneyPerHour
        {
            get
            {
                return weekSalary / (workHoursPerDay * 5);
            }
            set
            {
                this.moneyPerHour = value;
            }
        }

        public Worker(string firstName, string secondName, double weekSalary, double workHoursPerDay)
            :base(firstName,secondName)
        {
            this.weekSalary = weekSalary;
            this.workHoursPerDay = workHoursPerDay;
            this.moneyPerHour = this.MoneyPerHour;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0} week salary: {1} for {2} hours per day\n ( {3} per hour) ", base.ToString(),this.weekSalary.ToString(),this.workHoursPerDay.ToString(),
                this.moneyPerHour.ToString());
            return output.ToString();
        }


       
    }
}
