namespace CirclePerimeterAndRadius
{
    using System;

    /// Write a program that reads the radius r of a circle and prints its perimeter and area
    public class CirclePerimeterAndRadius
    {
        private static void Main()
        {
            // Radius of the circle input block with error check
            int insaneCounter = 10;
            double radius = new double();
            Console.WriteLine("Enter radius of the circle");
            do
            {
                Console.Write("-> ");
                string temp = Console.ReadLine();
                bool check = double.TryParse(temp, out radius);
                if (check && radius > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!!! Try again.");
                }

                insaneCounter--;
            } 
            while (insaneCounter > 0);
            Console.WriteLine("Circle\'s perimeter is: {0:F2}", 2 * Math.PI * radius);
            Console.WriteLine("Circle\'s area is: {0:F2}", Math.PI * radius * radius);
        }
    }
}
