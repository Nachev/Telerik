namespace Magento.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using System;
    using System.Linq;

    public class LoginPage
    {
        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement emailField;

        public IWebElement EmailField
        {
            get { return emailField; }
            set { emailField = value; }
        }

        [FindsBy(How = How.Id, Using = "pass")]
        private IWebElement passwordField;

        public IWebElement PasswordField
        {
            get { return passwordField; }
            set { passwordField = value; }
        }

        [FindsBy(How = How.Id, Using = "send2")]
        private IWebElement submitButton;

        public IWebElement SubmitButton
        {
            get { return submitButton; }
            set { submitButton = value; }
        }

        [FindsBy(How = How.Id, Using = "advice-required-entry-email")]
        private IWebElement mailWarning;

        public IWebElement MailWarning
        {
            get { return mailWarning; }
            set { mailWarning = value; }
        }

        [FindsBy(How = How.Id, Using = "advice-required-entry-pass")]
        private IWebElement passordWarning;

        public IWebElement PasswordWarning
        {
            get { return passordWarning; }
            set { passordWarning = value; }
        }

        public void LogIn(IWebDriver driver, string emailInput, string passwordInput)
        {
            PageFactory.InitElements(driver, this);
            this.EmailField.SendKeys(emailInput);
            this.PasswordField.SendKeys(passwordInput);
            this.SubmitButton.Click();
        }

        public bool AreWarningsVisible()
        {
            bool result = new bool();
            result = this.MailWarning.Displayed;
            result &= this.PasswordWarning.Displayed;
            return result;
        }
    }
}
