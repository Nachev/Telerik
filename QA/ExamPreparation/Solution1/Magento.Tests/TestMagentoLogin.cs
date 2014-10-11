using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Magento.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Magento.Tests
{
    [TestClass]
    public class TestMagentoLogin
    {
        private const string BaseUrl = "http://demo.nostresscommerce.cz/";

        private IWebDriver driver;
        private HomePage homePage;
        private LoginPage loginPage;

        [TestInitialize]
        public void TestInitialize()
        {
            this.driver = new FirefoxDriver();
            this.homePage = new HomePage();
            this.loginPage = new LoginPage();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            this.driver.Quit();
        }

        [TestMethod]
        public void LoginWithIncorrectCredentialsShouldResultAnError()
        {
            this.driver.Navigate().GoToUrl(BaseUrl);
            this.homePage.NavigateToMyAccount(this.driver);
            this.loginPage.LogIn(driver, "test@email.com", "123456");
            var wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(30));
            var warningMessage = wait.Until<IWebElement>((d) => 
            { 
                return d.FindElement(By.XPath("/html/body/div[1]/div/div[3]/div/div/div/ul/li/ul/li/span")); 
            });
            Assert.AreEqual("Invalid login or password.", warningMessage.Text, "No warning message present.");
        }

        [TestMethod]
        public void LoginWithoutCredentialsShouldResultAnRemainders()
        {
            this.driver.Navigate().GoToUrl(BaseUrl);
            this.homePage.NavigateToMyAccount(this.driver);
            this.loginPage.LogIn(driver, string.Empty, string.Empty);
            var wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(30));
            var remainderMessagesVisible = this.loginPage.AreWarningsVisible();
            Assert.IsTrue(remainderMessagesVisible, "Remainders are not visible.");
        }
    }
}
