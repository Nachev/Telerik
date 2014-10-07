namespace Random.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public class ResultPage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id=\"invisible\"]/pre")]
        private IWebElement resultNumber;

        public IWebElement ResultNumber
        {
            get { return resultNumber; }
            set { resultNumber = value; }
        }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"invisible\"]/form/input[8]")]
        private IWebElement againButton;

        public IWebElement AgainButton
        {
            get { return againButton; }
            set { againButton = value; }
        }

        public int GetResult(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until<IWebElement>((d) => { return d.FindElement(By.XPath("//*[@id=\"invisible\"]/form/input[8]")); });
            int result = new int();
            result = int.Parse(this.ResultNumber.Text);
            return result;
        }
    }
}
