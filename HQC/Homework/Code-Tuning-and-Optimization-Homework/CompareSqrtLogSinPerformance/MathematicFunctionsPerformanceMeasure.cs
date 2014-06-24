namespace CompareSqrtLogSinPerformance
{
    using System;
    using System.Diagnostics;

    public class MathematicFunctionsPerformanceMeasure
    {
        private const int MaxExecutions = 1000000;
        public static void PerformanceMeter(Action method)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            method();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        public static void SquareRoot()
        {
            Console.Write("Square root: ");
            double test;
            for (int i = 0; i < MaxExecutions; i++)
            {
                test = Math.Sqrt(144);
            }
        }

        public static void NaturalLogarithm()
        {
            Console.Write("NaturalLogarithm: ");
            double test;
            for (int i = 0; i < MaxExecutions; i++)
            {
                test = Math.Sqrt(144);
            }
        }

        public static void Sinus()
        {
            Console.Write("Sinus: ");
            double test;
            for (int i = 0; i < MaxExecutions; i++)
            {
                test = Math.Sin(60);
            }
        }

        static void Main()
        {
            PerformanceMeter(() => SquareRoot());
            PerformanceMeter(() => NaturalLogarithm());
            PerformanceMeter(() => Sinus());
        }
    }
}
