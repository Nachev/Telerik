namespace DynamicProgramming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Program
    {
        /*beer – weight=3, cost=2
         vodka – weight=8, cost=12
         cheese – weight=4, cost=5
         nuts – weight=1, cost=4
         ham – weight=2, cost=3
         whiskey – weight=8, cost=13        */

        private static readonly IDictionary<string, KeyValuePair<int, int>> inputItems = new Dictionary<string, KeyValuePair<int, int>>() 
        {
            { "beer", new KeyValuePair<int, int>(3, 2) },
            { "vodka", new KeyValuePair<int, int>(8, 12) },
            { "cheese", new KeyValuePair<int, int>(4, 5) },
            { "nuts", new KeyValuePair<int, int>(1, 4) },
            { "ham", new KeyValuePair<int, int>(2, 3) },
            { "whiskey", new KeyValuePair<int, int>(8, 13) },
        };

        private static void Main(string[] args)
        {
            // Input
            int numberOfItems = inputItems.Count;
            int[] values = new int[numberOfItems];
            int[] weigths = new int[numberOfItems];
            int knapsackCapacity = 10;

            for (int i = 0; i < numberOfItems; i++)
            {
                weigths[i] = inputItems.ElementAt(i).Value.Key;
                values[i] = inputItems.ElementAt(i).Value.Value;
            }

            // Solve
            int[,] m = new int[numberOfItems, knapsackCapacity];

            for (int i = 1; i < numberOfItems; i++)
            {
                for (int j = 0; j < knapsackCapacity; j++)
                {
                    if (weigths[i] <= j)
                    {
                        m[i, j] = Math.Max(m[i - 1, j], m[i - 1, j - weigths[i]] + values[i]);
                    }
                    else
                    {
                        m[i, j] = m[i - 1, j];
                    }
                }
            }

            Console.WriteLine(m[m.GetLength(0) - 1, m.GetLength(1) - 1]);
        }
    }
}
