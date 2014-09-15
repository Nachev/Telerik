namespace FindProductsInPriceRange
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class FindProductsInPriceRange
    {
        private const int MaxValue = 1000000;

        public static void Main(string[] args)
        {
            OrderedBag<Product> products = new OrderedBag<Product>();
            Random randomNumberGenerator = new Random();
            double randomNumber;
            for (int i = 0; i < 500000; i++)
            {
                randomNumber = randomNumberGenerator.NextDouble() * MaxValue;
                Product product = new Product("product" + i, randomNumber);
                products.Add(product);
            }

            double from;
            double to;
            for (int i = 0; i < 10000; i++)
            {
                from = randomNumberGenerator.NextDouble() * MaxValue;
                to = randomNumberGenerator.NextDouble() * MaxValue;
                var productInRange = products.Range(new Product("searchFrom", from), true, new Product("searchTo", to), true);
                foreach (var item in productInRange.Take(20))
                {
                    Console.Write("[{0} => {1}] ", item.Name, Math.Round(item.Price, 2));
                }

                Console.WriteLine();
            }
        }
    }
}
