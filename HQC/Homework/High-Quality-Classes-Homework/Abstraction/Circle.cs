// <copyright file="Circle.cs" company="ACME Inc.">
//     Copyright (c) ACME Inc. All rights reserved.
// </copyright>
namespace Abstraction
{
    using System;

    /// <summary>
    /// Circle class derived from Figure
    /// </summary>
    public class Circle : Figure
    {
        /// <summary>
        /// Exception message.
        /// </summary>
        private const string NegativeValueMessage = "Dimension value cannot be negative or zero";

        /// <summary>
        /// Radius of the circle field.
        /// </summary>
        private double radius;

        /// <summary>
        ///  Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="initialRadius">Initial value for radius.</param>
        public Circle(double initialRadius)
        {
            this.Radius = initialRadius;
        }

        /// <summary>
        /// Gets or sets radius.
        /// </summary>
        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("radius", NegativeValueMessage);
                }

                this.radius = value;
            }
        }
                
        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}