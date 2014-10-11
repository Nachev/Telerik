namespace WebDriver.Extensions
{
    using System;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public static class WebDriverExtensions
    {

        public static string GetText(this IWebDriver driver, By by)
        {
            return driver.FindElement(by).Text;
        }

        public static bool HasElement(this IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
            }
            catch (NoSuchElementException)
            {
                return false;
            }

            return true;
        }

        public static IWebElement FindElement(
            this IWebDriver driver, 
            By by, 
            int timeoutInSeconds = 30)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }

            return driver.FindElement(by);
        }

        public static IWebElement GetElement(
            this IWebDriver driver, 
            By by, 
            int timeoutInSeconds = 30)
        {
            IWebElement foundElement = null;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                foundElement = wait.Until<IWebElement>((d) => { return d.FindElement(by); });
            }
            catch (TimeoutException ex)
            {
                throw new NoSuchElementException("Element not found until timeout", ex);
            }

            return foundElement;
        }

        public static void WaitForElementWithClass(this IWebDriver driver, string className)
        {
            driver.GetElement(By.ClassName(className));
        }

        public static void WaitForElementWithClass(
            this IWebDriver driver, 
            By by, 
            string className, 
            int timeoutInSeconds = 30)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until<bool>((d) => 
                {
                    var element = driver.FindElement(by);
                    return element.HasClass(className);
                });
            }
            catch (TimeoutException ex)
            {                
                throw new NoSuchElementException("Element with such class is not present", ex);
            }
        }

        public static void WaitForElementPresent(this IWebDriver driver, By by)
        {
            driver.GetElement(by);
        }
    }
}