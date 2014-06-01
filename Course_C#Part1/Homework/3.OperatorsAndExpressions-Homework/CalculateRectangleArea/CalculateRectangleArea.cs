namespace CalculateRectangleArea
{
    using System;

    //Write an expression that calculates rectangle’s area by given width and height

    class CalculateRectangleArea
    {
        static void Main()
        {
            Console.Write("Give me width: ");
            double width = new double();
            int insaneCounter = new int();
            //input cycle for width with check for correct input
            do
            {
                Console.Write("-> ");
                if (double.TryParse(Console.ReadLine(), out width))
                {
                    break;
                }
                else
                {
                    insaneCounter++;
                    Console.WriteLine("Wrong input for width!");
                }
            }
            while (insaneCounter < 10);
            if (insaneCounter >= 10)
            {
                Console.WriteLine("Too many errors! Check your keyboard and try again later!");
                return;
            }
            insaneCounter = 0;
            Console.Write("Give me height: ");
            double height = new double();
            //input cycle for height with check for correct input
            do
            {
                Console.Write("-> ");
                if (double.TryParse(Console.ReadLine(), out height))
                {
                    break;
                }
                else
                {
                    insaneCounter++;
                    Console.WriteLine("Wrong input for height!");
                }
            }
            while (insaneCounter < 10);
            if (insaneCounter >= 10)
            {
                Console.WriteLine("Too many errors! Check your keyboard and try again later!");
                return;
            }
            //claculate the area
            double area = (width * height) / 2.0;
            Console.WriteLine("The area of a tiangle with width {1} and height {2} is: {0:0.000}", area, width, height);
        }
    }
}
