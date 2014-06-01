namespace MobilePhone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GSM
    {
        private static GSM iPhone4S = new GSM("Iphone 4S", "Apple", "Built-In", BatteryType.LiPoly, 14, 200, 3.5, 16000000, 450);

        private decimal price;
        private string owner;
        private Battery battery;
        private Display display;
        private List<Call> callHistory = new List<Call>();

        public GSM(
            string model,
            string manufacturer,
            string batteryModel = null,
            BatteryType? batteryType = null,
            int? batHoursTalk = null,
            int? batHoursIdle = null,
            double? screenDiagonal = null,
            int? numberOfColors = null,
            decimal? price = null,
            string owner = null)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.battery = new Battery(batteryModel, batteryType, batHoursTalk, batHoursIdle);
            this.display = new Display(screenDiagonal, numberOfColors);
            this.Price = price;
            this.Owner = owner;
        }

        public GSM(string model, string manufacturer, string batteryModel, double screenDiagonal)
            : this(model, manufacturer, batteryModel, null, null, null, screenDiagonal)
        {
        }

        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            private set
            {
                this.owner = value;
            }
        }

        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }
        }

        private string Model { get; set; }

        private string Manufacturer { get; set; }

        private decimal? Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value == null)
                {
                    this.price = 0M;
                }
                else if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price have to be positive number");
                }
                else
                {
                    this.price = (decimal)value;
                }
            }
        }

        public void CallHistoryAdd(Call currentCall)
        {
            this.callHistory.Add(currentCall);
        }

        public void CallHistoryDelAt(int posiiton)
        {
            this.callHistory.RemoveAt(posiiton - 1);
        }

        public void CallHistoryDeleteLast()
        {
            this.callHistory.RemoveAt(this.callHistory.Count - 1);
        }

        public void CallHistoryClear()
        {
            this.callHistory.Clear();
        }

        public int PositionOfLongestCall()
        {
            return this.callHistory.IndexOf(this.callHistory.Aggregate((agg, next) => next.CallDuration > agg.CallDuration ? next : agg)) + 1;
        }

        public decimal TotalPrice(decimal pricePerMinute)
        {
            decimal time = new decimal();
            foreach (var item in this.callHistory)
            {
                time += item.CallDuration / 60M;
            }

            return time * pricePerMinute;
        }

        public void GetPrice()
        {
            Console.WriteLine("This GSM costs: {0:C}", this.Price);
        }

        public string CallHistoryToString()
        {
            if (this.callHistory.Count == 0)
            {
                return "History is empty.";
            }

            StringBuilder result = new StringBuilder();
            result.AppendLine("History log: ");
            for (int count = 0; count < this.callHistory.Count; count++)
            {
                result.Append(count + 1).Append(' ');
                result.Append(this.callHistory[count].ToString());
                result.AppendLine();
            }

            return result.ToString();
        }

        public override string ToString()
        {
            StringBuilder tostr = new StringBuilder();
            tostr.Append(new string('*', Console.WindowWidth));
            tostr.Append("Manufacturer: ");
            tostr.Append(this.Manufacturer);
            tostr.Append(" ");
            tostr.Append("Model: ");
            tostr.Append(this.Model);
            tostr.Append(" ");
            if (this.price > 0)
            {
                tostr.Append("Price: ");
                tostr.Append(this.Price);
                tostr.Append(" ");
            }

            if (this.Owner != null)
            {
                tostr.Append("Owner: ");
                tostr.Append(this.Owner);
                tostr.Append(" ");
            }

            if (this.battery.ToString().Length > 0)
            {
                tostr.AppendLine();
                tostr.Append(this.battery.ToString());
            }

            if (this.display.ToString().Length > 0)
            {
                tostr.AppendLine();
                tostr.Append(this.display.ToString());
            }

            tostr.AppendLine();
            tostr.Append(new string('*', Console.WindowWidth));
            return tostr.ToString();
        }
    }
}