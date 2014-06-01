namespace BitsExchangeOnEnteredPosition
{
    using System;

    //Write a program that exchanges bits {p, p+1, …, p+k-1) with 
    //bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.

    class BitsExchangeOnEnteredPosition
    {
        static void Main()
        {
            uint inputNumber = new uint();
            byte coefficentK = new byte();
            byte firstSeqBitsPos = new byte();
            byte secondSeqBitsPos = new byte();
            Console.WriteLine("Enter an unsigned integer to exchange it's bit values according to \nthe formula: {p, p+1,..., p+k-1) with bits {q, q+1,..., q+k-1}");
            int insaneCounter = new int();
            //input cycle with check for correct value
            do
            {
                Console.Write("N -> ");
                if (uint.TryParse(Console.ReadLine(), out inputNumber))
                {
                    //visual check of input number in binary format
                    Console.WriteLine(Convert.ToString(inputNumber, 2).PadLeft(32, '0'));
                    break;
                }
                else
                {
                    if (insaneCounter < 10)
                    {
                        Console.WriteLine("Wrong input for unsigned integer!");
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
            //cycle to chek if Q, P and coefficent K fulfill the requirements.
            //if Q = P there is nothing to change. If Q+K-1 or P+K-1 >31 - outside the boundaries of uint32
            while (true)
            {
                Console.WriteLine("Enter coefficent value from 0 to (P + K - 1 < 32 or Q + K - 1 < 32)");
                insaneCounter = 0;
                //input cycle for coefficent with check for correct value. 
                //It should be simultaneously positive and less than 30  instead it will overrule the required formula
                do
                {
                    Console.Write("K -> ");
                    if (byte.TryParse(Console.ReadLine(), out coefficentK))
                    {
                        if (coefficentK >= 14)
                        {
                            Console.WriteLine("Input value has to be less than 30");
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong input for coefficent!");
                    }
                    if (insaneCounter >= 10)
                    {
                        Console.WriteLine("Too many errors! Check your keyboard and try again later!");
                        return;
                    }
                    insaneCounter++;

                }
                while (true);
                Console.WriteLine("Enter value for P from 0 to 31");
                insaneCounter = 0;
                //input cycle with check for correct value. It should be simultaneously positive and less than 32
                do
                {
                    Console.Write("P -> ");
                    if (byte.TryParse(Console.ReadLine(), out firstSeqBitsPos))
                    {
                        if (firstSeqBitsPos >= 32)
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
                        Console.WriteLine("Wrong input for bit position P!");
                    }
                    if (insaneCounter >= 10)
                    {
                        Console.WriteLine("Too many errors! Check your keyboard and try again later!");
                        return;
                    }
                    insaneCounter++;

                }
                while (true);
                Console.WriteLine("Enter value for Q from 0 to 31");
                insaneCounter = 0;
                //input cycle with check for correct value. It should be simultaneously positive and less than 32
                do
                {
                    Console.Write("Q -> ");
                    if (byte.TryParse(Console.ReadLine(), out secondSeqBitsPos))
                    {
                        if (secondSeqBitsPos >= 32)
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
                        Console.WriteLine("Wrong input for bit position Q!");
                    }
                    if (insaneCounter >= 10)
                    {
                        Console.WriteLine("Too many errors! Check your keyboard and try again later!");
                        return;
                    }
                    insaneCounter++;

                }
                while (true);
                if (firstSeqBitsPos == secondSeqBitsPos || (firstSeqBitsPos + coefficentK - 1 > 31) || (secondSeqBitsPos + coefficentK - 1 > 31))
                {
                    Console.WriteLine("Q and P must not be equal, Q + K - 1 and P + K - 1 must be less than 32");
                    continue;
                }
                else
                {
                    break;
                }
            }
            byte[] bitArr = new byte[32];
            uint mask = new uint();
            //converts the uint to array of bits 
            for (byte count = 0; count <= 31; count++)
            {
                mask = (uint)1 << count;
                mask = inputNumber & mask;
                bitArr[count] = (byte)(mask >> count);
            }
            ////checkpoint print. It's printed backwards for better visual performance - looks like real binary number
            //for (int bitPosition = 31; bitPosition >= 0; bitPosition-- )
            //{
            //    Console.Write(" {0}", bitArr[bitPosition]);
            //}
            //Console.WriteLine();
            //loop that exchanges values of required array cells
            for (byte count = 0; count < coefficentK; count++)
            {
                byte bitExch = bitArr[firstSeqBitsPos + count];
                //Console.Write("{0} ", bitExch);
                //Console.Write("-> {0}, ", bitArr[secondSeqBitsPos + count]);
                bitArr[firstSeqBitsPos + count] = bitArr[secondSeqBitsPos + count];
                bitArr[secondSeqBitsPos + count] = bitExch;
            }
            ////Console.WriteLine();
            ////checkpoint print. It's printed backwards for better visual performance - looks like real binary number
            //for (int bitPosition = 31; bitPosition >= 0; bitPosition--)
            //{
            //    Console.Write(" {0}", bitArr[bitPosition]);
            //}
            //Console.WriteLine();
            inputNumber = 0;
            //convert bit array to uint
            for (byte count = 0; count <= 31; count++)
            {
                //formula for converting binary number to decimal integer number 
                inputNumber = inputNumber + (bitArr[count] * (uint)Math.Pow(2, count));
            }
            //output
            Console.WriteLine("The new number is {0} in decimal or", inputNumber);
            //binary output
            Console.WriteLine(Convert.ToString(inputNumber, 2).PadLeft(32, '0') + " in binary");
        }
    }
}
