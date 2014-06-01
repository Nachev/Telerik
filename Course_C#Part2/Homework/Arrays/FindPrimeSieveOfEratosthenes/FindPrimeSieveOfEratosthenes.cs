namespace FindPrimeSieveOfEratosthenes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /*Write a program that finds all prime numbers in the range [1...10 000 000]. 
     * Use the sieve of Eratosthenes algorithm (find it in Wikipedia)*/

    public class FindPrimeSieveOfEratosthenes
    {
        public static void Main()
        {
            Console.Title = "Sieve of Erathosthenes algorithm";
            int enteredLength = 10000000;
            bool[] resultArray = new bool[enteredLength];

            // Call method to find Primes
            resultArray = SieveErathostenes(enteredLength);

            Output(resultArray);
        }

        private static void Output(bool[] resultArray)
        {
            // Create stringbuilder to ensure text will not exceed line limits
            StringBuilder result = new StringBuilder();
            StringBuilder finalResult = new StringBuilder();
            int window = Console.WindowWidth - 1;
            for (int index = 1; index < resultArray.Length; index++)
            {
                if (resultArray[index])
                {
                    // Take number length
                    int numbLength = new int();
                    int indexCopy = index;
                    while (indexCopy > 0)
                    {
                        indexCopy /= 10;
                        numbLength++;
                    }

                    // Check if line end is reached
                    if (result.Length + numbLength >= window)
                    {
                        finalResult.Append(result).AppendLine();
                        result.Clear();
                        result.Append(index).Append(" ");
                    }
                    else
                    {
                        result.Append(index).Append(" ");
                    }
                }
            }

            // Print the result
            Console.Write(finalResult.ToString());
            if (result.Length > 0)
            {
                Console.WriteLine(result.ToString());
            }
        }

        private static bool[] SieveErathostenes(int seqLength)
        {
            // Initialize bool array true
            bool[] isPrime = new bool[seqLength];
            for (int index = 0; index < seqLength; index++)
            {
                isPrime[index] = true;
            }

            int length = (int)Math.Sqrt(seqLength);
            /*if (length <= 2)
            {
                length = seqLength;
            }*/

            for (int extIndex = 2; extIndex < length; extIndex++)
            {
                if (isPrime[extIndex])
                {
                    // Make all next multiples false
                    int extIndSq = extIndex * extIndex;
                    for (int intIndex = extIndSq, mult = 0; intIndex < isPrime.Length; mult++, intIndex = extIndSq + (extIndex * mult))
                    {
                        isPrime[intIndex] = false;
                    }
                }
            }

            return isPrime;
        }
    }
}
