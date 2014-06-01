namespace MobilePhone
{
    using System;
    using System.Text;

    public enum BatteryType
    {
        LiIon, NiMH, NiCd, LiPoly
    }

    public class Battery
    {
        private TimeSpan hoursIdle;
        private TimeSpan hoursTalk;
        private BatteryType? battType;

        public Battery(string model = null, BatteryType? battType = null, int? hoursTalk = null, int? hoursIdle = null)
        {
            this.Model = model;
            this.BattType = battType;
            this.HoursTalk = hoursTalk;
            this.HoursIdle = hoursIdle;
        }

        private string Model { get; set; }

        private BatteryType? BattType
        {
            get
            {
                return this.battType;
            }

            set
            {
                this.battType = value;
            }
        }

        private int? HoursIdle
        {
            get 
            {
                if (this.hoursIdle.Days > 0)
                {
                    return (this.hoursIdle.Days * 24) + this.hoursIdle.Hours;
                }

                return this.hoursIdle.Hours; 
            }

            set 
            {
                TimeSpan temp;
                if (value == null)
                {
                    temp = new TimeSpan(0, 0, 0);
                }
                else if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Idle hours have to be positive");
                }
                else
                {
                    temp = new TimeSpan((int)value, 0, 0);
                }

                this.hoursIdle = temp;
            }
        }

        private int? HoursTalk
        {
            get
            {
                if (this.hoursTalk.Days > 0)
                {
                    return (this.hoursTalk.Days * 24) + this.hoursTalk.Hours;
                }

                return this.hoursTalk.Hours;
            }

            set
            {
                TimeSpan temp;
                if (value == null)
                {
                    temp = new TimeSpan(0, 0, 0);
                }
                else if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Talk hours have to be positive");
                }
                else
                {
                    temp = new TimeSpan((int)value, 0, 0);
                }

                this.hoursTalk = temp;
            }
        }

        public override string ToString()
        {
            StringBuilder toStr = new StringBuilder();
            if (this.Model != null)
            {
                toStr.Append("Battery model: ");
                toStr.Append(this.Model);
                toStr.Append(" ");
            }

            if (this.battType != null)
            {
                toStr.Append("Battery type: ");
                toStr.Append(this.battType);
                toStr.Append(" ");
            }

            if (this.hoursIdle.Hours != 0)
            {
                toStr.Append("Hours idle: ");
                toStr.Append(this.HoursIdle);
                toStr.Append(" ");
            }

            if (this.hoursTalk.Hours != 0)
            {
                toStr.Append("Hours talk: ");
                toStr.Append(this.HoursTalk);
                toStr.Append(" ");
            }

            return toStr.ToString();
        }
    }
}
