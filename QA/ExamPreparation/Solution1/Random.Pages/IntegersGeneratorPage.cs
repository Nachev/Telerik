namespace Random.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class IntegersGeneratorPage
    {
        [FindsBy(How = How.Name, Using = "num")]
        private IWebElement countNumber;

        public IWebElement CountNumber
        {
            get { return countNumber; }
            set { countNumber = value; }
        }

        [FindsBy(How = How.Name, Using = "min")]
        private IWebElement minNumber;

        public IWebElement MinNumber
        {
            get { return minNumber; }
            set { minNumber = value; }
        }

        [FindsBy(How = How.Name, Using = "max")]
        private IWebElement maxNumber;

        public IWebElement MaxNumber
        {
            get { return maxNumber; }
            set { maxNumber = value; }
        }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"invisible\"]/form/p[5]/input[1]")]
        private IWebElement getNumbersButton;

        public IWebElement GetNumbersButton
        {
            get { return getNumbersButton; }
            set { getNumbersButton = value; }
        }

        public void GenerateRandomNumber(IWebDriver driver, int numberCount, int minRange, int maxRange)
        {
            PageFactory.InitElements(driver, this);
            this.CountNumber.Clear();
            this.CountNumber.SendKeys(numberCount.ToString());
            this.MinNumber.Clear();
            this.MinNumber.SendKeys(minRange.ToString());
            this.MaxNumber.Clear();
            this.MaxNumber.SendKeys(maxRange.ToString());
            this.GetNumbersButton.Click();
        }
    }
}
