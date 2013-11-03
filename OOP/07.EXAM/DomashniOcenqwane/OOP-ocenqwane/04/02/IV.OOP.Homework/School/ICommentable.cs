using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public interface ICommentable
    {
        List<string> Comments
        {
            get;
        }
        void AddComment(string comment);
    }
}
