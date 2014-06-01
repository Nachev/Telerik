namespace ExtensionMethods
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TestExtensions
    {
        private static void Main()
        {
            var strBldr = new StringBuilder("Some test string");
            Console.WriteLine(strBldr.Substring(6, 4));

            IEnumerable<int> testEnum = new[] { 2, 5, 6, 8 };
            Console.WriteLine(testEnum.Average());

            Console.WriteLine(testEnum.Max());

            Console.WriteLine(testEnum.Min());
        }
    }
}
