using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_3_Students
{
    public class Student : ICloneable, IComparable<Student>
    {
        public string firstName;
        public string middleName;
        public string lastName;
        public long ssn;
        public string address;
        public long mobilePhone;
        public string email;
        public int course;
        public Specialty specialty;
        public University university;
        public Faculty faculty;

        public Student(string firstName, string middleName, string lastName, long ssn, string address,
            long mobilePhone, string email, int course, Specialty specialty, University university, Faculty faculty)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.ssn = ssn;
            this.address = address;
            this.mobilePhone = mobilePhone;
            this.email = email;
            this.course = course;
            this.specialty = specialty;
            this.university = university;
            this.faculty = faculty;
        }

        public override bool Equals(object obj)
        {
            if (this.ssn != (obj as Student).ssn)
                return false;

            return true;
        }

        public override string ToString()
        {
            return string.Format("Name: {0} {1} {2} \nSSN: {3} \nAddress: {4} \nMobile phone: {5} \nSpecialty: {6} \n" +
                "University: {7}", firstName, middleName, lastName, ssn, address, mobilePhone, specialty, university);
        }

        public override int GetHashCode()
        {
            return firstName.GetHashCode() ^ lastName.GetHashCode() ^ ssn.GetHashCode();
        }

        public static bool operator ==(Student s1, Student s2)
        {
            return (s1.ssn == s2.ssn);
        }

        public static bool operator !=(Student s1, Student s2)
        {
            return (s1.ssn != s2.ssn);
        }

        public object Clone()
        {
            return new Student(this.firstName, this.middleName, this.lastName, this.ssn, this.address,
            this.mobilePhone, this.email, this.course, this.specialty, this.university, this.faculty) as object;
        }

        public int CompareTo(Student s)
        {
            if (firstName.CompareTo(s.firstName) != 0)
                return firstName.CompareTo(s.firstName);
            else if (middleName.CompareTo(s.middleName) != 0)
                return middleName.CompareTo(s.middleName);
            else if (lastName.CompareTo(s.lastName) != 0)
                return lastName.CompareTo(s.lastName);
            else
            {
                return ssn.CompareTo(s.ssn);
            }
        }
    }
}
