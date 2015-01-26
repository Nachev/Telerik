namespace QA.TILS.Modules.Users.Core.Pages.LoginPage
{
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Extensions;
    using QA.TILS.Modules.Users.Core.Pages.Common;

    public class LoginPageValidator : BasePageValidator
    {
        public LoggedUsersUpperNavigationElements UpperNavigation
        {
            get
            {
                return new LoggedUsersUpperNavigationElements();
            }
        }

        public LoginPage LoginPage
        {
            get
            {
                return new LoginPage();
            }
        }

        public void VerifySuccessfullLogin(string expectedUsername)
        {
            this.UpperNavigation.LoggedUserUsernameSpan.Wait.ForExists();

            this.UpperNavigation.LoggedUserUsernameSpan.AssertTextEquals(expectedUsername);
        }

        public void VerifyErrorMessageOnInvalidLogin()
        {

        }
    }
}
