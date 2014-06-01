using System;

//// Have to split int in half and take the sum of each half for a player's ammount of drunken beer

private class DrunkenNumbers
{
    private static void Main()
    {
        int rounds = int.Parse(Console.ReadLine()); // Input rounds
        int drunkenNumber = new int(); // input drunken numbers
        int currentResultM = 0;
        int currentResultV = 0;
        for (int i = 0; i < rounds; i++)
        {
            bool sign = false;
            byte counter = 0;
            byte half = 0;
            int[] temp = new int[9];
            drunkenNumber = Math.Abs(int.Parse(Console.ReadLine()));

            // Check drunken numbers count of digits
            do
            {
                temp[counter] = (byte)(drunkenNumber % 10);
                drunkenNumber /= 10;
                counter++;
            }
            while (drunkenNumber > 0);

            // Check where is the middle of the number
            if (counter % 2 != 0)
            {
                half = (byte)((counter / 2) + 1);
                sign = true;
            }
            else
            {
                half = (byte)(counter / 2);
            }

            // Calculate number of beers for Vladko
            for (byte j = 0; j < half; j++)
            {
                currentResultV += temp[j];
            }

            // Calculate number of beers for Mitko      
            if (sign)
            {
                for (byte k = counter; k >= half; k--)
                {
                    currentResultM += temp[k - 1];
                }
            }
            else
            {
                for (byte k = counter; k > half; k--)
                {
                    currentResultM += temp[k - 1];
                }
            }
        }

        // Checking who is the winner
        if (currentResultM > currentResultV)
        {
            Console.Write("M {0}", currentResultM - currentResultV);
        }
        else if (currentResultV > currentResultM)
        {
            Console.Write("V {0}", currentResultV - currentResultM);
        }
        else
        {
            Console.Write("No {0}", currentResultV + currentResultM);
        }
    }
}
