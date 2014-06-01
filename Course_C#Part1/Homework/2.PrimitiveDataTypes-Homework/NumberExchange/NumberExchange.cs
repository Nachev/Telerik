namespace NumberExchange
{
    using System;

    /*Declare  two integer variables and assign them with 5 and 10 and after that exchange their values*/

    class NumberExchange
    {
        static void Main()
        {
            byte firstNumber = 5;
            byte secondNumber = 10;
            Console.WriteLine("First number is {0} and second one is {1}", firstNumber, secondNumber);
            short exchange = firstNumber;
            firstNumber = secondNumber;
            secondNumber = (byte)exchange;
            Console.WriteLine("After the exchange procedure first number becomes {0} and second one becomes {1}", firstNumber, secondNumber);
        }
    }
}
