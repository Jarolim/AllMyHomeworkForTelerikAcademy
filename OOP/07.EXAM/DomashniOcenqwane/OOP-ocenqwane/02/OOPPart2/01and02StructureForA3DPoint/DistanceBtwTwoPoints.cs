using System;

namespace _01and02StructureForA3DPoint
{
    public static class DistanceBtwTwoPoints
    {
        public static double CalculateDistance(Point3D firstPoint, Point3D secondPoint)
        {
            double distance = 0;
            // formula: distance3D = Sqrt(Pow(x1-x2) + Pow(y1-y2) + Pow(z1-z2))
            distance = Math.Sqrt(Math.Pow(firstPoint.coordX - secondPoint.coordX, 2) +
            + Math.Pow(firstPoint.coordY - secondPoint.coordY, 2) + 
            + Math.Pow(firstPoint.coordZ - secondPoint.coordZ, 2));
            return distance;
        }
    }
}
