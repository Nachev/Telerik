namespace TimerClass
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public delegate void TimerEventHandler(string text);

    public class Timer
    {
        private const int SECOND = 1000;

        private int period;
        private int timer;
        private string text;

        private Thread newThread;

        public Timer(TimerEventHandler method, string externalText, int period)
        {
            this.newThread = new Thread(this.RunTimer);
            this.text = externalText;
            this.period = period;
            this.TimeElapsed = method;
            this.timer = new int();
        }

        public event TimerEventHandler TimeElapsed;

        public TimerEventHandler DelegateMethod { get; set; }

        public void Run()
        {
            this.newThread.Start();
        }

        public void Stop()
        {
            this.newThread.Abort();
        }

        private void RunTimer()
        {
            while (true)
            {
                this.timer++;

                if (this.timer % this.period == 0)
                {
                    this.ThresholdReached();
                }

                Thread.Sleep(SECOND);
            }
        }

        private void ThresholdReached()
        {
            if (this.TimeElapsed != null)
            {
                this.TimeElapsed(this.text);
            }
        }
    }
}
