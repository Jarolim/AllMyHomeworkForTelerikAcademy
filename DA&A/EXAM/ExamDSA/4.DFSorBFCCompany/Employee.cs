using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.DFSorBFCCompany
{
    class Employee
    {
        public List<Employee> Subordinates { get; private set; }
        public int Salary { get; set; }
        public string Name { get; set; }

        //public void AddEmployee(Employee employee)
        //{
        //    
        //}

        public Employee(string name)
        { 
            this.Name = name;
            this.Salary = 1;
            this.Subordinates = new List<Employee>();
        }
    }
}
