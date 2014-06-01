namespace BitsExchange
{
    using System;

    //Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer

    class BitsExchange
    {
        static void Main()
        {
            Console.WriteLine("Enter an integer to exchange it's bit values of \n3rd, 4th and 5th bits with 24th, 25th and 26th");
            uint inputNumber = new uint();
            int insaneCounter = new int();
            //input cycle with check for correct value
            do
            {
                Console.Write("N -> ");
                if (uint.TryParse(Console.ReadLine(), out inputNumber))
                {
                    //visual check of input number in binary format
                    Console.WriteLine("Binary representation is: {0}", Convert.ToString(inputNumber, 2).PadLeft(32, '0'));
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
            //extract bit values of 3rd, 4th and 5th bits
            uint lowBitsValues = new uint();
            for (int counter = 3; counter <= 5; counter++)
            {
                uint mask = (uint)(1 << counter);
                lowBitsValues |= inputNumber & mask;
            }
            //extract bit values of 24th, 25th and 26th bits
            uint highBitsValues = new uint();
            for (int counter = 24; counter <= 26; counter++)
            {
                uint mask = (uint)(1 << counter);
                highBitsValues |= inputNumber & mask;
            }
            //Console.WriteLine(Convert.ToString(lowBitsValues, 2));
            //Console.WriteLine(Convert.ToString(highBitsValues, 2));
            
            //delete(initialize to zero) all required bits
            uint resultNumber = inputNumber;
            resultNumber ^= lowBitsValues;
            resultNumber ^= highBitsValues;
            //Console.WriteLine(Convert.ToString(resultNumber, 2));

            //exchange bits values
            lowBitsValues <<= 21;
            highBitsValues >>= 21;
            //Console.WriteLine(Convert.ToString(lowBitsValues, 2));
            //Console.WriteLine(Convert.ToString(highBitsValues, 2));

            //save changes
            resultNumber |= lowBitsValues;
            resultNumber |= highBitsValues;

            //printing the result
            Console.WriteLine("Result number: {0}", resultNumber);
            Console.WriteLine("In binary format: {0}", Convert.ToString(resultNumber, 2));

            ////defining new array to store bits values
            //int[] bitArr = new int[32];
            //uint bitCh = new uint();
            //uint mask = new uint();
            ////next cycle converts the uint to array of bits
            //for (int bitPosition = 0; bitPosition <= 31; bitPosition++)
            //{
            //    mask = (uint)1 << bitPosition;
            //    bitCh = inputNumber & mask;
            //    bitArr[bitPosition] = (int)(bitCh >> bitPosition);
            //}
            //int temp = new int();
            ////next cycle changes values of 3, 4 and 5 with 24, 25 and 26 bit array number
            //for (int bitPosition = 3; bitPosition <= 5; bitPosition++)
            //{
            //    temp = bitArr[bitPosition];
            //    bitArr[bitPosition] = bitArr[bitPosition + 21];
            //    bitArr[bitPosition + 21] = temp;
            //}
            //inputNumber = 0;
            ////convert bit array to uint
            //for (int bitPosition = 0; bitPosition <= 31; bitPosition++)
            //{
            //    //formula for converting binary number to decimal number 
            //    inputNumber = inputNumber + (uint)(bitArr[bitPosition] * Math.Pow(2, bitPosition));
            //}
            ////result output
            //Console.Write("The new number is {0} or ", inputNumber);
            ////binary output
            //Console.WriteLine(Convert.ToString(inputNumber, 2).PadLeft(32, '0'));
        }
    }
}
