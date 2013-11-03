using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableGenericExtensions
{
    public static class IEnumerableGenericExtensions
    {
        public static T Sum<T>(this IEnumerable<T> enumeration)
        {
            dynamic sum = 0;

            foreach (T item in enumeration)
            {
                sum += item;
            }

            return sum;
        }

        public static T Product<T>(this IEnumerable<T> enumeration)
        {
            dynamic product = 1;

            foreach (T item in enumeration)
            {
                product *= item;
            }

            return product;
        }

        public static T Min<T>(this IEnumerable<T> enumeration)
            where T : IComparable<T>
        {
            IEnumerator<T> first = enumeration.GetEnumerator();
            first.MoveNext();

            T min = first.Current;

            foreach (T item in enumeration)
            {
                if (min.CompareTo(item) == 1)
                {
                    min = item;
                }
            }

            return min;
        }

        public static T Max<T>(this IEnumerable<T> enumeration)
            where T : IComparable<T>
        {
            IEnumerator<T> first = enumeration.GetEnumerator();
            first.MoveNext();

            T max = first.Current;

            foreach (T item in enumeration)
            {
                if (max.CompareTo(item) == -1)
                {
                    max = item;
                }
            }

            return max;
        }

        private static int Count<T>(this IEnumerable<T> enumeration)
        {
            int count = 0;

            foreach (T item in enumeration)
            {
                count++;
            }

            return count;
        }

        public static Decimal Average<T>(this IEnumerable<T> enumeration)
        {
            Decimal average = Convert.ToDecimal(enumeration.Sum()) / enumeration.Count();

            return average;
        }
    }
}
