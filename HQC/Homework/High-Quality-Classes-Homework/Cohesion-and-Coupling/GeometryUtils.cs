namespace CohesionAndCoupling
{
    using System;

    public static class GeometryUtils
    {
        public static double CalcDistance2D(double firstXCoord, double firstYCoord, double secondXCoord, double secondYCoord)
        {
            double distance = Math.Sqrt(
                ((secondXCoord - firstXCoord) * (secondXCoord - firstXCoord)) +
                ((secondYCoord - firstYCoord) * (secondYCoord - firstYCoord)));

            return distance;
        }

        public static double CalcDistance3D(
            double firstXCoord, 
            double firstYCoord, 
            double firstZCoord, 
            double secondXCoord, 
            double secondYCoord, 
            double secondZCoord)
        {
            double distance = Math.Sqrt(
                ((secondXCoord - firstXCoord) * (secondXCoord - firstXCoord)) +
                ((secondYCoord - firstYCoord) * (secondYCoord - firstYCoord)) +
                ((secondZCoord - firstZCoord) * (secondZCoord - firstZCoord)));

            return distance;
        }
    }
}