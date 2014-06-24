namespace CompareArithmeticPerformance
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public class ArithmeticOperations
    {
        private const int MaxExecutions = 1000000;
        public static void PerformanceMeter(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        static void Add()
        {
            Console.Write("Int addition: ");
            PerformanceMeter(() =>
            {
                int sum = 0;
                for (int i = 0; i < MaxExecutions; i++)
                {
                    sum += 100;
                }
            });

            Console.Write("Long addition: ");
            PerformanceMeter(() =>
            {
                long sum = 0L;
                for (int i = 0; i < MaxExecutions; i++)
                {
                    sum += 100L;
                }
            });

            Console.Write("Float addition: ");
            PerformanceMeter(() =>
            {
                float sum = 0f;
                for (int i = 0; i < MaxExecutions; i++)
                {
                    sum += 100f;
                }
            });

            Console.Write("Double addition: ");
            PerformanceMeter(() =>
            {
                double sum = 0.0;
                for (int i = 0; i < MaxExecutions; i++)
                {
                    sum += 100.0;
                }
            });

            Console.Write("Decimal addition: ");
            PerformanceMeter(() =>
            {
                decimal sum = 0m;
                for (int i = 0; i < MaxExecutions; i++)
                {
                    sum += 100m;
                }
            });
        }

        static void Subtract()
        {
            Console.Write("Int subtraction: ");
            PerformanceMeter(() =>
            {
                int result = 1000000000;
                for (int i = 0; i < MaxExecutions; i++)
                {
                    result -= 100;
                }
            });

            Console.Write("Long subtraction: ");
            PerformanceMeter(() =>
            {
                long result = 1000000000L;
                for (int i = 0; i < MaxExecutions; i++)
                {
                    result -= 100L;
                }
            });

            Console.Write("Float subtraction: ");
            PerformanceMeter(() =>
            {
                float result = 1000000000F;
                for (int i = 0; i < MaxExecutions; i++)
                {
                    result -= 100f;
                }
            });

            Console.Write("Double subtraction: ");
            PerformanceMeter(() =>
            {
                double result = 1000000000.0D;
                for (int i = 0; i < MaxExecutions; i++)
                {
                    result -= 100.0;
                }
            });

            Console.Write("Decimal subtraction: ");
            PerformanceMeter(() =>
            {
                decimal result = 1000000000M;
                for (int i = 0; i < MaxExecutions; i++)
                {
                    result -= 100m;
                }
            });
        }

        static void Increment()
        {
            Console.Write("Integer incrementation: ");
            PerformanceMeter(() =>
            {
                int value = 1;
                for (int i = 0; i < MaxExecutions; i++)
                {
                    value++;
                }
            });

            Console.Write("Long incrementation: ");
            PerformanceMeter(() =>
            {
                long value = 1L;
                for (int i = 0; i < MaxExecutions; i++)
                {
                    value++;
                }
            });

            Console.Write("Float incrementation: ");
            PerformanceMeter(() =>
            {
                float value = 1f;
                for (int i = 0; i < MaxExecutions; i++)
                {
                    value++;
                }
            });

            Console.Write("Double incrementation: ");
            PerformanceMeter(() =>
            {
                double value = 1.0;
                for (int i = 0; i < MaxExecutions; i++)
                {
                    value++;
                }
            });

            Console.Write("Increment of decimal: ");
            PerformanceMeter(() =>
            {
                decimal value = 1m;
                for (int i = 0; i < MaxExecutions; i++)
                {
                    value++;
                }
            });
        }

        static void Multiply()
        {
            Console.Write("Integer multiplication: ");
            PerformanceMeter(() =>
            {
                int product = 1;
                for (int i = 0; i < MaxExecutions; i++)
                {
                    product *= 1;
                }
            });

            Console.Write("Long multiplication: ");
            PerformanceMeter(() =>
            {
                long product = 1L;
                for (int i = 0; i < MaxExecutions; i++)
                {
                    product *= 1L;
                }
            });

            Console.Write("Float multiplication: ");
            PerformanceMeter(() =>
            {
                float product = 1F;
                for (int i = 0; i < MaxExecutions; i++)
                {
                    product *= 1F;
                }
            });

            Console.Write("Double multiplication: ");
            PerformanceMeter(() =>
            {
                double product = 1.0;
                for (int i = 0; i < MaxExecutions; i++)
                {
                    product *= 1.0;
                }
            });

            Console.Write("Decimal multiplication: ");
            PerformanceMeter(() =>
            {
                decimal product = 1M;
                for (int i = 0; i < MaxExecutions; i++)
                {
                    product *= 1M;
                }
            });
        }

        static void Divide()
        {
            Console.Write("Integer division: ");
            PerformanceMeter(() =>
            {
                int result = 10000;
                for (int i = 0; i < MaxExecutions; i++)
                {
                    result /= 1;
                }
            });

            Console.Write("Long division: ");
            PerformanceMeter(() =>
            {
                long result = 10000L;
                for (int i = 0; i < MaxExecutions; i++)
                {
                    result /= 1L;
                }
            });

            Console.Write("Float division: ");
            PerformanceMeter(() =>
            {
                float result = 10000F;
                for (int i = 0; i < MaxExecutions; i++)
                {
                    result /= 1F;
                }
            });

            Console.Write("Double division: ");
            PerformanceMeter(() =>
            {
                double result = 10000.0;
                for (int i = 0; i < MaxExecutions; i++)
                {
                    result /= 1.0;
                }
            });

            Console.Write("Decimal division: ");
            PerformanceMeter(() =>
            {
                decimal result = 10000M;
                for (int i = 0; i < MaxExecutions; i++)
                {
                    result /= 1M;
                }
            });
        }

        static void Main()
        {
            Add();
            Subtract();
            Increment();
            Multiply();
            Divide();
        }
    }
}
