namespace FallDown
{
    using System;

    public class FallDown
    {
        private static void Main()
        {
            // Input
            int[] inputNumbers = new int[8];
            inputNumbers = Input(inputNumbers);

            // Solution
            int[] bitField = new int[8];
            bitField = FallingDown(inputNumbers);

            // Output
            Output(bitField);
        }

        private static int[] Input(int[] inputNumbers)
        {
            for (int index = 0; index < 8; index++)
            {
                inputNumbers[index] = int.Parse(Console.ReadLine());
            }

            return inputNumbers;
        }

        private static int[] FallingDown(int[] bitField)
        {
            bool isFalling = new bool();

            do
            {
                isFalling = false;
                for (int row = 7; row > 0; row--)
                {
                    for (int bitPosition = 0; bitPosition < 8; bitPosition++)
                    {
                        bool isCellEmpty = ((bitField[row] >> bitPosition) & 1) == 0;
                        bool isUpperFull = ((bitField[row - 1] >> bitPosition) & 1) == 1;
                        if (isCellEmpty && isUpperFull)
                        {
                            bitField[row] |= (1 << bitPosition);
                            bitField[row - 1] ^= (1 << bitPosition);
                            isFalling = true;
                        }
                    }
                }
            }
            while (isFalling);

            return bitField;
        }

        private static void Output(int[] bitField)
        {
            foreach (int bitLine in bitField)
            {
                Console.WriteLine(bitLine);
            }
        }
    }
}
