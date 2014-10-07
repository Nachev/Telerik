namespace BugTracker.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class FoundBugPage
    {
        [FindsBy(How = How.XPath, Using = "/html/body/div/div")]
        private IWebElement resultArea;

	    public IWebElement ResultArea
	    {
		    get { return resultArea;}
		    set { resultArea = value;}
	    }

        [FindsBy(How = How.XPath, Using = "/html/body/div/p/a")]
        private IWebElement viewBugsLink;

        public IWebElement ViewBugsLink
        {
            get { return viewBugsLink; }
            set { viewBugsLink = value; }
        }

        public bool CheckIfErrorPresent(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            bool result  = Regex.IsMatch(this.ResultArea.Text, @"\bBug\b \bnot\b \bfound\b\: \d*");
            return result;
        }
    }
}
