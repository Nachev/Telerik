namespace Telerik.Tests.Exceptions
{
    using System;

    public class TextNotFoundException : ApplicationException
    {
        public TextNotFoundException(string page, string text)            
            : base(string.Format("The text: {0} is not found on page: {1}", text, page))
        {
        }
    }
}
