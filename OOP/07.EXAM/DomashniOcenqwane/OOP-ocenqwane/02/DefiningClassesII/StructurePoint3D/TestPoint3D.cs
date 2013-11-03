using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructurePoint3D
{
    class TestPoint3D
    {
        static void Main()
        {
            Point3D point1 = new Point3D(3 ,4 ,5);
            Point3D point2 = new Point3D(3, 6, 5);
            Point3D point3 = new Point3D(3, 7, 2);
            Console.WriteLine(point1.ToString());
            Console.WriteLine(point2.ToString());
            Console.WriteLine(point3.ToString());
            List<Path3D> listPathsTest  = PathStorage3D.Load();
            foreach (Path3D path in listPathsTest)
            {
                PathStorage3D.Save(path);
                foreach (var listPoints in path.PathPoints)
                {
                    Console.WriteLine(listPoints.ToString());
                }
            }

        }
    }
}
