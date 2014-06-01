namespace HTMLTagReplacement
{
    using System;
    using System.Text.RegularExpressions;

    /*Write a program that replaces in a HTML document given as string all the 
     * tags <a href="…">…</a> with corresponding tags [URL=…]…/URL].*/

    public class HTMLTagReplacement
    {
        private const string SampleHTML = "<p>Please visit <a href=\"http://academy.telerik. com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";
 
        private static void Main()
        {
            string inputHtml = SampleHTML;
            string replacePattern = @"<\s*a\s+\bhref\b=""(?<url>[^""]+)"">(?<content>(.|\s)*?)</a>"; 
            string replacement = @"[URL=${url}]${content}[/URL]";
            string result = Regex.Replace(inputHtml, replacePattern, replacement);
            Console.WriteLine(result);
        }
    }
}
