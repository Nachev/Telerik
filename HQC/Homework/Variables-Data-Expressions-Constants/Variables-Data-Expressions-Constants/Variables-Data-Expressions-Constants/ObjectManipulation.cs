//-----------------------------------------------------------------------
//    ACME Inc.
// <summary>1. Refactor the following code to use proper variable naming and simplified expressions:</summary>
//-----------------------------------------------------------------------
namespace ObjectManipulation
{
    using System;

    /// <summary>
    /// Object manipulation
    /// </summary>
    public class ObjectManipulation
    {        
        /// <summary>
        /// Gets the bounding box after rotation.
        /// </summary>
        /// <param name="inputBox">Bounding box before rotation.</param>
        /// <param name="rotationAngle">Angle of rotation.</param>
        /// <returns>Bounding box.</returns>
        public static BoundingBox GetRotatedBox(BoundingBox inputBox, double rotationAngle) 
        {
            double angleCos = Math.Abs(Math.Cos(rotationAngle));
            double angleSin = Math.Abs(Math.Sin(rotationAngle));

            double newWidth = (angleCos * inputBox.Width) + (angleSin * inputBox.Height);
            double newHeight = (angleSin * inputBox.Width) + (angleCos * inputBox.Height);

            BoundingBox result = new BoundingBox(newWidth, newHeight);
            return result;
        }
    }
}