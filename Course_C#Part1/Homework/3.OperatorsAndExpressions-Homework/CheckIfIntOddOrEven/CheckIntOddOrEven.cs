namespace CheckIfIntOddOrEven
{
    using System;

    //Write an expression that checks if given integer is odd or even

    class CheckIntOddOrEven
    {
        static void Main()
        {
            Console.WriteLine("Enter an integer for test odd or even");
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
                Console.WriteLine("You are not testing a number, but playing with my programm.");
                return;
            }
            else
            {
                //check the last bit if 1 means odd
                if ((testNumber & 1) == 1)
                {
                    Console.WriteLine("This number is ODD");
                }
                else
                {
                    Console.WriteLine("This number is EVEN");
                }
            }
        }
    }
}
