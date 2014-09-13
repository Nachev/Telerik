namespace UsersAndGroups.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class UsersAndGroupsModel : DbContext
    {
        public UsersAndGroupsModel()
            : base("name=UsersAndGroupsModel")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Group> Groups { get; set; }
    }
}