﻿using System;
using System.Text;

public struct Point3D
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    static public readonly Point3D zero = new Point3D(0, 0, 0);

    public Point3D(int pointX, int pointY, int pointZ) : this()
    {
        this.X = pointX;
        this.Y = pointY;
        this.Z = pointZ;
    }

    public override string ToString()
    {
        StringBuilder text = new StringBuilder();
        text.AppendFormat("Coordinate X: {0}", this.X.ToString());
        text.AppendLine();
        text.AppendFormat("Coordinate Y: {0}", this.Y.ToString());
        text.AppendLine();
        text.AppendFormat("Coordinate Z: {0}", this.Z.ToString());
        text.AppendLine();
        text.Append("---");

        return text.ToString();
    }
}