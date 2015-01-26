namespace QA.Framework.Core.Base
{
    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.TestTemplates;

    public class BaseElementsMap : HtmlElementContainer
    {
        public BaseElementsMap()
            : base(Manager.Current.ActiveBrowser.Find)
        {
        }
    }
}