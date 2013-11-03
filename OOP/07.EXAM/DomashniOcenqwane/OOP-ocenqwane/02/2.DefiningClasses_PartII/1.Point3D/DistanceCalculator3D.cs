using System;
using System.Linq;


namespace ThreeDimensionalSpace
{
    static class DistanceCalculator3D
    {
        /// <summary>
        ///     Calculates 2D distance between given two points 
        /// </summary>
        /// <param name="firstAbscis">First point horizontal</param>
        /// <param name="firstOordinate">First pint Vertical</param>
        /// <param name="secondAbscis">Second poitn horizontal</param>
        /// <param name="secondOordinate">Second point vetical</param>
        /// <returns></returns>
        public static float CalculateDistance2D(float firstAbscis, float firstOordinate, float secondAbscis, float secondOordinate)
        {
            return (float)Math.Sqrt(Math.Pow(Math.Abs(firstAbscis - secondAbscis), 2) + Math.Pow(Math.Abs(firstOordinate - secondOordinate), 2));
        }

        /// <summary>
        /// Calculates distance between 2 points in the 3D space.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static float CalculateDistance3D(Point3D first, Point3D second)
        {
            ////calculate distance between 2D X and Z coordinates 
            //float distanceXZ = CalculateDistance2D(first.X,first.Z, second.X, second.Z);
            //calculate distance between 2D Y and Z coordinates 
            float distanceYZ = CalculateDistance2D(first.Y, first.Z, second.Y, second.Z);
            //calculate distance between 2D X and Y cooidrinates
            float distanceXY = CalculateDistance2D(first.X, first.Y, second.X, second.Y);

            //the calculated distances create a 90-degreee triangle from which I calculate the 3D distance
            float distanceXYZ = (float)Math.Sqrt(Math.Pow(distanceXY, 2) + Math.Pow(distanceYZ, 2));
            return distanceXYZ;
        }
    }
}
