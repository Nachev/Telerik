namespace Magento.Pages
{
    using System;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium.Support.UI;

    public class HomePage
    {
        private const int TimeToWaitInSeconds = 30;

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[1]/div/div/ul/li[1]/a")]
        private IWebElement myAccountButton;

        public IWebElement MyAccountButton
        {
            get { return myAccountButton; }
            set { myAccountButton = value; }
        }

        public void NavigateToMyAccount(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.MyAccountButton.Click();
        }
    }
}
