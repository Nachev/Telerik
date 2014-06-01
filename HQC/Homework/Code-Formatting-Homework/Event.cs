namespace Events
{
    using System;
    using System.Text;

    public class Event : IComparable
    {
        private DateTime date;
        private string title;
        private string location;

        public Event(DateTime date, string title, string location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public string Location
        {
            get
            {
                return this.location;
            }

            set
            {
                this.location = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                this.title = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }

            set
            {
                this.date = value;
            }
        }

        public int CompareTo(object obj)
        {
            var target = obj as Event;
            int byDate = this.date.CompareTo(target.date);
            int byTitle = this.title.CompareTo(target.title);
            int byLocation = this.location.CompareTo(target.location);
            if (byDate != 0)
            {
                return byDate;
            }
            else if (byTitle != 0)
            {
                return byTitle;
            }
            else
            {
                return byLocation;
            }
        }

        public override string ToString()
        {
            string separator = " | ";
            string dateFormat = "yyyy-MM-ddTHH:mm:ss";

            StringBuilder output = new StringBuilder();
            output.Append(this.date.ToString(dateFormat));
            output.Append(separator + this.title);
            if (!string.IsNullOrEmpty(this.location))
            {
                output.Append(separator + this.location);
            }

            return output.ToString();
        }
    }
}