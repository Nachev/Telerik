namespace FibonacciOneHundred
{
    using System;
    using System.Numerics;
    using System.Text;

    /* Write a program to print the first 100 members of the sequence of Fibonacci: 
    0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377,*/

    public class FibonacciOneHundred
    {
        private static void Main()
        {
            /*// Using array to store the values
            //Console.Write("Fibonacci: 0, 1, ");
            //ulong[] fibonacciArray = new ulong[100];
            //fibonacciArray[0] = 0;
            //fibonacciArray[1] = 1;
            //for (byte count = 2; count < 100; count++)
            //{
            //    fibonacciArray[count] = fibonacciArray[count - 1] + fibonacciArray[count - 2];
            //    Console.Write("{0}, ", fibonacciArray[count]);
            //    if ((count + 1) % 4 == 0)
            //    {
            //        Console.WriteLine();
            //    }
            //} */
            int length = 100;
            BigInteger fibGrandpa = 0;
            BigInteger fibFather = 1;
            StringBuilder builder = new StringBuilder("Fibonacci: 0, 1, ");
            StringBuilder builderTemp = new StringBuilder("Fibonacci: 0, 1, ");
            for (int count = 2; count <= length; count++)
            {
                BigInteger fibCurrent = new long();

                // Checked is used when fib Numbers type is ulong or shorter
                checked
                {
                    try
                    {
                        fibCurrent = fibFather + fibGrandpa;
                    }
                    catch (OverflowException)
                    {
                        builder.Append("\nToo many elements for calculation. OVERFLOW!");
                        Console.WriteLine(builder.ToString());
                        Environment.Exit(0);
                    }
                }

                fibGrandpa = fibFather;
                fibFather = fibCurrent;

                /* Next block is used to print numbers in line without cutting at the end of window. 
                Works for numbers shorter than window width */
                {
                    builderTemp.Append(fibCurrent).Append(", ");
                    if (builderTemp.Length < Console.WindowWidth)
                    {
                        builder.Append(fibCurrent).Append(", ");
                    }
                    else
                    {
                        builder.AppendLine().Append(fibCurrent).Append(", ");
                        builderTemp.Clear();
                        builderTemp.Append(fibCurrent).Append(", ");
                    }
                }
            }

            Console.WriteLine(builder.ToString());
        }
    }
}
