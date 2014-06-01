namespace NfactDividedByKfact
{
    using System;
    using System.Numerics; // Added reference for BigInteger

    /*Write a program that calculates N!/K! for given N and K (1<K<N)*/

    public class NfactorielDividedByKfactoriel
    {
        public static void Main()
        {
            // Input block with check for correct values
            int firstNumber = new int();
            int secondNumber = new int();
            do
            {
                bool check1 = new bool();
                do
                {
                    Console.Write("Enter N: ");
                    string temp1 = Console.ReadLine();
                    check1 = int.TryParse(temp1, out firstNumber);
                } 
                while (!check1);

                bool check2 = new bool();
                do
                {
                    Console.Write("Enter K: ");
                    string temp2 = Console.ReadLine();
                    check2 = int.TryParse(temp2, out secondNumber);
                } 
                while (!check2);
            } 
            while (!((secondNumber > 1) && (firstNumber > secondNumber)));

            BigInteger nFactoriel = 1;
            for (int i = 1; i <= firstNumber; i++)
            {
                nFactoriel *= i;
            }

            BigInteger kFactoriel = 1;
            for (int i = 1; i <= secondNumber; i++)
            {
                kFactoriel *= i;
            }

            Console.WriteLine("N!/K! = {0} / {1} = {2}", nFactoriel, kFactoriel, nFactoriel / kFactoriel);
        }
    }
}
