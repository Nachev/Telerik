namespace Defining_Classes_Part2
{
    using System;
    using System.Text;

    /*Create a structure Point3D to hold a 3D-coordinate 
     * {X, Y, Z} in the Euclidian 3D space. 
     * Implement the ToString() to enable printing a 3D point.*/

    public struct Point3D
    {
        public double XCoord;
        public double YCoord;
        public double ZCoord;

        /*Add a private static read-only field to hold the start of 
         * the coordinate system – the point O{0, 0, 0}. Add a static 
         * property to return the point O.*/
        private static readonly Point3D StartPoint = new Point3D(0, 0, 0);
        
        public Point3D(double xCoord, double yCoord, double zCoord)
        {
            this.XCoord = xCoord;
            this.YCoord = yCoord;
            this.ZCoord = zCoord;
        }

        public static Point3D ZeroPoint
        {
            get { return Point3D.StartPoint; }
        } 

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("X coord: ").Append(this.XCoord).Append(' ');
            result.Append("Y coord: ").Append(this.YCoord).Append(' ');
            result.Append("Z coord: ").Append(this.ZCoord);
            return result.ToString();
        }
    }
}
