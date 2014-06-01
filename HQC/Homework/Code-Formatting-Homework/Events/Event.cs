using System;
using System.Collections.Generic;
using System.Linq;
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
        Event other = obj as Event;
        int byDate = this.date.CompareTo(other.date);
        int byTitle = this.title.CompareTo(other.title);
        int byLocation = this.location.CompareTo(other.location);
        if (byDate == 0)
        {
            if (byTitle == 0)
            {
                return byLocation;
            }
            else
            {
                return byTitle;
            }
        }
        else
        {
            return byDate;
        }
    }

    public override string ToString()
    {
        StringBuilder toString = new StringBuilder();
        string separator = " | ";
        string dateFormat = "yyyy-MM-ddTHH:mm:ss";
        toString.Append(this.date.ToString(dateFormat));
        toString.Append(separator + this.title);
        if (!string.IsNullOrEmpty(this.location))
        {
            toString.Append(separator + this.location);
        }

        return toString.ToString();
    }
}