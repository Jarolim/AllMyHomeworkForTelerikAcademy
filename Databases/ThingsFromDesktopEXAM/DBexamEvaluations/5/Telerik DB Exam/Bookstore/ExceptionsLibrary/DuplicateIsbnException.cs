using System;
using System.Linq;

namespace ExceptionsLibrary
{
    public class DuplicateIsbnException : Exception
    {
        public DuplicateIsbnException(string msg)
            : base(msg)
        {
        }
    }
}
