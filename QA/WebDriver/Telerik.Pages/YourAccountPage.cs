namespace Telerik.Pages
{
    using System;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium.Support.UI;
    using WebDriver.Extensions;

    public class YourAccountPage
    {
        private const string ProfileLinkLocator = "//*[@id=\"your-account-links\"]/li[1]/a";
        private const string EditProfileLocator = "ctl00_ctl00_GeneralBox_YourAccountNavigationArea_ctl00_hlEditProfile";

        private readonly IWebDriver driver;

        [FindsBy(How = How.XPath, Using = ProfileLinkLocator)]
        private IWebElement profileLink;

        public YourAccountPage(IWebDriver initialDriver)
        {
            this.driver = initialDriver;
        }

        public IWebElement ProfileLink
        {
            get { return profileLink; }
            set { profileLink = value; }
        }

        [FindsBy(How = How.Id, Using = EditProfileLocator)]
        private IWebElement editProfileLink;

        public IWebElement EditProfileLink
        {
            get { return editProfileLink; }
            set { editProfileLink = value; }
        }

        public void NavigateToEditProfile()
        {
            PageFactory.InitElements(this.driver, this);

            this.ProfileLink.Click();
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(30));

            var liExpand = this.driver.FindElement(By.XPath("//*[@id=\"your-account-links\"]/li[1]"));
            wait.Until<bool>((d) => 
            {
                return liExpand.HasClass("expanded"); 
            });

            this.EditProfileLink.Click();
        }
    }
}
