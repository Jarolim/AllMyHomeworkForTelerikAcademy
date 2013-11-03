using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//sum, product, min, max, average.

namespace IEnumerableExtensions
{
   public static class Extensions
    {
       public static T SumIEnumerable<T>(this IEnumerable<T> input)
       {
           if (input.Count()==0)
           {
               throw new ArgumentOutOfRangeException("The stricture is empty.");
           }
           dynamic sum = default(T);
           foreach (var item in input)
           {
               sum += item;
           }
           return sum;
       }
       public static T ProductIEnumerable<T>(this IEnumerable<T> input) where T : IComparable, IComparable<T>
       {
           if (input.Count() == 0)
           {
               throw new ArgumentOutOfRangeException("The stricture is empty.");
           }
         
           T product = (dynamic)1;
           foreach (var item in input)
           {
               product *= (dynamic)item;
           }
           return product;
       }
       public static T MinIEnumerable<T>(this IEnumerable<T> input) where T : IComparable, IComparable<T>
       {
           if (input.Count() == 0)
           {
               throw new ArgumentOutOfRangeException("The stricture is empty.");
           }

           T minValue = input.First() ;
           foreach (var item in input)
           {
               if (minValue.CompareTo(item)<0)
               {
                   minValue = item;
               }
   
           }
           return minValue;
       }
       public static T MaxIEnumerable<T>(this IEnumerable<T> input) where T : IComparable, IComparable<T>
       {
           if (input.Count() == 0)
           {
               throw new ArgumentOutOfRangeException("The stricture is empty.");
           }

           T maxValue = input.First();
           foreach (var item in input)
           {
               if (maxValue.CompareTo(item) < 0)
               {
                   maxValue = item;
               }

           }
           return maxValue;
       }
       public static T AverageIEnumerable<T>(this IEnumerable<T> input) where T : IComparable, IComparable<T>
       {
           if (input.Count() == 0)
           {
               throw new ArgumentOutOfRangeException("The stricture is empty.");
           }
           dynamic sum = default(T);
           foreach (var item in input)
           {
               sum += item;
           }
           return sum/input.Count();
       }
    }
}
