namespace WebDriver.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using WebDriver.Extensions;
    using WebDriver.Pages;

    [TestClass]
    public class FillInDetailsTest : BaseTest
    {
        private const string BaseUrl = @"http://test.telerikacademy.com/";

        [TestInitialize]
        public void TestInitialize()
        {
            var driver = new FirefoxDriver(new FirefoxProfile());
            base.BaseTestInitialize(driver, BaseUrl, 10);
        }

        [TestCleanup]
        public void CleanUp()
        {
            base.Driver.Quit();
        }

        [TestMethod]
        public void InputValidDetails_ShouldProceedSuccessfully()
        {
            base.Driver.Navigate().GoToUrl(base.BaseUri);
            LoginPage loginPage = new LoginPage(base.Driver);
            DetailsPage detailsPage = new DetailsPage(base.Driver);
            loginPage.Login();
            base.WaitForElementPresent(By.Id("socialIcons"));
            Assert.AreEqual("Софтуерна академия на Телерик (безплатни видео курсове и уроци) - Телерик Академия - Студентска система (students system)", base.Driver.Title);
            detailsPage.EnterDetailsDefaultValues();
            this.Driver.GetElement(By.Id("ExitMI"));
        }
    }
}