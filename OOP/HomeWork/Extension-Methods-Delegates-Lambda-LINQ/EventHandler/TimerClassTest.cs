namespace TimerClass
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    public class TimerClassTest
    {
        private const int SECOND = 1000;
        private const int INTERVAL = 7;

        public static void Main()
        {
            Timer test = new Timer(PrintSomething, "3", 3);
            Timer texst2 = new Timer(PrintSomething, "5", 5);
            Stopwatch stopWatch = new Stopwatch();
            DateTime beginTimer = new DateTime();
            DateTime stopTimer = new DateTime();
            beginTimer = DateTime.Now;
            stopWatch.Start();
            test.Run();
            texst2.Run();
            while (!Console.KeyAvailable)
            {
                if (stopWatch.Elapsed.Seconds % 10 == INTERVAL)
                {
                    Console.WriteLine("Timer - StopWatch");
                }

                stopTimer = DateTime.Now;
                int dateTimeTimer = stopTimer.Second - beginTimer.Second;
                if (dateTimeTimer % 10 == INTERVAL)
                {
                    Console.WriteLine("Timer - DateTime");
                }

                Thread.Sleep(SECOND);
            }

            Environment.Exit(0);
        }

        private static void PrintSomething(string message)
        {
            Console.WriteLine(message);
        }
    }
}
