using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Implement an extension method Substring(int index, int length)
 * for the class StringBuilder that returns new StringBuilder and
 * has the same functionality as Substring in the class String.
 */
namespace Substring
{
    public static class StringBuilderSubString
    {
        public static StringBuilder SubString (this StringBuilder stringBuilderIn,int index,int length)
        {
            StringBuilder stringBuilderOut = new StringBuilder();
            if (index + length>=stringBuilderIn.Length ||index<0)
            {
                throw new ArgumentException("The index is out of range");
            }
            for (int i = index; i < index + length; i++)
            {
                stringBuilderOut.Append(stringBuilderIn[i]);
            }
            return stringBuilderOut;
        }
    }
}
