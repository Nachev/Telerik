namespace FeaturingWithGrisko
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FeaturingWithGrisko
    {
        private static int _counter = new int();
        private static HashSet<string> result = new HashSet<string>();

        private static void Main()
        {
            string input = Console.ReadLine();
            char[] word = new char[input.Length];
            InputToArray(input, word);
            GeneratePermutations(input.Length - 1, word);
            _counter = result.Count;
            Console.WriteLine(_counter);
        }

        private static void InputToArray(string input, char[] word)
        {
            for (int index = 0; index < input.Length; index++)
            {
                word[index] = input[index];
            }
        }

        /*procedure generate(N : integer, data : array of any):
    if N = 1 then
        output(data)
    else
        for c := 1; c <= N; c += 1 do
            generate(N - 1, data)
            swap(data[if N is odd then 1 else c], data[N])*/

        private static void GeneratePermutations(int n, char[] data)
        {
            if (n == 0)
            {
                CountUniques(data);
                return;
            }
            else
            {
                for (int c = 0; c <= n; c++)
                {
                    GeneratePermutations(n - 1, data);
                    if (data[((n & 1) == 0) ? 0 : c] == data[n])
                        continue;
                    Swap(data, (((n & 1) == 0) ? 0 : c), n);
                }
            }
        }

        private static void CountUniques(char[] data)
        {
            if (!CheckConsecutiveEquals(data))
            {
                result.Add(new string(data));
            }
        }

        private static bool CheckConsecutiveEquals(char[] data)
        {
            for (int index = 1; index < data.Length; index++)
            {
                if (data[index] == data[index - 1])
                {
                    return true;
                }
            }

            return false;
        }

        private static void Swap(char[] data, int first, int second)
        {
            char swap = data[first];
            data[first] = data[second];
            data[second] = swap;
        }
    }
}
