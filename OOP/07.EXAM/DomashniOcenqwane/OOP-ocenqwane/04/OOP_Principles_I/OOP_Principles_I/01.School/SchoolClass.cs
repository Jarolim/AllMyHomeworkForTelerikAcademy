using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public class SchoolClass:School,Icommentable
    {  
        private List<Student> students;
        private List<Teacher> teachers;
       
        public List<Student> Students
        {
            get
            {
                return this.students;
            }
            private set
            {
                if (students.Count < 1)
                {
                    throw new ArgumentException(
                        String.Format("at least 1 student")
                        );
                }
                this.students = value;
            } 
        }
        public List<Teacher> Teachers
        {
            get
            {
                return this.teachers.ToList();
            }
            private set
            {
                if (students.Count < 1)
                {
                    throw new ArgumentException(
                        String.Format("at least 1 student")
                        );
                }
                this.teachers = value;
            }
        }
        public string ClassID { get; set; }

        public SchoolClass(List<Teacher> teachers, List<Student> students,string classID)
        {
            this.teachers = teachers;
            this.students = students;
            this.ClassID = classID;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("ClassID: {0}",
                this.ClassID.ToString());
            output.AppendLine("\n\nStudents\n");
            foreach (Student student in Students)
            {
                output.AppendLine(student.ToString());
            }
            output.AppendLine("\n\nTeachers\n");
            foreach (Teacher teacher in Teachers)
            {
                output.AppendLine(teacher.ToString());
            }
            return output.ToString();
        }
    }
}
