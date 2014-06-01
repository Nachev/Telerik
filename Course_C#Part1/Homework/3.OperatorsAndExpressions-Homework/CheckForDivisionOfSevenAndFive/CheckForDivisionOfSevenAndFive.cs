namespace CheckForDivisionOfSevenAndFive
{
    using System;

    //Write a boolean expression that checks for given integer 
    //if it can be divided (without remainder) by 7 and 5 in the same time.

    class CheckForDivisionOfSevenAndFive
    {
        static void Main()
        {
            Console.WriteLine("Enter an integer for test if divisible by 7 and 5 without reminder");
            int testNumber = new int();
            int insaneCounter = new int();
            //input cycle with check for correct input
            do
            {
                Console.Write("-> ");
                if (int.TryParse(Console.ReadLine(), out testNumber))
                {
                    break;
                }
                else
                {
                    insaneCounter++;
                    Console.WriteLine("Wrong input for tested number!");
                }
            }
            while (insaneCounter < 10);
            if (insaneCounter >= 10)
            {
                Console.WriteLine("Too many errors! Check your keyboard and try again later!");
                return;
            }
            //check the requirements for tested number
            bool check = ((testNumber % 7) == 0) && ((testNumber % 5) == 0);
            if (check)
            {
                Console.WriteLine("This number could be devided by seven and five simultaniously");
            }
            else
            {
                Console.WriteLine("This number could not be devided by seven and five simultaniously");
            }
        }
    }
}
