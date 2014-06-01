namespace MinMaxOfNNumbers
{
    using System;

    /*Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.*/

    public class MinMaxOfNNumbers
    {
        public static void Main()
        {
            // Input block
            int length = new int();
            int breakCounter = 10;
            do
            {
                Console.Write("Enter number for sequence length: ");
                string temp = Console.ReadLine();
                bool check = int.TryParse(temp, out length);
                if (check)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!! Try again.");
                }

                breakCounter--;
            } 
            while (breakCounter > 0);

            int minNumber = int.MaxValue;
            int maxNumber = int.MinValue;
            for (int count = 1; count <= length; count++)
            {
                int number = new int();
                breakCounter = 10;
                do
                {
                    Console.Write("Enter element {0}: ", count);
                    string temp = Console.ReadLine();
                    bool check = int.TryParse(temp, out number);
                    if (check)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input!! Try again.");
                    }

                    breakCounter--;
                }
                while (breakCounter > 0);

                if (number > maxNumber)
                {
                    maxNumber = number;
                }
                else if (number < minNumber)
                {
                    minNumber = number;
                }
            }

            Console.WriteLine("Minimal number is {0} maximal is {1}", minNumber, maxNumber);
        }
    }
}
