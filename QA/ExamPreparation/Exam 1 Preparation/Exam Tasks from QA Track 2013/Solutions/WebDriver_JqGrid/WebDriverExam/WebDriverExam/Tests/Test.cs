using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverExam.Tests
{
    [TestFixture]
    class SeleniumTest
    {
        IWebDriver Driver { get; set; }
        public const int GlobalWait = 2000;

        public SeleniumTest()
        { }

        [SetUp]
        public void StartDriver()
        {
            this.Driver = new FirefoxDriver();
        }

        [TestCase("",0)]
        [TestCase("ID",1)]
        [TestCase("CompanyName",2)]
        [TestCase("ContactName",3)]
        [TestCase("Phone",4)]      
        [TestCase("City",5)]
        public void SampleTest(string expectedHeaderRowName, int Index)
        {
            this.Driver.Navigate().GoToUrl(@"http://www.trirand.net/demoaspnet.aspx");

            IWebElement navigateButton = this.Driver.FindElement(By.Id("ui-accordion-accordion-header-8"));
            navigateButton.Click();


            IWebElement nested2Button = this.Driver.FindElement(By.LinkText("Sub Grid (2 nested levels)"));
            nested2Button.Click();
            System.Threading.Thread.Sleep(10000);

            IWebElement headerRoot = this.Driver.FindElement(By.Id("JQGrid1"));
            IWebElement[] headerCells = headerRoot.FindElements(By.TagName("th")).ToArray();
            string currentHeaderCellText = headerCells[Index].Text;

            Assert.AreEqual(expectedHeaderRowName, currentHeaderCellText);

            System.Threading.Thread.Sleep(1000);
        }

        [Test]
        public void YahooTest()
        {
            this.Driver.Navigate().GoToUrl(@"http://www.yahoo.com/");

            IWebElement mailButton = this.Driver.FindElement(By.LinkText("Mail"));
            mailButton.Click();

            IWebElement userNameTextBox = this.Driver.FindElement(By.Id("username"));
            userNameTextBox.SendKeys("franzfischbach@yahoo.com");

            IWebElement passwdTextbox = this.Driver.FindElement(By.Id("passwd"));
            passwdTextbox.SendKeys("123qweASDzxcfasdffgh");

            IWebElement loginButton = this.Driver.FindElement(By.Id(".save"));
            loginButton.Click();

            System.Threading.Thread.Sleep(5000);

            IWebElement kompotButton = this.Driver.FindElement(By.LinkText("Compose"));
            kompotButton.Click();

            for (int attempt = 0; attempt * 1000 < GlobalWait; attempt++)
            {
                if (this.Driver.FindElements(By.Id("to-field")).Any())
                {
                    break;
                }
                System.Threading.Thread.Sleep(GlobalWait);
            }

            IWebElement toTextBox = this.Driver.FindElement(By.Id("to-field"));
            toTextBox.SendKeys("franzFischbach@yahoo.com");

            
            IWebElement sendButton = this.Driver.FindElement(By.LinkText("Send"));
            sendButton.Click();
            //IWebElement kompotButton = this.Driver.FindElement(By.LinkText("Compose"));
            System.Threading.Thread.Sleep(1500);

            IWebElement inboxButton = this.Driver.FindElement(By.Id("Inbox"));
            inboxButton.Click();
            System.Threading.Thread.Sleep(1500);

            IWebElement tableRoot = this.Driver.FindElement(By.Id("inboxcontainer"));
            IWebElement[] inboxMessages = tableRoot.FindElements(By.CssSelector("div[data-action='select-message']")).ToArray();
            string recievedDate = inboxMessages[0].FindElement(By.ClassName("date")).Text;

            throw new Exception(recievedDate);

            IWebElement sentButton = this.Driver.FindElement(By.Id("Sent"));
            inboxButton.Click();
            System.Threading.Thread.Sleep(1500);

            System.Threading.Thread.Sleep(4000);
        }

        [TearDown]
        public void CloseDriver()
        {
            this.Driver.Close();
        }
    }
}
