namespace QA.Framework.Core.Base
{
    using System.Threading;
    using ArtOfTest.WebAii.Core;

    public abstract class BasePage
    {
        public string Url { get; set; }

        public void NavigateTo()
        {
            Helpers.NavigateTo.Url(this.Url);
        }
    }
}
