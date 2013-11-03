using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Peshko", 4);
            Person p2 = new Person("Goshko");

            Console.WriteLine("--- Person 1 ---");
            Console.WriteLine(p1);
            Console.WriteLine();
            Console.WriteLine("--- Person 2 ---");
            Console.WriteLine(p2);
        }
    }

    /// <summary>
    /// Class Person
    /// </summary>
    class Person
    {
        private string Name;
        private int? Age;

        /// <summary>
        /// Property Person name
        /// </summary>
        public string name
        {
            get { return Name; }
            set { Name = value; }
        }

        /// <summary>
        /// Nullable property Person age
        /// </summary>
        public int? age
        {
            get { return Age.Value; }
            set { Age = value; }
        }

        /// <summary>
        /// Constructor for the Person class
        /// </summary>
        /// <param name="name">Person name</param>
        /// <param name="age">Person age</param>
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        /// <summary>
        /// Partial constructor for the Person class
        /// </summary>
        /// <param name="name">Person name</param>
        public Person(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Method overriding the built in ToString() method
        /// </summary>
        /// <returns>Information for the Person</returns>
        public override string ToString()
        {
            StringBuilder strBuild = new StringBuilder();
            strBuild.Append("Name: ");
            strBuild.Append(Name);
            strBuild.Append(Environment.NewLine);
            if (Age == null)
            {
                strBuild.Append("Age is not defined");
            }
            else
            {
                strBuild.Append("Age: ");
                strBuild.Append(Age);
            }
            return strBuild.ToString();
        }
    }
}
