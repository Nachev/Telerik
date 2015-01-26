namespace QA.Framework.Core.Helpers
{
    using ArtOfTest.WebAii.Core;
    using QA.Framework.Core.Base;

    public static class NavigateTo
    {
        public static void Url(string url)
        {
            Manager.Current.ActiveBrowser.NavigateTo(url);
        }

        public static void Page(BasePage page)
        {
            Url(page.Url);
        }
    }
}
