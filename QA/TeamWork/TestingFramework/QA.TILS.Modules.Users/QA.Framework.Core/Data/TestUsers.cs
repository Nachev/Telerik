namespace QA.Framework.Core.Data
{
    using Templates;

    public static class TestUsers
    {
        static TestUsers()
        {
            TestUser1 = new User 
            {
                Username = "usersModuleFrontTest",
                Password = "123456",
                ProfileUrl = "http://test.telerikacademy.com/Users/usersModuleFrontTest"
            };

            TestUser2 = new User
            {
                Username = "usersModuleFrontTest2",
                Password = "123456",
                ProfileUrl = "http://test.telerikacademy.com/Users/usersModuleFrontTest2"
            };

            Admin = new User
            {
                Username = "administrator",
                Password = "adminpassword"
            };

            NotExistingUser = new User
            {
                Username = "IDoNotExist"
            };
        }

        /// <summary>
        /// For test purposes valid user already registered in the database
        /// </summary>
        public static User TestUser1 { get; set; }

        /// <summary>
        /// For test purposes valid user already registered in the database
        /// </summary>
        public static User TestUser2 { get; set; }

        /// <summary>
        /// For test purposes valid user with admin access already registered in the database
        /// </summary>
        public static User Admin { get; set; }

        /// <summary>
        /// For test purposes with invalid usernames.
        /// </summary>
        public static User NotExistingUser { get; set; }
    }
}