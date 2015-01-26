namespace QA.TILS.Modules.Users.Core.Pages.LoginPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Extensions;

    public class LoginPageElements : BaseElementsMap
    {       

        public HtmlInputText UsernameField 
        {
            get
            {
                return this.Find.ById<HtmlInputText>("UsernameOrEmail");
            }
        }

        public HtmlInputPassword PasswordField
        {
            get
            {
                return this.Find.ById<HtmlInputPassword>("Password");
            }
        }

        public HtmlInputSubmit LoginButton
        {
            get
            {
                return this.Find.ByAttributes<HtmlInputSubmit>("generalButtonStyles normalButton greenButton".ToClassIsExpression());
            }
        }

        public HtmlAnchor ForgottenPasswordLink
        {
            get
            {
                return this.Find.ByAttributes<HtmlAnchor>("/Users/Auth/ForgottenPassword".ToLinkPointsToExpression());
            }
        }

        public HtmlDiv InvalidLoginErrorDiv
        {
            get
            {
                return this.Find.ByAttributes<HtmlDiv>("validation-summary-errors".ToClassIsExpression());
            }
        }
    }
}
