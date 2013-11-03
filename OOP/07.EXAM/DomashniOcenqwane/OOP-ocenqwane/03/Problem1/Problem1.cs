using System;
using System.Linq;
using System.Text;

namespace Problem1
{
	public static class Problem1
	{
		public static StringBuilder StringBuilderSubstring(this StringBuilder sb, int start, int count)
		{
			string substring  = sb.ToString().Substring(start, count);
			sb = sb.Clear().Append(substring);

			return sb;
		}
	}
}
