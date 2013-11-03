using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    interface ICommentable
    {
        void AddComment(string comment);
        string GetComment();
    }
}
