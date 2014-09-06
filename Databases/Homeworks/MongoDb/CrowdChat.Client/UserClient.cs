namespace CrowdChat.Client
{
    using System;
    using System.Linq;

    using CrowdChat.Data;

    internal class UserClient
    {
        private User currentUser;
        private IMongoRepository<User> dbRepo;

        public UserClient(IMongoRepository<User> dbRepo)
        {
            this.dbRepo = dbRepo;
        }

        public bool LogIn(string userName)
        {
            var user = this.dbRepo.Find(d => d.Name == userName).FirstOrDefault();
            bool result = true;

            if (user == null)
            {
                user = new User()
                {
                    Name = userName
                };

                result = this.dbRepo.Insert(user);
            }

            this.currentUser = user;

            return result;
        }

        public bool Post(string messageText)
        {
            var currentMessge = new Message() {
                 Text = messageText,
                 Date = DateTime.UtcNow
            };

            this.currentUser.Messages.Add(currentMessge);
            var result = this.dbRepo.Update(this.currentUser);
            return result;
        }
    }
}
