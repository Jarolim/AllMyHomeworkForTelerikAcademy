using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public interface Icommentable
    {
        string FreeComments { set; }

        void ShowFreeComments();
        string AddFreeComments(string comment);
        void ClearFreeComments();
    }   
}
        