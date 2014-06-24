// <copyright file="Figure.cs" company="ACME Inc.">
//     Copyright (c) ACME Inc. All rights reserved.
// </copyright>
namespace Abstraction
{
    using System;

    /// <summary>
    /// Geometric figure class.
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Figure"/> class.
        /// </summary>
        protected Figure()
        {
        }

        /// <summary>
        /// Calculates the perimeter of the figure.
        /// </summary>
        /// <returns>Perimeter in double.</returns>
        public abstract double CalcPerimeter();

        /// <summary>
        /// Calculates the surface of the figure.
        /// </summary>
        /// <returns>Surface in double.</returns>
        public abstract double CalcSurface();
    }
}