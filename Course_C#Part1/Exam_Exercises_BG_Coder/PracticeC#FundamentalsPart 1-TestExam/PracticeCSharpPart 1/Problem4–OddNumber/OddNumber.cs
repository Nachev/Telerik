using System;

class OddNumber
{
    static void Main()
    {
        string tempInputStr = Console.ReadLine();
        int numberN = int.Parse(tempInputStr);
        long[] inputNumber = new long[99999];
        for (int index = 0; index < numberN; index++)
		{
            tempInputStr = Console.ReadLine();
            inputNumber[index] = long.Parse(tempInputStr);
            int counter = index - 1;
            long tempLong = inputNumber[index];
            while (counter >= 0 && tempLong < inputNumber[counter])
            {
                inputNumber[counter + 1] = inputNumber[counter];
                inputNumber[counter] = tempLong;
                counter--;
            }
		}
        //for (int firstIndex = 0; firstIndex < numberN; firstIndex++)
        //{
        //    int counter = 1;
        //    for (int secondIndex = 0; secondIndex < numberN; secondIndex++)
        //    {
        //        if (firstIndex == secondIndex)
        //        {
        //            continue;
        //        }
        //        else if (inputNumber[firstIndex] == inputNumber[secondIndex])
        //        {
        //            counter++;
        //        }
        //    }
        //    if ((counter & 1) == 1)
        //    {
        //        Console.Write(inputNumber[firstIndex]);
        //        break;
        //    }
        //}
        //sort in increasing order
        //bool flagBigger = true;
        //bool flagSmaller = true;
        //int indexLenght = numberN - 1;
        //while (flagBigger || flagSmaller)
        //{
        //    flagBigger = false;
        //    flagSmaller = false;
        //    for (int index = 1; index < numberN; index++)
        //    {
        //        if (inputNumber[index] < inputNumber[index - 1])
        //        {
        //            long tempBigInt = inputNumber[index - 1];
        //            inputNumber[index - 1] = inputNumber[index];
        //            inputNumber[index] = tempBigInt;
        //            flagSmaller = true;
        //        }
        //        if (index < indexLenght)
        //        {
        //            if (inputNumber[index] > inputNumber[index + 1])
        //            {
        //                long tempBigInt = inputNumber[index + 1];
        //                inputNumber[index + 1] = inputNumber[index];
        //                inputNumber[index] = tempBigInt;
        //                flagBigger = true;
        //                index++;
        //            }
        //        }
        //    }
        //}
        int eqCounter = 1;
        //check if the first number is singular
        if (inputNumber[0] != inputNumber[1])
        {
            Console.Write(inputNumber[0]);
        }
        else
        {
            //cycle through the array
            for (int index = 1; index < numberN; index++)
            {
                //check every previous number for equality with the current one
                if ((inputNumber[index - 1] == inputNumber[index]))
                {
                    eqCounter++;
                }
                else
                {
                    //check if counter is odd or even
                    if ((eqCounter) % 2 == 0)
                    {
                        eqCounter = 1;
                    }
                    else
                    {
                        Console.Write(inputNumber[index - 1]);
                        break;
                    }
                }
                if ((index + 1) >= numberN)
                {
                    if ((eqCounter) % 2 == 0)
                    {
                        eqCounter = 1;
                        break;
                    }
                    else
                    {
                        Console.Write(inputNumber[index]);
                        break;
                    }
                }
            }
        }
    }
}
