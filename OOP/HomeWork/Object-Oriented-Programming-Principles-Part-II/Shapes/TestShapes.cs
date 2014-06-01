namespace Shapes
{
    using System;

    /*Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height. 
     * Define two new classes Triangle and Rectangle that implement the virtual method and return the surface 
     * of the figure (height*width for rectangle and height*width/2 for triangle). Define class Circle and suitable 
     * constructor so that at initialization height must be kept equal to width and implement the CalculateSurface() 
     * method. Write a program that tests the behavior of  the CalculateSurface() method for different shapes 
     * (Circle, Rectangle, Triangle) stored in an array.*/

    public class TestShapes
    {
        private static void Main()
        {
            var shapesArr = new Shape[3];
            shapesArr[0] = new Rectangle(2, 4);
            shapesArr[1] = new Triangle(3, 4);
            shapesArr[2] = new Circle(5);

            foreach (var shape in shapesArr)
            {
                Console.WriteLine("The area of the {0} is : {1}", shape.GetType().Name, shape.CalculateSurface());
            }
        }
    }
}
