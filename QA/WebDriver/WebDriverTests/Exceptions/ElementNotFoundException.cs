namespace WebDriver.Tests.Exceptions
{
    using System;

    public class ElementNotFoundException : ApplicationException
    {
        public ElementNotFoundException(string locator, string page)
            : base(string.Format("There is no element with locator: {0} on page: {1}", locator, page))
        {
        }
    }
}
