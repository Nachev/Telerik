namespace Telerik.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium.Firefox;
    using Telerik.Pages;
    using OpenQA.Selenium;
    using WebDriver.Extensions;

    [TestClass]
    public class TelerikTestProfilesWithoutJS : BaseTest
    {
        private const string BaseUrl = "http://www.telerik.com/";
        private ProfilePage profilePage;
        private LoginPage loginPage;
        private YourAccountPage yourAccountPage;
        private FirefoxProfile profile;

        [TestInitialize]
        public void TestInitialize()
        {
            this.profile = new FirefoxProfile();
            this.profile.SetPreference("javascript.enabled", false);
            var driver = new FirefoxDriver(profile);
            base.BaseTestInitialize(driver, BaseUrl, 20);
            this.loginPage = new LoginPage(driver);
            this.profilePage = new ProfilePage(driver);
            this.yourAccountPage = new YourAccountPage(driver);
        }

        [TestCleanup]
        public void Cleanup()
        {
            base.Driver.Quit();
        }

        [TestMethod]
        public void CheckBackendErrorMessages()
        {
            // Go to Telerik's site
            base.Driver.Navigate().GoToUrl(base.BaseUri);

            // HACK: Using login cookies from previous login, because login without JavaScript is not possible.
            foreach (var cookie in LoginPage.LoginCookies)
            {
                base.Driver.Manage().Cookies.AddCookie(cookie);
            } 

            /* Go to https://www.telerik.com/ and log in. */
            // Open login page
            var yourAccountButton = base.Driver.GetElement(By.Id("hlYourAccount"));
            yourAccountButton.Click();

            var pageTitle = base.Driver.Title;
            if (pageTitle == "Telerik Client Login")
            {
                /* Record a test to Edit your Profile. Fill the form as shown below, leave Company Name blank. 
                 * Verify that a message about missing Company name appears. */
                // Enter credentials
                this.loginPage.Login();

                // Check if No Robot Sign appears
                bool isNoBotVisible = this.loginPage.NoRobotMeassgeVilible();
                Assert.IsTrue(isNoBotVisible);
            }
            else
            {
                base.WaitForElementPresent(By.Id("ctl00_ctl00_GeneralBox_Sidebar_usercontrols_public_unitedaccount_client_shortprofile_ascx1_lblNickName"));
                // Navigate to Profile page
                this.Driver.Navigate().GoToUrl("https://www.telerik.com/account/profile.aspx");
                base.GetElementWithText(By.XPath("//*[@id=\"content\"]/h2"), "Edit Profile");

                // Enter invalid parameters
                this.profilePage.EnterInvalidParameters();

                // Check Error message
                bool backendErrorsPresent = this.profilePage.CheckBackEndErrors();
                bool companyError = this.profilePage.CheckIfCompanyErrorIsVisible();

                Assert.IsTrue(backendErrorsPresent);
            }
        }
    }
}
