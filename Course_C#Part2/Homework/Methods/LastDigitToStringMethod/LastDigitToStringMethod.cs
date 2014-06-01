namespace LastDigitToStringMethod
{
    using System;

    /*Write a method that returns the last digit of given integer as an English word. 
     * Examples: 512  "two", 1024  "four", 12309  "nine"*/

    public class LastDigitToStringMethod
    {
        private static void Main()
        {
            Console.Title = "Return last digit as word";

            int inputInteger = Input("input");

            DigitToString(inputInteger);
        }

        private static void DigitToString(int number)
        {
            string[] dictionary = 
            { 
                "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" 
            };

            int digit = number % 10;

            Console.WriteLine("The last digit of {0} is {1}", number, dictionary[digit]);
        }

        private static int Input(string name)
        {
            int inputValue = new int();
            int breakCount = 5;
            do
            {
                Console.Write("Enter value for {0} : ", name);
                string temp = Console.ReadLine();
                bool check = int.TryParse(temp, out inputValue);

                if (check)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!! Try again.");
                }

                breakCount--;

                if (breakCount <= 0)
                {
                    Console.WriteLine("Error limit reached! Exiting.");
                    Environment.Exit(0);
                }
            }
            while (true);

            return inputValue;
        }
    }
}
