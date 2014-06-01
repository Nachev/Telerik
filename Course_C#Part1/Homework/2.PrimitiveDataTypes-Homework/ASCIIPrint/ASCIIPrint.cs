namespace ASCIIPrint
{
    using System;
    /*Find online more information about ASCII (American Standard Code for Information Interchange) 
     * and write a program that prints the entire ASCII table of characters on the console*/
    class ASCIIPrint
    {
        static void Main()
        {
            char value;
            for (byte count = 0; count < 128; count++)
            {
                value = Convert.ToChar(count);
                Console.Write(" {0} ", value);
                if ((count + 1) % 10 == 0)
                    Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
