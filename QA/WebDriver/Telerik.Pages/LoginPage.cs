namespace Telerik.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using System.Collections.Generic;
    using WebDriver.Extensions;

    public class LoginPage
    {
        private const string UsernameLocator = "username";
        private const string PasswordLocator = "password";
        private const string LoginButtonLocator = "LoginButton";
        private const string NoBotMessageLocator = "GeneralContent_C049_ctl00_ctl00_NoBotValidation_ctl00_ctl00_cvNoBot";

        private readonly IWebDriver driver;

        [FindsBy(How = How.Id, Using = UsernameLocator)]
        private IWebElement username;

        [FindsBy(How = How.Id, Using = PasswordLocator)]
        private IWebElement password;

        [FindsBy(How = How.Id, Using = LoginButtonLocator)]
        private IWebElement loginButton;

        [FindsBy(How = How.Id, Using = NoBotMessageLocator)]
        private IWebElement noRobot;

        public static ICollection<Cookie> LoginCookies { get; set; }

        public LoginPage(IWebDriver initialDriver)
        {
            this.driver = initialDriver;
            if (LoginCookies == null)
            {
                LoginCookies = new List<Cookie>();
            }
        }

        public IWebElement NoRobot
        {
            get
            {
                return this.noRobot;
            }
            set
            {
                this.noRobot = value;
            }
        }

        public IWebElement Username
        {
            get
            {
                return this.username;
            }
            set
            {
                this.username = value;
            }
        }

        public IWebElement Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        public IWebElement LoginButton
        {
            get
            {
                return this.loginButton;
            }
            set
            {
                this.loginButton = value;
            }
        }

        public bool NoRobotMeassgeVilible()
        {
            return this.NoRobot.Displayed;
        }

        public void Login(string username = "a4143209@trbvm.com", string password = "12345")
        {
            PageFactory.InitElements(this.driver, this);
            this.driver.WaitForElementPresent(By.Id("login-form"));
            this.Username.SendKeys(username, true);
            this.Password.SendKeys(password, true);
            this.LoginButton.Click();
        }
    }
}
