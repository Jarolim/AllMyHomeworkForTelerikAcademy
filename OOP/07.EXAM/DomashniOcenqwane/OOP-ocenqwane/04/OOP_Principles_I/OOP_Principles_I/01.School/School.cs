using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{   
    public class School:Person        
    {
        private List<SchoolClass> schoolClasses;

        public string schoolName { get; set; }

        public School(){ }
        public School(string name,List<SchoolClass> schoolClasses)
        {
            this.schoolName = name;
            this.schoolClasses = schoolClasses;
        }
   
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("School: {0} \n\n", schoolName.ToString());
            foreach (var item in schoolClasses)
            {
                output.AppendLine(item.ToString());
            }
            return output.ToString();
        }
    }
}
