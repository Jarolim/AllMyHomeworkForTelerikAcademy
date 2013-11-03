using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Human
{
    abstract class Human
    {
        public string firstName { get; set; }
        public string secondName { get; set; }

        protected Human(string firstName, string secondName)
        {
            this.firstName = firstName;
            this.secondName = secondName;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("first name: {0}, second name: {1} ",
                this.firstName.ToString(), this.secondName.ToString());
            return output.ToString();
        }
    }
}
