namespace Telerik.Tests.Exceptions
{
    using System;

    public class ElementStillNotCheckedException : ApplicationException
    {
        public ElementStillNotCheckedException(string locator, string page)
            : base(string.Format("The element with locator: {0} on page: {1} is still not checked after timeout.", locator, page))
        {
        }
    }
}