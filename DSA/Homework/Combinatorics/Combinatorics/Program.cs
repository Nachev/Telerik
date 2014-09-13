namespace BinaryPasswords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Program
    {
        private static void Main(string[] args)
        {
            string input = Console.ReadLine();
            long result = 1;
            foreach (var symbol in input)
            {
                if (symbol == '*')
                {
                    result *= 2;
                }
            }
            Console.WriteLine(result);
        }
    }
}
