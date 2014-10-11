namespace Telerik.Tests
{
    using System;
    using System.Reflection;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Telerik.Tests.Exceptions;
    using log4net;
    using System.Collections.Generic;

    public class BaseTest
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected IWebDriver Driver { get; private set; }

        protected string BaseUri { get; private set; }

        protected int Timeout { get; private set; }

        protected WebDriverWait Wait { get; private set; }

        public void BaseTestInitialize(IWebDriver initialDriver, string baseUri, int timeout)
        {
            this.Driver = initialDriver;
            this.BaseUri = baseUri;
            this.Timeout = timeout;
            this.Wait = new WebDriverWait(initialDriver, TimeSpan.FromSeconds(timeout));
        }

        public IWebElement GetElement(By by)
        {
            IWebElement foundElement;

            try
            {
                foundElement = this.Wait.Until<IWebElement>((d) => { return d.FindElement(by); });
            }
            catch (TimeoutException ex)
            {
                log.Error(ex.Message);
                throw new ElementNotFoundException(by.ToString(), this.BaseUri);
            }

            return foundElement; 
        }

        public void WaitForElementText(By by, string text)
        {
            this.Wait.Until<bool>((d) =>
            {
                var element = this.GetElement(by);
                return element.Text == text;
            });
        }

        public IWebElement GetElementWithText(By by, string text)
        {
            IWebElement foundElement = null;

            try
            {
                this.Wait.Until<bool>((d) =>
                {
                    foundElement = this.GetElement(by);
                    return foundElement.Text.Contains(text);
                });
            }
            catch (TimeoutException ex)
            {
                log.Error(ex.Message);
                throw new ElementNotFoundException(by.ToString(), this.BaseUri);
            }

            return foundElement;
        }

        public void WaitForElementPresent(By by)
        {
            this.GetElement(by);
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                this.Driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException ex)
            {
                log.Info(ex.Message);
                return false;
            }
        }

        public void WaitForElementNotPresent(By by)
        {
            try
            {
                var currentElement = this.Driver.FindElement(by);
                bool notVisible = this.Wait.Until<bool>((d) => { return !currentElement.Displayed; });
                if (notVisible)
                {
                    return;
                }

                throw new ElementStillPresentException(by.ToString(), this.BaseUri);
            }
            catch (NoSuchElementException ex)
            {
                log.Info(ex.Message);
                return;
            }
            catch (TimeoutException ex)
            {
                log.Error(ex.Message);
                throw new ElementStillPresentException(by.ToString(), this.BaseUri);
            }
        }

        public void WaitForChecked(By by)
        {
            try
            {
                var currentElement = this.GetElement(by);
                bool notChecked = this.Wait.Until<bool>((d) => { return currentElement.Selected; });
                if (notChecked)
                {
                    return;
                }

                throw new ElementStillNotCheckedException(by.ToString(), this.BaseUri);
            }
            catch (NoSuchElementException ex)
            {
                log.Info(ex.Message);
                return;
            }
            catch (TimeoutException ex)
            {
                log.Error(ex.Message);
                throw new ElementStillNotCheckedException(by.ToString(), this.BaseUri);
            }
        }

        public void AssertTextPresent(string value)
        {
            if (!this.Driver.PageSource.Contains(value))
            {
                throw new TextNotFoundException(this.BaseUri, value);
            }
        }

        public void AssertTextPresentAtLocation(string value, IWebElement element)
        {
            if (!element.Text.Contains(value))
            {
                throw new TextNotFoundAtLocationException(this.BaseUri, element.TagName, value);
            }
        }
    }
}