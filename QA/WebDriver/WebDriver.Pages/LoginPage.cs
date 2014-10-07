namespace WebDriver.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    using WebDriver.Extensions;

    public class LoginPage
    {
        private const string LoginUrl = @"/Users/Auth/Login";
        private const string UsernameOrEmailLocator = "UsernameOrEmail";
        private const string PasswordLocator = "Password";
        private const string SubmitButtonLocator = "//*[@id=\"MainContent\"]/form/fieldset/input";

        private readonly IWebDriver driver;

        [FindsBy(How = How.Id, Using = UsernameOrEmailLocator)]
        private IWebElement usernameOrEmail;

        [FindsBy(How = How.Id, Using = PasswordLocator)]
        private IWebElement password;

        [FindsBy(How = How.XPath, Using = SubmitButtonLocator)]
        private IWebElement submit;

        public LoginPage(IWebDriver initialDriver)
        {
            this.driver = initialDriver;
        }

        public IWebElement UsernameOrEmail
        {
            get
            {
                return this.usernameOrEmail;
            }
            set
            {
                this.usernameOrEmail = value;
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

        public IWebElement Submit
        {
            get
            {
                return this.submit;
            }
            set
            {
                this.submit = value;
            }
        }

        public void Login(string username = "CB_test", string password = "testtest")
        {
            PageFactory.InitElements(this.driver, this);
            this.driver.Navigate().GoToUrl(string.Format("{0}{1}", this.driver.Url, LoginUrl));
            this.driver.WaitForElementPresent(By.XPath("//*[@id=\"MainContent\"]/form"));
            this.UsernameOrEmail.SendKeys(username, true);
            this.Password.SendKeys(password, true);
            this.Submit.Click();
        }
    }
}