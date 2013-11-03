/*
 * Task 4: Write methods that calculate the surface of a triangle by given
 * side and an altitude to it; Three sides; Two sides and an angle between
 * them. Use System.Math.
 */

using System;

namespace TriangleSurface
{
	internal class Program
	{
		private static void Main()
		{
			Console.WriteLine(GetSurfaceByHeight(2, 10));
			Console.WriteLine(GetSurfaceBySides(2, 3, 4));
			Console.WriteLine(GetSurfaceByAngle(2, 3, 30));
		}

		private static double GetSurfaceByHeight(double a, double h)
		{
			return (a*h)/2;
		}

		private static double GetSurfaceBySides(double a, double b, double c)
		{
			double p = (a + b + c)/2;
			return Math.Sqrt(p*(p - a)*(p - b)*(p - c));
		}

		private static double GetSurfaceByAngle(double a, double b, double angle)
		{
			return (a*b*Math.Sin(Math.PI*angle/180))/2;
		}
	}
}