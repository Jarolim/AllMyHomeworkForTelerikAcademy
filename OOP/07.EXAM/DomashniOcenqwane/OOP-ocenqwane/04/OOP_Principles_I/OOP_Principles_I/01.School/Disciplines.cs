using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public class Disciplines:Icommentable
    {   
        public string name { get; set; }
        public int numberOfLectures { get;  set; }
        public int numberOfExercies { get;  set; }

        public Disciplines(){}
        public Disciplines(string name, int lectures, int exercises)
        {
            this.name = name;
            this.numberOfLectures = lectures;
            this.numberOfExercies = exercises;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("Discipline {0} - {1} lectures and {2} exercises",
                this.name, this.numberOfLectures, this.numberOfExercies);
            return output.ToString();
        }

        #region OPTIONAL COMMENTS IMPLEMENTATION
            //----- FIELDS ------
        private string freeComments;
        public string FreeComments
        {
            get
            {
                return freeComments;
            }
            set
            {
                freeComments = value;
            }
        } 
          //----- GET | SET  CLEAR -----
        public void ShowFreeComments()
        {
            Console.WriteLine(freeComments);
        }
        public string AddFreeComments(string comments)
        {
            return freeComments += comments;
        }
        public void ClearFreeComments()
        {
            freeComments = "";
        }
        #endregion
    }
}
