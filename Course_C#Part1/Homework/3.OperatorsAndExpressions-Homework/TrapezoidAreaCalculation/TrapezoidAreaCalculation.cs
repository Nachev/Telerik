namespace TrapezoidAreaCalculation
{
    using System;

    //Write an expression that calculates trapezoid's area by given sides a and b and height h

    class TrapezoidAreaCalculation
    {
        static void Main()
        {
            //this variable is used to ensure that cylces will end
            int insaneCount = new int();
            Console.WriteLine("Enter values for: ");
            double sideA = new double();
            //input cycle for side A
            do
            {
                Console.Write("side A = ");
                string temp = Console.ReadLine();
                bool check = double.TryParse(temp, out sideA);
                if (check)
                {
                    break;
                }
                else
                {
                    if (insaneCount < 10)
                    {
                        Console.WriteLine("Wrong input for side A! Try again.");
                    }
                    else
                    {
                        Console.WriteLine("Too many wrong inputs. Check your keyboard.");
                        insaneCount++;
                        return;
                    }
                }
            }
            while (true);
            insaneCount = 0;
            double sideB = new double();
            //input cyclce for side B
            do
            {
                Console.Write("side B = ");
                string temp = Console.ReadLine();
                bool check = double.TryParse(temp, out sideB);
                insaneCount++;
                if (check)
                {
                    break;
                }
                else
                {
                    if (insaneCount < 10)
                    {
                        Console.WriteLine("Wrong input for side B! Try again.");
                    }
                    else
                    {
                        Console.WriteLine("Too many wrong inputs. Check your keyboard.");
                        return;
                    }
                }
            }
            while (true);
            insaneCount = 0;
            double height = new double();
            //input cyclce for height
            do
            {
                Console.Write("height = ");
                string temp = Console.ReadLine();
                bool check = double.TryParse(temp, out height);
                insaneCount++;
                if (check)
                {
                    break;
                }
                else
                {
                    if (insaneCount < 10)
                    {
                        Console.WriteLine("Wrong input for height! Try again.");
                    }
                    else
                    {
                        Console.WriteLine("Too many wrong inputs. Check your keyboard.");
                        return;
                    }
                }
            }
            while (true);
            //calculate the area
            double area = ((sideA + sideB) / 2) * height;
            Console.WriteLine("Trapezoid's area is {0:0.000}", area);
        }
    }
}
