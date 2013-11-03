using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructurePoint3D
{
    public class Path3D
    {
        public readonly List<Point3D> pathPoints = new List<Point3D>();

        public List<Point3D> PathPoints 
        {
            get { return this.pathPoints; }
        }

        public void AddPoint(Point3D point)
        {
            pathPoints.Add(point);
        }

        public void ClearPath()
        {
            pathPoints.Clear();
        }
    }
}
