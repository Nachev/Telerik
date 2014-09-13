namespace _3.BiDictionary
{
    using System;

    public class BiDictionaryDemo
    {
        public static void Main(string[] args)
        {
            BiDictionary<string, int, string> biDictionary = new BiDictionary<string, int, string>(true);
            biDictionary.Add("ab", 2, "abab");
            biDictionary.AddByKey1("ac", "acac");
            biDictionary.AddByKey1("ac", "ac");
            biDictionary.AddByKey2(2, "ac");

            Console.WriteLine("Items with key 2: ");
            foreach (var item in biDictionary.FindByKey2(2))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("Elements with keys 'ac' and 2: ");
            foreach (var item in biDictionary.FindByKeys("ac", 2))
            {
                Console.WriteLine(item);
            }
        }
    }
}
