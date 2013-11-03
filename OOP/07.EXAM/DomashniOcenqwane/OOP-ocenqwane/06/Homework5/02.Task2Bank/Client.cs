using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Task2Bank
{
    // The abstract class Client with protected constructor and overrident ToString
    public abstract class Client
    {
        private string name;

        public string Name
        {
            get { return name; }
            protected set {
                if (value == null)
                    throw new ArgumentNullException(String.Format("{0} name cannot be null or unassigned.",this.GetType().Name));
                name = value;
            }
        }

        protected Client(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return String.Format("Name: {0}, type: {1}", this.Name, this.GetType().Name);
        }
    }
}
