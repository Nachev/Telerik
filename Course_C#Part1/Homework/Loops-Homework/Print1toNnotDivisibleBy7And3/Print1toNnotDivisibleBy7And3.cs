namespace Print1toNnotDivisibleBy7And3
{
    using System;
    using System.Text;

    /*Write a program that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time*/

    public class Print1toNnotDivisibleBy7And3
    {
        public static void Main()
        {
            // Input block with check for correct input
            int numberN = new int();
            do
            {
                Console.Write("Enter number to count to: ");
                bool check = int.TryParse(Console.ReadLine(), out numberN);
                if (check && numberN != 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!! Try again.");
                }
            }
            while (true);

            int length = Math.Abs(numberN);

            // Take the sign of entered number
            int multiplier = Math.Sign(numberN);
            StringBuilder tempResult = new StringBuilder();

            // Take number of digits in entered number
            int numberLength = new int();
            numberN = Math.Abs(numberN);
            while (numberN > 0)
            {
                numberN /= 10;
                numberLength++;
            }

            // Print the result
            int width = Console.WindowWidth;
            for (int index = 1; index <= length; index++)
            {
                if ((index % 7 == 0) && (index % 3 == 0))
                {
                    if ((tempResult.Length + numberLength) < width)
                    {
                        tempResult.Append(index * multiplier).Append(" ");
                    }
                    else
                    {
                        Console.WriteLine(tempResult.ToString());
                        tempResult.Clear();
                    }
                }
            }

            // Print remaining elements
            Console.WriteLine(tempResult.ToString());
        }
    }
}
