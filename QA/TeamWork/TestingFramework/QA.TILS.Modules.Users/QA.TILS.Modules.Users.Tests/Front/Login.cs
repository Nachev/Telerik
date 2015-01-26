namespace QA.TILS.Modules.Users.Tests.Functional.Front
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Data;
    using QA.TILS.Modules.Users.Core.Pages.LoginPage;

    [TestClass]
    public class Login : BaseTest
    {
        private LoginPage loginPage;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            BaseClassInitialize();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            BaseClassCleanup();
        }

        public override void TestInitialize()
        {
            this.loginPage = new LoginPage();
        }

        [TestMethod]
        [Priority(1)]
        public void LoginWithBlankCredentials_ShouldFail()
        {
            this.loginPage.Login("", "");

            this.loginPage.Validator.VerifyErrorMessageOnInvalidLogin();
        }

        [TestMethod]
        [Priority(1)]
        public void LoginWithValidUsernameAndInvalidPassword_ShouldFail()
        {
            this.loginPage.Login(TestUsers.TestUser1.Username, "invalidPassword");

            this.loginPage.Validator.VerifyErrorMessageOnInvalidLogin();
        }

        [TestMethod]
        [Priority(1)]
        public void LoginWithValidCredentials_ShouldBeSuccessfull()
        {
            this.loginPage.Login(TestUsers.TestUser1);

            this.loginPage.Validator.VerifySuccessfullLogin(TestUsers.TestUser1.Username);
        }
    }
}
