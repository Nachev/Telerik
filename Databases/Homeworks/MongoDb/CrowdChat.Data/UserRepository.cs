﻿namespace CrowdChat.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserRepository : MongoRepository<User>
    {
        public UserRepository() 
            : base()
        {
        }
    }
}
