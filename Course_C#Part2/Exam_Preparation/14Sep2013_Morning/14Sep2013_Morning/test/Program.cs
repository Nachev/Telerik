using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> result = new List<string>() { "hi", "academy", "exam", input };
            
           
            Console.WriteLine(string.Join(",",result));
            string test = "test";
            for (int i = 0; i < test.Length; i++)
            {
                Console.WriteLine(test[i]);
            }
        }
    }
}
