using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using Random.Pages;
using OpenQA.Selenium;

namespace Random.Tests
{
    [TestClass]
    public class TestRandomGenerator
    {
        private const string StartUrl = "http://www.random.org/integers/";

        private IWebDriver browser;
        private IntegersGeneratorPage intGeneratorPage;
        private ResultPage resultPage;
        private HomePage homePage;
        
        [TestInitialize]
        public void TestInitialize()
        {
            var firefoxProfile = new FirefoxProfile();
            this.browser = new FirefoxDriver(firefoxProfile);
            this.intGeneratorPage = new IntegersGeneratorPage();
            this.resultPage = new ResultPage();
            this.homePage = new HomePage();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.browser.Quit();
        }

        [TestMethod]
        public void TestTaskWithCondition()
        {
            this.browser.Navigate().GoToUrl(StartUrl);
            this.intGeneratorPage.GenerateRandomNumber(browser, 1, 1, 2);
            int randomResult = this.resultPage.GetResult(browser);
            if (randomResult == 1)
            {
                this.homePage.NabigateToFaq(browser);
                Assert.IsTrue(this.browser.Title.Contains("Frequently Asked Questions"));
            }

            this.homePage.NavigateToHome(browser);
            Assert.IsTrue(this.browser.Title.Contains("True Random Number Service"));
        }
    }
}
