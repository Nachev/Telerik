namespace TestFramework.Core.Base
{
    using System;
    using ArtOfTest.WebAii.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public abstract class BaseTest
    {
        public Browser Browser
        {
            get
            {
                return Manager.Current.ActiveBrowser;
            }
        }

        public static void InitializeBrowser()
        {
            if (Manager.Current == null)
            {
                Settings mySettings = new Settings();

                mySettings.Web.KillBrowserProcessOnClose = true;
                mySettings.DisableDialogMonitoring = false;
                mySettings.UnexpectedDialogAction = UnexpectedDialogAction.HandleAndFailTest;
                mySettings.Web.ExecutingBrowsers.Add(BrowserExecutionType.InternetExplorer);
                mySettings.Web.Browser = BrowserExecutionType.InternetExplorer;
                mySettings.Web.DefaultBrowser = BrowserType.InternetExplorer;
                mySettings.Web.RecycleBrowser = true;

                var myManager = new Manager(mySettings);
                myManager.Start();
            }

            Manager.Current.LaunchNewBrowser();
        }

        public static void BrowserCleanup()
        {
            foreach (var browser in Manager.Current.Browsers)
            {
                browser.Close();
            }

            if (Manager.Current != null)
            {
                Manager.Current.Dispose();
            }
        }

        public virtual void TestInitialize()
        {
        }

        public virtual void TestCleanUp()
        {
        }

        [TestInitialize]
        public void CoreTestInitialize()
        {
            this.TestInitialize();
        }

        [TestCleanup]
        public void CoreTestCleanup()
        {
            this.TestCleanUp();
        }
    }
}