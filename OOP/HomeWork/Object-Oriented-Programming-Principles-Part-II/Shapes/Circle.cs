namespace Shapes
{
    using System;

    public class Circle : Shape
    {
        public Circle(double diameter)
            : base(diameter, diameter)
        {
        }

        public override double CalculateSurface()
        {
            return ((this.Width / 2D) * (this.Height / 2D)) * Math.PI;
        }
    }
}
