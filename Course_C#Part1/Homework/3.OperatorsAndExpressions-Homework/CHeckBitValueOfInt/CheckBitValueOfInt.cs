namespace CheckBitValueOfInt
{
    using System;

    //Write an expression that extracts from a given integer i the 
    //value of a given bit number b. Example: i=5; b=2  value=1.

    class CheckBitValueOfInt
    {
        static void Main()
        {
            Console.WriteLine("Enter an integer to extract it's bit value");
            int testNumber = new int();
            int insaneCounter = new int();
            //input cycle with check for correct value
            do
            {
                Console.Write("V -> ");
                if (int.TryParse(Console.ReadLine(), out testNumber))
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
            Console.WriteLine("Enter which bit you want to extract. Position number from 0 to 31");
            byte bitPosition = new byte();
            insaneCounter = 0;
            //input cycle with check for correct value. It should be both positive and less than 32
            do
            {
                Console.Write("P -> ");
                if (byte.TryParse(Console.ReadLine(), out bitPosition))
                {
                    if (bitPosition >= 32)
                    {
                        Console.WriteLine("Input value has to be less than 32");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input for bit position!");
                }
                if (insaneCounter >= 10)
                {
                    Console.WriteLine("Too many errors! Check your keyboard and try again later!");
                    return;
                }
                insaneCounter++;

            }
            while (true);
            //creating a mask with 'one' on required position
            int mask = 1 << (bitPosition);
            //bitwize 'and' gives bit condition
            int result = testNumber & mask;
            //move rquired bit to position 0
            result = result >> (bitPosition);
            bool check = (result == 1);
            //visual check of the answer
            Console.WriteLine(Convert.ToString(testNumber, 2).PadLeft(32, '0'));
            if (check)
            {
                Console.WriteLine("value = 1");
            }
            else
            {
                Console.WriteLine("value = 0");
            }
        }
    }
}
