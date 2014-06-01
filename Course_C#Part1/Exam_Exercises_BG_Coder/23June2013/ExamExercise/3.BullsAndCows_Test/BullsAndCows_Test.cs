using System;

class BullsAndCows_Test
{
    static void Main()
    {
        int secretNumber = int.Parse(Console.ReadLine());
        byte bulls = byte.Parse(Console.ReadLine());
        byte cows = byte.Parse(Console.ReadLine());
        int[] secretArray = new int [4];
        int[] multiplier = {1, 10, 100, 1000, 10000};
        //No cases 3b 1c; b + c > 4; 
        if ((bulls == 3 && cows == 1) || (bulls + cows > 4))
        {
            Console.Write("No");
        }
        else if (bulls == 4)
        {
            Console.Write(secretNumber);
        }
        else
        {
            for (int index = 0; index < 4; index++)
            {
                secretArray[index] = secretNumber % 10;
                secretNumber /= 10;
            }
            for (int firstDigit = 1; firstDigit <= 9; firstDigit++)
            {
                for (int secondDigit = 1; secondDigit <= 9; secondDigit++)
                {
                    for (int thirdDigit = 1; thirdDigit <= 9; thirdDigit++)
                    {
                        for (int fourthDigit = 1; fourthDigit <= 9; fourthDigit++)
                        {
                            if (true)
                            {
                                Console.Write("{0}{1}{2}{3}", firstDigit, secondDigit, thirdDigit, fourthDigit);
                            }
                        }
                    }
                }
            }
        }
    }
}