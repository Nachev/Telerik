namespace UsersAndGroups.Data
{
    using System;
    using System.Linq;

    public class User
    {
        public User()
        {
        }

        public int UserId { get; set; }

        public string Name { get; set; }

        public int GroupId { get; set; }

        public virtual Group Group { get; set; }
    }
}