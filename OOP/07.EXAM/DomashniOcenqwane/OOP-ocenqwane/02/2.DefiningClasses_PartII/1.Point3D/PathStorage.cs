using System;
using System.Linq;
using System.IO;

namespace ThreeDimensionalSpace
{
    static class PathStorage
    {
        //path and file name - can be accessed through properties Location and FileName
        static private string location = "..\\..\\paths\\";
        static private string fileName = "path1.pth";               

        /// <summary>
        /// Use this property to get/set the folder of the file in which to store the Path
        /// </summary>
        static public string Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }

        /// <summary>
        /// Use this property to get/set the name of the file in which to store the Path
        /// </summary>
        static public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
            }
        }

        /// <summary>
        /// Reads a path of 3D points from the Location/fileName that cane be set through the properties PathName and FileName
        /// </summary>
        /// <returns>Collection of Point3D</returns>
        static public Path ReadPathFromFile()
        {
            Path resultPath = new Path();
            StreamReader reader = new StreamReader(Location + FileName);
            string fileContents;
            string[] splitters = { "--", "\n", "[", "]", ",", ":","Point","->","\r\n"," "};

            //reads the contents of file 
            using (reader)
            {
                fileContents = reader.ReadToEnd();
            }
            //points is an array of strings containing ine [0] - the Path name and in all next 4-s - Point3d 
            string[] points = fileContents.Split(splitters, StringSplitOptions.RemoveEmptyEntries);

            //first is the name of the whole path
            resultPath.Name = points[0];

            //for every 4 elements in the points array get the nex Point X,Y,Z and Name and put them in a new instance of point
            for (int i = 1; i < points.Length; i += 4)
            {
                Point3D nextPoint = new Point3D(int.Parse(points[i + 1]), int.Parse(points[i + 2]), int.Parse(points[i + 3]), points[i]);
                resultPath.PathAddPoint = nextPoint;
            }

            return resultPath;
        }

        /// <summary>
        /// Saves a path to the previously defined Location/FileName 
        /// Throws exception if file with that name already exists
        /// </summary>
        static public void SavePath(Path path)
        {
            if (File.Exists(Location + FileName))
            {
                throw new FileLoadException("A file with that name already stores a Path. Change the name or rename the old file and try again.");
            }
            else
            {
                StreamWriter writer = new StreamWriter(Location + FileName);
                using (writer)
                {
                    writer.WriteLine(path.Name);

                    foreach (var point in path.PathGet)
                    {
                        writer.Write("{0}->", point.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// Adds a point to the end of the file(end of path) and saves to the same file
        /// </summary>
        /// <param name="point"></param>
        static public void AddPointToFile(Point3D point)
        {
            Path tempPath = PathStorage.ReadPathFromFile();
            File.Delete(PathStorage.Location + PathStorage.FileName);
            tempPath.PathAddPoint = point;
            PathStorage.SavePath(tempPath);
        }
    }
}
