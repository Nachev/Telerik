namespace HtmlBodyExtractor
{
    using System;
    using System.Text.RegularExpressions;

    /*Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags.*/

    public class HtmlBodyExtractor
    {
        private const string SampleHtml = "<html>\n" +
            "<head><title>News</title></head>\n" +
            "<body><p><a href=\"http://academy.telerik.com\">Telerik\n" +
            "Academy</a>aims to provide free real-world practical\n" +
            "training for young people who want to turn into\n" +
            "skillful .NET software engineers.</p></body>\n" +
            "</html>";

        private static void Main()
        {
            string inputHtml = SampleHtml;
            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Singleline;
            ExtractTitle(inputHtml, options);
            ExtractBody(inputHtml, options);
        }

        private static void ExtractBody(string inputHtml, RegexOptions options)
        {
            string regex = @"(?<=<\s*body\s*>)(?<body>.*?)(?=<\s*/body\s*>)";
            Match match = Regex.Match(inputHtml, regex, options);
            string splitPattern = @"\<.*?\>";
            string[] body = Regex.Split(match.ToString(), splitPattern, options);
            foreach (var element in body)
            {
                if (element != string.Empty)
                {
                    Console.WriteLine(element);
                }
            }
        }

        private static void ExtractTitle(string inputHtml, RegexOptions options)
        {
            string regex = @"(?<=<\s*title\s*>)(?<title>\w+)(?=<\s*/title\s*>)";
            Match match = Regex.Match(inputHtml, regex, options);
            if (match.Success)
            {
                Console.WriteLine(match);
            }
        }
    }
}
