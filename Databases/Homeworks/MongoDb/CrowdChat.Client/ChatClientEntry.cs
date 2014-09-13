namespace CrowdChat.Client
{
    using CrowdChat.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class ChatClientEntry
    {
        private static void Main(string[] args)
        {
            var userRepo = new UserRepository();
            var userClient = new UserClient(userRepo);
            userClient.LogIn("Pesho");
            userClient.Post("Az sam Pesho ida ot goritsa.");

            var allMessges = GetAllPosts(userRepo);
            foreach (var message in allMessges)
            {
                Console.WriteLine(message.Text + " - " + message.Date);
            }
        }

        private static IList<Message> GetAllPosts(UserRepository userRepo)
        {
            var users = userRepo.GetAllQueryable();
            IList<Message> allMessages = new List<Message>();

            foreach (var user in users)
            {
                var messages = user.Messages;
                allMessages = allMessages.Union(messages).ToList();
            }

            return allMessages;
        }
    }
}
