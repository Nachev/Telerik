using System;

private class Neurons
{
    private static void Main()
    {
        byte counter = 0;
        uint[] inputArray = new uint[32];
        for (byte arrIndex = 0; arrIndex < 32; arrIndex++)
        {
            if (uint.TryParse(Console.ReadLine(), out inputArray[arrIndex]))
            {
                counter++;
                continue;
            }
            else
            {
                break;
            }
        }

        // foreach (var item in inputArray)
        // {
        //     Console.WriteLine(Convert.ToString(item, 2).PadLeft(32,'0'));
        // }
        uint[] invertedArray = new uint[32];

        // Cycle through rows
        for (byte arrIndex = 0; arrIndex < counter; arrIndex++)
        {
            byte[] byteAtPos = new byte[32];
            byte tempSpaceCount = 0;
            byte spaceCount = 0;
            bool countFlag = new bool();
            byte neighbour = new byte();

            // Check each byte
            for (byte position = 0; position < 32; position++)
            {
                byte digit = (byte)((inputArray[arrIndex] >> position) & 1);

                // If cuurent byte is one set start counter flag true
                if (digit == 1)
                {
                    // If end of zero space reached save space counter
                    if (neighbour == 0 && countFlag)
                    {
                        spaceCount = tempSpaceCount;
                        tempSpaceCount = 0;
                    }

                    byteAtPos[position] = 0;
                    neighbour = digit;
                    countFlag = true;
                }
                else
                {
                    neighbour = digit;
                }

                if (digit == 0 && countFlag)
                {
                    tempSpaceCount++;
                    if (spaceCount == 0)
                    {
                        byteAtPos[position] = 1;
                    }
                    else
                    {
                        byteAtPos[position] = 0;
                    }
                }
            }

            if (spaceCount == 0)
            {
                invertedArray[arrIndex] = 0;
            }
            else
            {
                for (byte power = 0; power < 32; power++)
                {
                    invertedArray[arrIndex] += byteAtPos[power] * (uint)Math.Pow(2, power);
                }
            }
        }

        for (byte index = 0; index < counter; index++)
        {
            Console.WriteLine(invertedArray[index]);
        }
    }
}
