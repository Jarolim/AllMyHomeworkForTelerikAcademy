using System;
using System.Collections.Generic;

namespace _01and02StructureForA3DPoint
{
    class Path
    {
        public static List<Point3D> pointsStorage = new List<Point3D>();

        public void AddNewPoint(Point3D point)
        {
            pointsStorage.Add(point);
        }

        public void RemoveOnePoint(Point3D noPoint)
        {
            pointsStorage.Remove(noPoint);
        }

        public void ClearStorage()
        {
            pointsStorage.Clear();
        }
    }
}
