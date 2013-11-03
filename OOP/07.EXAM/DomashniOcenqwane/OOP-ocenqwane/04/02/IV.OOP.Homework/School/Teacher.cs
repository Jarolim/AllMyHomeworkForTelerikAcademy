using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Teacher: Person, ICommentable
    {
        private string teacherName;
        private List<Discipline> teacherObjects;
        private List<string> comments;

        public string TeacherName
        {
            get { return this.teacherName; }
            private set { this.teacherName = value; }
        }

        public List<Discipline> TeacherObjects
        {
            get {return this.teacherObjects; }
        }

        public List<string> Comments
        {
            get
            {
                return this.comments.ToList();
            }
        }

        public Teacher()
        {
            teacherName = "Empty Entry";
            this.teacherObjects = teacherObjects;
            this.comments = new List<string>();
        }

        public Teacher(string name): base()
        {
            this.teacherName = name;
        }

        public Teacher(string name, List<Discipline> disciplines): base()
        {
            this.teacherName = name;
            this.teacherObjects = disciplines;
        }

        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }
    }
}
