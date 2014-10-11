namespace Telerik.Tests.Exceptions
{
    using System;

    public class ElementStillPresentException : ApplicationException
    {
        public ElementStillPresentException(string locator, string page)
            : base(string.Format("The element with locator: {0} on page: {1} is still visible after timeout.", locator, page))
        {
        }
    }
}
