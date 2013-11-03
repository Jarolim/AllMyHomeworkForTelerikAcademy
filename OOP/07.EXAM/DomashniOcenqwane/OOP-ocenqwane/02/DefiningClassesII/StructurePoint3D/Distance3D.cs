using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructurePoint3D
{
    class Distance3D
    {
        public static double CalcDistance3D(Point3D point1,Point3D point2) 
        {
            double distance = 0;
            return distance = Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
        }
    }
}
