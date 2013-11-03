// Homework from task 1 to task 4.

using System;

namespace _01and02StructureForA3DPoint
{
    public class ProgramMain
    {
        static void Main()
        {
            Point3D firstPoint = new Point3D(5, 2, 8);
            Point3D secondPoint = new Point3D(4, 7, 1);
            Console.WriteLine("The distance between two points is:{0}",
                DistanceBtwTwoPoints.CalculateDistance(firstPoint, secondPoint));

            Path pathOne = new Path();
            pathOne.AddNewPoint(firstPoint);
            pathOne.AddNewPoint(firstPoint);
            pathOne.AddNewPoint(secondPoint);
            PathStorage.SavePath(pathOne);           
           
            Console.WriteLine(PathStorage.LoadPath());          
        }
    }
}
