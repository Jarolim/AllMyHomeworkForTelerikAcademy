using System;

namespace School
{
    class Student : Person, ICommentable
    {
        static int idCounter = 0;

        private string comment;
        public int UniqueId { get; private set; }
        
        public Student(string  pFirstName, string pLastName)
            : base(pFirstName, pLastName)
        {
            this.UniqueId = idCounter;
            idCounter++;
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
