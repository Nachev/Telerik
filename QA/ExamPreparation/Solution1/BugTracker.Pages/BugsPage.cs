namespace BugTracker.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class BugsPage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id=\"ctl00\"]/div[3]/table[3]/tbody/tr[3]/td[1]")]
        private IWebElement lastIdField;

        public IWebElement LastIdFIeld
        {
            get { return lastIdField; }
            set { lastIdField = value; }
        }

        [FindsBy(How = How.Name, Using = "id")]
        private IWebElement searchIdField;

        public IWebElement SearchIdField
        {
            get { return searchIdField; }
            set { searchIdField = value; }
        }

        [FindsBy(How = How.XPath, Using = "/html/body/table/tbody/tr/td[6]/form/input[1]")]
        private IWebElement goToIdButton;

        public IWebElement GoToIdButton
        {
            get { return goToIdButton; }
            set { goToIdButton = value; }
        }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"ctl00\"]/div[3]/table[1]/tbody/tr/td[1]/a")]
        private IWebElement addNewBugButton;

        public IWebElement AddNewBugButton
        {
            get { return addNewBugButton; }
            set { addNewBugButton = value; }
        }

        public void FindUnexistig(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            string lastId = this.LastIdFIeld.Text;
            int lastIdNumber = int.Parse(lastId);
            int idToFind = lastIdNumber + 10;
            this.SearchIdField.Clear();
            this.SearchIdField.SendKeys(idToFind.ToString());
            this.GoToIdButton.Click();
        }

        public void GoToAddNewBugPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.AddNewBugButton.Click();
        }
    }
}
