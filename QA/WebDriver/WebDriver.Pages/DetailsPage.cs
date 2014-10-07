namespace WebDriver.Pages
{
    using System;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium.Support.UI;

    using WebDriver.Extensions;

    public class DetailsPage
    {
        private const string DetailsPageUri = @"/Users/Profile/Settings";

        private const string FirstNameLocator = "FirstName";
        private const string LastNameLocator = "LastName";
        private const string FirstNameEnLocator = "FirstNameEn";
        private const string LastNameEnLocator = "LastNameEn";
        private const string BirthDateLocator = "BirthDay";
        private const string SexRadioLocator = "//*[@id=\"SettingsForm\"]/fieldset[2]/div[12]";
        private const string CitySelectLocator = "CityId_listbox";
        private const string OccupationLocator = "WorkEducationStatusId_listbox";
        private const string PhoneLocator = "Phone";
        private const string AboutMeLocator = "About";
        private const string UniversityLocator = "UniversityId_listbox";
        private const string FacultyLocator = "FacultyName";
        private const string UniversitySpecialityLocator = "UniversitySpeciality";
        private const string FacultyNumberLocator = "FacultyNumber";
        private const string SchoolLocator = "SchoolName";
        private const string WebSiteLocator = "Website";
        private const string SkypeLocator = "SkypeUsername";
        private const string FacebookLocator = "FacebookUrl";
        private const string GooglePlusLocator = "GooglePlusUrl";
        private const string LinkedInLocator = "LinkedInUrl";
        private const string TwitterLocator = "TwitterUrl";
        private const string GitHubLocator = "GitHubUrl";
        private const string SubmitButtonLocator = "//*[@id=\"SettingsForm\"]/div[2]/input";

        private readonly IWebDriver driver;

        [FindsBy(How = How.Id, Using = FirstNameLocator)]
        private IWebElement firstName;

        [FindsBy(How = How.Id, Using = LastNameLocator)]
        private IWebElement lastName;

        [FindsBy(How = How.Id, Using = FirstNameEnLocator)]
        private IWebElement firstNameInEng;

        [FindsBy(How = How.Id, Using = LastNameEnLocator)]
        private IWebElement lastNameInEng;

        [FindsBy(How = How.Id, Using = BirthDateLocator)]
        private IWebElement birthDate;

        [FindsBy(How = How.XPath, Using = SexRadioLocator)]
        private IWebElement sexRadio;

        [FindsBy(How = How.Id, Using = CitySelectLocator)]
        private IWebElement citySelect;

        [FindsBy(How = How.Id, Using = OccupationLocator)]
        private IWebElement occupation;

        [FindsBy(How = How.Id, Using = PhoneLocator)]
        private IWebElement phone;

        [FindsBy(How = How.Id, Using = AboutMeLocator)]
        private IWebElement aboutMe;

        [FindsBy(How = How.Id, Using = UniversityLocator)]
        private IWebElement universityLocator;

        [FindsBy(How = How.Id, Using = FacultyLocator)]
        private IWebElement faculty;

        [FindsBy(How = How.Id, Using = UniversitySpecialityLocator)]
        private IWebElement universitySpeciality;

        [FindsBy(How = How.Id, Using = FacultyNumberLocator)]
        private IWebElement facultyNumber;

        [FindsBy(How = How.Id, Using = SchoolLocator)]
        private IWebElement school;

        [FindsBy(How = How.Id, Using = WebSiteLocator)]
        private IWebElement webSite;

        [FindsBy(How = How.Id, Using = SkypeLocator)]
        private IWebElement skype;

        [FindsBy(How = How.Id, Using = FacebookLocator)]
        private IWebElement facebook;

        [FindsBy(How = How.Id, Using = GooglePlusLocator)]
        private IWebElement googlePlus;

        [FindsBy(How = How.Id, Using = LinkedInLocator)]
        private IWebElement linkedIn;

        [FindsBy(How = How.Id, Using = TwitterLocator)]
        private IWebElement twitter;

        [FindsBy(How = How.Id, Using = GitHubLocator)]
        private IWebElement gitHub;

        [FindsBy(How = How.XPath, Using = SubmitButtonLocator)]
        private IWebElement submit;

        public DetailsPage(IWebDriver initialDriver)
        {
            this.driver = initialDriver;
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

        public IWebElement FirstNameInEng
        {
            get
            {
                return this.firstNameInEng;
            }
            set
            {
                this.firstNameInEng = value;
            }
        }

        public IWebElement LastNameInEng
        {
            get
            {
                return this.lastNameInEng;
            }
            set
            {
                this.lastNameInEng = value;
            }
        }

        public IWebElement BirthDate
        {
            get
            {
                return this.birthDate;
            }
            set
            {
                this.birthDate = value;
            }
        }

        public IWebElement SexRadio
        {
            get
            {
                return this.sexRadio;
            }
            set
            {
                this.sexRadio = value;
            }
        }

        public IWebElement CitySelect
        {
            get
            {
                return this.citySelect;
            }
            set
            {
                this.citySelect = value;
            }
        }

        public IWebElement Occupation
        {
            get
            {
                return this.occupation;
            }
            set
            {
                this.occupation = value;
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

        public IWebElement AboutMe
        {
            get
            {
                return this.aboutMe;
            }
            set
            {
                this.aboutMe = value;
            }
        }

        public IWebElement University
        {
            get
            {
                return this.universityLocator;
            }
            set
            {
                this.universityLocator = value;
            }
        }

        public IWebElement Faculty
        {
            get
            {
                return this.faculty;
            }
            set
            {
                this.faculty = value;
            }
        }

        public IWebElement UniversitySpeciality
        {
            get
            {
                return this.universitySpeciality;
            }
            set
            {
                this.universitySpeciality = value;
            }
        }

        public IWebElement FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }
            set
            {
                this.facultyNumber = value;
            }
        }

        public IWebElement School
        {
            get
            {
                return this.school;
            }
            set
            {
                this.school = value;
            }
        }

        public IWebElement WebSite
        {
            get
            {
                return this.webSite;
            }
            set
            {
                this.webSite = value;
            }
        }

        public IWebElement Skype
        {
            get
            {
                return this.skype;
            }
            set
            {
                this.skype = value;
            }
        }

        public IWebElement Facebook
        {
            get
            {
                return this.facebook;
            }
            set
            {
                this.facebook = value;
            }
        }

        public IWebElement GooglePlus
        {
            get
            {
                return this.googlePlus;
            }
            set
            {
                this.googlePlus = value;
            }
        }

        public IWebElement LinkedIn
        {
            get
            {
                return this.linkedIn;
            }
            set
            {
                this.linkedIn = value;
            }
        }

        public IWebElement Twitter
        {
            get
            {
                return this.twitter;
            }
            set
            {
                this.twitter = value;
            }
        }

        public IWebElement GitHub
        {
            get
            {
                return this.gitHub;
            }
            set
            {
                this.gitHub = value;
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

        public void EnterDetailsDefaultValues()
        {
            PageFactory.InitElements(this.driver, this);
            this.NavigateToDetailsPage();
            this.driver.WaitForElementPresent(By.Id("SettingsForm"));
            this.InitializeWithDefaultValues();
            this.Submit.Click();
        }

        private void InitializeWithDefaultValues()
        {
            this.FirstName.SendKeys(DefaultUserDetails.FirstName, true);
            this.LastName.SendKeys(DefaultUserDetails.LastName, true);
            this.FirstNameInEng.SendKeys(DefaultUserDetails.FirstNameEn, true);
            this.LastNameInEng.SendKeys(DefaultUserDetails.LastNameEn, true);
            this.BirthDate.SendKeys(DefaultUserDetails.BirthDate, true);
            this.SelectSexById(DefaultUserDetails.Sex);
            this.SelectCityByText(DefaultUserDetails.CitySelect);
            this.SelectOccupationByText(DefaultUserDetails.OccupationSelect);
            this.Phone.SendKeys(DefaultUserDetails.Phone, true);
            this.AboutMe.SendKeys(DefaultUserDetails.AboutMe, true);
            this.WebSite.SendKeys(DefaultUserDetails.WebSite, true);
            this.SelectUniversityByText(DefaultUserDetails.University);
            this.Faculty.SendKeys(DefaultUserDetails.Faculty, true);
            this.UniversitySpeciality.SendKeys(DefaultUserDetails.UniversitySpeciality, true);
            this.FacultyNumber.SendKeys(DefaultUserDetails.FacultyNumber, true);
            this.School.SendKeys(DefaultUserDetails.School, true);
            this.WebSite.SendKeys(DefaultUserDetails.WebSite, true);
            this.Skype.SendKeys(DefaultUserDetails.Skype, true);
            this.Facebook.SendKeys(DefaultUserDetails.Facebook, true);
            this.GooglePlus.SendKeys(DefaultUserDetails.GooglePlus, true);
            this.LinkedIn.SendKeys(DefaultUserDetails.LinkedIn, true);
            this.Twitter.SendKeys(DefaultUserDetails.Twitter, true);
            this.GitHub.SendKeys(DefaultUserDetails.GitHub, true);
        }
 
        private void SelectSexById(string id)
        {
            this.SexRadio.FindElement(By.Id(id)).Click();
        }
 
        private void SelectUniversityByText(int index)
        {
            this.driver.GetElement(By.XPath("//*[@id=\"SettingsForm\"]/fieldset[3]/div[2]/span[1]/span/span/span")).Click();
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(30));
            wait.Until<bool>((d) =>
            {
                return this.driver.GetElement(By.Id("UniversityId-list")).Displayed;
            });
            this.University.FindElement(By.XPath(string.Format("//*[@id=\"UniversityId_listbox\"]/li[{0}]", index))).Click();
        }
 
        private void SelectOccupationByText(string text)
        {
            this.driver.GetElement(By.XPath("//*[@id=\"SettingsForm\"]/fieldset[2]/div[16]/span[1]/span/span[2]/span")).Click();
            this.Occupation.FindElement(By.XPath(string.Format("//li[normalize-space(.) = '{0}']", text))).Click();
        }
 
        private void SelectCityByText(string text)
        {
            this.driver.GetElement(By.XPath("//*[@id=\"SettingsForm\"]/fieldset[2]/div[14]/span[1]/span/span/span")).Click();
            this.CitySelect.FindElement(By.XPath(string.Format("//li[normalize-space(.) = '{0}']", text))).Click();
        }

        private void NavigateToDetailsPage()
        {
            this.driver.Navigate().GoToUrl(string.Format("{0}{1}", this.driver.Url, DetailsPageUri));
        }
    }
}