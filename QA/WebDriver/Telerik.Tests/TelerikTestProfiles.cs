namespace Telerik.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium.Firefox;
    using Telerik.Pages;
    using OpenQA.Selenium;
    using WebDriver.Extensions;

    [TestClass]
    public class TelerikTestProfiles : BaseTest
    {
        private const string BaseUrl = "http://www.telerik.com/";
        private ProfilePage profilePage;
        private LoginPage loginPage;
        private YourAccountPage yourAccountPage;

        [TestInitialize]
        public void TestInitialize()
        {
            var driver = new FirefoxDriver(new FirefoxProfile());
            base.BaseTestInitialize(driver, BaseUrl, 30);
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
        public void CheckCompanyNameMissingError()
        {
            /* Go to https://www.telerik.com/ and log in. */
            // Go to Telerik's site
            base.Driver.Navigate().GoToUrl(base.BaseUri);

            // Open login page
            var yourAccountButton = base.Driver.GetElement(By.Id("hlYourAccount"));
            yourAccountButton.Click();
            var loginHeader = base.Driver.GetElement(By.XPath("/html/body/form/div[3]/div/div/div[1]/div/span/h1"));
            if (loginHeader.Text.Contains("Telerik Login"))
            {
                /* Record a test to Edit your Profile. Fill the form as shown below, leave Company Name blank. 
                 * Verify that a message about missing Company name appears. */
                // Enter credentials
                this.loginPage.Login();
            }

            // Check if logged in correctly.
            var greeting = base.GetElementWithText(By.XPath("/html/body/form/div[3]/div/div/div[4]/div[1]/div/a/span"), "Hi, Asya");
            Assert.AreEqual("Hi, Asya", greeting.Text);

            // Save login cookie
            LoginPage.LoginCookies = base.Driver.Manage().Cookies.AllCookies;

            // Navigate to Profile page
            this.yourAccountPage.NavigateToEditProfile();
            base.GetElementWithText(By.XPath("//*[@id=\"content\"]/h2"), "Edit Profile");

            // Clear company name
            this.profilePage.EnterCompanyName(string.Empty);
            
            // Remove focus from company.
            this.profilePage.CountrySelectButton.Click();

            Assert.IsTrue(this.profilePage.CheckIfCompanyErrorIsVisible());

            /* Now fill in Company name using C# function, use unique name every time. 
             * Verify the message isn’t present anymore.*/
            // Fill in the company name
            this.profilePage.EnterRandomCompanyName();

            // Remove focus from company.
            this.profilePage.CountrySelectButton.Click();

            Assert.IsFalse(this.profilePage.CheckIfCompanyErrorIsVisible());
        }
    }
}
