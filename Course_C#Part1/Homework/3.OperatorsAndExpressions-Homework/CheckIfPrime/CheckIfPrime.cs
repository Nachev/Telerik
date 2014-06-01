namespace CheckIfPrime
{
    using System;

    //Write an expression that checks if given positive integer number n (n ≤ 100) is prime. 
    //E.g. 37 is prime

    class CheckIfPrime
    {
        static void Main()
        {
            Console.WriteLine("Enter an integer for test if it is prime");
            byte testNumber = new byte();
            int insaneCounter = new int();
            //input cycle with check for correct value
            do
            {
                Console.Write("-> ");
                if (byte.TryParse(Console.ReadLine(), out testNumber))
                {
                    break;
                }
                else
                {
                    if (insaneCounter < 10)
                    {
                        Console.WriteLine("Wrong input for tested number!");
                    }
                    else
                    {
                        Console.WriteLine("Too many errors! Check your keyboard and try again later!");
                        return;
                    }
                    insaneCounter++;
                }
            }
            while (true);
            bool check = new bool();
            //cycle to check if tested number is prime
            for (byte count = 2; count < testNumber; count++)
            {
                //if tested number reminder from division by count is zero means not prime
                if (testNumber % count == 0)
                {
                    //check becomes true when tested number reminder from division by count is zero
                    check = true;
                }
            }
            if (check)
            {
                Console.WriteLine("Number {0} is not prime", testNumber);
            }
            else
            {
                Console.WriteLine("Number {0} is prime", testNumber);
            }
        }
    }
}
