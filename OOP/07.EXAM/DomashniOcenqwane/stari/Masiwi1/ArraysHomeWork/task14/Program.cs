using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).
namespace task14
{
	class Program
	{
		static List<string> QuickSorting(List<string> array)
		{
			if (array.Count <= 1)
			{
				return array;
			}

			string middle = array[array.Count / 2];
			List<string> left = new List<string>();
			List<string> right = new List<string>();

			for (int i = 0; i < array.Count; i++)
			{
				if (i != (array.Count / 2))
				{
					bool isEqual = true;
					bool isBigger = true;
					string str = array[i];

					if (str.Length <= middle.Length)
					{
						for (int index = 0; index < str.Length; index++)
						{
							if (str[index] != middle[index])
							{
								isEqual = false;

								if (str[index] < middle[index])
								{
									isBigger = false;
								}

								break;
							}
						}

						if (isEqual && str.Length < middle.Length)
						{
							isBigger = false;
						}
					}
					else if (str.Length > middle.Length)
					{
						for (int index = 0; index < middle.Length; index++)
						{
							if (str[index] != middle[index])
							{
								isEqual = false;

								if (str[index] < middle[index])
								{
									isBigger = false;
								}

								break;
							}
						}
					}

					if (isBigger)
					{
						right.Add(array[i]);
					}
					else
					{
						left.Add(array[i]);
					}
				}
			}
			List<string> result = new List<string>();

			result.AddRange(QuickSorting(left));
			result.Add(middle);
			result.AddRange(QuickSorting(right));

			return result;
		}

		static void Main()
		{
			int length = int.Parse(Console.ReadLine());
			List<string> strList = new List<string>();

			for (int index = 0; index < length; index++)
			{
				strList.Add(Console.ReadLine());
			}

			List<string> sortedList = QuickSorting(strList);
		}
	}
}
