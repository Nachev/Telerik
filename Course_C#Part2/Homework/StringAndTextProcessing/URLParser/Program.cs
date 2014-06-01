namespace URLParser
{
    using System;

    /*Write a program that parses an URL address given in the format:
     * [protocol]://[server]/[resource]
     * and extracts from it the [protocol], [server] and [resource] elements.*/

    public class URLParser
    {
        private const string SampleUrl = "http://www.devbg.org/forum/index.php";

        private static void Main()
        {
            Uri url = new Uri(SampleUrl);

            Console.WriteLine("[protocol] = \"{0}\"", url.Scheme);
            Console.WriteLine("[server] = \"{0}\"", url.Host);
            Console.WriteLine("[resource] = \"{0}\"", url.LocalPath);
        }
    }
}
