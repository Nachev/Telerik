namespace TimerClass
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public delegate void EventStarter(string text);

    public class Timer
    {
        private const int SECOND = 1000;

        private int period;
        private int timer;
        private string text;

        private Thread newThread;

        public Timer(EventStarter method, string externalText, int period)
        {
            this.newThread = new Thread(this.RunTimer);
            this.text = externalText;
            this.period = period;
            this.DelegateMethod = method;
            this.timer = new int();
        }

        public EventStarter DelegateMethod { get; set; }

        public void Run()
        {
            this.newThread.Start();
        }

        private void RunTimer()
        {
            while (true)
            {
                this.timer++;

                if (this.timer % this.period == 0)
                {
                    this.DelegateMethod(this.text);
                }

                Thread.Sleep(SECOND);
            }
        }
    }
}
