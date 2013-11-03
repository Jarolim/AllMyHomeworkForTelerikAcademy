using System;
using System.Text;

namespace _01and02StructureForA3DPoint
{
    public struct Point3D
    {
        public int coordX { get; set; }
        public int coordY { get; set; }
        public int coordZ { get; set; }
        private static readonly Point3D startCoords = new Point3D(0, 0, 0);

        public Point3D(int coordX, int coordY, int coordZ) : this()
        {
            this.coordX = coordX;
            this.coordY = coordY;
            this.coordZ = coordZ;
        }

        public override string ToString()
        {
            StringBuilder coords = new StringBuilder();
            coords.AppendFormat("The X corrdinate is: {0}", coordX.ToString());
            coords.Append("\n");
            coords.AppendFormat("The Y corrdinate is: {0}", coordY.ToString());
            coords.Append("\n");
            coords.AppendFormat("The Z corrdinate is: {0}", coordZ.ToString());
            coords.Append("\n");
            return coords.ToString();
        }
    }
}
