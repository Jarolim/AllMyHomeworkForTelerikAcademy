using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem2
{
	public static class Problem2
	{
		public static decimal Min<T>(this IEnumerable<T> enumeration)
		{
			decimal min = decimal.MaxValue;
			foreach (var item in enumeration)
				if (Convert.ToDecimal(item) < min)
					min = Convert.ToDecimal(item);

			return min;
		}
	
		public static decimal Max<T>(this IEnumerable<T> enumeration)
		{
			decimal max = decimal.MinValue;
			foreach (var item in enumeration)
				if (Convert.ToDecimal(item) > max)
					max = Convert.ToDecimal(item);

			return max;
		}

		public static decimal Sum<T>(this IEnumerable<T> enumeration)
		{
			decimal sum = 0;
			foreach (var item in enumeration)
				sum += Convert.ToDecimal(item);

			return sum;
		}

		public static decimal Average<T>(this IEnumerable<T> enumeration)
		{
			decimal average = 0;
			foreach (var item in enumeration)
				average += Convert.ToDecimal(item);

			return average / enumeration.Count();
		}
	
		public static decimal Product<T>(this IEnumerable<T> enumeration)
		{
			decimal product = 1;
			foreach (var item in enumeration)
				product *= Convert.ToDecimal(item);

			return product;
		}
	}
}
