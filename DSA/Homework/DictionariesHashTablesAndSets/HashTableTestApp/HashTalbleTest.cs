namespace HashTableTestApp
{
    using HashTableImplementation;
    using System;
    using System.Linq;

    internal class HashTalbleTest
    {
        private static void Main(string[] args)
        {
            HashTable<int, string> test = new HashTable<int, string>();
            test.Add(5, "Pesho");
            test.Add(45, "Gosho");
            test.Add(18, "Mariika");

            Console.WriteLine("Test: " + string.Join(", ", test));
        }
    }
}