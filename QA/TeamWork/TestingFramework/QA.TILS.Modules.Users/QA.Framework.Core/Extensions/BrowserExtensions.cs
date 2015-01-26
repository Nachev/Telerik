namespace QA.Framework.Core.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.Controls;

    public static class BrowserExtensions
    {
        public static void WaitForElement(this Browser browser, HtmlControl element, int timeout)
        {
            browser.WaitForEvent(() => element != null, timeout);
        }

        public static void WaitForEvent(this Browser browser, Func<bool> predicate, int timeOut)
        {
            var start = DateTime.Now;
            while (true)
            {
                if (predicate())
                {
                    break;
                }

                if ((DateTime.Now - start).TotalSeconds > timeOut)
                {
                    throw new TimeoutException("Timed out waiting for condition!");
                }

                Thread.Sleep(100);
            }
        }
    }
}
