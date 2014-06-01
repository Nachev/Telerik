namespace ChangeBitValueOnPosition
{
    using System;

    //We are given integer number n, value v (v=0 or 1) and a position p. Write a sequence of operators 
    //that modifies n to hold the value v at the position p from the binary representation of n.
	//Example: n = 5 (00000101), p=3, v=1  13 (00001101)
	//n = 5 (00000101), p=2, v=0  1 (00000001)

    class ChangeBitValueOnPosition
    {
        static void Main()
        {
            Console.WriteLine("Enter an integer to change it's bit value to a desired state:");
            int testNumber = new int();
            int insaneCounter = new int();
            //input cycle with check for correct value
            do
            {
                Console.Write("N -> ");
                if (int.TryParse(Console.ReadLine(), out testNumber))
                {
                    //visual check of input number in binary format
                    Console.WriteLine(Convert.ToString(testNumber, 2).PadLeft(32, '0'));
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
            insaneCounter = 0;
            int bitValue = new int();
            //input cycle for bit value with check for correct value 0 or 1
            Console.WriteLine("Enter bit value (0 or 1):");
            do
            {
                Console.Write("V -> ");
                if (int.TryParse(Console.ReadLine(), out bitValue))
                {
                    if (bitValue == 1 || bitValue == 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Bit value V has to be 1 or 0");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input for bit value!");
                }
                if (insaneCounter >= 10)
                {
                    Console.WriteLine("Too many errors! Check your keyboard and try again later!");
                    return;
                }
                insaneCounter++;
            }
            while (true);
            Console.WriteLine("Enter which bit you want to change. Position number from 0 to 32");
            byte bitPosition = new byte();
            insaneCounter = 0;
            //input cycle with check for correct value. It should be simultaneously positive and less than 32
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
            //bitwize 'and' gives 'one' on searched positon if the bit there is 'one' - else 'zero'
            int bitCheck = testNumber & mask;
            bitCheck = bitCheck >> bitPosition;
            //if required value and current bit value are equal there is nothing to change
            if ((bitValue == 0 && bitCheck == 0) || (bitValue == 1 && bitCheck == 1))
            {
                Console.WriteLine("Nothing to change");
                Console.WriteLine(Convert.ToString(testNumber, 2).PadLeft(32, '0'));
            }
            else
            {
                //if entered value is 0 and current value 1 change to 1 
                if (bitValue == 0 && bitCheck == 1)
                {
                    testNumber = testNumber ^ mask;
                    Console.WriteLine("The new value is: {0}", testNumber);
                    Console.WriteLine(Convert.ToString(testNumber, 2).PadLeft(32, '0'));
                }
                //else change to zero
                else
                {
                    testNumber = testNumber | mask;
                    Console.WriteLine("The new value is: {0}", testNumber);
                    Console.WriteLine(Convert.ToString(testNumber, 2).PadLeft(32, '0'));
                }
            }
        }
    }
}
