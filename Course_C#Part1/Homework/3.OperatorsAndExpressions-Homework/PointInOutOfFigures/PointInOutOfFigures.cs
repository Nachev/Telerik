namespace PointInOutOfFigures
{
    using System;

    //Write an expression that checks for given point (x, y) if it is within 
    //the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).

    class PointInOutOfFigures
    {
        static void Main()
        {
            int insaneCount = new int();
            Console.WriteLine("Enter point coordinates");
            double xCoord = new double();
            //input cycle for X coordinate with check for correct value
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
            //input cyclce for Y coordinate with check fir correct value
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
            //Vector between point(x,y) and circle's center(1,1) has coordinates (x-1,y-1) and lenght vectorLenght
            double vectorLenght = Math.Sqrt((xCoord - 1) * (xCoord - 1) + (yCoord - 1) * (yCoord - 1));
            //If this requirement is fulfilled the point is outside the rectangle
            bool outRectangle = ((yCoord > 1) || (yCoord < -1)) || ((xCoord < -1) || (xCoord > 6));
            //If vector's lenght is shorter than the circle's radius and the point is outside the rectangle there is a hit
            if (vectorLenght < 3 && outRectangle)
            {
                Console.WriteLine("This point X = {0}, Y = {1} is inside the circle and outside the rectangle", xCoord, yCoord);
            }
            else
            {
                Console.WriteLine("This point X = {0}, Y = {1} does not fulfill the requirements", xCoord, yCoord);
            }
        }
    }
}
