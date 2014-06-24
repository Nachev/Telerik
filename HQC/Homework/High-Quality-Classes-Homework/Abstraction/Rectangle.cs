// <copyright file="Rectangle.cs" company="ACME Inc.">
// Copyright (c) ACME Inc. All rights reserved.
// </copyright>
namespace Abstraction
{
    using System;

    /// <summary>
    /// Rectangle class derived from Figure
    /// </summary>
    public class Rectangle : Figure
    {
        /// <summary>
        /// Exception message.
        /// </summary>
        private const string NegativeValueMessage = "Dimension value cannot be negative or zero";

        /// <summary>
        /// Width of the rectangle.
        /// </summary>
        private double width;

        /// <summary>
        /// Height of the rectangle.
        /// </summary>
        private double height;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="initialWidth">Initial value for width.</param>
        /// <param name="initialHeight">Initial value for height.</param>
        public Rectangle(double initialWidth, double initialHeight)
        {
            this.Width = initialWidth;
            this.Height = initialHeight;
        }

        /// <summary>
        /// Gets or sets width.
        /// </summary>
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
                    throw new ArgumentOutOfRangeException("width", NegativeValueMessage);
                }

                this.width = value;
            }
        }

        /// <summary>
        /// Gets or sets height.
        /// </summary>
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
                    throw new ArgumentOutOfRangeException("height", NegativeValueMessage);
                }

                this.height = value;
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}