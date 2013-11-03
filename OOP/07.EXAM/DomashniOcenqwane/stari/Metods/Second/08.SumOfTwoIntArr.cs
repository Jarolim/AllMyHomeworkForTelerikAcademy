using System;
using System.Collections.Generic;

namespace _08.SumOfTwoIntArr
{
    class SumOfTwoIntArr
    {
        static void Main()
        {
            uint firstNum = 0;
            uint secondNum = 0;
            List<uint> firstNumArr = new List<uint>();
            List<uint> secondNumArr = new List<uint>();
            List<uint> resultNumArr = new List<uint>();
            Console.Write("First positive num:");
            firstNum = uint.Parse(Console.ReadLine());
            Console.Write("Second positive num:");
            secondNum = uint.Parse(Console.ReadLine());
            firstNumArr = AddmInfirstNumArr(firstNum, firstNumArr);
            secondNumArr = AddmInfirstNumArr(secondNum, secondNumArr);            
            resultNumArr = sumArr(firstNumArr, secondNumArr);
            for (int i = resultNumArr.Count-1; i >= 0; i--)
            {
                Console.Write(resultNumArr[i]);
            }
            Console.WriteLine();
        }

        public static List<uint> AddmInfirstNumArr(uint firstNum, List<uint> numArr)
        {
            uint divider = 10;


            for (uint i = 0; i < 6; i++)
            {
                numArr.Add(firstNum % divider);
                firstNum = firstNum / divider;
            }
            return numArr;
        }
        public static List<uint> sumArr(List<uint> firstNumArr, List<uint> secondNumArr)
        {
            List<uint> resultArr = new List<uint>();
            uint mem = 0;
            uint sum=0;
            for (int i = 0; i < firstNumArr.Count; i++)
            {
                sum = firstNumArr[i] + secondNumArr[i] + mem;
                resultArr.Add(sum % 10);
                mem = sum / 10;
            }
            return resultArr;
        }
    }
}
