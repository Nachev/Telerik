namespace CheckIfPointInCircle
{
    using System;

    //Write an expression that checks if given point (x,  y) is within a circle K(O, 5).

    class CheckIfPointInCircle
    {
        static void Main()
        {
            int insaneCount = new int();
            Console.WriteLine("Enter point coordinates");
            double xCoord = new double();
            //input cycle for X coordinate
            do
            {
                Console.Write("X = ");
                string temp = Console.ReadLine();
                bool check = double.TryParse(temp, out xCoord);
                if (check)
                {
                    break;
                }
                else
                {
                    if (insaneCount < 10)
                    {
                        Console.WriteLine("Wrong input for X coordinate! Try again.");    
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
            double yCoord = new double();
            //input cyclce for Y coordinate
            do
            {
                Console.Write("Y = ");
                string temp = Console.ReadLine();
                bool check = double.TryParse(temp, out yCoord);
                insaneCount++;
                if (check)
                {
                    break;
                }
                else
                {
                    if (insaneCount < 10)
                    {
                        Console.WriteLine("Wrong input for Y coordinate! Try again.");
                    }
                    else
                    {
                        Console.WriteLine("Too many wrong inputs. Check your keyboard.");
                        return;
                    }
                }
            }
            while (true);
            //check the result using vector length
            double vectorLength = Math.Sqrt(xCoord * xCoord + yCoord * yCoord);
            if (vectorLength <= 5)
            {
                Console.WriteLine("HIT");
            }
            else
            {
                Console.WriteLine("Try again");
            }
        }
    }
}
