using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student
{
    using System;

    public class Student : ICloneable, IComparable<Student>
    {
        public enum Specialties { };
        public enum Universities { };
        public enum Faculties { };

        public string firstName;
        public string middleName;
        public string lastName;
        public string SSN;
        public string permanentAddress;
        public string mobilePhone;
        public string email;
        public string course;
        public Specialties specialty;
        public Universities university;
        public Faculties faculty;
        private Student student;

        public Student(string firstName, string middleName, string lastName, string SSN, string permanentAddress, string mobilePhone, string email, string course, Specialties specialty, Universities university, Faculties faculty)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.SSN = SSN;
            this.permanentAddress = permanentAddress;
            this.mobilePhone = mobilePhone;
            this.email = email;
            this.course = course;
            this.specialty = specialty;
            this.university = university;
            this.faculty = faculty;
        }

        public Student(Student student)
        {
            this.student = student;
        }

        public override string ToString()
        {
            string result = "";
            result += this.firstName;
            result += this.middleName;
            result += this.lastName;
            result += this.SSN;
            result += this.permanentAddress;
            result += this.mobilePhone;
            result += this.email;
            result += this.course;
            result += this.specialty;
            result += this.university;
            result += this.faculty;

            return result;
        }

        public override bool Equals(Student student)
        {
            return (this.ToString() == student.ToString());
        }

        public override int GetHashCode()
        {
            return this.firstName.GetHashCode() ^ this.middleName.GetHashCode() ^ this.lastName.GetHashCode() ^ this.SSN.GetHashCode() ^ this.permanentAddress.GetHashCode() ^ this.mobilePhone.GetHashCode() ^ this.email.GetHashCode() ^ this.course.GetHashCode() ^ this.specialty.GetHashCode() ^ this.university.GetHashCode() ^ this.faculty.GetHashCode();
        }

        public static bool operator ==(Student student1, Student student2)
        {
            return Student.Equals(student1, student2);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !(Student.Equals(student1, student2));
        }

        object ICloneable.Clone()
        {
            return new Student(this);
        }

        int IComparable<Student>.CompareTo(Student other)
        {
            if (this.firstName == other.firstName)
            {
                if (this.middleName == other.middleName)
                {
                    if (this.lastName == other.lastName)
                    {
                        return (this.SSN.CompareTo(other.SSN));
                    }
                    else return (this.lastName.CompareTo(other.lastName));
                }
                else return (this.middleName.CompareTo(other.middleName));
            }
            else return (this.firstName.CompareTo(other.firstName));
        }
    }
}    
                  
                  
                  
                  
                  