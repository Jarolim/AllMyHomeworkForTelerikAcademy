using System;
using System.Collections.Generic;

namespace School
{
    class SchoolClass : ICommentable
    {
        private static List<string> takenIdentifiers = new List<string>();

        public static List<string> TakenIdentifiers {get;private set;}

        private string comment;

        public string UniqueId { get; private set; }
        public List<Student> Students { get; private set; }
        public List<Teacher> Teachers { get; private set; }

        public SchoolClass(string pUniqueId)
        {
            if (TakenIdentifiers.IndexOf(pUniqueId) >= 0)
                throw new ArgumentException("Identifier is taken!");

            this.UniqueId = pUniqueId;
            TakenIdentifiers.Add(pUniqueId);
            this.Students = new List<Student>();
            this.Teachers = new List<Teacher>();
        }

        public void AddStudent(Student newStudent)
        {
            this.Students.Add(newStudent);
        }

        public void AddTeacher (Teacher newTeacher)
        {
            this.Teachers.Add(newTeacher);
        }

        public void AddComment(string pComment)
        {
            this.comment = pComment;
        }

        public string GetComment()
        {
            return this.comment ?? "";
        }
    }
}
