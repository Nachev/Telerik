// <copyright file="FiguresExample.cs" company="ACME Inc.">
//     Copyright (c) ACME Inc. All rights reserved.
// </copyright>
namespace Abstraction
{
    using System;

    /// <summary>
    /// Tests figures classes.
    /// </summary>
    public class FiguresExample
    {
        public static void Main()
        {
            const string MessgaeFormat = "I am a {0} and my perimeter is {1:f2}. My surface is {2:f2}.";
            Figure circle = new Circle(5);
            Console.WriteLine(
                MessgaeFormat,
                circle.GetType().Name,
                circle.CalcPerimeter(),
                circle.CalcSurface());
            Figure rect = new Rectangle(2, 3);
            Console.WriteLine(
                MessgaeFormat,
                rect.GetType().Name,
                rect.CalcPerimeter(),
                rect.CalcSurface());
        }
    }
}