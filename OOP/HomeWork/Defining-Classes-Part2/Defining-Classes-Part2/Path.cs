namespace Defining_Classes_Part2
{
    using System.Collections.Generic;
    using System.Text;

    /*Create a class Path to hold a sequence of points in the 3D space.*/

    public class Path
    {
        private List<Point3D> trail;

        public List<Point3D> Trail
        {
            get 
            { 
                return this.trail; 
            }

            set 
            { 
                this.trail = value; 
            }
        }

        public void AddPoint(Point3D point)
        {
            this.trail.Add(point);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (var point in this.trail)
            {
                result.Append(point.ToString());
                result.AppendLine();
            }

            return result.ToString();
        }
    }
}
