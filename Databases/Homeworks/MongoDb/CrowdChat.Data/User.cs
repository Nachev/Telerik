namespace CrowdChat.Data
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System.Collections.Generic;

    public class User : IEntity
    {
        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("username")]
        public string Name { get; set; }

        [BsonElement("messages")]
        public IList<Message> Messages { get; set; }

        public User()
        {
            this.Messages = new List<Message>();
        }
    }
}
