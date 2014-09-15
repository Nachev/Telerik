namespace ColoredRabbits
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
            long rabbitsCount = long.Parse(Console.ReadLine());
            Dictionary<long, long> rabbitsAnswers = new Dictionary<long, long>();
            long result = new long();
            for (long i = 0; i < rabbitsCount; i++)
            {
                long answer = long.Parse(Console.ReadLine());
                if (rabbitsAnswers.ContainsKey(answer))
                {
                    if (rabbitsAnswers[answer] == answer)
                    {
                        result += answer + 1;
                        rabbitsAnswers.Remove(answer);
                    }
                    else
                    {
                        rabbitsAnswers[answer] += 1;
                    }

                }
                else
                {
                    rabbitsAnswers.Add(answer, 1);
                }
            }

            foreach (var rabbitAnswer in rabbitsAnswers)
            {
                result += rabbitAnswer.Key + 1;
            }

            Console.WriteLine(result);
        }
    }
}
