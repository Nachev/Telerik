namespace FindOddOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /*Write a program that extracts from a given sequence 
    of strings all elements that present in it odd number 
    of times. Example:
    {C#, SQL, PHP, PHP, SQL, SQL }  {C#, SQL}*/
    internal class FindOddTimesPresentString
    {
        private static void Main(string[] args)
        {
            Console.Write("Enter comma separated array: ");
            string input = "C#, SQL, PHP, PHP, SQL, SQL"; // Console.ReadLine();
            var splittedInput = input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var elementsCount = new Dictionary<string, int>(splittedInput.Length);
            for (int index = 0; index < splittedInput.Length; index++)
            {
                string arrayElement = splittedInput[index];
                if (elementsCount.ContainsKey(arrayElement))
                {
                    elementsCount[arrayElement]++;
                }
                else
                {
                    elementsCount.Add(arrayElement, 1);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Input: {0}", string.Join(", ", splittedInput));
            Console.WriteLine(new string('-', 48));
            foreach (var pair in elementsCount)
            {
                if (pair.Value % 2 != 0)
                {
                    Console.WriteLine("Value: {0}, count: {1}", pair.Key, pair.Value);
                }
            }
        }
    }
}