using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using BugTracker.Pages;
using OpenQA.Selenium.Support.UI;

namespace BugTracker.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private const string StartUrl = "http://ifdefined.com/btnet/bugs.aspx";
        private IWebDriver browser;

        private BugsPage bugsPage;
        private FoundBugPage foundBugPage;

        [TestInitialize]
        public void TestInitialize()
        {
            this.browser = new FirefoxDriver();
            this.bugsPage = new BugsPage();
            this.foundBugPage = new FoundBugPage();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.browser.Quit();
        }

        [TestMethod]
        public void TestSearchForNonExistingBug()
        {
            this.browser.Navigate().GoToUrl(StartUrl);
            this.bugsPage.FindUnexistig(this.browser);
            WebDriverWait wait = new WebDriverWait(this.browser, TimeSpan.FromSeconds(30));
            wait.Until<IWebElement>((d) => { return d.FindElement(By.XPath("/html/body/div/p/a")); });
            bool testResult = this.foundBugPage.CheckIfErrorPresent(this.browser);
            Assert.IsTrue(testResult);
        }

        [TestMethod]
        public void TestAddNewBugWithProjectSpecificOption()
        {
            this.browser.Navigate().GoToUrl(StartUrl);
            this.bugsPage.GoToAddNewBugPage(this.browser);
            WebDriverWait wait = new WebDriverWait(this.browser, TimeSpan.FromSeconds(30));
            wait.Until<bool>((d) => { return d.Title.Contains("BugTracker.NET - Create Bug"); });
            var bugDescription = this.browser.FindElement(By.Id("short_desc"));

            var projectSelector = this.browser.FindElement(By.Id("project"));
            SelectElement projectSelect = new SelectElement(projectSelector);
            projectSelect.SelectByText("HasCustomFieldsProject");

            var anotherSampleCustomFieldSelector = this.browser.FindElement(By.Id("Anothersamplecustomfield"));
            SelectElement anotherSampleCustomFieldSelect = new SelectElement(anotherSampleCustomFieldSelector);
            anotherSampleCustomFieldSelect.SelectByText("red");

            var projectSpecificSelector = this.browser.FindElement(By.Id("Anothersamplecustomfield"));
            SelectElement projectSpecificSelect = new SelectElement(projectSpecificSelector);
            projectSpecificSelect.SelectByText("green");
        }
    }
}
