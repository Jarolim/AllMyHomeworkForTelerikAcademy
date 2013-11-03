/*Write methods that calculate the surface of a triangle by given:
 - Side and an altitude to it; 
 - Three sides; 
 - Two sides and an angle between them. Use System.Math.*/

using System;

class SurfaceOfTriangle
{
    static double SurfaceTriangle(double a, double ha)
    {
        if (a > 0 && ha > 0)
        {
            double s = a * ha / 2;
            return s;
        }
        else
        {
            return -1;
        }
      
    }

    static double SurfaceTriangle(double a, double b, double c)
    {
        if (a > 0 && b > 0 && c > 0)
        {
            double p = (a + b + c) / 2;
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return s;
        }
        else
        {
            return -1;
        }

    }

    static double SurfaceTriangleTwoSidesAngelBetweenThem(double a, double b, double angle)
    {
        angle = angle * Math.PI / 180.0;
        if (a > 0 && b > 0 && angle > 0 && angle < Math.PI)
        {
            double s = (a * b * Math.Sin(angle)) / 2;
            Console.WriteLine(Math.Sin(angle));
            return s;
            
        }
        else
        {
            return -1;
        }
    }

    static void Main()
    {
        Console.WriteLine("S = {0}", SurfaceTriangle(3,5));
        Console.WriteLine("S = {0}", SurfaceTriangle(3,4,5));
        Console.WriteLine("S = {0}", SurfaceTriangleTwoSidesAngelBetweenThem(3, 4, 90));
    }
}


