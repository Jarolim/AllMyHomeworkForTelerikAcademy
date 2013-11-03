using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructurePoint3D
{
    public static class PathStorage3D
    {
        public static void Save(Path3D path) 
        {
            using (StreamWriter writer = new StreamWriter(@"../../Saves.txt"))
            {
                foreach (var point in path.pathPoints)
                {
                    writer.WriteLine(point);
                }
            }
        }

        public static List<Path3D> Load() 
        {
            string lineSeparator = "---";
            Path3D loadPath = new Path3D();
            List<Path3D> loaded = new List<Path3D>();
            using (StreamReader reader = new StreamReader(@"../../Loads.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (line != lineSeparator)
                    {
                        Point3D point = new Point3D();
                        string[] points = line.Split(',');
                        point.X = int.Parse(points[0]);
                        point.Y = int.Parse(points[1]);
                        point.Y = int.Parse(points[2]);
                        loadPath.AddPoint(point);
                    }
                    else
                    {
                        loaded.Add(loadPath);
                        loadPath = new Path3D();
                    }
                    line = reader.ReadLine();
                }
            }
            return loaded;
        }
    }
}
