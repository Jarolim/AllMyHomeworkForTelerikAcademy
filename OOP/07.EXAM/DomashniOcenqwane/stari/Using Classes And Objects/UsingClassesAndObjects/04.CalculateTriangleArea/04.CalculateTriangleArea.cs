using System;

class CalculateTriangleArea
{
    static double CalculateSurface(float altitutde, float side)
    {
        return ((side * altitutde) / 2);
    }

    static double CalculateSurface(float side1, float side2, float side3)
    {
        double semiPerimiter = (side1 + side2 + side3) / 2;
        return Math.Sqrt(semiPerimiter * (semiPerimiter - side1) * (semiPerimiter - side2) * (semiPerimiter - side3));
    }

    static double CalculateSurface(float sideOne, float sideTwo, double angle)
    {
        double radians = angle * Math.PI / 180;
        return ((sideOne * sideTwo * Math.Sin(radians)) / 2);
    }

    static void Main()
    {
        // Write methods that calculate the surface of a triangle by given:
        // Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.

        //
        Console.WriteLine("Calculate area of triangle by given:\n");

        // Test code
        //Console.WriteLine("The area by given side and altitutde is {0} ", CalculateSurface(5.0f, 2.4f));
        //Console.WriteLine("The area by given three sides is {0} ", CalculateSurface(3.0f, 4.0f, 5.0f));
        //Console.WriteLine("The area by given two sides and their corresponding angle is {0} ", CalculateSurface(3.0f, 4.0f, 90.0d));

        Console.WriteLine("- Side and an altitude to it:");
        Console.Write("enter side = ");
        float side = float.Parse(Console.ReadLine());
        Console.Write("enter altitude = ");
        float altitude = float.Parse(Console.ReadLine());
        Console.WriteLine();

        Console.WriteLine("-Three sides:");
        Console.Write("enter side1 = ");
        float side1 = float.Parse(Console.ReadLine());
        Console.Write("enter side2 = ");
        float side2 = float.Parse(Console.ReadLine());
        Console.Write("enter side3 = ");
        float side3 = float.Parse(Console.ReadLine());
        Console.WriteLine();

        Console.WriteLine("-Two sides and an angle between them:");
        Console.Write("enter side1 = ");
        float sideOne = float.Parse(Console.ReadLine());
        Console.Write("enter side2 = ");
        float sideTwo = float.Parse(Console.ReadLine());
        Console.Write("enter angle = ");
        double angle = double.Parse(Console.ReadLine());
        Console.WriteLine();

        Console.WriteLine("The area by given side and altitutde is: {0} ", CalculateSurface(altitude, side));
        Console.WriteLine("The area by given three sides is: {0} ", CalculateSurface(side1, side2, side3));
        Console.WriteLine("The area by given two sides and their corresponding angle is: {0} ", CalculateSurface(sideOne, sideTwo, angle));
    }
}