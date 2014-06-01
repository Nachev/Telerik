namespace DefiningClassesPart2
{
    using System;

    /*Write a static class with a static method to calculate 
     * the distance between two points in the 3D space.*/

    public static class DistanceCalc
    {
        public static double CalcDistance(Point3D first, Point3D second)
        {
            return Math.Sqrt(
                (first.XCoord - second.XCoord) * (first.XCoord - second.XCoord) +
                (first.YCoord - second.YCoord) * (first.YCoord - second.YCoord) +
                (first.ZCoord - second.ZCoord) * (first.ZCoord - second.ZCoord));
        }
    }
}
