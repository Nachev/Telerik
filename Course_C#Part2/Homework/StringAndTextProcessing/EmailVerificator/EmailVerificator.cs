namespace EmailVerificator
{
    using System;
    using System.Text.RegularExpressions;

    /*Write a program for extracting all email addresses from given text. All substrings 
     * that match the format <identifier>@<host>…<domain> should be recognized as emails.*/

    public class EmailVerificator
    {
        private const string SampleText = "mylist@example.com - this is the email address people should use for new postings to the list. mylist-join@example.example.euro.com - by sending a message to this address, a new member can request subscription to the list. Both the Subject: header and body of such a message are ignored. Note that mylist-subscribe@example.com is an alias for the -join address.\n mylist-leave@[192.168.1.2].example.com - by sending a message to this address, a member can request unsubscription from the list. As with the -join address, the Subject: header and body of the message is ignored. Note that mylist-unsubscribe@example.com is an alias for the -leave address. mylist-owner@example-eu.com - This address reaches the list owner and list moderators directly. mylist-request@example.com - This address reaches a mail robot which processes email commands that can be used to set member subscription options, as well as process other commands.";

        private static void Main()
        {
            string inputText = SampleText;
            string regex = @"(\[([0-9]{1,3}\.){3}[0-9]{1,3}\.?\]([\.][a-zA-Z0-9]*)|[a-zA-Z0-9]+?[\-]?[a-zA-Z0-9]+)@(\[([0-9]{1,3}\.){3}[0-9]{1,3}\.?\]([\.][a-zA-Z0-9]*)*|[a-zA-Z0-9]+?[\-]?[a-zA-Z0-9]+([\.][a-zA-Z0-9]*)*)(\.[a-zA-z]+)";

            Match match = Regex.Match(inputText, regex);
            while (match.Success)
            {
                Console.WriteLine(match.Value);
                match = match.NextMatch();
            }
        }
    }
}
