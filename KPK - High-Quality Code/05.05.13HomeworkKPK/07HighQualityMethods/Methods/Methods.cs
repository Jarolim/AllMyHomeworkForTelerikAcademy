using System;

namespace Methods
{
    class Methods
    {
        static double CalculateTriangleArea(double a, double b, double c) // changed Calc to Calculate
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
				throw new ArgumentException("Sides should be positive!"); // changed to exeption besides -1 
            }

            double halfPerimeter = (a + b + c) / 2; // changed s to halfPerimeter
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));
            
			return area;
        }

        static string ConvertDigitToWord(int number) // changed name to be more precise
        {
			string numWithWords; // added variable

			switch (number)
            {
				case 0: numWithWords = "zero";break;
				case 1: numWithWords = "one"; break;
				case 2: numWithWords = "two"; break;
				case 3: numWithWords = "three"; break;
				case 4: numWithWords = "four"; break;
				case 5: numWithWords = "five"; break;
				case 6: numWithWords = "six"; break;
				case 7: numWithWords = "seven"; break;
				case 8: numWithWords = "eight"; break;
				case 9: numWithWords = "nine"; break;
				default: throw new ArgumentException(number + "is not a digit!"); // added exeption
            }

			return numWithWords;
        }

        static int FindMax(params int[] elements)
        {
            //Added exeptions and broke to 2 to have separate exeptions for different cases
			if (elements == null)
            {
				throw new ArgumentException("Input cannot be null!");
            }

			if (elements.Length <= 0)
			{
				throw new ArgumentException("Element count cannot be less than one!");
			}

			int maxElement = elements[0]; // added variable to be more understandable

            for (int i = 1; i < elements.Length; i++)
            {
				if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

			return maxElement;
        }

		//Changed to 3 different methods for the 3 different prints
		public static void PrintAsFloatNumber(double number)
		{
			Console.WriteLine("{0:f2}", number);
		}

		public static void PrintAsPercent(double number)
		{
			Console.WriteLine("{0:p0}", number);
		}

		public static void PrintAsRightAlignedNumber(double number)
		{
			Console.WriteLine("{0,8}", number);
		}

		//Changed to 3 different methods
        static double CalculateDistanceBetweenTwoPoints(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

            return distance;
        }

		public static bool CheckForVerticalLine(double x1, double x2)
		{
			bool isVertical = x1 == x2;

			return isVertical;
		}

		public static bool CheckForHorizontalLine(double y1, double y2)
		{
			bool isHorizontal = y1 == y2;

			return isHorizontal;
		}

        static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));

			Console.WriteLine(ConvertDigitToWord(5));
            
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

			PrintAsFloatNumber(1.3);
			PrintAsPercent(0.75);
			PrintAsRightAlignedNumber(2.30);

            Console.WriteLine(CalculateDistanceBetweenTwoPoints(3, -1, 3, 2.5));
            bool horizontal = CheckForHorizontalLine(3, 3);
            bool vertical = CheckForVerticalLine(-1, 2.5);
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

			Student peter = new Student("Peter", "Ivanov", "from Sofia", "17.03.1992");

			Student stella = new Student("Stella", "Markova", "From Vidin, gamer, high results", "03.11.1993");

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
