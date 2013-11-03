/*1.Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space.  * Implement the ToString() to enable printing a 3D point.2.Add a private static read-only field to hold the start of the coordinate  * system – the point O{0, 0, 0}. Add a static property to return the point O.3.Write a static class with a static method to calculate the distance between * two points in the 3D space.4.Create a class Path to hold a sequence of points in the 3D space. Create a 
 * static class PathStorage with static methods to save and load paths from a
 * text file. Use a file format of your choice.
*/
using System;
using System.IO;

namespace ThreeDimensionalSpace
{
    class TestPoint
    {
        static void Main()
        {
            try
            {

                Point3D point1 = new Point3D(-1, -1, 1, "K");
                Point3D point2 = new Point3D(-2, -2, -2, "M");
                Point3D point3 = new Point3D(5, 6, 7, "L");
                Point3D point4 = new Point3D(10, 10, 10, "N");
                Console.WriteLine("Center {0}\n{1}\n{2}\nDistance between point {4} and {5}:\t{3}\n", Point3D.Center, point1, point2,
                    DistanceCalculator3D.CalculateDistance3D(point1, point2), point1.Name, point2.Name);

                Path newPath = new Path(point1, "Path");
                newPath.PathAddPoint = point2;
                newPath.PathAddPoint = point1;
                newPath.PathAddPoint = point2;

                Path newPath1 = new Path(point3, "Path1");
                newPath1.PathAddPoint = point4;
                newPath1.PathAddPoint = point3;
                newPath1.PathAddPoint = point4;
                
                Console.WriteLine(newPath);
                Console.WriteLine(newPath1);

                Console.WriteLine("\nAdding Path (after) Path1");
                newPath1.PathAddPath(newPath);
                Console.WriteLine(newPath1);

                //PathStorage.FileName = newPath.Name + ".pth";
                //PathStorage.SavePath(newPath);
                Console.WriteLine("Path {0} saved in {1}{2}", newPath.Name, PathStorage.Location, PathStorage.FileName);
                PathStorage.FileName = newPath1.Name + ".pth";
                PathStorage.SavePath(newPath1);
                
                Path pathFromFIle = PathStorage.ReadPathFromFile();
                Console.WriteLine("\nPath read from file:{0}",pathFromFIle);                

                PathStorage.AddPointToFile(Point3D.Center);
                pathFromFIle = PathStorage.ReadPathFromFile();
                Console.WriteLine("\nAdded 'center' to pathfile : {0}", pathFromFIle);

            }
            catch (FileLoadException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
