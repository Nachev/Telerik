namespace QA.TILS.Modules.Users.Core.Pages.Common
{
    using ArtOfTest.WebAii.Controls.HtmlControls;

    using QA.Framework.Core.Base;

    public class NotLoggedUpperNavigationElements : BaseElementsMap
    {
        public HtmlAnchor LoginButton
        {
            get
            {
                return this.Find.ById<HtmlAnchor>("LoginButton");
            }
        }

        public HtmlAnchor SignUpButton
        {
            get
            {
                return this.Find.ById<HtmlAnchor>("SignUpButton");
            }
        }

        public HtmlAnchor FacebookLoginButton
        {
            get
            {
                return this.Find.ById<HtmlAnchor>("FbLogin");
            }
        }
    }
}
