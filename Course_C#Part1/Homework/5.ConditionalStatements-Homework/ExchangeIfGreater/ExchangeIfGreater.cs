namespace ExchangeIfGreater
{
    using System;

    /*Write an if statement that examines two integer variables and exchanges 
     * their values if the first one is greater than the second one*/

    public class ExchangeIfGreater
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

            // Input cycle for the second integer with error check
            int secondInt = new int();
            insaneCount = 10;
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

            // Check condition
            if (firstInt > secondInt)
            {
                int change = firstInt;
                firstInt = secondInt;
                secondInt = change;
            }

            // Print the result
            Console.WriteLine("First integer is {0} - second one is {1}", firstInt, secondInt);
        }
    }
}
