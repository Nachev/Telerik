namespace WebDriver.Tests.Exceptions
{
    using System;

    public class TextNotFoundAtLocationException : ApplicationException
    {
        public TextNotFoundAtLocationException(string page, string location, string text)
            : base(string.Format("The text: {0} is not found at element: {1} at page: {2}", text, location, page))
        {
        }
    }
}
