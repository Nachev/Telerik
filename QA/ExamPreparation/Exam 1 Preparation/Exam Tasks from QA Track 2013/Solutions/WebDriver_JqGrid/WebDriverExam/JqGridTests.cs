using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using OpenQA.Selenium.Firefox;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Support.UI;

namespace WebDriverExam
{

    [TestClass]
    public class JqGridTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private WebDriverWait GlobaWait { get; set; }

        [TestInitialize]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://www.trirand.net/";
            verificationErrors = new StringBuilder();
            this.GlobaWait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(20));

            driver.Navigate().GoToUrl(baseURL + "/demoaspnet.aspx");
            driver.FindElement(By.LinkText("Hierarchy")).Click();

            string subGrid2Locator = "Sub Grid (2 nested levels)";
            GlobaWait.Until(d => d.FindElements(By.LinkText(subGrid2Locator)).Any());
            driver.FindElement(By.LinkText(subGrid2Locator)).Click();

            string demoFrameLocator = "demoFrame";
            GlobaWait.Until(d => d.FindElements(By.Id(demoFrameLocator)).Any());
            driver.SwitchTo().Frame(demoFrameLocator);
        }


        [TestCleanup]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (AssertFailedException)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestMethod]
        public void VerifyTableHeaders()
        {
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*ID[\\s\\S]*$")) break;
                }
                catch (AssertFailedException)
                { }
                Thread.Sleep(1000);
            }

            string customerIdLocator = "jqgh_JQGrid1_CustomerID";
            try
            {
                Assert.AreEqual("ID", driver.FindElement(By.Id(customerIdLocator)).Text);
            }

            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }

            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*CompanyName[\\s\\S]*$")) break;
                }
                catch (AssertFailedException e)
                {
                    verificationErrors.Append(e.Message);
                }
                Thread.Sleep(1000);
            }

            string companyNameLocator = "jqgh_JQGrid1_CompanyName";
            try
            {
                Assert.AreEqual("CompanyName", driver.FindElement(By.Id(companyNameLocator)).Text);
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }

            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*ContactName[\\s\\S]*$")) break;
                }
                catch (AssertFailedException e)
                {
                    verificationErrors.Append(e.Message);
                }
                Thread.Sleep(1000);
            }

            string contactNameLocator = "jqgh_JQGrid1_ContactName";
            try
            {
                Assert.AreEqual("ContactName", driver.FindElement(By.Id(contactNameLocator)).Text);
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }

            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Phone[\\s\\S]*$")) break;
                }
                catch (AssertFailedException)
                { }
                Thread.Sleep(1000);
            }

            string phoneLocator = "jqgh_JQGrid1_Phone";
            try
            {
                Assert.AreEqual("Phone", driver.FindElement(By.Id(phoneLocator)).Text);
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }

            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*City[\\s\\S]*$")) break;
                }
                catch (AssertFailedException)
                { }
                Thread.Sleep(1000);
            }

            string cityLocator = "jqgh_JQGrid1_City";
            try
            {
                Assert.AreEqual("City", driver.FindElement(By.Id(cityLocator)).Text);
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [TestMethod]
        public void VerifyTableContent()
        {
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*ID[\\s\\S]*$")) break;
                }
                catch (AssertFailedException)
                { }
                Thread.Sleep(1000);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("//tr[@id='ANTON']/td[2]")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }

            string secondColumnContent = driver.FindElement(By.XPath("//tr[@id='ANTON']/td[2]")).Text;
            try
            {
                Assert.AreEqual("ANTON", secondColumnContent);
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }

            string companyName = driver.FindElement(By.XPath("//tr[@id='ANTON']/td[3]")).Text;

            driver.FindElement(By.XPath("//tr[@id='ANTON']/td[1]/a/span[@class='ui-icon ui-icon-plus']")).Click();

            string innerTablelLocator = "10365";
            GlobaWait.Until(d => d.FindElements(By.Id(innerTablelLocator)).Any());

            IWebElement innerTable = driver.FindElement(By.Id("10365"));
            string shipName = innerTable.FindElement(By.CssSelector("td[aria-describedby='JQGrid1_ANTON_t_ShipName']")).Text;

            try
            {
                Assert.AreEqual(companyName, shipName);
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [TestMethod]
        public void VerifyPaging()
        {

            string rowCountSelectRootLocator = "ui-pg-selbox";
            GlobaWait.Until(d => d.FindElements(By.ClassName(rowCountSelectRootLocator)).Any());

            IWebElement rowCountSelectRoot = this.driver.FindElement(By.ClassName(rowCountSelectRootLocator));
            SelectElement rowCountSelect = new SelectElement(rowCountSelectRoot);
            IList<IWebElement> availableOptions = rowCountSelect.Options;

            foreach (IWebElement currentOption in availableOptions)
            {
                int currentValue = int.Parse(currentOption.GetAttribute("value"));
                rowCountSelect.SelectByValue(currentValue.ToString());

                System.Threading.Thread.Sleep(3000);

                IWebElement tableRoot = this.driver.FindElement(By.Id("JQGrid1"));
                IEnumerable<IWebElement> tableRows = tableRoot.FindElements(By.CssSelector("tr[class~='ui-widget-content']"));
                int tableRowsRecordsCount = tableRows.Count();
                Assert.AreEqual(currentValue, tableRowsRecordsCount);
            }
        }


        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}

