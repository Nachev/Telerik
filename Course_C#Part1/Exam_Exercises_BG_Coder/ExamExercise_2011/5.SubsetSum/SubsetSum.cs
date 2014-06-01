//You are given a list of N numbers.
//Write a program that counts all non-empty subsets from this list,
//which have sum of their elements exactly S.

namespace SubsetSum
{
    using System;

    public class SubsetSum
    {
        static void Main()
        {
            long sumS = long.Parse(Console.ReadLine());//On the first input line there will be the number S
            byte setN = byte.Parse(Console.ReadLine());//On the second line you must read the number N 1 - 16
            long[] members = new long[16];
            //On each of the following N lines there will be one integer number written – all the numbers from the list
            for (int i = 0; i < setN; i++)
            {
                members[i] = long.Parse(Console.ReadLine());
            }
            int combinationMask = (int)Math.Pow(2, setN) - 1;//Creating combination mask used as binary number
            int counter = new int();
            for (int currentMask = 1; currentMask <= combinationMask; currentMask++)
            {
                long currentSum = new long();
                for (int i = 0; i < setN; i++)
                {
                    if (((currentMask >> i) & 1) == 1)
                    {
                        currentSum += members[i];
                    }
                }
                if (currentSum == sumS)
                {
                    counter++;
                }
            }
            Console.Write(counter);
        }
    }
}
