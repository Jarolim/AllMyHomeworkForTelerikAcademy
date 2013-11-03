using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2.Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = null;

            // yes 
            // http://fooplot.com/plot/kg8xnlh3vc
            input = "1.0 1.0|2.0 3.0|3.0 2.0|2.0 2.0";

            // no
            // input = "1.0 1.0|2.0 3.0|3.0 2.0|0.0 0.0";

            if (input != null)
                Console.SetIn(new StringReader(input.Replace(" ", "\n").Replace("|", "\n")));

            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());
            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());
            var x3 = double.Parse(Console.ReadLine());
            var y3 = double.Parse(Console.ReadLine());

            var x4 = double.Parse(Console.ReadLine());
            var y4 = double.Parse(Console.ReadLine());

            // barycentric coordinates of pt 4
            // see http://en.wikipedia.org/wiki/Barycentric_coordinate_system

            // there are at least four more ways to solve the problem
            // * check if the point is in the same half plane relative to each side as the barycenter, using vector cross products
            // * check if the angles from the point to each pair of vertices sum to 360
            // * check if the areas between the point and each pair of vertices sum to the area of the triangle 
            // * check if the line segments from the point to each vertex cross the opposite side

            // I personally would either use this solution or the cross product one

            double dx = (x4 - x3);
            double dy = (y4 - y3);

            double A = x1 - x3;
            double B = y1 - y3;
            double C = x2 - x3;
            double D = y2 - y3;

            double denom = A * D - B * C;

            double alpha = D * dx - C * dy;
            alpha /= denom;

            double beta = -B * dx + A * dy;
            beta /= denom;

            double gamma = 1.0 - (alpha + beta);

            if (alpha >= 0 && beta >= 0 && gamma >= 0)
                Console.WriteLine("Point lies inside the triangle.");
            else
                Console.WriteLine("Point lies outside the triangle.");

        }
    }
}

