namespace MobilePhone
{
    using System;
    using System.Text;

    public class Call
    {
        private string dialedNumber;
        private TimeSpan callDuration;
        private DateTime callDateTime;

        public Call(DateTime callStart, string dialedNumber, int callDuration)
        {
            this.CallDateTime = callStart;
            this.DialedNumber = dialedNumber;
            this.CallDuration = callDuration;
        }

        public string DialedNumber
        {
            get 
            { 
                return this.dialedNumber; 
            }

            private set 
            {
                foreach (var digit in value)
                {
                    if (!(char.IsDigit(digit) || digit == '+' || digit == ' '))
                    {
                        throw new ArgumentOutOfRangeException("Incorrect phone number!");
                    }
                }

                this.dialedNumber = value; 
            }
        }

        public int CallDuration
        {
            get 
            {
                int result = new int();
                if (this.callDuration.Hours > 0)
                {
                    result += this.callDuration.Hours * 3600;
                }

                if (this.callDuration.Minutes > 0)
                {
                    result += this.callDuration.Minutes * 60;
                }

                result += this.callDuration.Seconds;
                return result;
            }

            private set 
            {
                int temp = new int();
                if (int.TryParse(value.ToString(), out temp))
                {
                    this.callDuration = new TimeSpan(0, 0, temp); 
                }
                else
                {
                    throw new ArgumentException("Incorrect call duration!");
                }
            }
        }

        public DateTime CallDateTime
        {
            get 
            {
                return this.callDateTime; 
            }

            private set 
            {
                if (DateTime.TryParse(value.ToString(), out value))
                {
                this.callDateTime = value; 
                }
                else
                {
                    throw new ArgumentException("Incorrect call date or time!");
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Date: ");
            result.Append(this.CallDateTime.ToShortDateString());
            result.Append(" | ");
            result.Append("Time: ");
            result.Append(this.CallDateTime.ToLongTimeString());
            result.Append(" | ");
            result.Append("Number: ");
            result.Append(this.DialedNumber);
            result.Append(" | ");
            result.Append("Duration: ");
            result.Append(this.CallDuration).Append(" sec.");
            return result.ToString();
        }
    }
}
