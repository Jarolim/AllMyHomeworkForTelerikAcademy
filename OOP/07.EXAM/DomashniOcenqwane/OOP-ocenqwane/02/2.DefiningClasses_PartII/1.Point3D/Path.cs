using System;
using System.Collections.Generic;
using System.Text;


namespace ThreeDimensionalSpace
{
    public class Path
    {
        private List<Point3D> path;
        private string name;

        /// <summary>
        /// Sets or returns the name of the currnet path
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// Returns the List<path> or sets a new List<path> (overwrites the old)
        /// </summary>
        public List<Point3D> PathGet
        {
            get
            {
                return path;
            }
        }


        /// <summary>
        /// Adds a point to the path
        /// </summary>
        public Point3D PathAddPoint
        {
            set
            {
                this.path.Add(value);
            }
        }

        /// <summary>
        /// Adds a path to the already existing path without overwriting
        /// </summary>
        /// <param name="pathToAdd"></param>
        public void PathAddPath(Path pathToAdd)
        {
            this.path.AddRange(pathToAdd.PathGet);
        }

        /// <summary>
        /// Blank constructor, initializes the List<Point3D>
        /// </summary>
        public Path()
        {
            this.path = new List<Point3D>();
        }


        public Path(Point3D point, string name)
            : this()
        {
            this.Name = name;
            this.PathGet.Add(point);
        }

        /// <summary>
        /// Instantiates an instance with and existing List<Point3D>
        /// </summary>
        /// <param name="pathList"></param>
        public Path(List<Point3D> pathList, string name)
            : this()
        {
            this.Name = name;
            foreach (var point in pathList)
            {
                this.PathAddPoint = point;
            }

        }

        public override string ToString()
        {
            StringBuilder pathOfPoints = new StringBuilder();
            pathOfPoints.Append(string.Format("--{0}--\n", this.Name));
            foreach (var point in this.PathGet)
            {
                pathOfPoints.Append(string.Format("[{0}:{1},{2},{3}]->", point.Name, point.X, point.Y, point.Z));
            }
            pathOfPoints.Remove(pathOfPoints.Length - 2, 2);
            return pathOfPoints.ToString();

        }
    }
}
