namespace NfactMultipliedByKfactDividedKminusNfact
{
    using System;
    using System.Numerics;

    /*Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K)*/

    public class NfactMultipliedByKfactDividedKminusNfact
    {
        public static void Main()
        {
            Console.Title = "Claculate  N!*K! / (K-N)!";
            int firstNumberN = new int();
            int secondNumberK = new int();
            Console.WriteLine("Enter values for N and K. 1<N<K ");
            do
            {
                bool check1 = new bool();
                do
                {
                    Console.Write("Enter N: ");
                    string temp1 = Console.ReadLine();
                    check1 = int.TryParse(temp1, out firstNumberN);
                } 
                while (!check1);

                bool check2 = new bool();
                do
                {
                    Console.Write("Enter K: ");
                    string temp2 = Console.ReadLine();
                    check2 = int.TryParse(temp2, out secondNumberK);
                } 
                while (!check2);
            } 
            while (!((firstNumberN > 1) && (firstNumberN < secondNumberK)));

            BigInteger nFactorial = 1;
            for (int count = 1; count <= firstNumberN; count++)
            {
                nFactorial *= count;
            }

            BigInteger kFactorial = 1;
            for (int count = 1; count <= secondNumberK; count++)
            {
                kFactorial *= count;
            }

            BigInteger minusFactorial = 1;
            int length = secondNumberK - firstNumberN;
            for (int count = 1; count <= length; count++)
            {
                minusFactorial *= count;
            }

            Console.WriteLine("N!*K! / (K-N)! = {0}", (nFactorial * kFactorial) / minusFactorial);
        }
    }
}
