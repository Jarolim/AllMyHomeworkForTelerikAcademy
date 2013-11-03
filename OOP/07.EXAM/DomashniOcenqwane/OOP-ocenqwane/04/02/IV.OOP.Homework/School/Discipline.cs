using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Discipline: ICommentable
    {
        private string objectName;
        private int numLectures;
        private int numExercises;
        private List<string> comments;

        public string ObjectName
        {
            get { return this.objectName; }
            private set { this.objectName = value; }
        }

        public int NumLectures
        {
            get { return this.numLectures; }
            private set { this.numLectures = value; }
        }

        public int NumExercises
        {
            get { return this.numExercises; }
            private set { this.numExercises = value; }
        }

        public List<string> Comments
        {
            get
            {
                return this.comments.ToList();
            }
        }

        public Discipline()
        {
            this.objectName = "Empty entry";
            this.numLectures = 0;
            this.NumExercises = 0;
            this.comments = new List<string>();
        }

        public Discipline(string name): base()
        {
            this.objectName = name;
        }

        public Discipline(string name, int lecturesCount): base()
        {
            this.objectName = name;
            this.numLectures = lecturesCount;
        }

        public Discipline(string name, int lecturesCount, int exercisesCount): base()
        {
            this.objectName = name;
            this.numLectures = lecturesCount;
            this.NumExercises = exercisesCount;
        }

        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }
    }
}
