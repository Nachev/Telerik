namespace BiggestOfThreeInts
{
    using System;

    /* Write a program that finds the biggest of three integers using nested if statements.*/

    public class FindBiggestOfThree
    {
        public static void Main()
        {
            int firstInt = new int();
            int insaneCount = 10;

            // Input cycle for the first integer with error check
            do
            {
                Console.Write("Enter first integer: ");
                string temp = Console.ReadLine();
                if (int.TryParse(temp, out firstInt))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!!! Try again.");
                }

                insaneCount--;
            }
            while (insaneCount > 0);

            int secondInt = new int();
            insaneCount = 10;

            // Input cycle for the second integer with error check
            do
            {
                Console.Write("Enter second integer: ");
                string temp = Console.ReadLine();
                if (int.TryParse(temp, out secondInt))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!!! Try again.");
                }

                insaneCount--;
            }
            while (insaneCount > 0);

            int thirdInt = new int();
            insaneCount = 10;

            // Input cycle for the third integer with error check
            do
            {
                Console.Write("Enter third integer: ");
                string temp = Console.ReadLine();
                if (int.TryParse(temp, out thirdInt))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!!! Try again.");
                }

                insaneCount--;
            }
            while (insaneCount > 0);

            int result = new int();
            if (firstInt > secondInt)
            {
                if (firstInt > thirdInt)
                {
                    result = firstInt;
                }
                else if (thirdInt > secondInt)
                {
                    result = thirdInt;
                }
                else
                {
                    result = secondInt;
                }
            }
            else if (secondInt > thirdInt)
            {
                result = secondInt;
            }
            else
            {
                result = thirdInt;
            }

            Console.WriteLine("Biggest of those three numbers is " + result);
        }
    }
}
