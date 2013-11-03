using System;
using System.Collections.Generic;

namespace School
{
    class Teacher : Person, ICommentable
    {
        private string comment;
        public List<Discipline> Disciplines { get; private set; }

        public Teacher(string  pFirstName, string pLastName)
            : base(pFirstName, pLastName) 
        {
            this.Disciplines = new List<Discipline>();
        }

        public void AddDiscipline (Discipline newDiscipline)
        {
            this.Disciplines.Add(newDiscipline);
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
