namespace UsersAndGroups.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Group
    {
        public Group()
        {
        }

        public int GroupId { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}