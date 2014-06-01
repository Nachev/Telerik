namespace CheckThirdDigitForSeven
{
    using System;

    //Write an expression that checks for given integer if its third digit (right-to-left) is 7. 
    //E. g. 1732  true

    class CheckThirdDigitForSeven
    {
        static void Main()
        {
            Console.WriteLine("Enter an integer for test if it's third digit is seven");
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
            //check if tested number fulfill the requirements
            bool check = ((testNumber / 100) % 10) == 7;
            Console.WriteLine(check);
        }
    }
}
