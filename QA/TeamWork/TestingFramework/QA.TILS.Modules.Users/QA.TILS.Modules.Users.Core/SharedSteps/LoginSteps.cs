namespace QA.TILS.Modules.Users.Core.SharedSteps
{
    using QA.Framework.Core.Data;
    using QA.Framework.Core.Data.Templates;
    using QA.TILS.Modules.Users.Core.Pages.LoginPage;
    using ArtOfTest.WebAii.Core;

    public static class LoginSteps
    {
        static LoginSteps()
        {
            LoginPage = new LoginPage();
        }

        public static LoginPage LoginPage { get; set; }

        public static void LoginTestUser1()
        {
            LoginUser(TestUsers.TestUser1);
        }

        public static void LoginTestUser2()
        {
            LoginUser(TestUsers.TestUser2);
        }

        public static void LoginAdmin()
        {
            LoginUser(TestUsers.Admin);
        }

        private static void LoginUser(User user)
        {
            Manager.Current.ActiveBrowser.ClearCache(BrowserCacheType.Cookies);
            LoginPage.Login(user.Username, user.Password);
        }
    }
}
