using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Student: Person, ICommentable
    {
        private string studentName;
        private int uniqueNumber;
        private List<string> comments;

        public string StudentName
        {
            get { return this.studentName; }
            private set { this.studentName = value; }
        }

        public int UniqueNumber
        {
            get { return this.uniqueNumber; }
            private set { this.uniqueNumber = value; }
        }

        public List<string> Comments
        {
            get
            {
                return this.comments.ToList();
            }
        }

        public Student()
        {
            this.studentName = "Empty entry";
            this.uniqueNumber = default(int);
        }

        public Student(string name): base()
        {
            this.studentName = name;
        }

        public Student(string name, int number)
        {
            this.studentName = name;
            this.uniqueNumber = number;
            this.comments = new List<string>();
        }

        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }
    }
}
