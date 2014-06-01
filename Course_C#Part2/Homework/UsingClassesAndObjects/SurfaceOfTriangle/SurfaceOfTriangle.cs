namespace SurfaceOfTriangle
{
    using System;

    /// <summary>
    /// Program with methods that calculate the surface of a triangle by given: 
    /// Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.
    /// </summary>
    public class SurfaceOfTriangle
    {
        /// <summary>
        /// Test main method.
        /// </summary>
        private static void Main()
        {
            double testSurface = new double();

            // Side (cm)
            double sideA = 5.46D;
            double sideB = 8.52D;
            double sideC = 7.09D;

            // Angle (Deg) 
            /* double angleA = 39.62D;
               double angleB = 84.38D;*/
            double angleC = 56D;

            double altitude = 7.05D;

            testSurface = SurfaceBySideAndAltitude(sideA, altitude);
            Console.WriteLine("Surface calculated by side and altitude to it {0:#.##}", testSurface);
            testSurface = SurfaceByThreeSides(sideA, sideB, sideC);
            Console.WriteLine("Surface calculated by three sides {0:#.##}", testSurface);
            testSurface = SurfaceByTwoSidesAndAngle(sideA, sideB, angleC);
            Console.WriteLine("Surface claculated by two sides and angle between them {0:#.##}", testSurface);
        }

        /// <summary>
        /// Calculates surface of triangle by given side and altitude to it.
        /// </summary>
        /// <param name="sideLength">Length of side.</param>
        /// <param name="altitude">Length of altitude to side.</param>
        /// <returns>Surface of triangle.</returns>
        private static double SurfaceBySideAndAltitude(double sideLength, double altitude)
        {
            double surface = new double();
            surface = (sideLength * altitude) / 2.00;

            return surface;
        }

        /// <summary>
        /// Calculates surface of triangle by given three sides.
        /// </summary>
        /// <param name="sideA">Length of first side.</param>
        /// <param name="sideB">Length of second side.</param>
        /// <param name="sideC">Length of third side.</param>
        /// <returns>Surface of triangle.</returns>
        private static double SurfaceByThreeSides(double sideA, double sideB, double sideC)
        {
            double surface = new double();
            double p = (sideA + sideB + sideC) / 2.00;
            surface = Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));

            return surface;
        }

        /// <summary>
        /// Calculates surface of triangle by given two sides and an angle between them.
        /// </summary>
        /// <param name="sideA">Length of first side.</param>
        /// <param name="sideB">Length of second side.</param>
        /// <param name="angleInDegrees">Angle in degrees between entered sides.</param>
        /// <returns>Surface of triangle.</returns>
        private static double SurfaceByTwoSidesAndAngle(double sideA, double sideB, double angleInDegrees)
        {
            double surface = new double();

            // radians = degrees * (π/180)
            double angleInRadians = angleInDegrees * Math.PI / 180;

            surface = (1.00 / 2.00) * sideA * sideB * Math.Sin(angleInRadians);

            return surface;
        }
    }
}
