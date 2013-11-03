using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StringBuilderSubstring
{
    public static class StringExtensions
    {
        public static StringBuilder Substring(this StringBuilder stringHolder, int index, int length)
        {
            if (index < 0)
	        {
		        throw new ArgumentOutOfRangeException("index", "Index cannot be less than zero.");
	        }
	        if (index >= stringHolder.Length)
	        {
		        throw new ArgumentOutOfRangeException("index", "Index cannot be larger than or equal to the length of the StringBuilder object.");
	        }
	        if (length < 0)
	        {
		        throw new ArgumentOutOfRangeException("length", "Length cannot be less than zero.");
	        }
	        if (index > stringHolder.Length - length)
	        {
		        throw new ArgumentOutOfRangeException("length", "Index and length must refer to a location within the StringBuilder object.");
	        }

            if (length == 0)
            {
                return new StringBuilder();
            }

            if (index == 0 && length == stringHolder.Length)
            {
                return new StringBuilder(stringHolder.ToString());
            }

            StringBuilder substring = new StringBuilder();
            
            for (int i = index; i < index + length; i++)
            {
                substring.Append(stringHolder[i]);
            }

            return substring;
        }

        public static StringBuilder Substring(this StringBuilder stringHolder, int index)
        {
            return Substring(stringHolder, index, stringHolder.Length - index);
        }
    }
}
