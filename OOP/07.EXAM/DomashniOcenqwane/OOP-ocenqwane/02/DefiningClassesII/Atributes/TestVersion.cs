using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atributes
{
    class TestVersion
    {
        static void Main(string[] args)
        {
        Point xy = new Point();
        Type type = typeof(Point);

        object[] Attributes =

            type.GetCustomAttributes(false);

        foreach (Version attr in Attributes)
            {
                Console.WriteLine("{0}: {1}", attr, attr.VersionAtribute);
            }
        }
    }
    [Version(1.01)]
    public class Point
    {
    int x;
    int y;
    }
}
