namespace ReadFromConsoleAndPrint
{
    using System;

    //// Write a program that reads 3 integer numbers from the console and prints their sum

    public class ReadFromConsoleAndPrintSum
    {
        private static void Main()
        {
            int insaneCounter = 10;
            int firstInt = new int();

            // First integer input block with error check
            Console.WriteLine("Enter first integer");
            do
            {
                Console.Write("-> ");
                string temp = Console.ReadLine();
                if (int.TryParse(temp, out firstInt))
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

            // Second integer input block with error check
            insaneCounter = 10;
            int secondInt = new int();
            Console.WriteLine("Enter second integer");
            do
            {
                Console.Write("-> ");
                string temp = Console.ReadLine();
                if (int.TryParse(temp, out secondInt))
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

            // Third integer input block with error check
            insaneCounter = 10;
            int thirdInt = new int();
            Console.WriteLine("Enter third integer");
            do
            {
                Console.Write("-> ");
                string temp = Console.ReadLine();
                if (int.TryParse(temp, out thirdInt))
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
            Console.WriteLine("Entered numbers are {0}, {1} and {2}\n{0} + {1} + {2} = {3}", firstInt, secondInt, thirdInt, firstInt + secondInt + thirdInt);
        }
    }
} 
