using System;

class FallDown
{
    static void Main()
    {
        byte[] numbers = new byte[8];
        for (int index = 0; index < 8; index++)
        {
            numbers[index] = byte.Parse(Console.ReadLine());
        }
        //make numbers two dimensional byte array
        byte[,] bits = new byte[8, 8];
        for (int firstIndex = 0; firstIndex < 8; firstIndex++)
        {
            for (int secondIndex = 0; secondIndex < 8; secondIndex++)
            {
                bits[firstIndex, secondIndex] = (byte)(numbers[firstIndex] >> secondIndex & 1);
            }
        }
        bool flag = true;
        while (flag)
        {
            flag = false;
            for (int secondIndex = 0; secondIndex < 8; secondIndex++)
            {
                for (int firstIndex = 0; firstIndex < 7; firstIndex++)
                {
                    if (bits[firstIndex, secondIndex] == 1)
                    {
                        if (bits[firstIndex, secondIndex] > bits[firstIndex + 1, secondIndex])
                        {
                            bits[firstIndex, secondIndex] = 0;
                            bits[firstIndex + 1, secondIndex] = 1;
                            flag = true;
                        }
                    }
                }
            }    
        }
        for (int firstIndex = 0; firstIndex < 8; firstIndex++)
        {
            byte result = new byte();
            for (int secondIndex = 0; secondIndex < 8; secondIndex++)
            {
                result += (byte)(bits[firstIndex, secondIndex] * Math.Pow(2, secondIndex));
            }
            Console.WriteLine(result);
        }
    }
}
