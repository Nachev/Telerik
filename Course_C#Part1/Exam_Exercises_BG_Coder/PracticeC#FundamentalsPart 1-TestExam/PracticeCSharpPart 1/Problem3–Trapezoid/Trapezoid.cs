using System;

class Trapezoid
{
    static void Main()
    {
        string tempInputStr = Console.ReadLine();
        int smallBase = int.Parse(tempInputStr);
        int bigBase = 2 * smallBase;
        int height = smallBase + 1;
        int border = smallBase;
        for (int heightIndex = 1; heightIndex <= height; heightIndex++)
        {
            for (int rowDotIndex = 1; rowDotIndex <= border; rowDotIndex++)
            {
                Console.Write('.');
            }
            for (int rowStarIndex = border; rowStarIndex < bigBase; rowStarIndex++)
            {
                if (heightIndex > 1 && heightIndex < height)
                {
                    if (rowStarIndex > border && rowStarIndex < bigBase - 1)
                    {
                        Console.Write('.');
                    }
                    else
                    {
                        Console.Write('*');
                    }
                }
                else
                {
                    Console.Write('*');
                }
            }
            border--;
            Console.WriteLine();
        }
    }
}
