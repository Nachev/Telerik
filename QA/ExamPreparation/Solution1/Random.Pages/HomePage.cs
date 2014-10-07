namespace Random.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class HomePage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id=\"navigation\"]/li[1]/a")]
        private IWebElement homeLink;

        public IWebElement HomeLink
        {
            get { return homeLink; }
            set { homeLink = value; }
        }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"navigation\"]/li[9]/a")]
        private IWebElement learnMoreLink;

        public IWebElement LearnMoreLink
        {
            get { return learnMoreLink; }
            set { learnMoreLink = value; }
        }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"navigation\"]/li[9]/ul/li[3]/a")]
        private IWebElement faqLink;

        public IWebElement FaqLink
        {
            get { return faqLink; }
            set { faqLink = value; }
        }

        public void NavigateToHome(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.HomeLink.Click();
        }

        public void NabigateToFaq(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            Actions action = new Actions(driver);
            action.MoveToElement(this.LearnMoreLink).Perform();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until<bool>((d) => { return this.FaqLink.Displayed; });
            this.FaqLink.Click();
        }
    }
}