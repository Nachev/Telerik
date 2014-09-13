namespace CrowdChat.Data
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;

    public class Message : IComparable<Message>
    {
        [BsonElement("text")]
        public string Text { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; }

        public int CompareTo(Message other)
        {
            return this.Date.CompareTo(other.Date);
        }
    }
}