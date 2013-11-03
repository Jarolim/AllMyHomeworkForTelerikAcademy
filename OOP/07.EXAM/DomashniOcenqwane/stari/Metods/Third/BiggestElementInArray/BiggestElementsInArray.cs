using System;
using System.Linq;

namespace BiggestElementsInArray
{
    public class BiggestElementInArray
    {
        static void Main(string[] args)
        {
            int[] numbers = {3,4,3,9,8,7,8,2,1};
            Console.WriteLine(CheckElementInArray(0, numbers));
        }
       public  static bool CheckElementInArray(int element, int[] num )
        {
           
            if (element==0)
            {
                if (num[element] > num[element + 1])
                {                   
                    return true;
                }
                else
                {               
                    return false;
                }
            }
            else if (element== num.Length-1)
            {
                if (num[element] > num[element - 1])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (num[element] > num[element - 1] && num[element] > num[element + 1])
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }
    }
}
