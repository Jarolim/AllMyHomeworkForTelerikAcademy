using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program
{
    struct Employee
    {
        public int Value;
        public string FirstName;
        public string LastName;

        public Employee(int value, string firstName, string lastName)
        {
            this.Value = value;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }

    class EmployeeComparer : IComparer<Employee>
    {
        public int Compare(Employee empl1, Employee empl2)
        {
            if (empl1.Value == empl2.Value)
            {
                if (empl1.LastName == empl2.LastName)
                {
                    return empl2.FirstName.CompareTo(empl1.FirstName);
                }
                else
                {
                    return empl2.LastName.CompareTo(empl1.LastName);
                }
            }
            else
            {
                return empl1.Value.CompareTo(empl2.Value);
            }
        }
    }

    static void Main()
    {
        Hashtable positions = new Hashtable();
        Hashtable people = new Hashtable();
        List<Employee> employees = new List<Employee>();

        int positionCount = int.Parse(Console.ReadLine());

        for (int line = 0; line < positionCount; line++)
        {
            string position = Console.ReadLine();
            int firstIndex = position.IndexOf('-') - 1;
            int secondIndex = firstIndex + 3;
            positions[position.Substring(0, firstIndex)] = int.Parse(position.Substring(secondIndex, position.Length - (secondIndex)));
        }

        int peopleCount = int.Parse(Console.ReadLine());

        for (int line = 0; line < peopleCount; line++)
        {
            string position = Console.ReadLine();
            int firstIndex = position.IndexOf('-') - 1;
            int secondIndex = firstIndex + 3;
            people[position.Substring(0, firstIndex)] = positions[position.Substring(secondIndex, position.Length - (secondIndex))];
        }

        foreach (DictionaryEntry item in people)
        {
            string name = item.Key.ToString();
            int firstIndex = name.LastIndexOf(' ');
            int secondIndex = firstIndex;

            string firstName = name.Substring(0, firstIndex);
            string lastName = name.Substring(secondIndex, name.Length - (secondIndex));


            employees.Add(new Employee((int)item.Value, firstName, lastName));
        }

        employees.Sort(new EmployeeComparer());


        for (int i = employees.Count - 1; i >= 0; i--)
        {
            Console.WriteLine("{0} {1}", employees[i].FirstName.Trim(), employees[i].LastName.Trim());

        }
    }
}
