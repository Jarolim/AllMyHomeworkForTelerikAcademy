using System;

namespace School
{
    class Discipline : ICommentable
    {
        private string comment;

        public string Name { get; private set; }
        public int NumberLectures { get; private set; }
        public int NumberExercises { get; private set; }

        public Discipline (string pName, int pNumberLectures, int pNumberExercises)
        {
            this.Name = pName;
            this.NumberLectures = pNumberLectures;
            this.NumberExercises = pNumberExercises;
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
