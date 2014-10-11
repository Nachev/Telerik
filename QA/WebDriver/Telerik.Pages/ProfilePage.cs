namespace Telerik.Pages
{
    using System;
    using System.Linq;
    using System.Text;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using WebDriver.Extensions;

    public class ProfilePage
    {
        private const string NickLocator = "ctl00_ctl00_GeneralBox_Content_usercontrols_public_unitedaccount_client_editprofile_ascx1_scetbNick_tbSanitized";
        private const string FirstNameLocator = "ctl00_ctl00_GeneralBox_Content_usercontrols_public_unitedaccount_client_editprofile_ascx1_scetbFirstName_tbSanitized";
        private const string LastNameLocator = "ctl00_ctl00_GeneralBox_Content_usercontrols_public_unitedaccount_client_editprofile_ascx1_scetbLastName_tbSanitized";
        private const string CompanyLocator = "ctl00_ctl00_GeneralBox_Content_usercontrols_public_unitedaccount_client_editprofile_ascx1_scetbCompanyName_tbSanitized";
        private const string CountryLocator = "//*[@id=\"ctl00_ctl00_GeneralBox_Content_usercontrols_public_unitedaccount_client_editprofile_ascx1_ucCountrySelector_rcbCountry_DropDown\"]/div/ul";
        private const string CountrySelectLocator = "ctl00_ctl00_GeneralBox_Content_usercontrols_public_unitedaccount_client_editprofile_ascx1_ucCountrySelector_rcbCountry_Arrow";
        private const string JobTitleLocator = "ctl00_ctl00_GeneralBox_Content_usercontrols_public_unitedaccount_client_editprofile_ascx1_scetbJobTitle_tbSanitized";
        private const string PhoneLocator = "ctl00_ctl00_GeneralBox_Content_usercontrols_public_unitedaccount_client_editprofile_ascx1_scetbPhone_tbSanitized";
        private const string CompanyUrlLocator = "ctl00_ctl00_GeneralBox_Content_usercontrols_public_unitedaccount_client_editprofile_ascx1_scetbCompanyUrl_tbSanitized";
        private const string InterestsLocator = "ctl00_ctl00_GeneralBox_Content_usercontrols_public_unitedaccount_client_editprofile_ascx1_scetbInterests_tbSanitized";
        private const string BlogOrWebPageLocator = "ctl00_ctl00_GeneralBox_Content_usercontrols_public_unitedaccount_client_editprofile_ascx1_scetbWebpage_tbSanitized";
        private const string UpdateButtonLocator = "ctl00_ctl00_GeneralBox_Content_usercontrols_public_unitedaccount_client_editprofile_ascx1_lbUpdate";
        private const string CompanyErrorMessage = "ctl00_ctl00_GeneralBox_Content_usercontrols_public_unitedaccount_client_editprofile_ascx1_scetbCompanyName_rfvSanitizedControl";
        private const string BackEndErrorMessages = "ctl00_ctl00_GeneralBox_Content_usercontrols_public_unitedaccount_client_editprofile_ascx1_summary";

        private const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private readonly IWebDriver driver;

        [FindsBy(How = How.Id, Using = NickLocator)]
        private IWebElement nick;

        [FindsBy(How = How.Id, Using = FirstNameLocator)]
        private IWebElement firstName;

        [FindsBy(How = How.Id, Using = LastNameLocator)]
        private IWebElement lastName;

        [FindsBy(How = How.Id, Using = CompanyLocator)]
        private IWebElement company;

        [FindsBy(How = How.XPath, Using = CountryLocator)]
        private IWebElement country;

        [FindsBy(How = How.Id, Using = CountrySelectLocator)]
        private IWebElement countrySelectButton;

        [FindsBy(How = How.Id, Using = UpdateButtonLocator)]
        private IWebElement updateButton;

        [FindsBy(How = How.Id, Using = CompanyErrorMessage)]
        private IWebElement countryErrorMessage;

        [FindsBy(How = How.Id, Using = BackEndErrorMessages)]
        private IWebElement backEndSummary;

        [FindsBy(How = How.Id, Using = JobTitleLocator)]
        private IWebElement jobTitle;

        [FindsBy(How = How.Id, Using = PhoneLocator)]
        private IWebElement phone;

        [FindsBy(How = How.Id, Using = CompanyUrlLocator)]
        private IWebElement companyUrl;

        [FindsBy(How = How.Id, Using = InterestsLocator)]
        private IWebElement interests;

        [FindsBy(How = How.Id, Using = BlogOrWebPageLocator)]
        private IWebElement blogOrWebpage;

        public ProfilePage(IWebDriver initialDriver)
        {
            this.driver = initialDriver;
            PageFactory.InitElements(this.driver, this);
        }

        public IWebElement Nick
        {
            get
            {
                return this.nick;
            }
            set
            {
                this.nick = value;
            }
        }

        public IWebElement FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }
        
        public IWebElement LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }
        
        public IWebElement Company
        {
            get
            {
                return this.company;
            }
            set
            {
                this.company = value;
            }
        }
        
        public IWebElement Country
        {
            get
            {
                return this.country;
            }
            set
            {
                this.country = value;
            }
        }

        public IWebElement CountrySelectButton
        {
            get
            {
                return this.countrySelectButton;
            }
            set
            {
                this.countrySelectButton = value;
            }
        }

        public IWebElement UpdateButton
        {
            get
            {
                return this.updateButton;
            }
            set
            {
                this.updateButton = value;
            }
        }

        public IWebElement CountryErrorMessage
        {
            get
            {
                return this.countryErrorMessage;
            }
            set
            {
                this.countryErrorMessage = value;
            }
        }
        
        public IWebElement BackEndSummary
        {
            get
            {
                return this.backEndSummary;
            }
            set
            {
                this.backEndSummary = value;
            }
        }

        public IWebElement JobTitle
        {
            get
            {
                return this.jobTitle;
            }
            set
            {
                this.jobTitle = value;
            }
        }

        public IWebElement Phone
        {
            get
            {
                return this.phone;
            }
            set
            {
                this.phone = value;
            }
        }

        public IWebElement CompanyUrl
        {
            get
            {
                return this.companyUrl;
            }
            set
            {
                this.companyUrl = value;
            }
        }

        public IWebElement Interests
        {
            get
            {
                return this.interests;
            }
            set
            {
                this.interests = value;
            }
        }
        
        public IWebElement BlogOrWebPage
        {
            get
            {
                return this.blogOrWebpage;
            }
            set
            {
                this.blogOrWebpage = value;
            }
        }

        public void EnterCompanyName(string companyName)
        {
            this.Company.SendKeys(companyName, true);
        }

        public void EnterRandomCompanyName()
        {
            var date = DateTime.Now;
            string dateStr = string.Format("{0}{1}{2}", date.Day.ToString(), date.Month.ToString(), date.Year.ToString());
            var companyInput = string.Format("{0}{1}", dateStr, this.GetRandomString());
            this.Company.SendKeys(companyInput, true);
        }

        public bool CheckIfCompanyErrorIsVisible()
        {
            return this.CountryErrorMessage.Displayed;
        }

        public void EnterInvalidParameters()
        {
            this.Nick.SendKeys(InvalidProfileSymbols.Nick, true);
            this.FirstName.SendKeys(InvalidProfileSymbols.FirstName, true);
            this.LastName.SendKeys(InvalidProfileSymbols.LastName, true);
            this.Company.SendKeys(InvalidProfileSymbols.CompanyName, true);
            this.JobTitle.SendKeys(InvalidProfileSymbols.JobTitle, true);
            this.Phone.SendKeys(InvalidProfileSymbols.Phone, true);
            this.CompanyUrl.SendKeys(InvalidProfileSymbols.CompanyUrl, true);
            this.Interests.SendKeys(InvalidProfileSymbols.Interests, true);
            this.BlogOrWebPage.SendKeys(InvalidProfileSymbols.BlogOrWebPage, true);
            this.UpdateButton.Click();
        }

        public bool CheckBackEndErrors()
        {
            bool result = this.BackEndSummary.Displayed;

            result &= this.BackEndSummary.FindElement(By.XPath("ul/li[1]/strong")).Text.Contains(InvalidProfileSymbols.NickErrorMessage);
            result &= this.BackEndSummary.FindElement(By.XPath("ul/li[2]/strong")).Text.Contains(InvalidProfileSymbols.FirstNameErrorMessage);
            result &= this.BackEndSummary.FindElement(By.XPath("ul/li[3]/strong")).Text.Contains(InvalidProfileSymbols.LastNameErrorMessage);
            result &= this.BackEndSummary.FindElement(By.XPath("ul/li[4]/strong")).Text.Contains(InvalidProfileSymbols.CompanyNameErrorMessage);
            result &= this.BackEndSummary.FindElement(By.XPath("ul/li[5]/strong")).Text.Contains(InvalidProfileSymbols.JobTitleErrorMessage);
            result &= this.BackEndSummary.FindElement(By.XPath("ul/li[6]/strong")).Text.Contains(InvalidProfileSymbols.PhoneErrorMessage);
            result &= this.BackEndSummary.FindElement(By.XPath("ul/li[7]/strong")).Text.Contains(InvalidProfileSymbols.CompanyUrlErrorMessage);
            result &= this.BackEndSummary.FindElement(By.XPath("ul/li[8]/strong")).Text.Contains(InvalidProfileSymbols.InterestsErrorMessage);
            result &= this.BackEndSummary.FindElement(By.XPath("ul/li[9]/strong")).Text.Contains(InvalidProfileSymbols.BlogOrWebPageErrorMessage);

            return result;
        }

        private string GetRandomString(int length = 5)
        {
            StringBuilder result = new StringBuilder();
            var rng = new Random();
            for (int count = 0; count < length; count++)
            {
                int index = rng.Next(Alphabet.Length);
                result.Append(Alphabet[index]);
            }

            return result.ToString();
        }
    }
}