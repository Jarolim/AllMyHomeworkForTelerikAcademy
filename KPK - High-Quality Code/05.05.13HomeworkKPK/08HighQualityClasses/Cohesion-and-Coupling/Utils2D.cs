using System;
using System.Linq;

namespace CohesionAndCoupling
{
	public class Utils2D
	{
		public static double CalcDistance2D(double x1, double y1, double x2, double y2)
		{
			double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
			return distance;
		}

		public static double CalcDiagonal2D(double firstSide, double secondSide)
		{
			double distance = Math.Sqrt((firstSide * firstSide) + (secondSide * secondSide));
			return distance;
		}
	}
}
