namespace Shapes
{
    public abstract class Shape
    {
        protected Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public abstract double CalculateSurface();
    }
}
