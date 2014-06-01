namespace NumbersDivisibleByFiveInRange
{
    using System;

    /* Write a program that reads two positive integer numbers and prints 
    //how many numbers p exist between them such that the reminder of the division 
    //by 5 is 0 (inclusive). Example: p(17,25) = 2 */

    public class NumbersDivisibleByFiveInRange
    {
        private static void Main()
        {
            uint firstInt;
            uint secondInt;
            byte checkpoint = 10;
            do
            {
                Console.Write("Enter first positive integer number:");
                string temp = Console.ReadLine();
                if (uint.TryParse(temp, out firstInt))
                {
                    Console.WriteLine("\r\nCorrect input :{0}", firstInt);
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input. Try again");
                }

                checkpoint--;
            }
            while (checkpoint > 0);
            Console.WriteLine();
            checkpoint = 10;
            do
            {
                Console.Write("Enter second positive integer number:");
                string temp = Console.ReadLine();
                if (uint.TryParse(temp, out secondInt))
                {
                    Console.WriteLine("\r\nCorrect input :{0}", secondInt);
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input. Try again");
                }

                checkpoint--;
            }
            while (checkpoint > 0);
            Console.WriteLine();
            int counter = 0;
            if (firstInt < secondInt)
            {
                for (uint count = firstInt; count <= secondInt; count++)
                {
                    if ((firstInt + count) % 5 == 0)
                    {
                        counter++;
                    }
                }
            }
            else
            {
                for (uint count = secondInt; count <= firstInt; count++)
                {
                    if ((secondInt + count) % 5 == 0)
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine("p({0},{1}) = {2}", firstInt, secondInt, counter);
        }
    }
}
