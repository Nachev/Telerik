namespace CohesionAndCoupling
{
    using System;

    public class RectangularSolid
    {
        private const string NegativeValueMessage = "Dimension value cannot be negative or zero";

        private double width;

        private double height;

        private double depth;

        public RectangularSolid(double initialWidth, double initialHeight, double initialDepth)
        {
            this.Width = initialWidth;
            this.Height = initialHeight;
            this.Depth = initialDepth;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Width", NegativeValueMessage);   
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height", NegativeValueMessage);
                }
                
                this.height = value;
            }
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Depth", NegativeValueMessage);
                }

                this.depth = value;
            }
        }
        
        public double CalcVolume()
        {
            double volume = this.Width * this.Height * this.Depth;

            return volume;
        }

        public double CalcDiagonalXYZ()
        {
            double distance = CalcDiagonal(this.Width, this.Height, this.Depth);

            return distance;
        }

        public double CalcDiagonalXY()
        {
            double distance = CalcDiagonal(0, this.Width, this.Height);

            return distance;
        }

        public double CalcDiagonalXZ()
        {
            double distance = CalcDiagonal(0, this.Width, this.Depth);

            return distance;
        }

        public double CalcDiagonalYZ()
        {
            double distance = CalcDiagonal(0, this.Height, this.Depth);

            return distance;
        }

        private static double CalcDiagonal(double sideOne, double sideTwo, double sideThree)
        {
            double result = Math.Sqrt((sideOne * sideOne) + (sideTwo * sideTwo) + (sideThree * sideThree));

            return result;
        }
    }
}