namespace NumberOfOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /*Write a program that counts in a given array of 
    double values the number of occurrences of each 
    value. Use Dictionary<TKey,TValue>.
    Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
    -2.5  2 times
    3  4 times
    4  3 times*/
    internal class CountOccurrences
    {
        private static void Main(string[] args)
        {
            Console.Write("Enter comma separated array: ");
            string input = "3, 4, 4, -2.5, 3, 3, 4, 3, -2.5"; // Console.ReadLine();
            var splittedInput = input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var inputArray = new List<double>(splittedInput.Length);
            var elementsCount = new Dictionary<double, int>(splittedInput.Length);
            for (int index = 0; index < splittedInput.Length; index++)
            {
                double arrayElement = new double();
                if (double.TryParse(splittedInput[index], out arrayElement))
                {
                    inputArray.Add(arrayElement);

                    if (elementsCount.ContainsKey(arrayElement))
                    {
                        elementsCount[arrayElement]++;
                    }
                    else
                    {
                        elementsCount.Add(arrayElement, 1);
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Input: {0}", string.Join(", ", inputArray));
            Console.WriteLine(new string('-', 48));
            foreach (var pair in elementsCount)
            {
                Console.WriteLine("Value: {0}, count: {1}", pair.Key, pair.Value);
            }
        }
    }
}