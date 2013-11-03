using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonTypeSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student("Ivan", "Borisov", "Tonchev", "1223413245", "Milka, Sofia", "0892345678", "Chichka@xyz.com",1,
                Specialty.KST, University.TU, Faculty.FKSU);

            Student s2 = new Student("Ivan", "Borisov", "Tonchev", "1223413245", "Milka, Sofia", "0892345678", "Chichka@xyz.com",1,
                Specialty.KST, University.TU, Faculty.FKSU);

            Console.WriteLine("Student 1 equals Student 2 ?");
            Console.WriteLine(s1.Equals(s2));
            Console.WriteLine();
            Console.WriteLine("Student 1 get hash code: ");
            Console.WriteLine(s1.GetHashCode());
            Console.WriteLine();
            Console.WriteLine("--- Student 1 toString() ---");
            Console.WriteLine(s1.ToString());
            Student s3 = (Student)s2.Clone();
            Console.WriteLine();
            s3.ssn = "2113453312";
            Console.WriteLine("Student 1 compared to Student 2: ");
            Console.WriteLine(s1.CompareTo(s2));
            Console.WriteLine();
            Console.WriteLine("Student 1 compared to Student 3: ");
            Console.WriteLine(s1.CompareTo(s3));
        }
    }

    /// <summary>
    /// Class Student - Inheriting interfaces IClonable and IComparable
    /// </summary>
    class Student : ICloneable, IComparable<Student>
    {
        private string FirstName;
        private string MiddleName;
        private string LastName;
        private string SSN;
        private string Address;
        private string Phone;
        private string E_mail;
        private int Course;
        private Specialty Specialty;
        private University University;
        private Faculty Faculty;

        /// <summary>
        /// Property Student firstname
        /// </summary>
        public string firstname
        {
            get { return FirstName; }
            set { FirstName = value; }
        }

        /// <summary>
        /// Property Student middlename
        /// </summary>
        public string middlename
        {
            get { return MiddleName; }
            set { MiddleName = value; }
        }

        /// <summary>
        /// Property Student lastname
        /// </summary>
        public string lastname
        {
            get { return LastName; }
            set { LastName = value; }
        }

        /// <summary>
        /// Property Student ssn
        /// </summary>
        public string ssn
        {
            get { return SSN; }
            set { SSN = value; }
        }

        /// <summary>
        /// Property Student address
        /// </summary>
        public string address
        {
            get { return Address; }
            set { Address = value; }
        }

        /// <summary>
        /// Property Student phone
        /// </summary>
        public string phone
        {
            get { return Phone; }
            set { Phone = value; }
        }

        /// <summary>
        /// Property Student email
        /// </summary>
        public string email
        {
            get { return E_mail; }
            set { E_mail = value; }
        }

        /// <summary>
        /// Property Student course
        /// </summary>
        public int course
        {
            get { return Course; }
            set { Course = value; }
        }

        /// <summary>
        /// Property Student Specialty objcet
        /// </summary>
        public Specialty specialty
        {
            get { return Specialty; }
            set { Specialty = value; }
        }

        /// <summary>
        /// Property Student University objcet
        /// </summary>
        public University university
        {
            get { return University; }
            set { University = value; }
        }

        /// <summary>
        /// Property Student Faculty objcet
        /// </summary>
        public Faculty faculty
        {
            get { return Faculty; }
            set { Faculty = value; }
        }

        /// <summary>
        /// Constructor for the class Student
        /// </summary>
        /// <param name="fName">Student firstname</param>
        /// <param name="mName">Student middlename</param>
        /// <param name="lName">Student lastname</param>
        /// <param name="ssn">Student ssn</param>
        /// <param name="address">Student address</param>
        /// <param name="phone">Student phone</param>
        /// <param name="mail">Student mail</param>
        /// <param name="course">Student course</param>
        /// <param name="spec">Student specialty object</param>
        /// <param name="univ">Student university object</param>
        /// <param name="facu">Student faculty object</param>
        public Student(string fName, string mName, string lName, string ssn, string address,
            string phone, string mail, int course, Specialty spec, University univ, Faculty facu)
        {
            FirstName = fName;
            MiddleName = mName;
            LastName = lName;
            SSN = ssn;
            Address = address;
            Phone = phone;
            Course = course;
            E_mail = mail;
            Specialty = spec;
            University = univ;
            Faculty = facu;
        }

        /// <summary>
        /// A clonable constructor for the Student
        /// </summary>
        /// <returns>A clone of the current object</returns>
        public Object Clone()
        {
            Student s = new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN, this.Address,
                this.Phone, this.E_mail, this.course, this.Specialty, this.University, this.Faculty);
            return s;
        }

        /// <summary>
        /// Method for overriding the built in method Equals
        /// </summary>
        /// <param name="obj">Student object</param>
        /// <returns>true - if equal, and false - if not equal</returns>
        public override bool Equals(object obj)
        {
            bool equals = true;
            if (obj is Student)
            {
                Student o = obj as Student;

                if (o == null)
                {
                    equals = false;
                }
                else
                {
                    return (o.address == address) && (o.firstname == firstname) && (o.middlename == middlename)
                        && (o.lastname == lastname) && (o.phone == phone) && (o.email == email) 
                        && (o.faculty == faculty)&& (o.university == university) && (o.specialty == specialty)
                        && (o.ssn == ssn) && (o.course == course);
                }
                
            }
            else
            {
                equals = false;
            }
                
            return equals;
        }

        /// <summary>
        /// Method for overriding the built in method ToString()
        /// </summary>
        /// <returns>Information for the Student object</returns>
        public override string ToString()
        {
            StringBuilder strBuild = new StringBuilder();
            strBuild.Append("First name: ");
            strBuild.Append(FirstName);
            strBuild.Append(Environment.NewLine);
            strBuild.Append("Middle name: ");
            strBuild.Append(MiddleName);
            strBuild.Append(Environment.NewLine);
            strBuild.Append("Last name: ");
            strBuild.Append(LastName);
            strBuild.Append(Environment.NewLine);
            strBuild.Append("SSN: ");
            strBuild.Append(SSN);
            strBuild.Append(Environment.NewLine);
            strBuild.Append("Address: ");
            strBuild.Append(Address);
            strBuild.Append(Environment.NewLine);
            strBuild.Append("Phone: ");
            strBuild.Append(Phone);
            strBuild.Append(Environment.NewLine);
            strBuild.Append("Mail: ");
            strBuild.Append(E_mail);
            strBuild.Append(Environment.NewLine);
            strBuild.Append("Course: ");
            strBuild.Append(Course);
            strBuild.Append(Environment.NewLine);
            strBuild.Append("Specialty: ");
            strBuild.Append(Specialty);
            strBuild.Append(Environment.NewLine);
            strBuild.Append("University: ");
            strBuild.Append(University);
            strBuild.Append(Environment.NewLine);
            strBuild.Append("Faculty: ");
            strBuild.Append(Faculty);
            strBuild.Append(Environment.NewLine);

            return strBuild.ToString();
        }

        /// <summary>
        /// Method overriding the built in GetHashCode method
        /// </summary>
        /// <returns>the hash code</returns>
        public override int GetHashCode()
        {
            return Address.GetHashCode() ^ FirstName.GetHashCode() ^ MiddleName.GetHashCode()
                        ^ LastName.GetHashCode() ^ Phone.GetHashCode() ^ E_mail.GetHashCode()
                        ^ Faculty.GetHashCode() ^ University.GetHashCode() ^ Specialty.GetHashCode()
                        ^ SSN.GetHashCode() ^ Course.GetHashCode();
        }

        /// <summary>
        /// Method for overriding the == operator
        /// </summary>
        /// <param name="s1">Student object 1</param>
        /// <param name="s2">Student object 2</param>
        /// <returns>true - if equal, false - if not equal</returns>
        public static bool operator ==(Student s1,Student s2)
        {
            bool isEqual = false;
            if(s1.Equals(s2))
            {
                return !isEqual;
            }
            else
            {
                return isEqual;
            }

        }

        /// <summary>
        /// Method for overriding the != operator
        /// </summary>
        /// <param name="s1">Student object 1</param>
        /// <param name="s2">Student object 2</param>
        /// <returns>true - if not equal, false - if equal</returns>
        public static bool operator !=(Student s1, Student s2)
        {
            bool isEqual = false;
            if (s1.Equals(s2))
            {
                return isEqual;
            }
            else
            {
                return !isEqual;
            }

        }

        /// <summary>
        /// Method for overriding the built in CompareTo method
        /// </summary>
        /// <param name="that">Student object</param>
        /// <returns>int value indicating the comparison result</returns>
        public int CompareTo(Student that)
        {
            if (this.FirstName.CompareTo(that.FirstName)<0) return -1;
            else if (this.FirstName.CompareTo(that.FirstName) > 0) return 1;
            else
            {
                if (this.MiddleName.CompareTo(that.MiddleName) < 0) return -1;
                else if (this.MiddleName.CompareTo(that.MiddleName) > 0) return 1;
                else
                {
                    if (this.LastName.CompareTo(that.LastName) < 0) return -1;
                    else if (this.LastName.CompareTo(that.LastName) > 0) return 1;
                    else
                    {
                        if (this.SSN.CompareTo(that.SSN) > 0) return -1;
                        else if (this.SSN.CompareTo(that.SSN) < 0) return 1;
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// Specialty enumeration
    /// </summary>
    public enum Specialty { KST = 1, ETT = 2, BA = 3, IM = 4 };

    /// <summary>
    /// University enumeration
    /// </summary>
    public enum University { TU = 1, UNSS = 2, SU = 3 };

    /// <summary>
    /// Faculty enumeration
    /// </summary>
    public enum Faculty { FKSU = 1, FETT = 2, BAM = 3, MI = 4 };
}
