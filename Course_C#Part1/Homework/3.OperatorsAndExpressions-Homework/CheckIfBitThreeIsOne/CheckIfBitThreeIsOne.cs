namespace CheckIfBitThreeIsOne
{
    using System;


    class CheckIfBitThreeIsOne
    {
        static void Main()
        {
            Console.WriteLine("Enter an integer for test if it's third bit is one or zero");
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
            //check tested number's third bit 
            int result = (testNumber >> 2) & 1;
            //for better visual appearance the answer is word
            string[] answer = { "zero", "one" };
            Console.WriteLine("Third bit of the tested number {0} is {1}", testNumber, answer[result]);
        }
    }
}