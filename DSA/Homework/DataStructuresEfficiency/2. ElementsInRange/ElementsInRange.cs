namespace _2.ElementsInRange
{
    using System;
    using Wintellect.PowerCollections;

    public class ElementsInRange
    {
        private const int MaxValue = 1000000;

        public static void Main(string[] args)
        {
            OrderedMultiDictionary<double, Article> articles = new OrderedMultiDictionary<double, Article>(true);
            Random randomNumberGenerator = new Random();
            double randomNumber;
            for (int i = 0; i < 2000000; i++)
            {
                randomNumber = randomNumberGenerator.NextDouble() * MaxValue;
                Article article = new Article("barcode" + i, "vendor" + i, "article" + i, randomNumber);
                articles.Add(article.Price, article);
            }

            Console.Write("from = ");
            double from = double.Parse(Console.ReadLine());
            Console.Write("to = ");
            double to = double.Parse(Console.ReadLine());
            var articlesInRange = articles.Range(from, true, to, true);
            foreach (var pair in articlesInRange)
            {
                foreach (var article in pair.Value)
                {
                    Console.WriteLine("{0} => {1}", Math.Round(article.Price, 2), article);
                }
            }
        }
    }
}
